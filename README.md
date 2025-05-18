# MotoSecurityX API

O projeto MotoSecurityX tem como objetivo o controle e monitoramento de motos, permitindo o registro, atualização, exclusão e consulta de dados das motos por meio de uma API RESTful. Esse projeto é feito em colaboração com a MOTTU.

## 👥 Integrantes

- Caio Henrique – RM: 554600  
- Carlos Eduardo - RM: 555223
- Antônio Lino - RM: 554518


## 🔧 Tecnologias Utilizadas

- ASP.NET 
- Entity Framework Core
- Banco de Dados Oracle
- Swagger (OpenAPI)
- Injeção de Dependência
- RESTful API

## 📦 Funcionalidades

Moto
GET /api/moto – Lista todas as motos
GET /api/moto/{id} – Busca moto por ID
GET /api/moto/placa/{placa} – Busca moto por placa
GET /api/moto/situação/{situação} - Busca motos que estão dentro ou fora do pátio
POST /api/moto – Cadastra uma nova moto
PUT /api/moto/{id} – Atualiza uma moto existente
DELETE /api/moto/{id} – Remove uma moto
Pátio
GET /api/patio – Lista todos os pátios
GET /api/patio/{id} – Busca pátio por ID
POST /api/patio – Cadastra um novo pátio
PUT /api/patio/{id} – Atualiza um pátio existente
DELETE /api/patio/{id} – Remove um pátio

## ⚙️ Instalação

1. Clone o repositório:
```bash
git clone https://github.com/caiohc28/MotoSecurityX.git
```

2. Execute o projeto:
```bash
cd MotoSecurityX
dotnet run
```

## 🧪 Swagger

A documentação interativa da API estará disponível em:
```
https://localhost:5024/swagger
```

