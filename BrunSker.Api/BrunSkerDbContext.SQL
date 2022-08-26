ALTER DATABASE CHARACTER SET utf8mb4;


CREATE TABLE `Locacao` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `preco` decimal(18,2) NOT NULL,
    `esta_locado` bit(1) NOT NULL,
    `registration_date` datetime NOT NULL,
    CONSTRAINT `PK_Locacao` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;


CREATE TABLE `Endereco` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `cep` char(9) CHARACTER SET utf8mb4 NOT NULL,
    `logradouro` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
    `complemento` varchar(50) CHARACTER SET utf8mb4 NULL,
    `bairro` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
    `localidade` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
    `uf` char(2) CHARACTER SET utf8mb4 NOT NULL,
    `ibge` char(7) CHARACTER SET utf8mb4 NOT NULL,
    `gia` char(4) CHARACTER SET utf8mb4 NULL,
    `ddd` char(2) CHARACTER SET utf8mb4 NOT NULL,
    `siafi` char(4) CHARACTER SET utf8mb4 NOT NULL,
    `LocacaoId` int NOT NULL,
    `registration_date` datetime NOT NULL,
    CONSTRAINT `PK_Endereco` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Endereco_Locacao_LocacaoId` FOREIGN KEY (`LocacaoId`) REFERENCES `Locacao` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;


CREATE UNIQUE INDEX `IX_Endereco_LocacaoId` ON `Endereco` (`LocacaoId`);


