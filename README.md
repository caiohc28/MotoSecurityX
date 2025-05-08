# MotoSecurityX API

API RESTful desenvolvida com ASP.NET Core para gerenciar motos no pátio da empresa Mottu.

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

- **GET** `/api/moto` – Lista todas as motos
- **GET** `/api/moto/{id}` – Busca moto por ID
- **GET** `/api/moto/placa/{placa}` – Busca moto por placa
- **GET** `/api/moto/situação/{situação}` - Busca motos que estão dentro ou fora do pátio
- **POST** `/api/moto` – Cadastra uma nova moto
- **PUT** `/api/moto/{id}` – Atualiza uma moto existente
- **DELETE** `/api/moto/{id}` – Remove uma moto

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

