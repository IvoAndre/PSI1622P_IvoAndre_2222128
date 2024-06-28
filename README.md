# BankStore - Integration

## Índice

0. [Introdução](#introdução)
1. [Tecnologias e Recursos](#tecnologias-e-recursos)
   - [Bibliotecas Utilizadas](#bibliotecas-utilizadas)
   - [Ferramentas Utilizadas](#ferramentas-utilizadas)
   - [Requisitos Mínimos](#requisitos-mínimos)
2. [Estrutura da Base de Dados](#estrutura-da-base-de-dados)
3. [Gatilhos Utilizados](#gatilhos-utilizados)

## Introdução

O projeto "BankStore - Integration" é um programa que integra um sistema bancário e uma loja para facilitar as interações entre o utilizador, o banco e a loja em uma plataforma única. O objetivo principal do projeto é permitir operações bancárias como depósito, levantamento e transferência de fundos, consulta de transações e permitir compras simples e rápidas com uma loja que oferece um grande stock de itens variados e uma forma fácil e eficiente de pagar com a conta bancária.

## Tecnologias e Recursos

### Bibliotecas Utilizadas

- **Microsoft.Data.SqlClient**: Usada para acessar e manipular dados em SQL Server.
- **System.Data**: Usada para gerir dados da base de dados.
- **System.Security.Cryptography**: Usada para encriptar palavras-passe e PINs dos utilizadores na base de dados.
- **System.Text**: Usada em conjunto com System.Security.Cryptography para criar um buffer de bytes para a encriptação.

### Ferramentas Utilizadas

- **Visual Studio 2022**: Utilizada para a execução do projeto e gestão da base de dados.
- **Dbschema 8.2.7**: Usada para criar o esquema da base de dados para documentação.
- **Balsamiq Wireframes 4.7.5**: Usada para criar o rascunho da estrutura dos formulários.
- **Excalidraw**: Usado para estruturar o projeto de forma visual.

### Requisitos Mínimos

- **CPU**: Qualquer processador Intel ou AMD x64 bits.
- **RAM**: 2GB+.
- **Armazenamento**: 1GB+.

## Estrutura da Base de Dados

A base de dados foi projetada para suportar o sistema integrado de banco e loja. O modelo de dados inclui as seguintes tabelas:

1. **Tabela `users`**
   - Campos: `id` (chave primária, autoincremento), `name`, `password`, `username`.

2. **Tabela `bank_accounts`**
   - Campos: `userid` (chave estrangeira referenciando `users.id`), `pin`, `saldo`, `IBAN`.
   - Restrições: Chave primária `userid`, chave estrangeira referenciando `users.id` com ação CASCADE.

3. **Tabela `bank_transactions`**
   - Campos: `id` (chave primária, autoincremento), `userid` (chave estrangeira referenciando `bank_accounts.userid`), `time`, `description`, `variation`, `finalbalance`.
   - Restrições: Chave primária `id`, chave estrangeira referenciando `bank_accounts.userid` com ação CASCADE.

4. **Tabela `shop_categories`**
   - Campos: `id` (chave primária, autoincremento), `name`.

5. **Tabela `shop_products`**
   - Campos: `idprod` (chave primária, autoincremento), `idcat` (chave estrangeira referenciando `shop_categories.id`), `catpos`, `name`, `description`, `stock`, `price`, `imagepath`.
   - Restrições: Chave primária `idprod`, chave estrangeira referenciando `shop_categories.id` com ação CASCADE.

## Gatilhos Utilizados

1. **Trigger `trg_maintain_finalbalance`**
   - Atualiza o `finalbalance` em `bank_transactions` e o `saldo` em `bank_accounts` após inserções, atualizações ou exclusões em `bank_transactions`.

2. **Trigger `trg_OrderProductsByCategory`**
   - Mantém a ordem alfabética dos produtos por categoria na tabela `shop_products` após inserções, atualizações ou exclusões.
