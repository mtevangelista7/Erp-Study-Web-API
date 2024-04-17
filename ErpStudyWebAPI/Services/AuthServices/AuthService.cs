using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Repository.UsuarioRepo;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ErpStudyWebAPI.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMemoryCache _memoryCache;

        public AuthService(IUsuarioRepository usuarioRepository, IConfiguration configuration, IMemoryCache memoryCache)
        {
            _configuration = configuration;
            _usuarioRepository = usuarioRepository;
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// Cria um novo token
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public string CriaToken(Usuario usuario)
        {
            // Aqui definimos nossas claims (propriedades do token)
            List<Claim> claims = new List<Claim>
            {
                // Para a de NameIdentifier utilizamos o Guid e para o Name, o nome do usuário
                new Claim(ClaimTypes.NameIdentifier, usuario.UsuarioId.ToString()),
                new Claim(ClaimTypes.Name, usuario.NomeUsuario)
            };

            // Recupera a chave do appsetting, realiza o enconding e converte em bytes
            SymmetricSecurityKey chaveSecretaCriptografada = new SymmetricSecurityKey(Encoding.ASCII
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            // Aqui criamos nossa credencial de assinatura, usando a chave recupera acima
            // para assinar os tokens JWT
            SigningCredentials creds =
                new SigningCredentials(chaveSecretaCriptografada, SecurityAlgorithms.HmacSha512Signature);

            // Aqui definimos as propriedades para nosso token
            SecurityTokenDescriptor tokenPropriedades = new SecurityTokenDescriptor
            {
                // Para nosso sujeito passamos as claims que criamos acima
                Subject = new ClaimsIdentity(claims),
                // Definimos que o token expira um dia após sua criação
                Expires = DateTime.Now.AddDays(1),
                // Passamos nossa chave de criptografia
                SigningCredentials = creds
            };

            // variável que gera o token
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            // realiza a criação do troken
            SecurityToken token = tokenHandler.CreateToken(tokenPropriedades);

            // Retorna o token compactado
            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// Realiza o login do usuario, cria um token de autenticação para o mesmo
        /// </summary>
        /// <param name="nomeUsuario"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        public async Task<string> RealizaLogin(string nomeUsuario, string senha)
        {
            string tokenUsuarioLogado;

            // busca o usuario na base
            Usuario usuario = await _usuarioRepository.RetornaUsuario(nomeUsuario.ToLower());

            // usuario não localizado
            if (usuario is null)
            {
                return string.Empty;
            }
            
            // senha incorreta
            if (!VerificaSenhaHash(senha, usuario.PasswordHash, usuario.PasswordSalt))
            {
                return string.Empty;
            }

            // Tenta recuperar um token armazenado no cache 
            tokenUsuarioLogado = RecuperaTokenJWTCache(usuario.UsuarioId);

            // Caso não tenha token no cache
            if (!string.IsNullOrWhiteSpace(tokenUsuarioLogado))
            {
                return tokenUsuarioLogado;
            }

            // cria um novo token para esse usuario
            tokenUsuarioLogado = CriaToken(usuario);
                    
            // Armazena o novo token para o usuario
            ArmazenaTokenJWTCache(usuario.UsuarioId, tokenUsuarioLogado);

            // retorna o token criado
            return tokenUsuarioLogado;
        }

        /// <summary>
        /// Insere o usuario na base e retorna o token gerado
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        public async Task<string> RegistraUsuario(Usuario usuario, string senha)
        {
            // Verifica se o usuário já está cadastrado na base
            if (await UsuarioExiste(usuario.NomeUsuario))
            {
                // Caso sim, não retorna o token
                return string.Empty;
            }

            // Cria um noovo hash para o usuario
            CriaHashSenha(senha, out byte[] passwordHash, out byte[] passwordSalt);

            // adiciona as senhas criadas para o usuario
            usuario.PasswordHash = passwordHash;
            usuario.PasswordSalt = passwordSalt;

            // insere o usuario na base
            await _usuarioRepository.InsereUsuario(usuario);

            // cria um novo token para esse usuario cadastrado
            string tokenUsuarioCadastrado = CriaToken(usuario);
                
            // Armazena o novo token para o usuario cadastrado no cache
            ArmazenaTokenJWTCache(usuario.UsuarioId, tokenUsuarioCadastrado);

            // retorna o token para o usuario que foi criado
            return tokenUsuarioCadastrado;
        }

        /// <summary>
        /// Cria um hash da senha do usuario para poder ser armazenada no banco
        /// </summary>
        /// <param name="senha"></param>
        /// <param name="hashSenha"></param>
        /// <param name="senhaSalt"></param>
        public void CriaHashSenha(string senha, out byte[] hashSenha, out byte[] senhaSalt)
        {
            using HMACSHA512 hmac = new System.Security.Cryptography.HMACSHA512();
            senhaSalt = hmac.Key;
            hashSenha = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
        }

        /// <summary>
        /// Verifica se o usuario já existe na base
        /// </summary>
        /// <param name="nomeUsuario"></param>
        /// <returns></returns>
        public async Task<bool> UsuarioExiste(string nomeUsuario)
        {
            return await _usuarioRepository.RetornaUsuario(nomeUsuario) != null;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="senha"></param>
        /// <param name="senhaHash"></param>
        /// <param name="senhaSalt"></param>
        /// <returns></returns>
        public bool VerificaSenhaHash(string senha, IReadOnlyList<byte> senhaHash, byte[] senhaSalt)
        {
            using HMACSHA512 hmac = new System.Security.Cryptography.HMACSHA512(senhaSalt);
            byte[] computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
            return !computedHash.Where((t, i) => t != senhaHash[i]).Any();
        }

        /// <summary>
        /// Armazena o valor do token para determinado usuario no cache
        /// </summary>
        /// <param name="guidUsuario"></param>
        /// <param name="token"></param>
        public void ArmazenaTokenJWTCache(Guid guidUsuario, string token)
        {
            _memoryCache.Set(guidUsuario.ToString(), token, TimeSpan.FromDays(1));
        }

        /// <summary>
        /// Recupera o token armazenado no cache
        /// </summary>
        /// <param name="guidUsuario"></param>
        /// <returns></returns>
        public string RecuperaTokenJWTCache(Guid guidUsuario)
        {
            // Verifica se temos um token armazenado no cache pelo Guid do usuario, caso sim retorna, caso não retorna null
            return _memoryCache.TryGetValue(guidUsuario.ToString(), out string cachedToken) ? cachedToken : null;
        }
    }
}