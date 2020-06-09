-- ORDERING RESULTS

-- Populations of all countries in descending order
select population
from country
order by population desc


--Names of countries and continents in ascending order
select name, continent
from country
order by name
-- LIMITING RESULTS
-- The name and average life expectancy of the countries with the 10 highest life expectancies.
select top 10 name, lifeexpectancy
	from country
		order by lifeexpectancy desc
-- CONCATENATING OUTPUTS


-- The name & state of all cities in California, Oregon, or Washington.
-- "city, state", sorted by state then city

select CONCAT(name, ', ', district) CityState
	from city
	where district in ('california', 'oregon', 'washington') 
	order by district, name


-- Can you do it another way?

select name + ', ' + district As CityState
	from city
	where district = 'washington' or district = 'oregon' or district = 'california'
	order by district, name


-- AGGREGATE FUNCTIONS
-- Average Life Expectancy in the World
select avg(lifeexpectancy)
	from country

	select round(avg(lifeexpectancy), 0) from country --just to show you that you can do this
-- Total population in Ohio
select sum(population)
	from city
	where district = 'Ohio' -- could be more specific with country code usa incase there is another ohio district

	select count(*)
	from city
	where district = 'ohio'

select sum(population), count(*)
	from city
	where district = 'ohio'

-- The surface area of the smallest country in the world
select Min(surfacearea)
	from country

--How to get the name as well?
select top 1 name, surfacearea
	from country
	Order by surfacearea asc
-- The 10 largest countries in the world
select top 10 name, surfacearea	
	from country
	order by surfacearea Desc
-- The number of countries who declared independence in 1991
select count(*)
	from country
	where indepyear = 1991

-- GROUP BY
-- Count the number of countries where each language is spoken, ordered from most countries to least
select * from country language

select language, Count(*)
	from countrylanguage
	group by language
	order by 2 Desc
-- Average life expectancy of each continent ordered from highest to lowest
select continent, Avg(lifeexpectancy) as LE
	from country
	group by continent
	order by LE desc

-- Exclude Antarctica from consideration for average life expectancy
select continent, Avg(lifeexpectancy) as LE
	from country
	where lifeexpectancy is not null
	group by continent
	order by LE desc
-- Sum of the population of cities in each state in the USA ordered by state name
select district, sum(population)
	from city
	where countrycode = 'usa'
	group by district
	order by district 
-- The average population of cities in each state in the USA ordered by state name
select district, avg(population)
	from city
	where countrycode = 'usa'
	group by district
	order by district 
-- The average populat

-- SUBQUERIES
-- Find the names of cities under a given government leader
Select name
	from city
	
-- Find the names of cities whose country they belong to has not declared independence yet
Select name	
	from city
	where countrycode in (

Select code from country where indepyear is null)

-- Select those countries with lower than average life expectancy 

select avg(lifeexpectancy) from country 

select *
	from country
	where lifeexpectancy <(select avg(lifeexpectancy) from country)

-- Additional samples
-- You may alias column and table names to be more descriptive

-- Alias can also be used to create shorthand references, such as "c" for city and "co" for country.

-- Ordering allows columns to be displayed in ascending order, or descending order (Look at Arlington)

-- While you can use TOP to limit the number of results returned by a query,
-- in SQL Server it is recommended to use OFFSET and FETCH if you want to get
-- "pages" of results. For instance, to get the first 10 rows in the city table
-- ordered by the name, you could use the following query.
-- (Skip 0 rows, and return only the first 10 rows from the sorted result set.)

-- Most database platforms provide string functions that can be useful for working with string data. In addition to string functions, string concatenation is also usually supported, which allows us to build complete sentences if necessary.

-- Aggregate functions provide the ability to COUNT, SUM, and AVG, as well as determine MIN and MAX. Only returns a single row of value(s) unless used with GROUP BY.
-- Counts the number of rows in the city table

-- Also counts the number of rows in the city table

-- Gets the SUM of the population field in the city table, as well as
-- the AVG population, and a COUNT of the total number of rows.

-- Gets the MIN population and the MAX population from the city table.

-- Using a GROUP BY with aggregate functions allows us to summarize information for a specific column. For instance, we are able to determine the MIN and MAX population for each countrycode in the city table.
