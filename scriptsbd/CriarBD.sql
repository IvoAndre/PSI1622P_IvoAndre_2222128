/****** SCRIPT REDUNDANTE ******/
/*PROGRAMA CRIA A PRÓPRIA BASE DE DADOS*/
/*PROGRAMA CRIA A PRÓPRIA BASE DE DADOS*/
/*PROGRAMA CRIA A PRÓPRIA BASE DE DADOS*/
/*PROGRAMA CRIA A PRÓPRIA BASE DE DADOS*/
/*PROGRAMA CRIA A PRÓPRIA BASE DE DADOS*/
/*PROGRAMA CRIA A PRÓPRIA BASE DE DADOS*/
/*PROGRAMA CRIA A PRÓPRIA BASE DE DADOS*/

IF DB_ID('Projeto_2_Ano') IS NULL CREATE DATABASE Projeto_2_Ano;

IF OBJECT_ID('users', 'U') IS NULL
                    CREATE TABLE [dbo].[users] (
                    [id]       INT           IDENTITY (1, 1) NOT NULL,
                    [name]     VARCHAR (100) NOT NULL,
                    [password] VARCHAR (64)  NOT NULL,
                    [username] VARCHAR (100) NOT NULL,
                    CONSTRAINT [Pk_users_id] PRIMARY KEY CLUSTERED ([id] ASC)
                    );
                        
                    IF OBJECT_ID('bank_accounts','U') IS NULL
                    CREATE TABLE [dbo].[bank_accounts] (
                    [userid] INT          NOT NULL,
                    [pin]    VARCHAR (64) NOT NULL,
                    [saldo]  FLOAT (53)   CONSTRAINT [defo_bank_accounts_saldo] DEFAULT ((0.00)) NOT NULL,
                    [IBAN]   VARCHAR (25) CONSTRAINT [defo_bank_accounts_IBAN] NOT NULL,
                    CONSTRAINT [Pk_bankaccounts_userid] PRIMARY KEY CLUSTERED ([userid] ASC),
                    CONSTRAINT [Fk_bankuid] FOREIGN KEY ([userid]) REFERENCES [dbo].[users] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
                    );

                    IF OBJECT_ID('bank_transactions','U') IS NULL
                    CREATE TABLE [dbo].[bank_transactions] (
                    [id]           INT           IDENTITY (1, 1) NOT NULL,
                    [userid]       INT           NOT NULL,
                    [time]         DATETIME      CONSTRAINT [defo_bank_transactions_time] DEFAULT (getdate()) NOT NULL,
                    [description]         VARCHAR (250) NOT NULL,
                    [variation]    FLOAT (53)    NOT NULL,
                    [finalbalance] FLOAT (53)    CONSTRAINT [defo_bank_transactions_finalbalance] DEFAULT (0) NOT NULL,
                    CONSTRAINT [Pk_banktransactions_id] PRIMARY KEY CLUSTERED ([id] ASC),
                    CONSTRAINT [FK_banktransuid] FOREIGN KEY ([userid]) REFERENCES [dbo].[bank_accounts] ([userid]) ON DELETE CASCADE ON UPDATE CASCADE
                    );

                    IF OBJECT_ID('shop_categories','U') IS NULL
                    CREATE TABLE [dbo].[shop_categories] (
                        [name] VARCHAR (100) NOT NULL,
                        [id]   INT           IDENTITY (1, 1) NOT NULL,
                        CONSTRAINT [Pk_shop_categories_id] PRIMARY KEY CLUSTERED ([id] ASC)
                    );

                    IF OBJECT_ID('shop_products','U') IS NULL
                    CREATE TABLE [dbo].[shop_products] (
                        [idprod]      INT           IDENTITY (1, 1) NOT NULL,
                        [idcat]       INT           NOT NULL,
                        [catpos]      INT           NOT NULL,
                        [name]        VARCHAR (100) NOT NULL,
                        [description] VARCHAR (500) NULL,
                        [stock]       INT           NOT NULL,
                        [price]       FLOAT (53)    NOT NULL,
                        [imagepath]  VARCHAR(255)  CONSTRAINT [defo_shop_products_imagepath] NOT NULL DEFAULT 'config\noimage.png',
                        CONSTRAINT [Pk_produtos_idpr] PRIMARY KEY CLUSTERED ([idprod] ASC),
                        CONSTRAINT [fk_idcat] FOREIGN KEY ([idcat]) REFERENCES [dbo].[shop_categories] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
                    );

