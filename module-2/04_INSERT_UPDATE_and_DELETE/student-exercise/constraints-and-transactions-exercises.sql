-- Write queries to return the following:
-- The following changes are applied to the "dvdstore" database.**

-- 1. Add actors, Hampton Avenue, and Lisa Byway to the actor table.
Insert into actor (first_name, last_name)
	Values ('Hampton', 'Avenue')
Insert into actor (first_name, last_name)
	Values ('Lisa', 'Byway')

	Select * from actor 
-- 2. Add "Euclidean PI", "The epic story of Euclid as a pizza delivery boy in
-- ancient Greece", to the film table. The movie was released in 2008 in English.
-- Since its an epic, the run length is 3hrs and 18mins. There are no special
-- features, the film speaks for itself, and doesn't need any gimmicks.
select * from film
select * from language
oofs
Insert into film (title, description, release_year,language_id,original_language_id,length)
		Values ('Euclidean PI', 'The epic story of Euclid as a pizza delivery boy in ancient Greece', 2008, 1, 1, 198) 
-- 3. Hampton Avenue plays Euclid, while Lisa Byway plays his slightly
-- overprotective mother, in the film, "Euclidean PI". Add them to the film.
select * from film_actor

Insert into film_actor (actor_id, film_id)
	Values (201,1001), (202,1001)
-- 4. Add Mathmagical to the category table.
select * from category

Insert into category ( name)
	Values ('Mathmagical')

-- 5. Assign the Mathmagical category to the following films, "Euclidean PI",
-- "EGG IGBY", "KARATE MOON", "RANDOM GO", and "YOUNG LANGUAGE"
Select film.film_id	
	from film
	where title = 'YOUNG LANGUAGE'
select * from category


Insert into film_category (film_id, category_id)
	Values (1001,17), (274,17), (494,17), (714,17), (996,17)

-- 6. Mathmagical films always have a "G" rating, adjust all Mathmagical films
-- accordingly.
-- (5 rows affected)

Update film
	set rating = 'G'
	from film
	join film_category on film.film_id = film_category.film_id
	where film_category.category_id = 17

	select rating
		from film
		join film_category on film.film_id = film_category.film_id
		where film_category.category_id = 17

-- 7. Add a copy of "Euclidean PI" to all the stores.
Insert into inventory (film_id, store_id)
	Values (1001,1), (1001, 2)

	select film.film_id	
		from film
		Where title = 'Euclidean PI'
select store.store_id
		from store 
		group by store.store_id
-- 8. The Feds have stepped in and have impounded all copies of the pirated film,
-- "Euclidean PI". The film has been seized from all stores, and needs to be
-- deleted from the film table. Delete "Euclidean PI" from the film table.
-- (Did it succeed? Why?)
-- <YOUR ANSWER HERE>
Delete film where film.film_id = 1001

--it failed because of a reference contstraint located in the film_actor table.



-- 9. Delete Mathmagical from the category table.
-- (Did it succeed? Why?)
-- <YOUR ANSWER HERE>

delete category where name = 'Mathmagical'

--It failed because of a reference constraint in the film_category table. that would affect category_ID

-- 10. Delete all links to Mathmagical in the film_category tale.
-- (Did it succeed? Why?)
-- <YOUR ANSWER HERE>
delete film_category where category_id = 17

--Yes it deleted the links because there were no constraints



-- 11. Retry deleting Mathmagical from the category table, followed by retrying
-- to delete "Euclidean PI".
-- (Did either deletes succeed? Why?)
-- <YOUR ANSWER HERE>

delete category where name = 'Mathmagical'
--This worked because the constraints where removed when we deleted the links to film_category

Delete film where film.film_id = 1001
--this did not work becuase there are still restraints moving the other direction towards film_actor
-- 12. Check database metadata to determine all constraints of the film id, and
-- describe any remaining adjustments needed before the film "Euclidean PI" can
-- be removed from the film table.

--you would need to remove the links at film_id from inventory and film_actor so that there would be no more restraints remaining. Then you would be able to remove it from the film table. 
