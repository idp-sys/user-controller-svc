# user-controller-svc

Web API que execute as funções de controle de usuários.

GET: Busca a lista de todos os usuários cadastrados.
- ID 
- Nome
- Status

GET\{ID}: Busca usuário cadastrado por ID

GET\ByName\{Name}: Busca usuário cadastrado por Nome

POST: Insere novo usuário. Necessário informar no corpo (body) Valores para "Name" e "Status". 
O Id é gerado automaticamente.

PUT\{ID}: Altera o cadastro do usuário informado pelo ID.
Necessário informar no corpo (body) os novos valores para os campos "Name" e "Status". 
    
DELETE\{ID}: Exclui o usuário informado no ID. Exclusão apenas lógica. Ao reiniciar a API, o arquivo físico não é modificado e os registros excluídos permanecem salvos.
Arquivo Json é salvo no diretório padrão da aplicação (AppDomain.CurrentDomain.BaseDirectory).
