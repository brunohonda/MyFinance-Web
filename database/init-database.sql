CREATE DATABASE myfinance;
GO

USE myfinance;
GO

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'myfinance')
BEGIN
	CREATE DATABASE myfinance;
END;
GO

USE myfinance;
GO

CREATE TABLE PlanoConta (
	id INT NOT NULL IDENTITY(1, 1),
	descricao VARCHAR(50) NOT NULL,
	tipo CHAR(1) NOT NULL CHECK (tipo IN ('D', 'R')),
	PRIMARY KEY (id),
);
GO

CREATE TABLE Transacao(
	id INT NOT NULL IDENTITY(1, 1),
	historico VARCHAR(50) NULL,
	valor DECIMAL (9, 2),
	data DATETIME DEFAULT CURRENT_TIMESTAMP,
	planocontaid INT NOT NULL
	PRIMARY KEY (id),
	CONSTRAINT fk_lano_conta FOREIGN KEY (planocontaid) REFERENCES PlanoConta (id)
);