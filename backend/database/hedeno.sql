/* Patient */
CREATE TABLE `heDeno`.`Patient` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `secretId` VARCHAR(100) NOT NULL,
  `email` VARCHAR(100) NOT NULL UNIQUE,
  `isEmailVerified` TINYINT NOT NULL DEFAULT 0,
  `phoneNum` VARCHAR(45) NOT NULL,
  `firstName` VARCHAR(45) NOT NULL,
  `lastName` VARCHAR(45) NOT NULL,
  `dob` DATE NOT NULL,
  `gender` VARCHAR(45) NOT NULL,
  `password` VARCHAR(1000) NOT NULL,
  PRIMARY KEY (`id`));
/* === Column Changes By XinYang === */  
  ALTER TABLE `heDeno`.`Patient` 
ADD COLUMN `NRIC` VARCHAR(45) NOT NULL AFTER `password`;


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
/* === Column Changes By XinYang === */                  
ALTER TABLE `heDeno`.`Clinic` 
ADD UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE;
;
/* === Column Changes By XinYang === */                 
SET FOREIGN_KEY_CHECKS=0;
ALTER TABLE `heDeno`.`Clinic` 
CHANGE COLUMN `id` `id` INT(11) NOT NULL AUTO_INCREMENT ;
SET FOREIGN_KEY_CHECKS=1;
          
               
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
/* === Column Changes By XinYang === */                
SET FOREIGN_KEY_CHECKS=0;
ALTER TABLE `heDeno`.`ClinicAdmin` 
CHANGE COLUMN `id` `id` INT(11) NOT NULL AUTO_INCREMENT ;
SET FOREIGN_KEY_CHECKS=1; 

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
/* === Column Changes By XinYang === */   
SET FOREIGN_KEY_CHECKS=0;
ALTER TABLE `heDeno`.`ClinicAdmin` 
CHANGE COLUMN `id` `id` INT(11) NOT NULL AUTO_INCREMENT ;
SET FOREIGN_KEY_CHECKS=1; 
/* === Column Changes By XinYang === */  
ALTER TABLE `heDeno`.`ClinicAdmin` 
ADD COLUMN `verified` VARCHAR(45) NULL DEFAULT 0 AFTER `clinicId`; 
/* === Column Changes By XinYang === */  
ALTER TABLE `heDeno`.`ClinicAdmin` 
ADD COLUMN `verificationId` VARCHAR(1000) NULL AFTER `verified`;


/* === New Medical Certificate Table By Qihan === */
CREATE TABLE `heDeno`.`MC` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `startDate` DATE NOT NULL,
  `endDate` DATE NOT NULL,
  `comments` VARCHAR(1000),
  `doctorId` INT NOT NULL,
  `doctorSignature` VARCHAR(1000) NOT NULL,
  `patientId` INT NOT NULL,
  `appointmentId` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_MC_1_idx` (`doctorId` ASC) VISIBLE,
  INDEX `fk_MC_2_idx` (`patientId` ASC) VISIBLE,
  CONSTRAINT `fk_MC_1`
    FOREIGN KEY (`doctorId`)
    REFERENCES `heDeno`.`Doctor` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_MC_2`
    FOREIGN KEY (`patientId`)
    REFERENCES `heDeno`.`Patient` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


