# CSharp Azure Storage Account

Projeto com objetivo de ajudar a fazer UPLOAD e DOWNLOAD de arquivos utilizando o [Storage Account](https://docs.microsoft.com/pt-br/azure/storage/common/storage-account-overview) do [Azure](https://azure.microsoft.com/pt-br/).

## O que foi utilizado? 

1. Terraform para criar nosso Storage Account no Azure
2. Projeto do tipo Web API (.net core 3.1)
3. Para exibir outputs sensiveis 
   ```
    terraform output -json
   ```