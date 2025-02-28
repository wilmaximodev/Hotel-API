# Hotel-API

## 📜 O que foi desenvolvido

Foi desenvolvido um back-end em C# e ASP.NET Core para um software de booking para várias redes de hotéis.

## 🛠️ Habilidades trabalhadas

- Entender o funcionamento do ASP.NET e como ele se integra ao C#.
- Compreender o funcionamento do banco de dados SQL Server.
- Criar operações de manipulação de banco de dados em uma API.

## 📥 Como instalar

1. Clone o repositório:
   bash
   git clone github.com/wilmaximodev/Hotel-API.git
   

2. Entre na pasta do repositório que você acabou de clonar:
   bash
   cd Trybe-Hotel
   

3. Instale as dependências:
   bash
   dotnet restore
   

## 🚀 Como rodar o projeto

1. Inicie o Banco de Dados:
   bash
   docker compose up -d --build
   

2. Execute as migrations:
   bash
   dotnet ef migrations add InitialCreate
   

3. Crie as tabelas do Banco de Dados:
   bash
   dotnet ef database update
   

4. Inicie a API:
   bash
   dotnet run
   

## 📚 Endpoints

### GET /

**Retorno:**
- **Status**: 200
- **Corpo**:
  json
  {
    "message": "online"
  }
  

### GET /city

**Retorno:**
- **Status**: 200
- **Corpo**:
  json
  [
    {
      "cityId": 1,
      "name": "Rio Branco",
      "state": "AC"
    },
    ...
  ]
  

### POST /city

**Corpo da requisição:**
json
{
  "Name": "Rio de Janeiro",
  "State": "RJ"
}


**Retorno:**
- **Status**: 201
- **Corpo**:
  json
  {
    "cityId": 2,
    "name": "Rio de Janeiro",
    "state": "RJ"
  }
  

### PUT /city

**Corpo da requisição:**
json
{
  "CityId": 1,
  "Name": "Rio de Janeiro",
  "State": "RJ"
}


**Retorno:**
- **Status**: 200
- **Corpo**:
  json
  {
    "cityId": 1,
    "name": "Rio de Janeiro",
    "state": "RJ"
  }
  

### GET /hotel

**Retorno:**
- **Status**: 200
- **Corpo**:
  json
  [
    {
      "hotelId": 1,
      "name": "Trybe Hotel SP",
      "address": "Avenida Paulista, 1400",
      "cityId": 1,
      "cityName": "São Paulo",
      "state": "SP"
    },
    ...
  ]
  

### POST /hotel

**Requisito:** Token de um admin no Bearer da requisição.

**Corpo da requisição:**
json
{
  "Name": "Trybe Hotel RJ",
  "Address": "Avenida Atlântica, 1400",
  "CityId": 2
}


**Retorno:**
- **Status**: 201
- **Corpo**:
  json
  {
    "hotelId": 2,
    "name": "Trybe Hotel RJ",
    "address": "Avenida Atlântica, 1400",
    "cityId": 2,
    "cityName": "Rio de Janeiro",
    "state": "RJ"
  }
  

### GET /room/:hotelId

**Parâmetro**: `hotelId` deve ser o id do Hotel desejado.

**Retorno:**
- **Status**: 200
- **Corpo**:
  json
  [
    {
      "roomId": 1,
      "name": "Suite básica",
      "capacity": 2,
      "image": "image suite",
      "hotel": {
        "hotelId": 1,
        "name": "Trybe Hotel SP",
        "address": "Avenida Paulista, 1400",
        "cityId": 1,
        "cityName": "São Paulo",
        "state": "SP"
      }
    },
    ...
  ]
  

### POST /room

**Requisito:** Token de um admin no Bearer da requisição.

**Corpo da requisição:**
json
{
  "Name": "Suite básica",
  "Capacity": 2,
  "Image": "image suite",
  "HotelId": 1
}


**Retorno:**
- **Status**: 201
- **Corpo**:
  json
  {
    "roomId": 1,
    "name": "Suite básica",
    "capacity": 2,
    "image": "image suite",
    "hotel": {
      "hotelId": 1,
      "name": "Trybe Hotel SP",
      "address": "Avenida Paulista, 1400",
      "cityId": 1,
      "cityName": "São Paulo",
      "state": "SP"
    }
  }
  

### DELETE /room/:roomId

**Requisito:** Token de um admin no Bearer da requisição.

**Parâmetro**: `roomId` deve ser o id do Quarto desejado para exclusão.

**Retorno:**
- **Status**: 204
- Caso o `roomId` seja inválido, o retorno será:
  - **Status**: 400

### POST /user

**Corpo da requisição:**
json
{
  "Name": "João Benício",
  "Email": "j.beniciopp@gmail.com",
  "Password": "123456"
}


**Retorno:**
- Em caso de e-mail repetido, a resposta será:
  - **Status**: 409
  - **Corpo**:
    json
    {
      "message": "User email already exists"
    }
    
- Em caso de sucesso:
  - **Status**: 201
  - **Corpo**:
    json
    {
      "userId": 1,
      "name": "João Benício",
      "email": "j.beniciopp@gmail.com",
      "userType": "client"
    }
    

### GET /user

**Requisito:** Token de um admin no Bearer da requisição.

**Retorno:**
- **Status**: 200
- **Corpo**:
  json
  [
    {
      "userId": 1,
      "name": "João Benício",
      "email": "j.beniciopp@gmail.com",
      "userType": "client"
    },
    ...
  ]
  

### POST /login

**Corpo da requisição:**
json
{
  "Email": "j.beniciopp@gmail.com",
  "Password": "123456"
}


**Retorno:**
- Em caso de combinação de e-mail e senha incorreta:
  - **Status**: 401
  - **Corpo**:
    json
    {
      "message": "Incorrect e-mail or password"
    }
    
- Em caso de sucesso:
  - **Status**: 200
  - **Corpo**:
    json
    {
      "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
    }
    

### POST /booking

**Corpo da requisição:**
json
{
  "CheckIn": "2030-08-27",
  "CheckOut": "2030-08-28",
  "GuestQuant": 1,
  "RoomId": 1
}


**Retorno:**
- Em caso de `GuestQuant` maior que a capacidade do quarto:
  - **Status**: 400
  - **Corpo**:
    json
    {
      "message": "Guest quantity over room capacity"
    }
    
- Em caso de sucesso:
  - **Status**: 201
  - **Corpo**:
    json
    {
      "bookingId": 1,
      "checkIn": "2030-08-27T00:00:00",
      "checkOut": "2030-08-28T00:00:00",
      "guestQuant": 1,
      "room": {
        "roomId": 1,
        "name": "Suite básica",
        "capacity": 2,
        "image": "image suite",
        "hotel": {
          "hotelId": 1,
          "name": "Trybe Hotel RJ",
          "address": "Avenida Atlântica, 1400",
          "cityId": 1,
          "cityName": "Rio de Janeiro",
          "state": "RJ"
        }
      }
    }

### GET /booking

*Requisito:* Token de quem fez a reserva no Bearer da requisição.

*Retorno:*
- *Status*: 200
- *Corpo*
