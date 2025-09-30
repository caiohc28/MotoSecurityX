CREATE TABLE dbo.patios (
    ID INT IDENTITY(1,1) NOT NULL,
    NOME_LOCAL NVARCHAR(200) NOT NULL,
    
    -- Chave Primária
    CONSTRAINT PK_patios PRIMARY KEY (ID)
);
GO

-- Comentários da tabela patios
EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Tabela que armazena os pátios/locais do sistema',
    @level0type = N'SCHEMA', @level0name = N'dbo',
    @level1type = N'TABLE', @level1name = N'patios';

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Identificador único do pátio (chave primária, auto incremento)',
    @level0type = N'SCHEMA', @level0name = N'dbo',
    @level1type = N'TABLE', @level1name = N'patios',
    @level2type = N'COLUMN', @level2name = N'ID';

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Nome do local/pátio (campo obrigatório)',
    @level0type = N'SCHEMA', @level0name = N'dbo',
    @level1type = N'TABLE', @level1name = N'patios',
    @level2type = N'COLUMN', @level2name = N'NOME_LOCAL';
GO

CREATE TABLE dbo.motos (
    ID INT IDENTITY(1,1) NOT NULL,
    PLACA NVARCHAR(10) NOT NULL,
    MODELO NVARCHAR(100) NOT NULL,
    SITUACAO NVARCHAR(20) NOT NULL,
    
    -- Chave Primária
    CONSTRAINT PK_motos PRIMARY KEY (ID),
    
    -- Constraint de Unicidade
    CONSTRAINT UQ_motos_placa UNIQUE (PLACA),
    
    -- Constraint de Validação
    CONSTRAINT CK_motos_situacao CHECK (SITUACAO IN ('dentro', 'fora'))
);
GO

-- Índices para otimização de consultas
CREATE INDEX IX_motos_situacao ON dbo.motos(SITUACAO);
CREATE INDEX IX_motos_placa ON dbo.motos(PLACA);
GO

-- Comentários da tabela motos
EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Tabela que armazena as motocicletas do sistema',
    @level0type = N'SCHEMA', @level0name = N'dbo',
    @level1type = N'TABLE', @level1name = N'motos';

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Identificador único da motocicleta (chave primária, auto incremento)',
    @level0type = N'SCHEMA', @level0name = N'dbo',
    @level1type = N'TABLE', @level1name = N'motos',
    @level2type = N'COLUMN', @level2name = N'ID';

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Placa da motocicleta no formato ABC1234 ou ABC1D23 (campo único e obrigatório)',
    @level0type = N'SCHEMA', @level0name = N'dbo',
    @level1type = N'TABLE', @level1name = N'motos',
    @level2type = N'COLUMN', @level2name = N'PLACA';

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Modelo da motocicleta (ex: Honda CG 160, Yamaha MT-03)',
    @level0type = N'SCHEMA', @level0name = N'dbo',
    @level1type = N'TABLE', @level1name = N'motos',
    @level2type = N'COLUMN', @level2name = N'MODELO';

EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Situação da motocicleta: "dentro" (no pátio) ou "fora" (fora do pátio)',
    @level0type = N'SCHEMA', @level0name = N'dbo',
    @level1type = N'TABLE', @level1name = N'motos',
    @level2type = N'COLUMN', @level2name = N'SITUACAO';
GO


-- Inserir 2 pátios
INSERT INTO dbo.patios (NOME_LOCAL) VALUES ('Pátio Central - São Paulo');
INSERT INTO dbo.patios (NOME_LOCAL) VALUES ('Pátio Norte - Guarulhos');
GO

-- Inserir 2 motocicletas
INSERT INTO dbo.motos (PLACA, MODELO, SITUACAO) VALUES ('ABC1234', 'Honda CG 160 Fan', 'dentro');
INSERT INTO dbo.motos (PLACA, MODELO, SITUACAO) VALUES ('XYZ9876', 'Yamaha MT-03', 'fora');
GO

-- Verificar estrutura das tabelas
SELECT 
    t.TABLE_NAME AS 'Tabela',
    c.COLUMN_NAME AS 'Coluna',
    c.DATA_TYPE AS 'Tipo',
    c.CHARACTER_MAXIMUM_LENGTH AS 'Tamanho',
    c.IS_NULLABLE AS 'Permite NULL'
FROM INFORMATION_SCHEMA.TABLES t
INNER JOIN INFORMATION_SCHEMA.COLUMNS c ON t.TABLE_NAME = c.TABLE_NAME
WHERE t.TABLE_NAME IN ('motos', 'patios')
ORDER BY t.TABLE_NAME, c.ORDINAL_POSITION;
GO

-- Verificar constraints
SELECT 
    tc.TABLE_NAME AS 'Tabela',
    tc.CONSTRAINT_NAME AS 'Constraint',
    tc.CONSTRAINT_TYPE AS 'Tipo'
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc
WHERE tc.TABLE_NAME IN ('motos', 'patios')
ORDER BY tc.TABLE_NAME, tc.CONSTRAINT_TYPE;
GO

-- Contar registros
SELECT 'motos' AS Tabela, COUNT(*) AS Total FROM dbo.motos
UNION ALL
SELECT 'patios' AS Tabela, COUNT(*) AS Total FROM dbo.patios;
GO

-- Listar todas as motos
SELECT * FROM dbo.motos;
GO

-- Listar todos os pátios
SELECT * FROM dbo.patios;
GO

-- Listar motos por situação
SELECT 
    SITUACAO,
    COUNT(*) AS 'Quantidade'
FROM dbo.motos
GROUP BY SITUACAO;
GO