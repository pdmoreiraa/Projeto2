	-- Criando banco de dados 
		create database dbProjeto2;
		use dbProjeto2;

		create table Usuarios(
			IdUser int primary key auto_increment,
			Nome varchar(50) not null,
			Email varchar(50) not null,
			Senha varchar(50) not null
		);
		
		create table Produtos(
			IdProd int primary key auto_increment,
			Descricao varchar(50) not null,
			Preco double(4,2) not null,
			Quantidade int not null
		);