-- SELECT ... FROM
-- Selecting the names for all countries

/*
This is a 
multi-line
comment
*/

SELECT name 
	FROM country;

-- Selecting the name and population of all countries
Select name, population
	From country


-- Selecting all columns from the city table
select * from city

-- SELECT ... FROM ... WHERE
-- Selecting the cities in Ohio
Select * 
	From city
	Where district = 'ohio'


-- Selecting countries that gained independence in the year 1776
Select * 
	from country
	where indepyear = 1776

-- Selecting countries that gained independence since the year 1776
Select * 
	from country
	where indepyear >= 1776

-- Selecting countries that gained independence between the years 1776 and 1800
Select * 
	from country
	where indepyear between 1776 and 1811

-- Selecting countries not in Asia
select name, continent
	From country
	where continent != 'Asia'


-- Selecting countries that do not have an independence year
select *
	from country
	where indepyear is null

-- Selecting countries that do have an independence year
select *
	from country
	where indepyear is not null


-- Selecting countries that have a population greater than 5 million
select *
	from country
	where population > 5000000


-- SELECT ... FROM ... WHERE ... AND/OR
-- Selecting cities in Ohio and Population greater than 400,000
select * from city
	where district = 'Ohio'
	And population > 400000

-- Selecting country names on the continent North America or South America
Select * 
	from country
	where continent = 'North America' Or continent = 'South America'

Select *
	from country
	Where continent Like '%America'

select * 
	from country
	where continent in ('North america', 'South America', 'Europe')


-- SELECTING DATA w/arithmetic
-- Selecting the population, life expectancy, and population per area
--	note the use of the 'as' keyword
Select name, population, lifeexpectancy As 'Life Expectancy', surfacearea, population / surfacearea As 'Population Density'
	From country


