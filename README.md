# 📌 ConsultaCep

Aplicação em **.NET (C#)** para consulta de endereços a partir de um CEP, utilizando uma API backend e um cliente consumidor.

---

## 📖 Sobre

O projeto permite buscar informações de endereço (logradouro, bairro, cidade e UF) a partir de um CEP informado.

Estrutura:
- `ConsultaCepApi` → API responsável pelas consultas  
- `ConsultaCep` → Cliente consumidor  
- `ConsultaCep.sln` → Solution principal  

---

## ⚙️ Funcionalidades

- Consulta de CEP  
- Integração com API externa (ex: ViaCEP)  
- Retorno em JSON  
- Separação em camadas (API + cliente)  

---

## 🚀 Tecnologias

- .NET / ASP.NET Core  
- C#  
- HttpClient  
- JSON  

---

## ▶️ Como rodar

### Pré-requisitos
- .NET SDK instalado

### Clonar o repositório
```bash
git clone https://github.com/RobsonBSF/ConsultaCep.git
cd ConsultaCep
```

### 💻 Executando no Visual Studio

1. Abra o Visual Studio
2. Clique em *"Open a project or solution"*
3. Selecione o arquivo:

```bash
ConsultaCep.sln
```

4. Aguarde o carregamento dos projetos
5. Defina o projeto de inicialização clicando com o botão direito em **ConsultaCep** ou **ConsultaCepApi**
6. Selecione *"Set as Startup Project"*
7. Execute o projeto pressionando **F5**
