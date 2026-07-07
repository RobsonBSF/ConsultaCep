# ConsultaCep

Solução desenvolvida em **C# e .NET** para consulta de endereços a partir de um CEP, composta por duas aplicações que demonstram diferentes abordagens de consumo e disponibilização de dados.

## 📋 Projetos da Solução

### 🖥️ ConsultaCep (Console Application)

Aplicação executada via terminal que permite ao usuário informar um CEP e obter os dados do endereço correspondente.

**Principais características:**
- Interface simples via console
- Consulta de CEP em tempo real
- Exibição formatada das informações obtidas
- Validação de entrada do usuário
- Registro de histórico de consultas

### 🌐 ConsultaCepApi (Web API)

API REST desenvolvida com ASP.NET Core para disponibilizar consultas de CEP através de endpoints HTTP.

**Principais características:**
- Arquitetura em camadas
- Controllers, Services e Models
- Integração com serviço de consulta de CEP
- Registro de histórico de consultas

## 🚀 Tecnologias Utilizadas

- C#
- .NET
- ASP.NET Core Web API
- HttpClient
- REST APIs

## ▶️ Como Executar

### Pré-requisitos

- .NET SDK 8.0 ou superior

### Clonar o repositório

```bash
git clone https://github.com/RobsonBSF/ConsultaCep.git
cd ConsultaCep
```

### Executar a aplicação Console

```bash
dotnet run --project ConsultaCep
```

### Executar a API

```bash
dotnet run --project ConsultaCepApi
```
