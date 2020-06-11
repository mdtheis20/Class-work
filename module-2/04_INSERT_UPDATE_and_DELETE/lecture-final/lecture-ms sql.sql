-- ********** Outer Join

-- List the country and its capital city

select name, capital from country
select count(*) from country where capital is null

-- Just the countries that have capitals
select country.name, city.name
	From country
	Inner Join city on country.capital = city.id

-- Show me the country and capital, but if there is not a capital, shjow me the country anyway
select country.name, city.name
	From country left Outer Join city on country.capital = city.id

-- UNION gives me rows from more than one query, appended together into a single result set
-- Get name, population, and whether this is a city or country, ordered by population desc

Select name As Place, population As Pop, 'Country' as Type
	From country
UNION
Select name, population, 'City'
	From city
Order by population desc

-- INSERT

-- 1. Add Klingon as a spoken language in the USA
	Select * 
		from countrylanguage
		where countrycode = 'USA'

	Insert into countrylanguage (countrycode, language, isofficial, percentage)
	VALUES ('USA', 'Klingon', 1, 46.90)

-- 2. Add Klingon as a spoken language in Great Britain
	select * from country where name like '%united%'

	Insert into countrylanguage (countrycode, language, isofficial, percentage)
	VALUES ('GBR', 'Klingon', 0, 66.90)


-- UPDATE

-- 1. Update the capital of the USA to Houston
select * from city where name in ('Houston', 'Washington')


Update country
	Set capital = 3796	
	Where code = 'USA'



-- 2. Update the capital of the USA to Washington DC and the head of state
Update country
	Set capital = 3813,
	headofstate = 'Dwayne The Rock Johnson'
	Where code = 'USA'



-- DELETE

-- 1. Delete English as a spoken language in the USA
	Delete countrylanguage Where
		countrycode = 'USA' And
		[language] = 'English'

-- 2. Delete all occurrences of the Klingon language 
	Delete countrylanguage where language = 'Klingon'



-- REFERENTIAL INTEGRITY

-- 1. Try just adding Elvish to the country language table.

-- 2. Try inserting English as a spoken language in the country ZZZ. What happens?
	Insert into countrylanguage (countrycode, language, isofficial, percentage)
	VALUES ('ZZZ', 'Elvish', 0, 0.5)


-- 3. Try deleting the country USA. What happens?
	Delete from country Where code = 'USA'


-- CONSTRAINTS

-- 1. Try inserting English as a spoken language in the USA
	Insert countrylanguage (countrycode, language, isofficial, percentage)
	Values('USA', 'English', 1, 89)

-- 2. Try again. What happens?

-- 3. Let's relocate the USA to the continent - 'Outer Space'
-- CHECK Constraint - continent must be valid
Update country
	Set continent = 'Atlantis'
where code = 'USA'


-- How to view all of the constraints

SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
SELECT * FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE
SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS


-- TRANSACTIONS

--BEGIN Transaction
--Update savings 
--	Set balance = balance - 500
--	where acct = 1234

--Update checking
--	set balance = balance + 500
--	where acct = 4321
--Commit Transaction

BEGIN Transaction
Update savings 
	Set balance = balance - 500
	where acct = 1234

Update checking
	set balance = balance + 500
	where acct = 4321
Commit Transaction

-- 1. Try deleting all of the rows from the country language table and roll it back.
Begin transaction
	Select * from countrylanguage

	Delete from countrylanguage

	Select * from countrylanguage

Rollback transaction
	Select * from countrylanguage


-- 2. Try updating all of the cities to be in the USA and roll it back
Begin Tran
	Update city 
		set population = 0
		Where countrycode = 'USA'
	Select * from city where countrycode = 'USA'

Rollback Tran

-- 3. Demonstrate two different SQL connections trying to access the same table where one happens to be inside of a transaction but hasn't committed yet.