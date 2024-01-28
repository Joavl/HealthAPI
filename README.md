# HealthAPI

**Bem-vindo à HealthAPI, um sistema simples de agendamento de consultas médicas.**

Este projeto é uma API desenvolvida em ASP.NET Core para permitir o **agendamento** de consultas médicas entre pacientes e médicos.

**Funcionalidades Principais**

* **Cadastro de Pacientes e Médicos**
* **Agendamento de Consultas**
* **Consulta de Agenda de Pacientes e Médicos**

**Tecnologias Utilizadas**

* ASP.NET Core
* Entity Framework Core
* SQL Server

**Configuração do Ambiente de Desenvolvimento**

Para configurar o ambiente de desenvolvimento, siga estas etapas:

1. Instale o .NET Core SDK.
2. Clone o repositório: `git clone https://github.com/joavl/HealthAPI.git`
3. Navegue até o diretório do projeto: `cd HealthAPI`
4. Execute o aplicativo: `dotnet run`

**Endpoints da API**

A HealthAPI oferece os seguintes endpoints:

### Pacientes

* `GET /api/pacientes`: Listar todos os pacientes.
* `GET /api/pacientes/{id}`: Obter detalhes de um paciente específico.
* `POST /api/pacientes`: Cadastrar um novo paciente.
* `PUT /api/pacientes/{id}`: Atualizar as informações de um paciente existente.
* `DELETE /api/pacientes/{id}`: Remover um paciente.

### Médicos

* `GET /api/medicos`: Listar todos os médicos.
* `GET /api/medicos/{id}`: Obter detalhes de um médico específico.
* `POST /api/medicos`: Cadastrar um novo médico.
* `PUT /api/medicos/{id}`: Atualizar as informações de um médico existente.
* `DELETE /api/medicos/{id}`: Remover um médico.

### Agendamentos

* `GET /api/agendamentos`: Listar todos os agendamentos.
* `GET /api/agendamentos/{id}`: Obter detalhes de um agendamento específico.
* `POST /api/agendamentos`: Agendar um novo agendamento.
* `PUT /api/agendamentos/{id}`: Atualizar as informações de um agendamento existente.
* `DELETE /api/agendamentos/{id}`: Remover um agendamento.

**Documentação da API**

A documentação completa da API está disponível no endpoint `/swagger`.

**Contribuições**

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou pull requests.

**Licença**

Este projeto é licenciado sob a licença MIT.

**Desenvolvido por João Vitor Ávila**
