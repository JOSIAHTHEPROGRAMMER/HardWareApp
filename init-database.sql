-- Create database
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'HardwareDB')
BEGIN
    CREATE DATABASE HardwareDB;
END
GO

USE HardwareDB;
GO


CREATE TABLE Categories (
    CategoryId INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL,
    CategoryDescription NVARCHAR(255) NOT NULL
);
GO

CREATE TABLE Items (
    ItemId INT IDENTITY(1,1) PRIMARY KEY,
    ItemName NVARCHAR(100) NOT NULL,
    CategoryId INT FOREIGN KEY REFERENCES Categories(CategoryId),
    Price DECIMAL(10,2) NOT NULL,
    StockQuantity INT NOT NULL,
    ItemDescription NVARCHAR(255) NOT NULL
);
GO

CREATE TABLE Customers (
    CustomerId INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20),
    Gender NVARCHAR(10)
);
GO

CREATE TABLE Billings (
    BillingId INT IDENTITY(1,1) PRIMARY KEY,
    CustomerId INT FOREIGN KEY REFERENCES Customers(CustomerId),
    BillingDate DATETIME NOT NULL DEFAULT GETDATE(),
    TotalAmount DECIMAL(10,2) NOT NULL,
    PaymentMethod NVARCHAR(50) NOT NULL
);
GO

-- Optional seed data
INSERT INTO Categories (CategoryName, CategoryDescription)
VALUES 
('Tools', 'Hand and power tools for general use'),
('Paint', 'Interior and exterior paints'),
('Electrical', 'Wiring, sockets, and lighting supplies');
GO
