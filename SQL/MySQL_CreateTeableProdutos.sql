CREATE TABLE `produto` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nome` text,
  `Preco` decimal(10,0) DEFAULT NULL,
  `DataFabricacao` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

