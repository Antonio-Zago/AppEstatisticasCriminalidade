CREATE TABLE OCORRENCIAS
(
	ID int PRIMARY KEY IDENTITY(1,1),
	DESCRICAO VARCHAR(500), 
	DATAHORA DATETIME,
	CADASTROUBOLETIMOCORRENCIA BIT
);

INSERT INTO OCORRENCIAS (DESCRICAO, DATAHORA, CADASTROUBOLETIMOCORRENCIA)
VALUES 
('Ocorr�ncia 1', CONVERT(DATETIME, '2024-05-26 08:00:00', 120), 1),
('Ocorr�ncia 2', CONVERT(DATETIME, '2024-05-26 09:15:00', 120), 0),
('Ocorr�ncia 3', CONVERT(DATETIME, '2024-05-26 10:30:00', 120), 1),
('Ocorr�ncia 4', CONVERT(DATETIME, '2024-05-26 11:45:00', 120), 0),
('Ocorr�ncia 5', CONVERT(DATETIME, '2024-05-26 13:00:00', 120), 1),
('Ocorr�ncia 6', CONVERT(DATETIME, '2024-05-26 14:15:00', 120), 0),
('Ocorr�ncia 7', CONVERT(DATETIME, '2024-05-26 15:30:00', 120), 1),
('Ocorr�ncia 8', CONVERT(DATETIME, '2024-05-26 16:45:00', 120), 0),
('Ocorr�ncia 9', CONVERT(DATETIME, '2024-05-26 18:00:00', 120), 1),
('Ocorr�ncia 10', CONVERT(DATETIME, '2024-05-26 19:15:00', 120), 0),
('Ocorr�ncia 11', CONVERT(DATETIME, '2024-05-26 20:30:00', 120), 1),
('Ocorr�ncia 12', CONVERT(DATETIME, '2024-05-26 21:45:00', 120), 0),
('Ocorr�ncia 13', CONVERT(DATETIME, '2024-05-26 22:00:00', 120), 1),
('Ocorr�ncia 14', CONVERT(DATETIME, '2024-05-26 23:15:00', 120), 0),
('Ocorr�ncia 15', CONVERT(DATETIME, '2024-05-27 08:30:00', 120), 1),
('Ocorr�ncia 16', CONVERT(DATETIME, '2024-05-27 09:45:00', 120), 0),
('Ocorr�ncia 17', CONVERT(DATETIME, '2024-05-27 11:00:00', 120), 1),
('Ocorr�ncia 18', CONVERT(DATETIME, '2024-05-27 12:15:00', 120), 0),
('Ocorr�ncia 19', CONVERT(DATETIME, '2024-05-27 13:30:00', 120), 1),
('Ocorr�ncia 20', CONVERT(DATETIME, '2024-05-27 14:45:00', 120), 0);


ALTER TABLE OCORRENCIAS
ADD TIPOOCORRENCIA int;

UPDATE ocorrencias
SET tipoocorrencia = 1
where id < 10;

UPDATE ocorrencias
SET tipoocorrencia = 2
where id >= 10;


CREATE TABLE ASSALTOS
(
	ID int PRIMARY KEY IDENTITY(1,1),
	QUANTIDADEAGRESSORES INT, 
	POSSUIARMA BIT,
	OCORRENCIAID INT
);

ALTER TABLE ASSALTOS
ADD CONSTRAINT ASSALTOS_OCORRENCIAS_FK FOREIGN KEY (OCORRENCIAID) REFERENCES OCORRENCIAS (ID);

INSERT INTO ASSALTOS (QUANTIDADEAGRESSORES, POSSUIARMA, OCORRENCIAID)
VALUES
    (3, 1, 3),
    (2, 0, 4),
    (1, 1, 5),
    (4, 1, 6),
    (2, 0, 7),
    (1, 0, 8),
    (3, 1, 9),
    (2, 0, 10)

CREATE TABLE TIPOARMAS
(
	ID int PRIMARY KEY IDENTITY(1,1),
	DESCRICAO VARCHAR(30), 
	ARMADEFOGO BIT
);


