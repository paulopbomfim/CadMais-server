<h1 align="center">
  Cad+ Módulo (cadastro de usuários - Servidor)
</h1>

---

## Projeto

- O projeto é um desafio técnico para uma empresa que me candidatei e consiste numa aplicação de um módulo de cadastramento de usuários para um sistema ERP de um hospital.
---
## Tecnologias utilizadas
- .Net 6.0
- Asp.Net 6
- Entity Framework
- JWT Bearer
- BCrypt
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

- A documentação da API pode ser encontrada na rota
```
https://localhost:7099/swagger
```

---
## Próximos passos
- [x] Finalizar validação das entradas de dados
- [x] Implementar Autenticação e Autorização de usuários com Token JWT
- [ ] Implementar Rota de recuperação de senhas
- [ ] Desenvolver o Front-end da aplicação
