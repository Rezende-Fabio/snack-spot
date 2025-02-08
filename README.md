# Snack-Spot

Snack-Spot é uma aplicação web construída usando a arquitetura MVC em C#. Ela fornece uma plataforma para gerenciamento de serviços relacionados a lanches e roda em um banco de dados PostgreSQL hospedado em um contêiner Docker.

## Tecnologias Utilizadas

- **C#** (.NET MVC)
- **Entity Framework Core**
- **PostgreSQL** (Contêiner Docker)
- **Docker**
- **HTML, CSS, JavaScript** (Frontend)

## Pré-requisitos

Certifique-se de ter os seguintes itens instalados no seu sistema:

- [.NET SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/get-started)
- [Cliente PostgreSQL](https://www.postgresql.org/download/)

## Como começar

### 1. Clone o repositório
```sh
git clone https://github.com/Rezende-Fabio/snack-spot.git
cd snack-spot
```

### 2. Configurar o banco de dados
- #### 2.1 Mudar senha do banco
    Atualize o arquivo `Dockerfile.example` com a senha para o banco de dados:

    > obs.: Retire o .example do nome do arquivo 

    ```dockerfile
    ENV POSTGRES_PASSWORD=*Senha*
    ```

- #### 2.2 Gerar imagem
    Gere uma imagem do Dockerfile:
    ```dockerfile
    docker build -t postgres-db-snack-spot -f caminho/para/Dockerfile .
    ```

- #### 2.3 Subir o banco
    Execute o seguinte comando para iniciar um contêiner PostgreSQL:
    ```sh
    docker run --name postgres-db-snack-spot -p 5432:5432 -d postgres-snack-spot
    ```

### 3. Configure a aplicação
- #### 3.1 Configure a senha do usuário Admin
    Atualize o arquivo `appsettings.json` com a senha do usuário Admin:
    ```json
    "AdminUser": {
        "Email": "admin@admin.com",
        "Password": "senha_usuario_admin"
    }
    ```

- #### 3.2 Configure a ConnectionStrings do projeto
    Atualize o arquivo `appsettings.json` com a string de conexão do banco de dados:
    ```json
    "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=sua_base_de_dados;Username=seu_usuario;Password=sua_senha"
    }
    ```

- #### 3.3 Configure o caminho do repositório de imagem
    Atualize o arquivo `appsettings.json` com o caminho da pasta onde vão ficar as imagens dos lanches:
    ```json
    "ConfigurationImagePath": {
        "NameFoldersImagesProducts": "images/products"
    }
    ```

### 4. Aplicar Migrações
Execute o seguinte comando para aplicar as migrações do Entity Framework:
```sh
dotnet ef database update
```

### 5. Executar a aplicação
Inicie a aplicação usando:
```sh
dotnet run
```
A aplicação estará disponível em `http://localhost:5267`.