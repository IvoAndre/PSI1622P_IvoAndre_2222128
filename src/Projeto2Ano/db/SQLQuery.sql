CREATE TABLE users ( 
	id                   int NOT NULL   IDENTITY ,
	name                 varchar(100) NOT NULL    ,
	password             varchar(100) NOT NULL    ,
	username             varchar(100) NOT NULL    ,
	CONSTRAINT Pk_users_id PRIMARY KEY  ( id )
 );

CREATE TABLE bank_accounts ( 
	userid               int NOT NULL    ,
	pin                  int NOT NULL    ,
	saldo                float NOT NULL CONSTRAINT defo_bank_accounts_saldo DEFAULT 0.00   ,
	IBAN                 int NOT NULL CONSTRAINT defo_bank_accounts_IBAN DEFAULT 1300000000000000   ,
	CONSTRAINT Pk_bankaccounts_userid PRIMARY KEY  ( userid )
 );

ALTER TABLE bank_accounts ADD CONSTRAINT Fk_bankuid FOREIGN KEY ( userid ) REFERENCES users( id ) ON DELETE CASCADE ON UPDATE CASCADE;

CREATE TABLE bank_transactions ( 
	id                   int NOT NULL   IDENTITY ,
	userid               int NOT NULL    ,
	time                 datetime NOT NULL CONSTRAINT defo_bank_transactions_time DEFAULT CURRENT_TIMESTAMP   ,
	name                 varchar(250) NOT NULL    ,
	variation            float NOT NULL    ,
	finalbalance         float NOT NULL    ,
	CONSTRAINT Pk_banktransactions_id PRIMARY KEY  ( id )
 );

ALTER TABLE bank_transactions ADD CONSTRAINT FK_banktransuid FOREIGN KEY ( userid ) REFERENCES bank_accounts( userid ) ON DELETE CASCADE ON UPDATE CASCADE;

CREATE TABLE shop_products ( 
	idprod               int NOT NULL   IDENTITY ,
	idcat                int NOT NULL    ,
	catpos               int NOT NULL    ,
	name                 varchar(100) NOT NULL    ,
	description          varchar(500)     ,
	stock                int NOT NULL    ,
	price                float NOT NULL    ,
	CONSTRAINT Pk_produtos_idpr PRIMARY KEY  ( idprod )
 );

