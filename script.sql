CREATE DATABASE [itCollage]
GO

USE [itCollage]
GO

/************/

CREATE TABLE [dbo].[roles] (
[RoleID] INT NOT NULL PRIMARY KEY, 
[RoleName] nvarchar(40) NOT NULL 
);

/************/


CREATE TABLE [dbo].[departments](
	[department_id] [nvarchar](50)  PRIMARY KEY,
	[department_name] [nvarchar](50) NULL,
);
GO

/************/

CREATE TABLE [dbo].[instructors](
	[instructor_id] [nvarchar](50)  PRIMARY KEY,
	[instructor_name] [nvarchar](50) NULL,
	[department_id] [nvarchar](50)  NOT NULL,
	FOREIGN KEY (department_id) REFERENCES departments(department_id)
);
GO

/************/

CREATE TABLE [dbo].[users](
	[userID] [nvarchar](50)  PRIMARY KEY,
	[full_name] [nvarchar](50) NULL,
	[BirthDate] date NULL,
	[contact_no] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[department_id] [nvarchar](50) NULL,
	[GPA] [nvarchar](50) NULL,
	[student_info] [nvarchar](max) NULL,
	[account_status] [nvarchar](50) NULL,
	[RoleID] [int] NOT NULL DEFAULT(222),
	[password] [nvarchar](50) NOT NULL,
	FOREIGN KEY (RoleID) REFERENCES Roles(RoleID),
	FOREIGN KEY (department_id) REFERENCES departments(department_id)
);
GO

/************/

CREATE TABLE [dbo].[materials](
	[material_id] [nchar](10) NOT NULL PRIMARY KEY,
	[material_name] [nvarchar](50) NULL,
	[instructor_id] [nvarchar](50) NULL,
	[department_id] [nvarchar](50) NULL,
	[seats_no] [nchar](10) NULL,
	[reserved_seats] [nchar](10) NULL,
	[available_seats] [nchar](10) NULL,
	[material_info] [nvarchar](max) NULL,
	[material_link] [nvarchar](max) NULL,
	FOREIGN KEY (department_id) REFERENCES departments(department_id),
	FOREIGN KEY (instructor_id) REFERENCES instructors(instructor_id)
);
GO

/************/



CREATE TABLE [dbo].[book_material](
	[userID] [nvarchar](50) NOT NULL,
	[material_id] [nchar](10) NULL,
	[book_date] date NULL,
	FOREIGN KEY (userID) REFERENCES users(userID),
	FOREIGN KEY (material_id) REFERENCES materials(material_id)
    );
GO

/************/

INSERT INTO roles (RoleID, RoleName)
VALUES (111, 'admin');
GO

INSERT INTO roles (RoleID, RoleName)
VALUES (222, 'user');
GO


INSERT INTO departments (department_id, department_name)
VALUES ('d1', N'القسم العام');
GO

INSERT INTO departments (department_id, department_name)
VALUES ('d2', N'علوم حاسوب');
GO

INSERT INTO departments (department_id, department_name)
VALUES ('d3', N'الوسائط المتعددة');
GO

INSERT INTO departments (department_id, department_name)
VALUES ('d4', N'نظم المعلومات');
GO

INSERT INTO departments (department_id, department_name)
VALUES ('d5', N'هندسة البرمجيات');
GO

INSERT INTO departments (department_id, department_name)
VALUES ('d6', N'شبكات');
GO

INSERT INTO departments (department_id, department_name)
VALUES ('d7', N'نظم إنترنت');
GO


INSERT INTO instructors (instructor_id, instructor_name, department_id)
VALUES ('m1', N'فراس', 'd2');
GO

INSERT INTO instructors (instructor_id, instructor_name, department_id)
VALUES ('m2', N'علي', 'd3');
GO

INSERT INTO instructors (instructor_id, instructor_name, department_id)
VALUES ('m3', N'عبد الله', 'd4');
GO

INSERT INTO instructors (instructor_id, instructor_name, department_id)
VALUES ('m4', N'أحمد', 'd5');
GO

INSERT INTO instructors (instructor_id, instructor_name, department_id)
VALUES ('m5', N'أسامة', 'd6');
GO


INSERT INTO users (userID, full_name, RoleID, password)
VALUES ('admin', 'admin', 111, 'admin');
GO
