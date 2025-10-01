# 🚀 MotoSecurityX - DevOps & Cloud Computing (ACI + ACR + Azure SQL)

Sistema de monitoramento de motos em pátios (filiais), com controle de **entradas e saídas** via API .NET, publicado em **Azure Container Instance (ACI)** com imagem no **Azure Container Registry (ACR)** e banco **Azure SQL**.


##  1. Descrição da Solução

O **MotoSecurityX** é uma API REST para controle de **motos e pátios**, permitindo **cadastro, listagem, edição e exclusão**.

##  2. Benefícios para o Negócio

| Problema | Solução |
|----------|---------|
| Controle manual em planilhas | Banco centralizado na nuvem |
| Falta de rastreamento de entradas/saídas | API com histórico completo |
| Falta de integração entre pátios | Acesso unificado via endpoints REST |


##  3. Banco de Dados (Executar script_bd.sql)

Tabelas:

- **dbo.motos**
- **dbo.patios**


##  4. Deploy com Docker + Azure

```bash
docker build -t acrmotox.azurecr.io/motox:v2 .
az login
az acr login --name acrmotox
docker push acrmotox.azurecr.io/motox:v2
````

## 5. Integrantes
### CAIO HENRIQUE - RM 554600
### ANTÔNIO LINO - RM 554518
### CARLOS EDUARDO - RM 555223

## 6. Testes do CRUD

``` bash
🔹 Motos

✅ POST /api/Moto

{
  "id": "0",
  "placa": "chc2812",
  "modelo": "Honda",
  "situacao": "dentro"
}


✅ PUT /api/Moto/3

{
  "id": "3",
  "placa": "chc2812",
  "modelo": "Honda",
  "situacao": "fora"
}


✅ DELETE /api/Moto/3

✅ GET /api/Moto
```

````bash
🔹 Patios

✅ POST /api/Patio

{
  "id": "0"
  "nome": "Pátio Leste - Itaquera",
}


✅ PUT /api/Patio/3

{
  "id": 3,
  "nome": "Pátio Leste - Patriarca",
}


✅ DELETE /api/Patio/3

✅ GET /api/Patio
