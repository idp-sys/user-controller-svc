# User Controller 

# Requisitos
- .NET Core 3.0
- Visual Studio

> Modos de uso


> Listar usuários
- Inicie uma requisição, método HttpGet
- Insira a URL -> http://localhost:5000/api/user/getList
- Clique em Enviar

> Pesquisar por Nome
- Insira a URL -> http://localhost:5000/api/user/getbyname/{name}
- Clique em Enviar

> Pesquisar por ID
- Inicie uma requisição, método HttpGet
- Insira a URL -> http://localhost:5000/api/user/getbyid/{id}
- Clique em Enviar



> Adicionar usuário
- Inicie uma requisição, método HttpPost
- Insira a URL -> http://localhost:5000/api/user/add/{id}
- Exemplo Json:
[
    {
        "name": "Epaminondas",
        "status": "Ativo",
        "id": 1
    }
]
- Clique em Enviar

> Alterar usuário
- Inicie uma requisição, método HttpPost
- Insira a URL -> http://localhost:5000/api/user/update/{id}?name={nome}&status={status}
- Clique em Enviar

> Remover usuário
- Inicie uma requisição, método HttpPost
- Insira a URL -> http://localhost:5000/api/user/delete/{id}
- Clique em Enviar

## Documentação
https://localhost:5001/swagger/index.html
