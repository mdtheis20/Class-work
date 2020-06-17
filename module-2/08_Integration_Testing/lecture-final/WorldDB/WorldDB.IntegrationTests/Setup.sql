-- Start a transaction
--Begin transaction

-- Remove data from the db
	delete from countrylanguage
	update country set capital = null
	Delete from city
	delete from country
	
-- Insert some test countries
Insert into country (code, name, continent, region, surfacearea, indepyear, population, lifeexpectancy, gnp, gnpold, localname, governmentform, headofstate, capital, code2)
	Values ('USA', 'United States', 'North America', 'Region', 100, 1776, 1000, 80, 5000, 4500, 'Merica', 'You tell me', 'Zoran', null, 'US')
Insert into country (code, name, continent, region, surfacearea, indepyear, population, lifeexpectancy, gnp, gnpold, localname, governmentform, headofstate, capital, code2)
	Values ('ZZZ', 'ZZZ Land', 'North America', 'Region', 100, 1776, 1000, 80, 5000, 4500, 'Nu Z-land', 'You tell me', 'Zoran', null, 'ZZ')

-- Insert some test cities
Insert into city (name, countrycode, district, population)
	Values ('Candyland', 'USA', 'Iowa', 100)

Declare @candylandId int
Select @candylandId = @@IDENTITY

Update Country
	Set capital = @candylandId
	where code = 'USA'

Insert into city (name, countrycode, district, population)
	Values ('Utopia', 'USA', 'Iowa', 30)
Declare @utopia int
Select @utopia = @@identity

-- Insert some country/languages
Insert countrylanguage (countrycode, language, isofficial, percentage)
	Values ('USA', 'Pig Latin', 1, 100.0)


-- For now, run some queries to show our test datsa
--select * from city
--select * from country
--select * from countrylanguage

-- Return some data to the caller to be used during tresting
Select @candylandId As CandyLandId, @utopia as UtopiaId

-- Rollback transaction
--Rollback transaction

