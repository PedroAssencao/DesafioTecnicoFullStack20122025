# Controle Financeiro

Sistema de controle financeiro fullstack desenvolvido com .NET 8 no backend e React com TypeScript no frontend. O projeto permite a gestão de transações, categorias e pessoas.

## Instalacao

Siga os passos abaixo para configurar e rodar o projeto.

### Pre-requisitos

* SDK do .NET 8.0
* Node.js e npm
* Docker e Docker Compose

### 1. Configuracao de Ambiente

1. Clone o repositorio.
2. **Backend:**
   * Navegue ate `ControleFinanceiro.API`.
   * Renomeie o arquivo `appsettings.example.json` para `appsettings.json`.
   * Se nao estiver usando Docker, preencha a string de conexao em `ConnectionStrings:Chinook`.
   * inicialize o projeto via visual studio ou usando comando do cli dotnet run
3. **Frontend:**
   * Navegue ate `controlefinanceiro.view`.
   * Renomeie o arquivo `.env.example` para `.env`, seguir instruções do proprio arquivo para configuração de url da api
   * iniciar usando npm run dev

### 2. Executando com Docker (Recomendado)

O projeto utiliza Docker Compose para orquestrar a API, o Banco de Dados (SQL Server) e o Frontend.

1. Na raiz da solucao (onde esta o arquivo `docker-compose.yml`), execute:
   ```bash
   docker-compose up -d --build

### 3. Obs
Em ambos os casos da instalação, a aplciação front end deve estar localizada em localhost:3000
