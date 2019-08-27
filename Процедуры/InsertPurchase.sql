CREATE PROCEDURE InsertPurchase
    @login nvarchar(50),
	@password nvarchar(max),
	@date date,
	@rc nvarchar(10) = '' output
	AS BEGIN
		DECLARE @user_id uniqueidentifier;
		SET @user_id = (SELECT ID FROM USERS WHERE LOGIN = @login and PASSWORD = @password);
		BEGIN
		   SET @rc = (select char((rand()*25 + 65))+char((rand()*25 + 65))+char((rand()*25 + 65))+char((rand()*25 + 65))+char((rand()*25 + 65)));
		   INSERT INTO PURCHASE(USER_ID, DATE, UNIQUE_PASSWORD)
		      VALUES (@user_id, @date, @rc);
		  -- SET @rc = (select left(RAND(),5));
		END
	END;
	exec InsertPurchase @login = 'Nikki', @password = 1111, @date = '3.12.2018';

SELECT * FROM PURCHASE
DELETE PURCHASE;
DROP PROCEDURE InsertPurchase;
