create table users
(
	email varchar(100) primary key not null, 
	nome varchar(55) not null, 
	sobrenome varchar(55) not null,
	dt_nascimento date not null,
	nickUser varchar(25),
	senha varchar (55) not null
);
go 

create table foruns
(
	criador varchar(100) not null,
	CONSTRAINT fk_criador FOREIGN KEY (criador) REFERENCES users (email),
	nome varchar(55) primary key not null,
	descricao varchar(255) not null
);
go

create table cargos
(
	nome varchar(55) primary key,
	comentario bit,
	likes bit,
	deslikes bit
);
go

create table participantes 
(
	forum varchar(55), 
	constraint fk_forum foreign key (forum) references foruns(nome),
	participante varchar(100),
	constraint fk_user foreign key (participante) references users(email),
	cargo_user varchar(55),
	constraint fk_cargo foreign key (cargo_user) references cargos(nome)
);
go

create table post
(
	id int primary key identity,
	titulo varchar(100) not null,
	texto varchar(255) not null,
	qtd_like int,
	qtd_deslike int,
	qtd_coment int,
	dataPost date not null,
	forum varchar(55) not null, 
	constraint fk_forum2 foreign key (forum) references foruns(nome),
	participante varchar(100) not null,
	constraint fk_user2 foreign key (participante) references users(email)
);
go

create table comentario 
(
	participante varchar(100) not null,
	constraint fk_user3 foreign key (participante) references users(email),
	texto varchar(255) not null,
);
go


create table likes 
(
	id int primary key identity,
	participante varchar(100) not null,
	constraint fk_user4 foreign key (participante) references users(email),
	post int,
	constraint fk_post foreign key (post) references post(id)
);


select * from likes