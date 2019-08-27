CREATE PROCEDURE InsertHall
    @name nvarchar(30),
	@cinema nvarchar(30),
	@rows tinyint,
	@seats tinyint,
	@rc int output
	AS BEGIN
	    SET @rc = 0;
		DECLARE  @cinema_id int;
		SET @cinema_id = (SELECT ID FROM CINEMA WHERE NAME = @cinema);
		BEGIN
		    INSERT INTO HALL(NAME, CINEMA_ID, ROWS, SEATS)
			    VALUES (@name, @cinema_id, @rows, @seats);
			SET @rc = 1;
		END
	END;
	select * from HALL;
DROP PROCEDURE InsertHall;