# User Controller V1

# Requisitos
- .NET Core 3.0
- Visual Studio versão 16.3 ou superior

# Primeiros passos
1. Abrir o Visual Studio selecionar a opção para clonar o repositório do Git.
2. Inserir o endereço do repositório `https://github.com/dnlhirata/user-controller-svc.git` no primeiro campo (Repository Location).
3. Inserir o diretório onde será salvo os arquivos extraidos do GitHub.
4. Clicar em clonar.
5. Após a clonagem, apertar F5 para rodar a aplicação.

# Modos de uso

## Instalar o Postman
1. Acessar o site do [Postman](https://www.getpostman.com/`) e fazer a instalação do aplicativo.
2. Após a instalação, inicie o aplicativo e desabilite a função **Verificação do certificado SSL** (Arquivo > Configurações).

## (/GET) Listar usuários
- Crie uma requisição
- Altere o método HTTP para **GET**
- Insira a URL `https://localhost:44357/user-controller`
- Clique em **ENVIAR**

## (/GET) Pesquisar por ID
- Crie uma requisição
- Altere o método HTTP para **GET**
- Insira a URL `https://localhost:44357/user-controller/buscar-por-id/{id}`, onde **{id}** é o ID do usuário a ser pesquisado (retirar as chaves)
- Clique em **ENVIAR**

## (/GET) Pesquisar por Nome
- Crie uma requisição
- Altere o método HTTP para **GET**
- Insira a URL `https://localhost:44357/user-controller/buscar-por-nome/{nome}`, onde **{nome}** é o nome do usuário a ser pesquisado (retirar as chaves)
- Clique em **ENVIAR**

## (/POST) Adicionar usuário
- Crie uma requisição
- Altere o método HTTP para **POST**
- Insira a URL `https://localhost:44357/user-controller/adicionar`
- Selecione a guia **CORPO**
- Selecione a opção **BRUTO**
- Defina o tipo como **JSON**
- No corpo insira um JSON válido como o exemplo abaixo:
```json
{
    "id": 1,
    "name": "Daniel",
    "status": "Ativo"
}
```
- Clique em **ENVIAR**

## (/PUT) Alterar usuário
- Crie uma requisição
- Altere o método HTTP para **PUT**
- Insira a URL `https://localhost:44357/user-controller/atualizar/{id}?name={nome}&status={status}`, onde **{id}** é o id do usuário a ser atualizado, **{nome}** o novo nome do usuário e **{status}** o novo status do usuário, sendo nome e status parâmetros opcionais e é necessário retirar as chaves dos parâmetros.
- Clique em **ENVIAR**

## (/DELETE) Remover usuário
- Crie uma requisição
- Altere o método HTTP para **DELETE**
- Insira a URL `https://localhost:44357/user-controller/remover-por-id/{id}`, onde **{id}** é o id do usuário a ser removido (retirar as chaves)
- Clique em **ENVIAR**

## Documentação
Após iniciada a aplicação, a documentação poderá ser encontrada em https://localhost:44357/swagger
