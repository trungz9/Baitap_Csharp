CREATE DATABASE IF NOT EXISTS `QLSV`
	CHARACTER SET utf8mb4
	COLLATE utf8mb4_unicode_ci;

USE `QLSV`;

CREATE TABLE IF NOT EXISTS `class` (
	`Code` VARCHAR(7) NOT NULL,
	`Name` VARCHAR(100) NOT NULL,
	PRIMARY KEY (`Code`),
	CONSTRAINT `CK_class_Code_Format`
		CHECK (`Code` REGEXP '^CSE[0-9]{4}$')
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS `student` (
	`StudentId` VARCHAR(20) NOT NULL,
	`FullName` VARCHAR(100) NOT NULL,
	`Email` VARCHAR(254) NOT NULL DEFAULT '',
	`DateOfBirth` DATE NOT NULL,
	`Phone` VARCHAR(30) NOT NULL DEFAULT '',
	`Score` DECIMAL(4,2) NOT NULL DEFAULT 0,
	`Status` VARCHAR(50) NOT NULL DEFAULT '',
	`ClassCode` VARCHAR(7) NULL,
	PRIMARY KEY (`StudentId`),
	INDEX `IX_student_ClassCode` (`ClassCode`),
	CONSTRAINT `CK_student_Score_Range`
		CHECK (`Score` >= 0 AND `Score` <= 10),
	CONSTRAINT `FK_student_class_ClassCode`
		FOREIGN KEY (`ClassCode`) REFERENCES `class` (`Code`)
		ON UPDATE CASCADE
		ON DELETE SET NULL
) ENGINE=InnoDB;

INSERT IGNORE INTO `class` (`Code`, `Name`) VALUES
	('CSE4001', 'CSE4001 - Software Engineering'),
	('CSE4002', 'CSE4002 - Information Systems'),
	('CSE4003', 'CSE4003 - Computer Science'),
	('CSE4004', 'CSE4004 - Data Science'),
	('CSE4005', 'CSE4005 - Cybersecurity'),
	('CSE4006', 'CSE4006 - Artificial Intelligence'),
	('CSE4007', 'CSE4007 - Network Engineering'),
	('CSE4008', 'CSE4008 - Web Development'),
	('CSE4009', 'CSE4009 - Mobile Development'),
	('CSE4010', 'CSE4010 - Database Systems'),
	('CSE4011', 'CSE4011 - Cloud Computing'),
	('CSE4012', 'CSE4012 - Computer Graphics'),
	('CSE4013', 'CSE4013 - Embedded Systems'),
	('CSE4014', 'CSE4014 - Game Development'),
	('CSE4015', 'CSE4015 - Machine Learning'),
	('CSE4016', 'CSE4016 - Data Engineering'),
	('CSE4017', 'CSE4017 - IT Management'),
	('CSE4018', 'CSE4018 - Software Testing'),
	('CSE4019', 'CSE4019 - Computer Networks'),
	('CSE4020', 'CSE4020 - Human Computer Interaction');

INSERT IGNORE INTO `student`
	(`StudentId`, `FullName`, `Email`, `DateOfBirth`, `Phone`, `Score`, `Status`, `ClassCode`) VALUES
	('TEST1001', 'Nguyen Minh Anh', 'minhanh.nguyen@example.com', '2003-01-15', '0901000001', 8.25, 'Active', 'CSE4001'),
	('TEST1002', 'Tran Bao Chau', 'baochau.tran@example.com', '2002-04-22', '0901000002', 7.50, 'Active', 'CSE4002'),
	('TEST1003', 'Le Duc Huy', 'duchuy.le@example.com', '2003-07-09', '0901000003', 9.00, 'Active', 'CSE4003'),
	('TEST1004', 'Pham Gia Han', 'giahan.pham@example.com', '2002-11-30', '0901000004', 6.75, 'Inactive', 'CSE4004'),
	('TEST1005', 'Hoang Quoc Bao', 'quocbao.hoang@example.com', '2003-02-18', '0901000005', 8.80, 'Active', 'CSE4005'),
	('TEST1006', 'Vo Thanh Tam', 'thanhtam.vo@example.com', '2002-06-03', '0901000006', 7.20, 'Active', 'CSE4006'),
	('TEST1007', 'Dang Phuong Linh', 'phuonglinh.dang@example.com', '2003-09-27', '0901000007', 9.50, 'Active', 'CSE4007'),
	('TEST1008', 'Bui Tuan Kiet', 'tuankiet.bui@example.com', '2002-12-12', '0901000008', 5.90, 'Inactive', 'CSE4008'),
	('TEST1009', 'Do Khanh Ly', 'khanhly.do@example.com', '2003-03-05', '0901000009', 8.10, 'Active', 'CSE4009'),
	('TEST1010', 'Ngo Hoang Nam', 'hoangnam.ngo@example.com', '2002-08-16', '0901000010', 6.40, 'Active', 'CSE4010'),
	('TEST1011', 'Duong Ngoc Mai', 'ngocmai.duong@example.com', '2003-05-21', '0901000011', 9.20, 'Active', 'CSE4011'),
	('TEST1012', 'Ly Minh Quan', 'minhquan.ly@example.com', '2002-10-08', '0901000012', 7.85, 'Inactive', 'CSE4012'),
	('TEST1013', 'Mai Thu Trang', 'thutrang.mai@example.com', '2003-12-01', '0901000013', 8.60, 'Active', 'CSE4013'),
	('TEST1014', 'Truong Anh Tuan', 'anhtuan.truong@example.com', '2002-01-29', '0901000014', 6.95, 'Active', 'CSE4014'),
	('TEST1015', 'Cao Kim Ngan', 'kimngan.cao@example.com', '2003-06-14', '0901000015', 9.75, 'Active', 'CSE4015'),
	('TEST1016', 'Phan Thanh Dat', 'thanhdat.phan@example.com', '2002-09-02', '0901000016', 5.50, 'Inactive', 'CSE4016'),
	('TEST1017', 'Vu Thao Nguyen', 'thaonguyen.vu@example.com', '2003-04-11', '0901000017', 7.95, 'Active', 'CSE4017'),
	('TEST1018', 'Ta Hoai Phuong', 'hoaiphuong.ta@example.com', '2002-07-25', '0901000018', 8.35, 'Active', 'CSE4018'),
	('TEST1019', 'Dinh Gia Minh', 'giaminh.dinh@example.com', '2003-10-19', '0901000019', 6.80, 'Inactive', 'CSE4019'),
	('TEST1020', 'Ha Bao Yen', 'baoyen.ha@example.com', '2002-02-07', '0901000020', 9.10, 'Active', 'CSE4020');
