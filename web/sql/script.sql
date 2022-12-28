CREATE DATABASE estoque;

CREATE TABLE produtos(
	id INTEGER NOT NULL AUTO_INCREMENT PRIMARY KEY, 
	nome VARCHAR(100) NOT NULL, 
	descricao TEXT,  
	data_criacao VARCHAR(10),
	data_validade VARCHAR(10),
	quantidade_estoque INTEGER 
);

insert into produtos(nome, descricao, data_criacao, data_validade, quantidade_estoque )values('Maçã', 'Maçã Argentina', '12/11/2022', '26/11/2022', '30');
insert into produtos(nome, descricao, data_criacao, data_validade, quantidade_estoque )values('Banana', 'Banana Prata', '25/12/2022', '30/12/2022', '40');
insert into produtos(nome, descricao, data_criacao, data_validade, quantidade_estoque )values('Uva', 'Uva Verde', '30/10/2022', '05/11/2022', '10');
insert into produtos(nome, descricao, data_criacao, data_validade, quantidade_estoque )values('Goiaba', 'Goiaba vermelha', '26/12/2022', '30/12/2022', '50');
insert into produtos(nome, descricao, data_criacao, data_validade, quantidade_estoque )values('Manga', 'Manga Rosa', '05/12/2022', '26/12/2022', '20');

select * from produtos;

select * from produtos where id = 1; --filtra por id
select * from produtos where id in (1,2); --filtra por varios ids
select * from produtos where nome = 'Maçã'; --filtra por nome de forma exata
select * from produtos where nome like 'Ba%'; --filtra por parte do nome no inicio
select * from produtos where nome like '%aba'; --filtra por parte do nome no inicio
select * from produtos where nome like '%an%'; --filtra por parte do texto

update produtos set nome ='Uva', descricao ='Uva Sem semente', data_criacao='2022-10-31', data_validade= '2022-11-10', quantidade_estoque= '25' where id =3;

insert into produtos(nome, descricao, data_criacao, data_validade, quantidade_estoque)values('teste', 'teste', '2022-02-02', '2022-02-02', '10');

delete from produtos where id =5;
DROP TABLE produtos; -- deletar a tabela

START TRANSACTION; --starta uma transação segura

COMMIT; --confirma a transação
ROLLBACK; --desfaz a transação

--DUMP DO BANCO DE DADOS SQL
mysqldump -u root -p'broot' estoque > sql/backup.sql;