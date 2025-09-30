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

- **Pátios**
- **Motos**


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

✅ POST /api/motos

{
  "placa": "AAA1B23",
  "modelo": "Honda Titan 160",
  "status": "DENTRO_PATIO"
}


✅ PUT /api/motos/1

{
  "placa": "AAA1B23",
  "modelo": "Honda Titan 160 EX",
  "status": "FORA_PATIO"
}


✅ DELETE /api/motos/1

✅ GET /api/motos
```

````bash
🔹 Patios

✅ POST /api/patios

{
  "nome": "Filial Rio de Janeiro",
  "cep": "22031-050",
  "cidade": "Rio de Janeiro"
}


✅ PUT /api/patios/1

{
  "nome": "Filial São Paulo - Centro Atualizada",
  "cep": "01000-000",
  "cidade": "São Paulo"
}


✅ DELETE /api/patios/1

✅ GET /api/patios
```
