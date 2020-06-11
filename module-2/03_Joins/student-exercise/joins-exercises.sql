-- The following queries utilize the "dvdstore" database.

-- 1. All of the films that Nick Stallone has appeared in
-- (30 rows)
select title	
	from film
	join film_actor on film.film_id = film_actor.film_id
	join actor on film_actor.actor_id = actor.actor_id
	where  first_name = 'nick' and last_name = 'stallone'
-- 2. All of the films that Rita Reynolds has appeared in
-- (20 rows)
select title	
	from film
	join film_actor on film.film_id = film_actor.film_id
	join actor on film_actor.actor_id = actor.actor_id
	where  first_name = 'rita' and last_name = 'reynolds'
-- 3. All of the films that Judy Dean or River Dean have appeared in
-- (46 rows)
select title	
	from film
	join film_actor on film.film_id = film_actor.film_id
	join actor on film_actor.actor_id = actor.actor_id
	where  first_name = 'judy' or first_name = 'river' and last_name = 'stallone' or last_name = 'dean'
-- 4. All of the the ‘Documentary’ films
-- (68 rows)
select title
	from film f
	join film_category fc on f.film_id = fc.film_id
	join category c on fc.category_id = c.category_id
	where name = 'documentary'
-- 5. All of the ‘Comedy’ films
-- (58 rows)
select title
	from film f
	join film_category fc on f.film_id = fc.film_id
	join category c on fc.category_id = c.category_id
	where name = 'comedy'
-- 6. All of the ‘Children’ films that are rated ‘G’
-- (10 rows)
select title
	from film f
	join film_category fc on f.film_id = fc.film_id
	join category c on fc.category_id = c.category_id
	where name = 'children' and rating = 'g'
-- 7. All of the ‘Family’ films that are rated ‘G’ and are less than 2 hours in length
-- (3 rows)
select title
	from film f
	join film_category fc on f.film_id = fc.film_id
	join category c on fc.category_id = c.category_id
	where name = 'family' and rating = 'g' and length < 120 
-- 8. All of the films featuring actor Matthew Leigh that are rated ‘G’
-- (9 rows)
select title	
	from film
	join film_actor on film.film_id = film_actor.film_id
	join actor on film_actor.actor_id = actor.actor_id
	where  first_name = 'matthew' and last_name = 'leigh' and rating = 'g'
-- 9. All of the ‘Sci-Fi’ films released in 2006
-- (61 rows)
select title
	from film f
	join film_category fc on f.film_id = fc.film_id
	join category c on fc.category_id = c.category_id
	where name = 'sci-fi' and release_year  = 2006
-- 10. All of the ‘Action’ films starring Nick Stallone
-- (2 rows)
select title
	from film f
	join film_category fc on f.film_id = fc.film_id
	join category c on fc.category_id = c.category_id
	join film_actor on f.film_id = film_actor.film_id
	join actor on film_actor.actor_id = actor.actor_id
	where name = 'action' and first_name = 'nick' and last_name = 'stallone'
-- 11. The address of all stores, including street address, city, district, and country
-- (2 rows)
select address, city, district, country
	from store s

	join address a on s.address_id = a.address_id
	join city c on a.city_id = c.city_id
	join country on c.country_id = country.country_id
-- 12. A list of all stores by ID, the store’s street address, and the name of the store’s manager
-- (2 rows)
select staff.store_id,   address, staff.First_name, staff.last_name
	from store s
	join address a on s.address_id = a.address_id
	join staff on s.manager_staff_id = staff.staff_id
	order by staff.store_id

