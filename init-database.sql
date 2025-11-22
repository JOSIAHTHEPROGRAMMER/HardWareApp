USE [${DB_NAME}];
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

INSERT INTO Categories (CategoryName, CategoryDescription)
VALUES 
('Tools', 'Hand and power tools'),
('Paint', 'Interior and exterior paints'),
('Electrical', 'Wiring, sockets, lighting supplies');
GO

INSERT INTO Items (ItemName, CategoryId, Price, StockQuantity, ItemDescription)
VALUES 
('Hammer', 1, 15.99, 50, '16 oz claw hammer'),
('Screwdriver Set', 1, 25.49, 30, 'Set of 6 screwdrivers'),
('Interior Paint - White', 2, 29.99, 100, '1 gallon of white interior paint'),
('LED Light Bulb', 3, 5.99, 200, '10W LED light bulb');
GO

INSERT INTO Customers (CustomerName, Phone, Gender)
VALUES 
('John Doe', '555-1234', 'Male'),
('Jane Smith', '555-5678', 'Female');
GO

INSERT INTO Billings (CustomerId, TotalAmount, PaymentMethod)
VALUES 
(1, 45.48, 'Credit Card'),
(2, 35.98, 'Cash');
GO
