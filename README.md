CQRS Application
Este é um exemplo de aplicação usando CQRS (Command Query Responsibility Segregation), implementada com ASP.NET Core, MediatR, AutoMapper, FluentValidation e um repositório básico para gerenciar produtos. Este projeto demonstra como aplicar o padrão CQRS para separar a lógica de comandos (modificação de dados) e consultas (leitura de dados), facilitando a escalabilidade e a manutenção do código.

Tecnologias Usadas
ASP.NET Core 6/7

CQRS

MediatR

AutoMapper

FluentValidation

SQL Server

Entity Framework Core

Swagger (para documentação da API)

Estrutura do Projeto
O projeto está dividido em diferentes camadas de responsabilidade, seguindo o padrão Clean Architecture:

bash
Copiar
Editar
src/
│
├── CQRS.Commands        # Comandos para criar, deletar, e atualizar produtos
├── CQRS.Querys          # Consultas para buscar produtos
├── CQRS.Handlers        # Manipuladores para lidar com comandos e consultas
├── CQRS.Models          # Modelos de dados (ex: Product)
├── CQRS.DTOs            # Objetos de transferência de dados (DTOs)
├── CQRS.Validators      # Validação de comandos usando FluentValidation
├── CQRS.Reposiotry      # Repositórios para interação com o banco de dados
└── CQRS.Mapping         # Mapeamento de objetos com AutoMapper
Funcionalidades
Comandos
CreateProductCommand: Cria um novo produto no sistema.

UpdateProductCommand: Atualiza um produto existente.

DeleteProductCommand: Deleta um produto do sistema.

Consultas
GetAllProductsQuery: Recupera todos os produtos.

GetProductByIdQuery: Recupera um produto específico pelo ID.

Manipuladores
CreateProductHandler: Manipula a criação de um produto.

UpdateProductHandler: Manipula a atualização de um produto.

DeleteProductHandler: Manipula a exclusão de um produto.

GetProductByIdHandler: Manipula a consulta de um produto pelo ID.

GetAllProductsHandler: Manipula a consulta de todos os produtos.

Validação
CreateProductCommandValidator: Valida as entradas para criar um produto.

UpdateProductCommandValidator: Valida as entradas para atualizar um produto.

Mapeamento
ProductProfile: Configuração do AutoMapper para mapear entre as entidades e DTOs.

Como Rodar o Projeto
Pré-requisitos
.NET 6 ou superior: Certifique-se de que o SDK do .NET está instalado.

SQL Server: O projeto usa SQL Server como banco de dados. Certifique-se de ter o SQL Server ou Docker configurado.

Passos
Clone o repositório:

bash
Copiar
Editar
git clone https://github.com/seu-usuario/cqrs-application.git
Navegue até a pasta do projeto:

bash
Copiar
Editar
cd cqrs-application
Restaure as dependências:

bash
Copiar
Editar
dotnet restore
Atualize a string de conexão no arquivo appsettings.json com a sua configuração do SQL Server.

Crie a base de dados e execute as migrações:

bash
Copiar
Editar
dotnet ef database update
Execute o projeto:

bash
Copiar
Editar
dotnet run
A aplicação estará disponível em https://localhost:5001 ou http://localhost:5000.

Testando com Swagger
A API tem o Swagger integrado, e você pode acessá-lo em:

bash
Copiar
Editar
http://localhost:5000/swagger
No Swagger, você pode testar todos os endpoints da API de forma simples, incluindo a criação, consulta e exclusão de produtos.

Endpoints
A aplicação expõe os seguintes endpoints:

Produtos
POST /api/products: Cria um novo produto.

GET /api/products: Recupera todos os produtos.

GET /api/products/{id}: Recupera um produto específico pelo ID.

PUT /api/products/{id}: Atualiza um produto.

DELETE /api/products/{id}: Deleta um produto pelo ID.

Exemplo de Requisição
Criar Produto (POST)
json
Copiar
Editar
POST /api/products
{
  "name": "Produto Exemplo",
  "price": 100.00
}
Atualizar Produto (PUT)
json
Copiar
Editar
PUT /api/products/{id}
{
  "name": "Produto Atualizado",
  "price": 150.00
}
Excluir Produto (DELETE)
json
Copiar
Editar
DELETE /api/products/{id}
Validação
As entradas são validadas usando o FluentValidation. Por exemplo, ao criar um produto, a aplicação valida se o nome não está vazio e se o preço é maior que zero.

Exemplo de Validação
Se você enviar uma requisição com dados inválidos (por exemplo, um nome vazio ou preço negativo), a resposta será:

json
Copiar
Editar
{
  "errors": [
    "O nome do produto é obrigatório.",
    "O preço deve ser maior que zero."
  ]
}
Contribuindo
Fork o repositório.

Crie uma branch para a sua feature (git checkout -b minha-feature).

Faça as suas alterações e comite (git commit -am 'Adiciona nova feature').

Envie a sua branch para o repositório remoto (git push origin minha-feature).

Abra um Pull Request.
