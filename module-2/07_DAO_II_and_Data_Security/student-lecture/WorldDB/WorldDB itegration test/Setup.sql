--start a transaction
--Begin transaction
--remove data from db

delete from countrylanguage
update country set capital = null
Delete from city
Delete from country


-- Instert some test countries
Insert into country (code,name,continent,region,surfacearea,indepyear,population,lifeexpectancy,gnp,gnpold,localname,governmentform,headofstate,capital,code2)
	Values('USA', 'United States', 'North America', 'Region', 100, 1776, 1000, 80, 5000, 4500, 'America', 'You tell me', 'Zoran', null, 'US')
Insert into country (code,name,continent,region,surfacearea,indepyear,population,lifeexpectancy,gnp,gnpold,localname,governmentform,headofstate,capital,code2)
	Values('ZZZ', 'ZZZ Land', 'North America', 'Region', 100, 1776, 1000, 80, 5000, 4500, 'America', 'You tell me', 'Zoran', null, 'ZZ')
--Insert some test cities



--Insert some test cities
Insert into city(name, countrycode,district,population)
	values ('Candyland', 'USA', 'Iowa', 100)

Declare @candylandId int
select @candylandId = @@IDentity 
UPdate	country	
	set capital = @candylandId
	Where code = 'USA'

Insert into city(name, countrycode,district,population)
	values ('Utopia', 'USA', 'Iowa', 30)

--Insert some countrylanguages

Insert into countrylanguage(countrycode, language, isofficial, percentage)
	Values ('USA', 'Pig Latin', 1, 100.0)



--for now, run some queries to show our test data
select * from city
select * from country
select * from countrylanguage

--rollback transaction
--Rollback transaction