/*
use conhecimentoe;
CREATE TABLE climaAeroporto (
    climaId int NOT NULL AUTO_INCREMENT,
    umidade varchar(3) ,
    visibilidade int,
    intensidade varchar(3),
    Age int,
    codigo_icao varchar(10),
    pressao_atmosferica varchar(10),
    vento int,
    direcao_vento int,
   condicao varchar(10),
  condicao_desc varchar(10),
  temp int,
  atualizado_em  varchar(20),
   PRIMARY KEY (climaId)
);

CREATE TABLE clima (
oclimaId int NOT NULL AUTO_INCREMENT,
data  varchar(20),
condicao varchar(10),
min int,
max int,
indice_uv int,
condicao_desc varchar(50),
 PRIMARY KEY (oclimaId)

);

CREATE TABLE cidade (
cidadeId int NOT NULL AUTO_INCREMENT,
cidade varchar(50),
estado varchar(2),
atualizado_em varchar(20),
oclimaId int,
PRIMARY KEY (cidadeId)
) 
 
 */