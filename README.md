# RentAMoto

## Requisitos de Software
- Docker: Necessário para executar o PostgreSQL e o RabbitMQ em contêineres.
- .NET SDK: Necessário para compilar e executar a aplicação RentAMoto.

## Configuração Inicial

### Clone o Repositório
Clone o repositório RentAMoto do GitHub para o seu ambiente local: 
https://github.com/GeisianHReis/RentAMoto.git


### Configuração do Docker Compose
1. Navegue até o diretório raiz do projeto onde o arquivo `docker-compose.yml` está localizado.
2. Execute o seguinte comando para iniciar os serviços do RabbitMQ e do banco de dados PostgreSQL: docker-compose up -d


### Verificar Status dos Serviços
Execute o seguinte comando para verificar se os contêineres estão em execução corretamente: docker-compose ps


## Execução da Aplicação

### Instalação das Dependências
Antes de executar a aplicação, restaure todas as dependências do projeto: dotnet restore


### Compilação da Aplicação
Compile a aplicação executando o seguinte comando: dotnet build


### Execução da Aplicação
Execute a aplicação usando o comando: dotnet run



Após seguir estas instruções, os serviços do RabbitMQ e do banco de dados PostgreSQL estarão em execução e prontos para serem utilizados pela aplicação RentAMoto. Certifique-se de que os serviços estejam em execução antes de prosseguir para executar a aplicação.