-- 13. The first and last name of the top ten customers ranked by number of rentals 
-- (#1 should be “ELEANOR HUNT” with 46 rentals, #10 should have 39 rentals)
select top 10 Count(payment.payment_id),  customer.first_name, customer.last_name 
	from customer
	join rental on customer.customer_id = rental.customer_id
	join payment on rental.rental_id = payment.rental_id
	group by customer.first_name, customer.last_name
	order by Count(payment_id) desc
	
	
-- 14. The first and last name of the top ten customers ranked by dollars spent 
-- (#1 should be “KARL SEAL” with 221.55 spent, #10 should be “ANA BRADLEY” with 174.66 spent)
select top 10  customer.first_name, customer.last_name, sum(amount)
	from customer
	join rental on customer.customer_id = rental.customer_id
	join payment on rental.rental_id = payment.rental_id
	group by customer.first_name, customer.last_name
	order by sum(amount) desc
-- 15. The store ID, street address, total number of rentals, total amount of sales (i.e. payments), and average sale of each store.
-- (NOTE: Keep in mind that an employee may work at multiple stores.)
-- (Store 1 has 7928 total rentals and Store 2 has 8121 total rentals)
	select s.store_id, address, Count(*), sum(amount), avg(amount)
		from store s
		join inventory I on i.store_id = s.store_id  
		join rental r on i.inventory_id = r.inventory_id
		join payment on r.rental_id = payment.rental_id
		join address a on s.address_id = a.address_id
		group by s.store_id, address

-- 16. The top ten film titles by number of rentals
-- (#1 should be “BUCKET BROTHERHOOD” with 34 rentals and #10 should have 31 rentals)
select top 10 title, count(payment.payment_date)
	from film
		join inventory on film.film_id = inventory.film_id
		join rental on inventory.inventory_id = rental.inventory_id
		join payment on rental.rental_id = payment.rental_id
		group by title
		order by count(payment.payment_date) desc
-- 17. The top five film categories by number of rentals 
-- (#1 should be “Sports” with 1179 rentals and #5 should be “Family” with 1096 rentals)
select top 5 category.name, count(payment.payment_date)
	from film
		join inventory on film.film_id = inventory.film_id
		join rental on inventory.inventory_id = rental.inventory_id
		join payment on rental.rental_id = payment.rental_id
		join film_category on film.film_id = film_category.film_id
		join category on film_category.category_id = category.category_id
		group by category.name
		order by count(payment.payment_date) desc
-- 18. The top five Action film titles by number of rentals 
-- (#1 should have 30 rentals and #5 should have 28 rentals)
select top 5 title, count(payment.payment_date)
	from film
		join inventory on film.film_id = inventory.film_id
		join rental on inventory.inventory_id = rental.inventory_id
		join payment on rental.rental_id = payment.rental_id
		join film_category on film.film_id = film_category.film_id
		join category on film_category.category_id = category.category_id
		where category.name = 'action'
		group by title
		order by count(payment.payment_date) desc
-- 19. The top 10 actors ranked by number of rentals of films starring that actor 
-- (#1 should be “GINA DEGENERES” with 753 rentals and #10 should be “SEAN GUINESS” with 599 rentals)
select Top 10 actor.actor_id, actor.first_name, actor.last_name, count(payment.payment_date)
	from actor
	join film_actor on actor.actor_id = film_actor.actor_id
	join film on film_actor.film_id = film.film_id
		join inventory on film.film_id = inventory.film_id
		join rental on inventory.inventory_id = rental.inventory_id
		join payment on rental.rental_id = payment.rental_id
		group by actor.actor_id, actor.first_name, actor.last_name
		order by Count(payment.payment_id) desc
-- 20. The top 5 “Comedy” actors ranked by number of rentals of films in the “Comedy” category starring that actor 
-- (#1 should have 87 rentals and #5 should have 72 rentals)
select Top 5 actor.actor_id, category.name, actor.first_name, actor.last_name, count(payment.payment_date)
	from actor
	join film_actor on actor.actor_id = film_actor.actor_id
	join film on film_actor.film_id = film.film_id
		join inventory on film.film_id = inventory.film_id
		join rental on inventory.inventory_id = rental.inventory_id
		join payment on rental.rental_id = payment.rental_id
		join film_category on film.film_id = film_category.film_id
		join category on film_category.category_id = category.category_id
		where category.name = 'comedy'
		group by  category.name, actor.actor_id, actor.first_name, actor.last_name
	
		order by Count(payment.payment_id) desc