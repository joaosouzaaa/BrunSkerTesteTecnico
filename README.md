# Tecnologias usadas
- .NET6
- C#
- MySql
- EntityFrameworkCore
- xUnit

# Melhores Práticas
- Testes Unitários
- Testes de Integração
- Design Patterns
- Clean Code

# Arquitetura
- Arquitetura em camadas (cebola)
- Code First

# Setup da aplicação

- Acesse app.settings:

![alt text](https://github.com/joaosouzaaa/BrunSkerTesteTecnico/blob/master/ImagesForGit/appsettingslocal.png)

- Mude a connection string, representada por "DefaultConnection"

![alt text](https://github.com/joaosouzaaa/BrunSkerTesteTecnico/blob/master/ImagesForGit/appsettings.png)

- Acesse o package manager:

![alt text](https://github.com/joaosouzaaa/BrunSkerTesteTecnico/blob/master/ImagesForGit/where%20to%20access.png)

Selecione o pipeline para utilizar o projeto de Infra:
![alt text](https://github.com/joaosouzaaa/BrunSkerTesteTecnico/blob/master/ImagesForGit/pipeline.png)

Insira o comando: "update-database".

Seu banco já estará pronto para uso, o script de criação se encontra na camada de api, porém seu uso não é necessário.

# Executar os testes

- Acesse o Test Explorer:

![alt text](https://github.com/joaosouzaaa/BrunSkerTesteTecnico/blob/master/ImagesForGit/where%20to%20access%20tests.png)

Execute os testes, clicando em run all:

![alt text](https://github.com/joaosouzaaa/BrunSkerTesteTecnico/blob/master/ImagesForGit/run%20all%20tests.png)

