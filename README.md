# Desafio para Desenvolvedor de Software – Ânima Digital

O Manual do desafio encontra-se [aqui](CHALLENGE.md).

## Requerimentos

* .NET Core 3.1 ou superior
* SQL Server 2017 ou superior

## Executando

Primeiramete navegue para o diretório ```Anima.Api```

Configure a conexeção para sua base de dados SQL Server no aquivo ```/appsettings.json``` em ```DefaultConnection```.

Realize a migração para a base de dados:
```
dotnet ef database update
```

Execute a Aplicação
```
dotnet run
```
