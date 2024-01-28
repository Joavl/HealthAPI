# HealthAPI

Bem-vindo à HealthAPI , um sistema simples de agendamento de consultas médicas .

## Sobre o Projeto

Este projeto é uma API desenvolvida em ASP.NET Core para permitir o agendamento de consultas médicas entre pacientes e médicos.

## Funcionalidades Principais

- Cadastro de Pacientes e Médicos
- Agendamento de Consultas
- Consulta de Agenda de Pacientes e Médicos

## Tecnologias Utilizadas

- ASP.NET Core
- Entity Framework Core
- SQL Server
- JWT para autenticação básica

## Configuração do Ambiente de Desenvolvimento

Certifique-se de ter o [.NET Core SDK](https://dotnet.microsoft.com/download) instalado.

1. Clone o repositório: `git clone https://github.com/joavl/HealthAPI.git`
2. Navegue até o diretório do projeto: `cd HealthAPI`
3. Execute o aplicativo: `dotnet run`

## Endpoints da API

- `GET /api/pacientes`: Obter a lista de pacientes.
- `GET /api/medicos`: Obter a lista de médicos.
- `POST /api/consultas`: Agendar uma nova consulta.
- `GET /api/consultas`: Obter a lista de consultas.
- `GET /api/consultas/{id}`: Obter detalhes de uma consulta específica.

Consulte a documentação Swagger para obter mais detalhes.

## Autenticação

A API utiliza autenticação JWT. Ao fazer requisições, inclua o token JWT no cabeçalho `Authorization`.

## Documentação da API

A documentação da API está disponível no endpoint `/swagger`.

## Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou pull requests.

## Licença

Este projeto é licenciado sob a licença [MIT](LICENSE).

---

**Desenvolvido por João Vitor Avila