/* === New Medical Instruction Table By Qihan === */
CREATE TABLE `heDeno`.`medicalInstruct` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `date` DATE NOT NULL,
  `prescription` VARCHAR(100) NOT NULL,
  `instruction` VARCHAR(100) NOT NULL,
  `quantity` VARCHAR(100) NOT NULL,
  `refills` VARCHAR(100) NOT NULL,
  `doctorId` INT NOT NULL,
  `patientId` INT NOT NULL,
  `appointmentId` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_medicalInstruct_1_idx` (`doctorId` ASC) VISIBLE,
  INDEX `fk_medicalInstruct_2_idx` (`patientId` ASC) VISIBLE,
  CONSTRAINT `fk_medicalInstruct_1`
    FOREIGN KEY (`doctorId`)
    REFERENCES `heDeno`.`Doctor` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_medicalInstruct_2`
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
/* === Column Changes By Qihan === */
ALTER TABLE `hedeno`.`MedicalRecord`
CHANGE COLUMN `id` `id` INT NOT NULL AUTO_INCREMENT;
ALTER TABLE `hedeno`.`MedicalRecord`
DROP COLUMN `mc`;
ALTER TABLE `hedeno`.`MedicalRecord`
DROP COLUMN `medicalInstruction`;
ALTER TABLE `hedeno`.`MedicalRecord`
DROP COLUMN `doctorComment`;
ALTER TABLE `hedeno`.`MedicalRecord`
ADD `allergies` VARCHAR(2000);
ALTER TABLE `hedeno`.`MedicalRecord`
ADD `familyMedicalHistory` VARCHAR(2000);
ALTER TABLE `hedeno`.`MedicalRecord`
ADD `currentMedications` VARCHAR(2000);
ALTER TABLE `hedeno`.`MedicalRecord`
ADD `diagnosis` VARCHAR(2000) NOT NULL;
ALTER TABLE `hedeno`.`MedicalRecord`
ADD `comment` VARCHAR(2000);
ALTER TABLE `hedeno`.`MedicalRecord`
ADD `appointmentId` INT NOT NULL;
    
    
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
/* === Column Changes By FangJun === */
ALTER TABLE `heDeno`.`appointment` 
CHANGE COLUMN `id` `id` INT NOT NULL AUTO_INCREMENT ;
/* === Column Changes By FangJun === */
ALTER TABLE `heDeno`.`appointment` 
DROP COLUMN `endDateTime`;
/* === Column Changes By FangJun === */
ALTER TABLE `heDeno`.`appointment` 
ADD COLUMN `time` TIME NOT NULL AFTER `date`,
CHANGE COLUMN `startDateTime` `date` VARCHAR(45) NOT NULL ;
ALTER TABLE `heDeno`.`Appointment` 
ADD COLUMN `status` VARCHAR(45) NOT NULL AFTER `patientId`;
/* === Column Changes By XinYang === */
ALTER TABLE `heDeno`.`Appointment` 
ADD COLUMN `status` VARCHAR(45) NOT NULL AFTER `patientId`;
ALTER TABLE `heDeno`.`Appointment` 
CHANGE COLUMN `status` `status` VARCHAR(45) NOT NULL DEFAULT 0 ;
/* === Column Changes By Qihan === */
ALTER TABLE `hedeno`.`appointment`
ADD `MCId` INT;
ALTER TABLE `hedeno`.`appointment`
ADD `medicalRecordId` INT;
ALTER TABLE `hedeno`.`appointment`
ADD `medicalInstructId` INT;
ALTER TABLE `hedeno`.`appointment`
ADD FOREIGN KEY (`MCId`) REFERENCES `heDeno`.`mc` (`id`);
ALTER TABLE `hedeno`.`appointment`
ADD FOREIGN KEY (`medicalRecordId`) REFERENCES `heDeno`.`medicalrecord` (`id`);
ALTER TABLE `hedeno`.`appointment`
ADD FOREIGN KEY (`medicalInstructId`) REFERENCES `heDeno`.`medicalinstruct` (`id`);


/* === New Specialty Table By Fang Jun === */
CREATE TABLE `heDeno`.`specialty` (
  `specialtyName` VARCHAR(45) NOT NULL,
  `specialtyDesc` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`specialtyName`));
INSERT INTO `heDeno`.`specialty` (`specialtyName`, `specialtyDesc`) VALUES ('Cardiology', 'Heart related');
INSERT INTO `heDeno`.`specialty` (`specialtyName`, `specialtyDesc`) VALUES ('Dermatology', 'Skin related');
INSERT INTO `heDeno`.`specialty` (`specialtyName`, `specialtyDesc`) VALUES ('Endocrinology', '');
INSERT INTO `heDeno`.`specialty` (`specialtyName`, `specialtyDesc`) VALUES ('Diagnostic Radiology', 'MRI');
INSERT INTO `heDeno`.`specialty` (`specialtyName`, `specialtyDesc`) VALUES ('Gastroenterology', 'Digestive system related');
INSERT INTO `heDeno`.`specialty` (`specialtyName`, `specialtyDesc`) VALUES ('General Surgery', 'Abdominal related');
INSERT INTO `heDeno`.`specialty` (`specialtyName`, `specialtyDesc`) VALUES ('Haematology', 'Blood related');
INSERT INTO `heDeno`.`specialty` (`specialtyName`, `specialtyDesc`) VALUES ('Neurology', 'Nervous system related');
INSERT INTO `heDeno`.`specialty` (`specialtyName`, `specialtyDesc`) VALUES ('Ophthalmology', 'Eye related');
INSERT INTO `heDeno`.`specialty` (`specialtyName`, `specialtyDesc`) VALUES ('Pathology', 'Disease related');
INSERT INTO `heDeno`.`specialty` (`specialtyName`, `specialtyDesc`) VALUES ('Plastic Surgery', 'Alteration of human body');
INSERT INTO `heDeno`.`specialty` (`specialtyName`, `specialtyDesc`) VALUES ('Psychiatry', 'Mental related');
INSERT INTO `heDeno`.`specialty` (`specialtyName`, `specialtyDesc`) VALUES ('Rheumatology', 'Bone/Muscle related');
INSERT INTO `heDeno`.`specialty` (`specialtyName`, `specialtyDesc`) VALUES ('Urology', 'Urine related');
/* === Column Changes By FangJun === */
INSERT INTO `hedeno`.`specialty` (`specialtyName`, `specialtyDesc`) VALUES ('General', 'General');
INSERT INTO `hedeno`.`specialty` (`specialtyName`, `specialtyDesc`) VALUES ('Dentist', 'Teeth-related');
