# 2VTD
Завдання 4. "ADO.Net. - робота у під'єднаному режимі"
Для виконання цього завдання вам потрібно:
1) використати базу даних Northwind (стягнути з інтернету) і SQL Server  (або інший провайдер).
3) Створюєте консольну програмку для виконання поставлених завдань. 
Результат повинен бути у вигляді DataReader і виведення на консоль.

1.	Show all info about the employee with ID 8.
2.	Show the list of first and last names of the employees from London.
3.	Show the list of first and last names of the employees whose first name begins with letter A.
4.	Show the list of first, last names and ages of the employees whose age is greater than 55. The result should be sorted by last name.
5.	Calculate the count of employees from London.
6.	Calculate the greatest, the smallest and the average age among the employees from London.
7.	Calculate the greatest, the smallest and the average age of the employees for each city.
8.	Show the list of cities in which the average age of employees is greater than 60 (the average age is also to be shown)
9.	Show the first and last name(s) of the eldest employee(s). 
10.	Show first, last names and ages of 3 eldest employees.
-----------------------------------------------------------------------------------------------------------------------------------------
11.	Show the list of all cities where the employees are from.0
12.	Show first, last names and dates of birth of the employees who celebrate their birthdays this month.
13.	Show first and last names of the employees who used to serve orders shipped to Madrid.
14.	Show first and last names of the employees as well as the count of orders each of them have received during the year 1997 (use left join).
15.	Show first and last names of the employees as well as the count of orders each of them have received during the year 1997
16.	Show first and last names of the employees as well as the count of their orders shipped after required date during the year 1997 (use left join).
17.	Show the count of orders made by each customer from France.
18.	Show the list of french customers’ names who have made more than one order (use grouping).
19.	Show the list of french customers’ names who have made more than one order
20.	Show the list of customers’ names who used to order the ‘Tofu’ product.
-------------------------------------------------------------------------------------------------------------------------------
21.	*Show the list of customers’ names who used to order the ‘Tofu’ product, along with the total amount of the product they have ordered and with the total sum for ordered product calculated.
22.	*Show the list of french customers’ names who used to order non-french products (use left join).
23.	*Show the list of french customers’ names who used to order non-french products.
24.	*Show the list of french customers’ names who used to order french products.
25.	*Show the total ordering sum calculated for each country of customer.
26.	*Show the total ordering sums calculated for each customer’s country for domestic and non-domestic products separately (e.g.: “France – French products ordered – Non-french products ordered” and so on for each country).
27.	*Show the list of product categories along with total ordering sums calculated for the orders made for the products of each category, during the year 1997.
28.	*Show the list of product names along with unit prices and the history of unit prices taken from the orders (show ‘Product name – Unit price – Historical price’). The duplicate records should be eliminated. If no orders were made for a certain product, then the result for this product should look like ‘Product name – Unit price – NULL’. Sort the list by the product name.
29.	*Show the list of employees’ names along with names of their chiefs (use left join with the same table).
30.	*Show the list of cities where employees and customers are from and where orders have been made to. Duplicates should be eliminated.
----------------------------------------------------------------------------------------------------------------------------------- 
31.	*Insert 5 new records into Employees table. Fill in the following  fields: LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes. The Notes field should contain your own name.
32.	*Fetch the records you have inserted by the SELECT statement
33.	*Change the City field in one of your records using the UPDATE statement.
34.	*Change the HireDate field in all your records to current date.
35.	*Delete one of your records.

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

Завдання 5
- В проекті, який реалізовує Task3 замінити рівень, який відповідає за зберігання даних на роботу з базою даних.
- Для цього використати Entity Framework Code First, створити моделі для представлення даних задачі, контекст, згенерувати відповідну базу.
- Також в проекті повинен бути реалізовані патерни Repository і UnitOfWork.
- Юніт тести і xml документація, обробка виняткових ситуацій

-----------------------------------------------------------------------
Завдання 3. WPF-Service
Утворити трьохрівневу аплікацію для реалізації поставленої задачі.
Перший рівень – доступ до даних, які зберігаються у текстових файлах. Класи цього рівня дозволяють зчитувати-записувати-змінювати-видаляти дані.
Другий рівень – бізнес логіка, тут повинна бути вся логіка вашої програми.
Третій рівень – UI, де використати WPF
Також повинен бути окремий проект з юніт тестами.
Обробка виняткових ситуацій, XML документація 

Варіант 10.  «Послуги по перевезенню вантажу» (для клієнта-замовника)
-----------------------------------------------------------------------
