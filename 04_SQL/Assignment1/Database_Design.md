# Assignment - Database Design

## Problem 1:
Design the database for a movie listing site like IMDB.com. The different Entities and their properties are as follows:

The relationships of the different entities are as follows:
- Movies Can have only a single producer.
- Movies can have multiple Actors acting in it.
- An Actor can act in multiple movies
- A Producer can produce multiple movies.


**Solution:**

<div align = "center">
<img width="650" alt="image" src="https://github.com/user-attachments/assets/ab731e3e-f356-422c-a0dd-47f2eab9cfe4" />
</div>


<br>

## Problem 2
Design an Database for the following problem
Swiggy/Zomato/UberEats

XXXX is an app used for food delivery from various restaurants.\
Restaurants have dishes, multiple restaurants can have the same dishes,\
dishes have their own ratings for every restaurant and every user.\
For Example, Users can give Dish 1 of Restaurant 1 as 5 stars.\
This needs to be preserved. Design a Database for the above scenario.

> [!Note]
> Note that, user is rating a `Dish Served by a specific Restaurant`,
> not just a `Dish`

**Solution:**

<div align = "center">
<img width="650" alt="image" src="https://github.com/user-attachments/assets/07de511e-df46-4a38-8a10-11ba62936814" />
</div>






###  Now 
We have a requirement, that 

1. One restaurant can have many addresses,
2. One user can have many address (eg:- Home Address , office Address)

**Solution:**

<div align = "center">
    <img width="650" alt="image" src="https://github.com/user-attachments/assets/19c18aca-173f-4ca0-983e-51731b915ff3" />
</div>