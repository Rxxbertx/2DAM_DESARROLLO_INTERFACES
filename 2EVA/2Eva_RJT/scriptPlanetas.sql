-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema Exam2Eva_xyz
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `Exam2Eva_xyz` DEFAULT CHARACTER SET utf8mb4 ;
USE `Exam2Eva_xyz` ;

-- -----------------------------------------------------
-- Table `Exam2Eva_xyz`.`TipoPlaneta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Exam2Eva_xyz`.`TipoPlaneta` (
  `idTipoPlaneta` INT AUTO_INCREMENT,
  `NombreTipo` VARCHAR(45) NULL,
  PRIMARY KEY (`idTipoPlaneta`))
ENGINE = InnoDB;
INSERT INTO TipoPlaneta (NombreTipo) VALUES ('Rocoso');
INSERT INTO TipoPlaneta (NombreTipo) VALUES ('Gaseoso');

-- -----------------------------------------------------
-- Table `Exam2Eva_xyz`.`Planetas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Exam2Eva_xyz`.`Planetas` (
  `idPlanetas` INT AUTO_INCREMENT,
  `CodPlaneta` VARCHAR(5) NOT NULL,
  `Nombre` VARCHAR(45) NOT NULL,
  `Numero_de_satelites` INT NULL DEFAULT 0,
  `Factor_gravitacional` FLOAT NULL,
  `Existe_vida` TINYINT NULL DEFAULT 0,
  `TipoPlaneta_idTipoPlaneta` INT NOT NULL,
  PRIMARY KEY (`idPlanetas`),
  INDEX `fk_Planetas_TipoPlaneta_idx` (`TipoPlaneta_idTipoPlaneta` ASC) VISIBLE,
  CONSTRAINT `fk_Planetas_TipoPlaneta`
    FOREIGN KEY (`TipoPlaneta_idTipoPlaneta`)
    REFERENCES `Exam2Eva_xyz`.`TipoPlaneta` (`idTipoPlaneta`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

INSERT INTO Planetas (CodPlaneta, Nombre, Factor_gravitacional, Numero_de_satelites, Existe_vida, TipoPlaneta_idTipoPlaneta) 
VALUES 
('MER','Mercurio', 3.7, 0, 0, 1),
('VEN','Venus', 8.87, 0, 0, 1),
('TIE','Tierra', 9.81, 1, 1, 1),
('MAR','Marte', 3.71, 2, 0, 1),
('JUP','Júpiter', 24.79, 79, 0, 2),
('SAT','Saturno', 10.44, 82, 0, 2),
('URA','Urano', 8.69, 27, 0, 2),
('NEP','Neptuno', 11.15, 14, 0, 2),
('PLU','Plutón', 0.62, 5, 0, 1);

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
