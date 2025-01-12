# Teste de Conhecimentos Playmove - Lucas Mascarello Perin

## Configuração Inicial

Antes de executar a aplicação, é necessário realizar algumas etapas para configurar corretamente o ambiente de execução.

### Passo 1: Criar o Banco de Dados

Crie o banco de dados `FornecedoresDB` em uma instância do SQL Server local ou remota.

O repositório utiliza uma instância local padrão: `localhost/SQLEXPRESS`.

### Passo 2: Configurar o arquivo `appsettings.json`

Altere a string de conexão no arquivo `appsettings.json` para apontar para a instância configurada no passo anterior.

Exemplo:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=FornecedoresDB;Trusted_Connection=True;"
  }
}
```
### Passo 3: Atualizar o Banco de Dados com Migrations

Certifique-se de que está na raiz do projeto e execute o seguinte comando no console:

```
dotnet ef database update
```

Esse comando aplicará as migrations existentes e criará as tabelas necessárias no banco de dados.

Caso precise especificar o caminho para o projeto de infraestrutura, use:

```
dotnet ef database update --project C:\caminho\para\FornecedoresAPP\FornecedoresApp.Infrastructure
```
## Execução da Aplicação

Após realizar as etapas de configuração, a aplicação estará pronta para ser executada.

Inicie a aplicação utilizando o comando:

```
dotnet run
```

Acesse os endpoints da API por meio da interface do Swagger, que estará disponível em:
```
http://localhost:{porta}/swagger
```

## Observações Importantes:
* Certifique-se de que o nome do banco de dados criado seja exatamente FornecedoresDB.
* O projeto foi desenvolvido utilizando uma conexão básica com o SQL Server.
* Caso utilize uma instância diferente de localhost/SQLEXPRESS, ajuste a string de conexão conforme necessário.
  
Com as etapas acima concluídas, a aplicação estará pronta para uso.