IF NOT EXISTS (SELECT * FROM sys.triggers WHERE name = 'trg_maintain_finalbalance')
                    BEGIN
                        EXEC ('CREATE TRIGGER trg_maintain_finalbalance
                        ON [dbo].[bank_transactions]
                        AFTER INSERT, UPDATE, DELETE
                        AS
                        BEGIN
                            SET NOCOUNT ON;

                            DECLARE @userid INT;

                            -- Determine affected user ID
                            IF EXISTS (SELECT 1 FROM inserted) 
                                SET @userid = (SELECT TOP 1 userid FROM inserted);
                            ELSE 
                                SET @userid = (SELECT TOP 1 userid FROM deleted);

                            -- Update finalbalance for all transactions of the affected userid
                            WITH cte AS (
                                SELECT 
                                    id,
                                    userid,
                                    variation,
                                    SUM(variation) OVER (PARTITION BY userid ORDER BY [time], id ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS running_total
                                FROM 
                                    [dbo].[bank_transactions]
                                WHERE 
                                    userid = @userid
                            )
                            UPDATE bt
                            SET bt.finalbalance = ROUND(cte.running_total, 2)
                            FROM 
                                [dbo].[bank_transactions] bt
                            JOIN 
                                cte ON bt.id = cte.id;

                            -- Update saldo in bank_accounts table
                            UPDATE ba
                            SET ba.saldo = (
                                SELECT ROUND(ISNULL(SUM(variation), 0), 2)
                                FROM [dbo].[bank_transactions]
                                WHERE userid = @userid
                            )
                            FROM [dbo].[bank_accounts] ba
                            WHERE ba.userid = @userid;
                        END');
                    END;

IF NOT EXISTS (SELECT * FROM sys.triggers WHERE name = 'trg_OrderProductsByCategory')
                    BEGIN
                        EXEC ('CREATE TRIGGER trg_OrderProductsByCategory
                    ON shop_products
                    AFTER INSERT, UPDATE, DELETE
                    AS
                    BEGIN
                        SET NOCOUNT ON;

                        ;WITH AffectedCategories AS (
                            SELECT DISTINCT idcat
                            FROM inserted
                            UNION
                            SELECT DISTINCT idcat
                            FROM deleted
                        ),

                        CTE AS (
                            SELECT 
                                sp.idprod, 
                                sp.idcat,
                                ROW_NUMBER() OVER (PARTITION BY sp.idcat ORDER BY sp.name) AS RowNum
                            FROM 
                                shop_products sp
                            INNER JOIN 
                                AffectedCategories ac ON sp.idcat = ac.idcat
                        )
    
                        UPDATE sp
                        SET sp.catpos = cte.RowNum
                        FROM shop_products sp
                        INNER JOIN CTE ON sp.idprod = CTE.idprod;
                    END');
                    END;

IF NOT EXISTS (SELECT 1 FROM [dbo].[shop_categories]) 
                AND NOT EXISTS (SELECT 1 FROM [dbo].[shop_products])
            BEGIN
                INSERT INTO [dbo].[shop_categories] ([name])
                VALUES
                    ('Tecnologia'),
                    ('Alimentos'),
                    ('Bebidas'),
                    ('Lazer'),
                    ('Produtos Automóveis');
            
                INSERT INTO [dbo].[shop_products] ([idcat], [catpos], [name], [description], [stock], [price], [imagepath])
                VALUES
                    (1, 1, 'Calculadora gráfica Texas Instruments TI-82 STAT', 'Calculadora gráfica avançada TI-82 STAT.', 20, 189.99, 'config\\loja\\default\\texascalc.png'),
                    (1, 2, 'Cartão presente Microsoft Azure 1 Mês', 'Cartão presente para 1 mês de serviços Microsoft Azure.', 10, 69.99, 'config\\loja\\default\\azuregiftcard.png'),
                    (1, 3, 'Smartphone SAMSUNG Galaxy S24 Ultra 256GB', 'Smartphone topo de gama Samsung Galaxy S24 Ultra com 256GB de armazenamento.', 15, 1299.99, 'config\\loja\\default\\s24.png'),
                    (1, 4, 'MacBook Pro M4 16 Polegadas 48GB RAM 1TB', 'MacBook Pro de 16 polegadas com 48GB de RAM e 1TB de armazenamento.', 5, 5899.99, 'config\\loja\\default\\macbook.png'),
                    (1, 5, 'TV LG OLED83G45LW (OLED - 83'' - 210 cm - 4K Ultra HD)', 'Televisão LG OLED de 83 polegadas com resolução 4K Ultra HD.', 10, 5699.99, 'config\\loja\\default\\lgtvhd.png'),
                    (1, 6, 'Aspirador Robô IROBOT Roomba Combo J9+ 2-em-1', 'Aspirador robô IROBOT Roomba Combo J9+ com função 2-em-1.', 25, 999.99, 'config\\loja\\default\\irobot.png'),

                    (2, 1, 'Carne de Javali 1kg', 'Carne de javali de alta qualidade, 1 kg.', 30, 25.50, 'config\\loja\\default\\carnejavali.png'),
                    (2, 2, 'Leite Mário Edição Limitada', 'Leite especial em edição limitada.', 100, 12.99, 'config\\loja\\default\\mariomilk.png'),
                    (2, 3, 'Croquetes de Carne', 'Deliciosos croquetes de carne.', 200, 3.99, 'config\\loja\\default\\croquetes.png'),
                    (2, 4, 'Bacalhau Desfiado Congelado', 'Bacalhau desfiado e congelado, pronto a cozinhar.', 150, 9.49, 'config\\loja\\default\\bacalhau.png'),
                    (2, 5, 'Manga Palmer Maturada 1kg', 'Mangas Palmer maturadas, 1 kg.', 100, 2.99, 'config\\loja\\default\\manga.png'),
                    (2, 6, 'Pimento Vermelho 500g', 'Pimentos vermelhos frescos, 500 g.', 200, 1.89, 'config\\loja\\default\\pimentos.png'),

                    (3, 1, 'Cerveja com Álcool Super Bock Mini Pack 30', 'Pack de 30 unidades de cerveja Super Bock Mini.', 120, 13.85, 'config\\loja\\default\\super.png'),
                    (3, 2, 'Compal Laranja do Algarve 1L', 'Sumo de laranja natural do Algarve, 1 litro.', 300, 1.99, 'config\\loja\\default\\compal.png'),
                    (3, 3, 'Coca-Cola Pack 4x1L', 'Pack de 4 garrafas de 1 litro de Coca-Cola.', 150, 5.49, 'config\\loja\\default\\cocacola.png'),
                    (3, 4, 'Ice Tea Limão Lipton 2x2L', 'Pack de 2 garrafas de 2 litros de Ice Tea Limão Lipton.', 100, 4.20, 'config\\loja\\default\\icetea.png'),
                    (3, 5, 'Água sem Gás Luso 6x1,5L', 'Pack de 6 garrafas de 1,5 litros de água sem gás Luso.', 200, 3.89, 'config\\loja\\default\\luso.png'),
                    (3, 6, 'Só Pias Vinho Tinto 5L', 'Garrafão de 5 litros de vinho tinto Só Pias.', 50, 9.39, 'config\\loja\\default\\sopias.png'),

                    (4, 1, 'Livro de Poemas de Antero de Quental', 'Livro com uma coleção de poemas de Antero de Quental.', 50, 22.40, 'config\\loja\\default\\anteroquental.png'),
                    (4, 2, 'Pacote de Férias no Dubai', 'Pacote de férias completo para o Dubai.', 5, 889.75, 'config\\loja\\default\\feriasdubai.png'),
                    (4, 3, 'Isto é Matemática Blu-ray Edição Limitada', 'Edição limitada do Blu-ray ""Isto é Matemática"".', 30, 19.99, 'config\\loja\\default\\istoematematica.png'),
                    (4, 4, 'Bola Anti-Stress Newtoniana', 'Bola anti-stress de design newtoniano.', 100, 1.99, 'config\\loja\\default\\bolastressnewtoniana.png'),
                    (4, 5, 'Cigarro Marlboro Gold 10 unidades', 'Pacote de cigarros Marlboro Gold, 10 unidades.', 200, 7.90, 'config\\loja\\default\\marlboro.png'),
                    (4, 6, 'Helldivers 2', 'Jogo de ação cooperativa ""Helldivers 2"".', 50, 39.99, 'config\\loja\\default\\helldivers2.png'),

                    (5, 1, 'Lâmpadas NORAUTO Clássico W5W 2un', 'Par de lâmpadas clássicas para automóveis, modelo W5W.', 100, 4.99, 'config\\loja\\default\\lampadascarro.png'),
                    (5, 2, 'Bateria VARTA E44 Silver Dynamic 77 Ah - 780 A', 'Bateria automóvel de alta performance, 77 Ah e 780 A.', 50, 139.00, 'config\\loja\\default\\bateriacarro.png'),
                    (5, 3, 'Escova limpa-vidros NORAUTO Performance 165 650mm', 'Escova limpa-vidros de alta performance, 650mm.', 75, 15.99, 'config\\loja\\default\\escovalimpavidros.png'),
                    (5, 4, 'Óleo de Motor SHELL HELIX HX8 5W30 ECT 5L', 'Óleo de motor de qualidade superior, 5W30 ECT, 5 litros.', 40, 39.99, 'config\\loja\\default\\oleomotor.png'),
                    (5, 5, 'Colete de segurança amarelo adulto', 'Colete de segurança amarelo para adultos, obrigatório em veículos.', 200, 3.99, 'config\\loja\\default\\coleteseg.png'),
                    (5, 6, 'Pack 4 Pneus Multi-usos', 'Conjunto de 4 pneus multi-usos para diversos tipos de terreno.', 20, 499.99, 'config\\loja\\default\\4pneus.png');
            END;

