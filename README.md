API de Gerenciamento de Usuários, Coleções e Modelos

Esta é uma API de gerenciamento de usuários, coleções e modelos, desenvolvida em C# utilizando o Entity Framework Core. A API permite criar, visualizar, atualizar e excluir registros nas tabelas principais: Usuarios, Colecoes e Modelos.

Recursos Disponíveis
Usuarios

    GET /usuarios: Retorna todos os usuários cadastrados.
    GET /usuarios/{id}: Retorna os detalhes do usuário com o ID fornecido.
    POST /usuarios: Cria um novo usuário com base nos dados fornecidos.
    PUT /usuarios/{id}: Atualiza os dados do usuário com o ID fornecido.
    PUT /usuarios/{id}/status: Atualiza o status do usuário com o ID fornecido.

Coleções

    GET /colecoes: Retorna todas as coleções cadastradas.
    GET /colecoes/{id}: Retorna os detalhes da coleção com o ID fornecido.
    POST /colecoes: Cria uma nova coleção com base nos dados fornecidos.
    PUT /colecoes/{id}: Atualiza os dados da coleção com o ID fornecido.
    PUT /colecoes/{id}/status: Atualiza o status da coleção com o ID fornecido.
    DELETE /colecoes/{id}: Exclui a coleção com o ID fornecido.

Modelos

    GET /modelos: Retorna todos os modelos cadastrados.
    GET /modelos/{id}: Retorna os detalhes do modelo com o ID fornecido.
    POST /modelos: Cria um novo modelo com base nos dados fornecidos.
    PUT /modelos/{id}: Atualiza os dados do modelo com o ID fornecido.
    PUT /modelos/{id}/layout: Atualiza o layout do modelo com o ID fornecido.
    DELETE /modelos/{id}: Exclui o modelo com o ID fornecido.

Formato de Dados

A API aceita e retorna dados no formato JSON. Os dados devem ser enviados no corpo das requisições POST e PUT no seguinte formato:

Erros e Códigos de Status

A API utiliza os seguintes códigos de status HTTP para indicar o resultado das requisições:

    200 OK: A requisição foi bem-sucedida.
    201 Created: O recurso foi criado com sucesso.
    204 No Content: A requisição foi bem-sucedida, mas não há conteúdo a ser retornado.
    400 Bad Request: A requisição possui parâmetros inválidos ou dados ausentes.
    401 Unauthorized: Falha na autenticação ou falta de permissões necessárias.
    404 Not Found: O recurso solicitado não foi encontrado.
    409 Conflict: Quando há algum conflito com o banco.
    500 Internal Server Error: Erro interno do servidor.
    
Considerações Finais

Esta API de gerenciamento de usuários, coleções e modelos oferece uma maneira conveniente de criar, visualizar, atualizar e excluir registros nas tabelas de usuários, coleções e modelos. Sinta-se à vontade para explorar os endpoints disponíveis e realizar operações com os recursos fornecidos.
