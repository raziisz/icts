<h1 align="center">ICTS_TEST</h1>
<p align="center">Versão Api de desafio backend pleno</p>

### Pré-requisitos

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
[Git](https://git-scm.com), [.Net Core](https://dotnet.microsoft.com/download). 
Também deve usar o SGBD [Mysql](https://www.mysql.com/downloads/).
Além disto é bom ter um editor para trabalhar com o código como [VSCode](https://code.visualstudio.com/)

### 🎲 Rodando a API (servidor)

```bash
# Clone este repositório
$ git clone <https://github.com/raziisz/icts.git>

# Acesse a pasta do projeto no terminal/cmd
$ cd icts_test

# Instale as dependências
$ dotnet restore

# Instale a ferramenta Entity Framework core para controle das migrations e subir banco
$ dotnet tool install --global dotnet-ef --version 7.0.7

# Acesse a pasta appsettings.json na raiz do seu projeto com seu editor de código
$ "ConnectionStrings": {
    "DefaultConnection" : "Host=myLocalhost;Database=myDb;Username=myUser;Password=myPassword"
  },
  na connection string altere a string connection com as credênciais de seu banco de dados
# Execute comando para rodar as migrações e criar banco de dados icts no SBGD Mysql
$ dotnet ef database update

# Execute a aplicação em modo de desenvolvimento
$ dotnet watch run

# O servidor inciará na porta:5042 - acesse <http://localhost:5042>

# Automaticamente ira abrir no browser o swagger da aplicação com as rotas.
```

#

### 🛠 Tecnologias

As seguintes ferramentas foram usadas na construção do projeto:

- [.NetCore](https://dotnet.microsoft.com/)
- [Entity Framework Core](https://docs.microsoft.com/pt-br/ef/)
- [Jwt](https://jwt.io/)
- [Mysql](https://www.mysql.com/)

### Autor
---

<a href="http://raziisz.github.io/">
 <img style="border-radius: 50%;" src="https://avatars2.githubusercontent.com/u/42245201?s=460&u=ce3bae80de213ad246855873906246051fba4458&v=4" width="100px;" alt=""/>
 <br />
 <sub><b>Luiz Felipe</b></sub></a> <a href="http://raziisz.github.io/" title="Dev">🚀</a>


Feito com ❤️ por Luiz Felipe 👋🏽 Entre em contato!

[![Linkedin Badge](https://img.shields.io/badge/-Felipe-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/luiz-felipe-libertino-a87840170/)](https://www.linkedin.com/in/luiz-felipe-libertino-a87840170/) 
[![Outlook Badge](https://img.shields.io/badge/-raziel_libertino@hotmail.com-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:raziel_libertino@hotmail.com)](mailto:raziel_libertino@hotmail.com)

