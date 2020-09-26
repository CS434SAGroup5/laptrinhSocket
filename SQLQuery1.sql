CREATE DATABASE QuanLiQuanCafe
GO

USE QuanLiQuanCafe
GO


CREATE TABLE TableFood
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Bàn chưa có tên',
	status NVARCHAR(100) NOT NULL DEFAULT N'Trống'	
)
GO

CREATE TABLE Account
(
	UserName NVARCHAR(100) PRIMARY KEY,	
	DisplayName NVARCHAR(100) NOT NULL ,
	PassWord NVARCHAR(1000) NOT NULL DEFAULT 0,
	Type INT NOT NULL  DEFAULT 0 
)
GO

CREATE TABLE FoodCategory
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên'
)
GO

CREATE TABLE Food
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	idCategory INT NOT NULL,
	price FLOAT NOT NULL DEFAULT 0
	
	FOREIGN KEY (idCategory) REFERENCES dbo.FoodCategory(id)
)
GO

CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	DateCheckOut DATE,
	idTable INT NOT NULL,
	status INT NOT NULL DEFAULT 0 
	
	FOREIGN KEY (idTable) REFERENCES dbo.TableFood(id)
)
GO

CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idFood INT NOT NULL,
	count INT NOT NULL DEFAULT 0
	
	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idFood) REFERENCES dbo.Food(id)
)
GO

INSERT INTO dbo.Account
        ( UserName ,
          DisplayName ,
          PassWord ,
          Type
        )
VALUES  ( N'admin' , -- UserName - nvarchar(100)
          N'admin' , -- DisplayName - nvarchar(100)
          N'1' , -- PassWord - nvarchar(1000)
          1  -- Type - int
        )


CREATE PROC USP_GetAccountByUserName
@userName nvarchar(100)
AS 
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName
END
GO



CREATE PROC USP_Login
@userName nvarchar(100), @passWord nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName AND PassWord = @passWord
END
GO

-- thêm bàn
DECLARE @i INT = 0

WHILE @i <= 10
BEGIN
	INSERT dbo.TableFood ( name)VALUES  ( N'Bàn' + CAST(@i AS nvarchar(100)))
	SET @i = @i + 1
END
GO

CREATE PROC USP_GetTableList
AS SELECT * FROM dbo.TableFood
GO


INSERT dbo.FoodCategory(name)
VALUES (N'Trà-Cafe')

INSERT dbo.FoodCategory(name)
VALUES (N'Kem-Sữa chua')

INSERT dbo.FoodCategory(name)
VALUES (N'Sinh tố')

INSERT dbo.FoodCategory(name)
VALUES (N'Nước ép trái cây')

INSERT dbo.FoodCategory(name)
VALUES (N'Smothies')

INSERT dbo.FoodCategory(name)
VALUES (N'Bia-Coke')

INSERT dbo.Food(name,idCategory,price)
VALUES (N'Cà phê đen',1,20000)

INSERT dbo.Food(name,idCategory,price)
VALUES (N'Cà phê nâu',1,20000)

INSERT dbo.Food(name,idCategory,price)
VALUES (N'Cacao',1,20000) 

INSERT dbo.Food(name,idCategory,price)
VALUES (N'Trà Lipton',1,18000)

INSERT dbo.Food(name,idCategory,price)
VALUES (N'Kem ly',2,30000)

INSERT dbo.Food(name,idCategory,price)
VALUES (N'Sữa ngô',2,15000)

INSERT dbo.Food(name,idCategory,price)
VALUES (N'Sinh tố xoài',3,25000)

INSERT dbo.Food(name,idCategory,price)
VALUES (N'Sinh tố dưa hấu',3,25000)

INSERT dbo.Food(name,idCategory,price)
VALUES (N'Nước ép táo',4,29000)

INSERT dbo.Food(name,idCategory,price)
VALUES (N'Nước ép cà rốt',4,29000)

INSERT dbo.Food(name,idCategory,price)
VALUES (N'Smothies Special(Cam-Cà rốt-Dứa)',5,30000)

INSERT dbo.Food(name,idCategory,price)
VALUES (N'Smothies 1(Cam-Cà rốt-Táo)',5,30000)	

INSERT dbo.Food(name,idCategory,price)
VALUES (N'Pepsi',6,15000)

INSERT dbo.Food(name,idCategory,price)
VALUES (N'Coca kem ',6,20000)

--thêm bill
INSERT dbo.Bill
		( DateCheckIn,
		DateCheckOut,
		idTable,
		status
		)
VALUES (GETDATE(),
		NULL,
		1,
		0
		)

INSERT dbo.Bill
		( DateCheckIn,
		DateCheckOut,
		idTable,
		status
		)
VALUES (GETDATE(),
		NULL,
		3,
		0
		)

INSERT dbo.Bill
		( DateCheckIn,
		DateCheckOut,
		idTable,
		status
		)
VALUES (GETDATE(),
		GETDATE(),
		2,
		1
		)

