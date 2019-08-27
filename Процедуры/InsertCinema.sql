CREATE PROCEDURE InsertCinema
    @name nvarchar(30),
	@address nvarchar(max),
	@website nvarchar(max),
	@region nvarchar(30),
	@halls int,
	@ticketoffice nvarchar(30),
	@rc int output
	AS BEGIN
	    SET @rc = 0;
		BEGIN
		    INSERT INTO CINEMA (NAME, ADDRESS, WEBSITE, REGION, NUMBER_OF_HALLS, TICKET_OFFICE)
			    VALUES (@name, @address, @website, @region, @halls, @ticketoffice);
			SET @rc = 1;
		END
	END;

DROP PROCEDURE InsertCinema;
select * from CINEMA;
exec InsertCinema @name = 'Центральный', @address = 'г.Минск, пр-т Независимости, 13', @website = 'https://vk.com/kino_centralny', @region = 'Центральный', @halls = 1,@ticketoffice = 'ПН-ВС с 11.30 до 21.30', @rc = 1;
