# CadMais-server
Desafio técnico

O projeto consiste numa aplicação em C# que funciona como back-end de um módulo ce cadastramento de usuários de um sistema ERP.
---
## Tecnologias utilizadas
- .Net 6.0
- Asp.Net 6
- Entity Framework 
- Insomnia (Para fazer as requisições)
---

## Inicialização 
O Projeto foi desenvolvido utilizando o dotnet 6.0 e a cli do Entity Framework
### Para rodar a aplicação rode os seguintes comandos no terminal
- Baixe as dependências do projeto com:
```
 dotnet restore
```

- com o banco de dados inicializado, rode:
```
 dotnet ef database update
```

- Para executar a aplicação:
```
 dotnet run
```

---
## Proximos passos
-[] Finalizar validação das entradas de dados
-[] Implementar Autenticação e Autorização de usuários com Token JWT
-[] Desenvolver o Front-end da aplicação
