# ERP Study Web

ERP Study Web é um projeto de estudo focado na criação de um sistema ERP simples (apenas o backend) para simular uma aplicação real. Este projeto utiliza princípios do Domain-Driven Design (DDD) para organização de código, e várias tecnologias modernas para garantir a eficiência e segurança.

## Tecnologias Utilizadas

- **.NET 8 com C# 12**
- **Entity Framework Core** - ORM
- **SQL Server** - Banco de dados
- **Autenticação e Autorização JWT**
- **Hash e Salt de Senhas**
- **Cache nos Endpoints**
- **Swagger UI** - Documentação da API

## Configuração e Execução

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/mtevangelista7/Erp-Study-Web-API.git
   
2. **Configure o banco de dados SQL Server.**

3. **Atualize a string de conexão no `appsettings.json`:**
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=.;Database=ERPStudyWeb;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```

4. **Abra o console do gerenciador de pacotes e execute as migrações do Entity Framework:**
   ```bash
   Update-Database
   ```

5. **Compile e execute o projeto:**
   ```bash
   dotnet run
   ```

6. **Acesse o Swagger UI para testar a API:**
   Abra seu navegador e vá para `https://localhost:5001/swagger`.
