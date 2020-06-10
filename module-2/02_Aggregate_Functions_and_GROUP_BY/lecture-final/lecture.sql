-- ORDERING RESULTS

-- Populations of all countries in descending order
Select name, population
	From country
	Order by population desc



--Names of countries and continents in ascending order
Select name, continent
	From country
	Order By name desc

Select continent, name
	From country
	Order by continent desc, name asc

Select continent, name
	From country
	Order by population desc

Select name, population / surfacearea As PopulationDensity
	from country
	Order by PopulationDensity desc



-- LIMITING RESULTS
-- The name and average life expectancy of the countries with the 10 highest life expectancies.
Select Top 10 name, lifeexpectancy
	From country
	Order by lifeexpectancy desc


-- CONCATENATING OUTPUTS

-- The name & state of all cities in California, Oregon, or Washington.
-- "city, state", sorted by state then city
Select Concat(name, ', ', district) AS CityState
	from city
	Where district in ('California', 'Oregon', 'Washington')
	Order By district, name
	

-- Can you do it another way?
Select name + ', ' + district AS CityState
	From city
	Where district = 'Washington' Or district = 'California' Or district = 'Oregon' 
	Order by district, name

Select Substring(district, 1, 2) 
	from city
	where countrycode = 'USA'

-- SQL Server functions for getting todays date, then getting only the year part of it.
select Year(getdate())


-- AGGREGATE FUNCTIONS
-- Average Life Expectancy in the World
Select AVG(lifeexpectancy) From country
--Select lifeexpectancy from country Where lifeexpectancy is not null

-- Total population of all listed cities in Ohio
Select SUM(population) 
	From city
	where district = 'Ohio'

Select Count(*)
	From city
	where district = 'Ohio'

Select Sum(population) As 'Total Population', Count(*) As 'Number of Cities', Avg(population) As 'Average Population'
	from city
	where district = 'Ohio'


-- The surface area of the smallest country in the world
Select Min(surfacearea)
	From country

-- How to get the name also?
Select Top 1 name, surfacearea
	from country
	Order by surfacearea ASC

-- Now that we know how to do subquery, one more way of doing it...
Select Name, surfacearea
	from country
	Where surfacearea = (Select Min(surfacearea) From country)


-- The 10 largest countries in the world
Select Top 10 name, surfacearea 
	From country
	Order By surfacearea Desc

-- The number of countries who declared independence in 1991
Select Count(*)
	From country
	where indepyear = 1991


-- GROUP BY
-- Count the number of countries where each language is spoken, ordered from most countries to least
select * from countrylanguage

Select language, Count(*) As 'Count'
	From countrylanguage
	Group By language
	Order by 'Count' DESC



-- Average life expectancy of each continent ordered from highest to lowest
Select continent, Avg(lifeexpectancy) As LE
	From country
	Group by continent
	Order By LE Desc

-- Exclude Antarctica from consideration for average life expectancy
Select continent, Avg(lifeexpectancy) As LE
	From country
	Where lifeexpectancy is not null
	Group by continent
	Order By LE Desc

-- Sum of the population of cities in each state in the USA ordered by state name
Select district, sum(population) As Population, Avg(population) As Average  -- 5. Print the name in one column and the sum in another column
	From city									-- 1. give me rows from the city table
	Where countrycode = 'USA'					-- 2. filter out rows that are not in the USA
	Group by district							-- 3. Sum up the populations in buckets by district
	Order by district							-- 4. Sort those summed up rows by district


-- The average population of cities in each state in the USA ordered by state name

-- SUBQUERIES
-- Find the names of cities under a given government leader
select * from country where headofstate = 'George W. Bush'

Select * 
	From city
	Where countrycode in ('ASM', 'GUM', 'MNP', 'PRI', 'UMI', 'USA', 'VIR')

Select * 
	From city
	Where countrycode in (select code from country where headofstate = 'George W. Bush')


-- Find the names of cities whose country they belong to has not declared independence yet

Select name, countrycode
	From city
	Where countrycode in (
		Select code from country where indepyear is null
	)

-- Select those countries with lower than average life expectancy
Select Avg(lifeexpectancy) from country

Select * 
	from country 
	where lifeexpectancy < 66.4860361116426
	
Select name, lifeexpectancy
	from country
	where lifeexpectancy < (Select Avg(lifeexpectancy) from country)
	order by lifeexpectancy

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