INSERT dbo.Bill
		( DateCheckIn,
		DateCheckOut,
		idTable,
		status
		)
VALUES (GETDATE(),
		NULL,
		5,
		0
		)

--thêm billinfo
INSERT dbo.BillInfo(idBill,idFood,count)
VALUES (1,1,2)

INSERT dbo.BillInfo(idBill,idFood,count)
VALUES (1,3,4)

INSERT dbo.BillInfo(idBill,idFood,count)
VALUES (2,5,1)

INSERT dbo.BillInfo(idBill,idFood,count)
VALUES (2,2,2)

INSERT dbo.BillInfo(idBill,idFood,count)
VALUES (3,6,2)

INSERT dbo.BillInfo(idBill,idFood,count)
VALUES (3,5,2)

INSERT dbo.BillInfo(idBill,idFood,count)
VALUES (4,5,2)
GO

CREATE PROC USP_InsertBill
@idTable INT
AS 
BEGIN
	INSERT dbo.Bill(DateCheckIn ,
					DateCheckOut ,
					idTable ,
					status,
					discount)
	VALUES (GETDATE() ,
			NULL, 
			@idTable ,
			0,
			0)
END
GO


CREATE PROC USP_InsertBillInfo
@idBill INT , @idFood INT , @count INT
AS	
BEGIN
	DECLARE @isExitsBillInfo INT 
	DECLARE @countFood INT = 1

	SELECT @isExitsBillInfo = id , @countFood = b.count
	FROM dbo.BillInfo AS b
	WHERE idBill = @idBill AND idFood = @idFood

	IF(@isExitsBillInfo > 0)
	BEGIN
		DECLARE @newCount INT = @countFood + @count
		IF(@newCount > 0)
			UPDATE dbo.BillInfo SET count = @countFood + @count WHERE idFood = @idFood
		ELSE
			DELETE dbo.BillInfo WHERE idBill =@idBill AND idFood = @idFood
	END
	ELSE 
		BEGIN
			INSERT dbo.BillInfo(idBill , idFood , count )
			VALUES(@idBill , @idFood , @count )
		END
END
GO

CREATE TRIGGER UTG_UpdateBillInfo
ON dbo.BillInfo FOR INSERT , UPDATE
AS
BEGIN
	DECLARE @idBill INT
	SELECT @idBill = idBill FROM inserted
	DECLARE @idTable INT
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill AND status = 0
	UPDATE dbo.TableFood SET status = N'Có người' WHERE id = @idTable
END
GO	

CREATE TRIGGER UTG_UpdateBill	
ON dbo.Bill FOR UPDATE
AS
BEGIN 
	DECLARE @idBill INT
	
	SELECT @idBill = id FROM Inserted	
	
	DECLARE @idTable INT
	
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill
	
	DECLARE @count int = 0
	
	SELECT @count = COUNT(*) FROM dbo.Bill WHERE idTable = @idTable AND status = 0
	
	IF (@count = 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable
END
GO

 ALTER TABLE dbo.Bill

 ADD discount INT

 UPDATE dbo.Bill SET discount = 0
 GO

 ALTER TABLE dbo.Bill ADD totalPrice FLOAT
 GO

 CREATE PROC USP_GetListBillDate
 @checkIn DATE , @checkOut DATE
 AS
 BEGIN
	SELECT t.name AS [Tên bàn] , b.totalPrice AS [Tổng tiền], DateCheckIn AS [Ngày vào], DateCheckOut AS [Ngày ra],discount AS [Giảm giá]
	FROM dbo.Bill AS b , dbo.TableFood AS t
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1
	AND t.id = b.idTable
END
GO




CREATE PROC USP_UpdateAccount
@userName NVARCHAR(100),@displayName NVARCHAR(100),@passWord NVARCHAR(100),@newPassWord NVARCHAR(100)
AS
BEGIN 
	DECLARE @isRightPass INT = 0
	SELECT @isRightPass = COUNT(*) FROM dbo.Account WHERE UserName = @userName AND PassWord =@passWord
	IF(@isRightPass = 1)
	BEGIN
		IF(@newPassWord = NULL OR @newPassWord = '')
		BEGIN
			UPDATE dbo.Account SET DisplayName = @displayName WHERE UserName = @userName
		END
		ELSE 
			UPDATE dbo.Account SET DisplayName = @displayName , PassWord =@newPassWord WHERE UserName = @userName
	END
END
GO

CREATE TRIGGER UTG_DeleteBillInfo
ON dbo.BillInfo FOR DELETE
AS
BEGIN
	DECLARE @idBillInfo INT
	DECLARE @idBill INT 
	SELECT  @idBillInfo = id , @idBill = deleted.idBill FROM deleted

	DECLARE @idTable INT
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill

	DECLARE @count INT = 0
	SELECT @count = COUNT(*) FROM dbo.BillInfo , dbo.Bill WHERE Bill.id = BillInfo.id AND Bill.id = @idBill AND Bill.status = 0
	IF(@count = 0 )
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable
END
GO
