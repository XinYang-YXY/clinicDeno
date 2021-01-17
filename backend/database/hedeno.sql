/* Patient */
CREATE TABLE `heDeno`.`Patient` (
  `id` INT NOT NULL,
  `secretId` VARCHAR(100) NOT NULL,
  `email` VARCHAR(100) NOT NULL,
  `phoneNum` VARCHAR(45) NOT NULL,
  `firstName` VARCHAR(45) NOT NULL,
  `lastName` VARCHAR(45) NOT NULL,
  `dob` DATE NOT NULL,
  `gender` VARCHAR(45) NOT NULL,
  `password` VARCHAR(1000) NOT NULL,
  PRIMARY KEY (`id`));

/* Clinic */
CREATE TABLE `heDeno`.`Clinic` (
  `id` INT NOT NULL,
  `address` VARCHAR(1000) NOT NULL,
  `phoneNum` VARCHAR(100) NOT NULL,
  `email` VARCHAR(100) NOT NULL,
  `clinicName` VARCHAR(100) NOT NULL,
  `clinicType` VARCHAR(100) NOT NULL,
  `operatingHours` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`id`));
               
/* === Column Changes By XinYang === */               
ALTER TABLE `heDeno`.`Clinic` 
DROP COLUMN `operatingHours`,
ADD COLUMN `startTime` TIME NOT NULL AFTER `clinicType`,
ADD COLUMN `endTime` TIME NOT NULL AFTER `startTime`;
               
/* Doctor */
CREATE TABLE `heDeno`.`Doctor` (
  `id` INT NOT NULL,
  `email` VARCHAR(100) NOT NULL,
  `phoneNum` VARCHAR(100) NOT NULL,
  `firstName` VARCHAR(100) NOT NULL,
  `lastName` VARCHAR(100) NOT NULL,
  `dob` DATE NOT NULL,
  `gender` VARCHAR(45) NOT NULL,
  `signature` VARCHAR(1000) NOT NULL,
  `password` VARCHAR(1000) NOT NULL,
  `clientId` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Doctor_1_idx` (`clientId` ASC) VISIBLE,
  CONSTRAINT `fk_Doctor_1`
    FOREIGN KEY (`clientId`)
    REFERENCES `heDeno`.`Clinic` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


/* Clinic Admin */
CREATE TABLE `heDeno`.`ClinicAdmin` (
  `id` INT NOT NULL,
  `email` VARCHAR(100) NOT NULL,
  `phoneNum` VARCHAR(100) NOT NULL,
  `firstName` VARCHAR(45) NOT NULL,
  `lastName` VARCHAR(45) NOT NULL,
  `dob` DATE NOT NULL,
  `gender` VARCHAR(45) NOT NULL,
  `password` VARCHAR(1000) NOT NULL,
  `clinicId` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_ClinicAdmin_1_idx` (`clinicId` ASC) VISIBLE,
  CONSTRAINT `fk_ClinicAdmin_1`
    FOREIGN KEY (`clinicId`)
    REFERENCES `heDeno`.`Clinic` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


/* Appointment */
CREATE TABLE `heDeno`.`Appointment` (
  `id` INT NOT NULL,
  `startDateTime` DATETIME NOT NULL,
  `endDateTime` DATETIME NOT NULL,
  `doctorId` INT NOT NULL,
  `patientId` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Appointment_1_idx` (`doctorId` ASC) VISIBLE,
  INDEX `fk_Appointment_2_idx` (`patientId` ASC) VISIBLE,
  CONSTRAINT `fk_Appointment_1`
    FOREIGN KEY (`doctorId`)
    REFERENCES `heDeno`.`Doctor` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Appointment_2`
    FOREIGN KEY (`patientId`)
    REFERENCES `heDeno`.`Patient` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

/* Medical Record */
CREATE TABLE `heDeno`.`MedicalRecord` (
  `id` INT NOT NULL,
  `date` DATE NOT NULL,
  `mc` VARCHAR(100) NOT NULL,
  `medicalInstruction` VARCHAR(2000) NOT NULL,
  `doctorComment` VARCHAR(2000) NOT NULL,
  `doctorId` INT NOT NULL,
  `clinicId` INT NOT NULL,
  `patientId` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_MedicalRecord_1_idx` (`doctorId` ASC) VISIBLE,
  INDEX `fk_MedicalRecord_2_idx` (`clinicId` ASC) VISIBLE,
  INDEX `fk_MedicalRecord_3_idx` (`patientId` ASC) VISIBLE,
  CONSTRAINT `fk_MedicalRecord_1`
    FOREIGN KEY (`doctorId`)
    REFERENCES `heDeno`.`Doctor` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_MedicalRecord_2`
    FOREIGN KEY (`clinicId`)
    REFERENCES `heDeno`.`Clinic` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_MedicalRecord_3`
    FOREIGN KEY (`patientId`)
    REFERENCES `heDeno`.`Patient` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


