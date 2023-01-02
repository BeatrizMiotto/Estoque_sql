CREATE DATABASE estoque;

CREATE TABLE produto(
	id INTEGER NOT NULL AUTO_INCREMENT PRIMARY KEY, 
	nome VARCHAR(100) NOT NULL, 
	descricao TEXT,  
	entrada VARCHAR(10),
	validade VARCHAR(10),
	quantidade INTEGER 
);

insert into produto(nome, descricao, entrada, validade, quantidade )values('Maçã', 'Maçã Argentina', '12/11/2022', '26/11/2022', '30');
insert into produto(nome, descricao, entrada, validade, quantidade )values('Banana', 'Banana Prata', '25/12/2022', '30/12/2022', '40');
insert into produto(nome, descricao, entrada, validade, quantidade )values('Uva', 'Uva Verde', '30/10/2022', '05/11/2022', '10');
insert into produto(nome, descricao, entrada, validade, quantidade )values('Goiaba', 'Goiaba vermelha', '26/12/2022', '30/12/2022', '50');
insert into produto(nome, descricao, entrada, validade, quantidade )values('Manga', 'Manga Rosa', '05/12/2022', '26/12/2022', '20');

select * from produto;

select * from produto where id = 1; --filtra por id
select * from produto where id in (1,2); --filtra por varios ids
select * from produto where nome = 'Maçã'; --filtra por nome de forma exata
select * from produto where nome like 'Ba%'; --filtra por parte do nome no inicio
select * from produto where nome like '%aba'; --filtra por parte do nome no inicio
select * from produto where nome like '%an%'; --filtra por parte do texto

update produto set nome ='Maçã', descricao ='Maçã Red', entrada='12/11/2022', validade= '26/11/2022', quantidade= '30' where id =16;

insert into produto(nome, descricao, entrada, validade, quantidade)values('teste', 'teste', '2022-02-02', '2022-02-02', '10');

delete from produto where id =5;
DROP TABLE produto; -- deletar a tabela

START TRANSACTION; --starta uma transação segura

COMMIT; --confirma a transação
ROLLBACK; --desfaz a transação

--DUMP DO BANCO DE DADOS SQL
mysqldump -u root -p'broot' estoque > sql/backup.sql;