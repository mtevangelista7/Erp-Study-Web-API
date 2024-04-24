# ERP Study Web API

Esta é uma API web desenvolvida com ASP.NET Core, utilizando ADO.NET para acesso ao banco de dados, implementando recursos de cache, autenticação e autorização com JSON Web Token (JWT). As senhas dos usuários são armazenadas no banco de dados de forma segura, utilizando hash e salt. O banco de dados utilizado é o SQL Server. Além disso, a documentação da API é fornecida através do Swagger UI.

## Recursos Principais

- **ASP.NET Core**: Framework web robusto e flexível para o desenvolvimento de aplicativos web em C#.
- **ADO.NET**: Biblioteca para acesso a dados, utilizada para comunicação com o banco de dados SQL Server.
- **Cache**: Implementação de cache para melhorar o desempenho e a escalabilidade da API.
- **Autenticação e Autorização JWT**: Utilização de tokens JWT para autenticação e autorização de usuários.
- **Hash e Salt de Senhas**: Senhas dos usuários são armazenadas no banco de dados de forma segura, utilizando técnicas de hash e salt.
- **SQL Server**: Banco de dados relacional utilizado para armazenamento dos dados da aplicação.
- **Swagger UI**: Interface interativa para documentação da API, facilitando o entendimento e o teste dos endpoints.

## Configuração e Uso

Para configurar e executar a API, siga as etapas abaixo:

1. **Requisitos**:
    - [.NET Core SDK](https://dotnet.microsoft.com/download) instalado.
    - Banco de dados SQL Server configurado e acessível.

2. **Clonar o Repositório**:
    ```bash
    git clone https://github.com/seu-usuario/erp-study-web-api.git
    ```

3. **Configuração do Banco de Dados**:
    - Execute os scripts SQL fornecidos na pasta `Scripts` para criar o banco de dados e as tabelas necessárias.

4. **Configuração do Projeto**:
    - Abra o arquivo `appsettings.json` e atualize a string de conexão com o banco de dados de acordo com as suas configurações.

5. **Execução da API**:
    - Navegue até a pasta raiz do projeto e execute o seguinte comando:
    ```bash
    dotnet run
    ```

6. **Documentação da API**:
    - Após iniciar a aplicação, acesse o Swagger UI em [http://localhost:5000/swagger](http://localhost:5000/swagger) para explorar e testar os endpoints disponíveis.

## Licença

Este projeto está licenciado sob a [Licença MIT](LICENSE).
