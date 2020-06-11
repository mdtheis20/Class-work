-- List the "city name, country name" and city population, sorted by country and city population descending
Select * -- city.name As City, district, country.name As Country
	From city
	inner join country on city.countrycode = country.code
	order by country.name, city.name

-- List the city name, country name and the percentage of the country's population in the city

-- List the country name and its languages
select c.name, cl.language
	From countrylanguage as cl
	join country as c on cl.countrycode = c.code

-- List the country name and its official language
Select c.name, cl.language As OfficialLanguage
	From countrylanguage cl
	join country c on cl.countrycode = c.code
	Where isofficial = 1

-- List the countries and their capital cities
Select co.name As Country, ci.name As Capital
	From country co
	inner join city ci on co.capital = ci.id

-- Where are the other 7 rows?
select * from country where capital is null

-- List the countries and their capital cities, but make sure the country is listed even if it has no capital
Select co.name As Country, ci.name As Capital
	From country co left outer join city ci on co.capital = ci.id


-- List the cities which are not capitals

-- Another way

-- ********* INNER JOIN ***********

-- Let's find out who made payment 16666:
select customer_id 
	from payment
	where payment_id = 16666

-- Ok, that gives us a customer_id, but not the name. We can use the customer_id to get the name FROM the customer table
select first_name, last_name 
	from payment p
	inner join customer c on p.customer_id = c.customer_id
	where payment_id = 16666

-- We can see that the * pulls back everything from both tables. We just want everything from payment and then the first and last name of the customer:
select p.*, c.first_name, c.last_name 
	from payment p
	inner join customer c on p.customer_id = c.customer_id
	where payment_id = 16666

-- But when did they return the rental? Where would that data come from? From the rental table, so let’s join that.
select p.*, c.first_name, c.last_name, r.return_date
	from payment p
	inner join customer c on p.customer_id = c.customer_id
	inner join rental r on p.rental_id = r.rental_id
	where payment_id = 16666

-- What did they rent? Film id can be gotten through inventory.
select p.*, c.first_name, c.last_name, r.return_date, f.title
	from payment p
	inner join customer c on p.customer_id = c.customer_id
	inner join rental r on p.rental_id = r.rental_id
	join inventory i on i.inventory_id = r.inventory_id
	join film f on f.film_id = i.film_id
	where payment_id = 16666

-- What if we wanted to know who acted in that film?
select p.*, c.first_name, c.last_name, r.return_date, f.title, Concat(a.first_name, ' ', a.last_name)
	from payment p
	inner join customer c on p.customer_id = c.customer_id
	inner join rental r on p.rental_id = r.rental_id
	join inventory i on i.inventory_id = r.inventory_id
	join film f on f.film_id = i.film_id
	join film_actor fa on f.film_id = fa.film_id
	join actor a on fa.actor_id = a.actor_id
	where payment_id = 16666

-- What if we wanted a list of all the films and their categories ordered by film title
select f.title, c.name
	from film f 
	join film_category fc on f.film_id = fc.film_id
	join category c on fc.category_id = c.category_id
	Order by f.title

-- Show all the 'Comedy' films ordered by film title
select f.title, c.name
	from film f 
	join film_category fc on f.film_id = fc.film_id
	join category c on fc.category_id = c.category_id
	Where c.name = 'Comedy'
	Order by f.title

-- Finally, let's count the number of films under each category
-- Comedy 52
-- Drama  12
select c.name, Count(*)
	from film f 
	join film_category fc on f.film_id = fc.film_id
	join category c on fc.category_id = c.category_id
	Group by c.name
	Order by c.name

-- ********* LEFT JOIN ***********

-- (There aren't any great examples of left joins in the "dvdstore" database, so the following queries are for the "world" database)

-- A Left join, selects all records from the "left" table and matches them with records from the "right" table if a matching record exists.

-- Let's display a list of all countries and their capitals, if they have some.

-- Only 232 rows
-- But we’re missing entries:

-- There are 239 countries. So how do we show them all even if they don’t have a capital?
-- That’s because if the rows don’t exist in both tables, we won’t show any information for it. If we want to show data FROM the left side table everytime, we can use a different join:

-- *********** UNION *************

-- Back to the "dvdstore" database...

-- Gathers a list of all first names used by actors and customers
-- By default removes duplicates

-- Gather the list, but this time note the source table with 'A' for actor and 'C' for customer
