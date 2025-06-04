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
            Nome varchar(50) not null,
			Descricao varchar(50) not null,
			Preco double(4,2) not null,
			Quantidade int not null
		);
        
        insert into Usuarios (Nome, Email, Senha)
        values ('Pedro Pessanha', 'ph123@gmail.com', 'ph12318');
        
		insert into Produtos (Nome, Descricao, Preco, Quantidade)
        values ('Bola', 'Bola de Futebol', 50.89, 10);