ALTER TABLE ASSALTOS
ADD TIPOARMAID INT;

ALTER TABLE ASSALTOS
ADD CONSTRAINT ASSALTOS_TIPOARMAS_FK FOREIGN KEY (TIPOARMAID) REFERENCES TIPOARMAS (ID);

INSERT INTO TIPOARMAS (DESCRICAO, ARMADEFOGO) 
VALUES 
('Pistola', 1),
('Fuzil', 1),
('Faca', 0),
('Rev�lver', 1),
('MotoSerra', 0);

UPDATE ASSALTOS
SET tipoarmaid = 2;


CREATE TABLE ROUBOS
(
	ID int PRIMARY KEY IDENTITY(1,1),
	OCORRENCIAID INT
);

ALTER TABLE ROUBOS
ADD CONSTRAINT ROUBOS_OCORRENCIAS_FK FOREIGN KEY (OCORRENCIAID) REFERENCES OCORRENCIAS (ID);

INSERT INTO ROUBOS (OCORRENCIAID) 
VALUES 
    (11),
    (12),
    (13),
    (14),
    (15),
    (16),
    (17)


CREATE TABLE TIPOBENS
(
	ID int PRIMARY KEY IDENTITY(1,1),
	NOME VARCHAR(30)
);

CREATE TABLE ASSALTOSTIPOBENS
(
	ASSALTOID INT NOT NULL,
	TIPOBEMID INT NOT NULL
);
 


ALTER TABLE ASSALTOSTIPOBENS
ADD CONSTRAINT ASSALTOSTIPOBENS_ASSALTOS_FK FOREIGN KEY (ASSALTOID) REFERENCES ASSALTOS (ID);

ALTER TABLE ASSALTOSTIPOBENS
ADD CONSTRAINT ASSALTOSTIPOBENS_TIPOBENS_FK FOREIGN KEY (TIPOBEMID) REFERENCES TIPOBENS (ID);

ALTER TABLE ASSALTOSTIPOBENS
ADD CONSTRAINT ASSALTOSTIPOBENS_PK PRIMARY KEY CLUSTERED (ASSALTOID, TIPOBEMID);

INSERT INTO TIPOBENS (NOME) 
VALUES 
    ('Item A'),
    ('Item B'),
    ('Item C'),
    ('Item D'),
    ('Item E');


CREATE TABLE ROUBOSTIPOBENS
(
	ROUBOID INT NOT NULL,
	TIPOBEMID INT NOT NULL
);
 


ALTER TABLE ROUBOSTIPOBENS
ADD CONSTRAINT ROUBOSTIPOBENS_ROUBOS_FK FOREIGN KEY (ROUBOID) REFERENCES ROUBOS (ID);

ALTER TABLE ROUBOSTIPOBENS
ADD CONSTRAINT ROUBOSTIPOBENS_TIPOBENS_FK FOREIGN KEY (TIPOBEMID) REFERENCES TIPOBENS (ID);

ALTER TABLE ROUBOSTIPOBENS
ADD CONSTRAINT ROUBOSTIPOBENS_PK PRIMARY KEY CLUSTERED (ROUBOID, TIPOBEMID);

CREATE TABLE INDOCORRENCIAS
(
	ID int PRIMARY KEY IDENTITY(1,1),
	NUMBO VARCHAR(30),
	DATAOCORRENCIA DATETIME,
	TIPO INT,
	CIDADE VARCHAR(50),
	LATITUDE VARCHAR(50),
	LONGITUDE VARCHAR(50)
);

select * from INDOCORRENCIAS

INSERT INTO INDOCORRENCIAS (NUMBO, DATAOCORRENCIA, TIPO, CIDADE, LATITUDE, LONGITUDE)
VALUES ('BO12345', '2024-06-01', 'Roubo', 'S�o Paulo', '23.5505� S', '46.6333� W');


ALTER TABLE INDOCORRENCIAS
ALTER COLUMN DataOcorrencia DATETIME

ALTER TABLE INDOCORRENCIAS
ALTER COLUMN TIPO VARCHAR(50)

