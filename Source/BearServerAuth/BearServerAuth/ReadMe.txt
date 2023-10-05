0.	Полезные ссылки:
	-https://metanit.com/sharp/entityframeworkcore/7.1.php
	-https://habr.com/ru/articles/594971/
	-https://metanit.com/sharp/aspnet6/13.2.php

1.	Необходимо добавить через Nuget пакеты: 
	-Npgsql.EntityFrameworkCore.PostgreSQL
	-Microsoft.EntityFrameworkCore.Tools
	-Newtonsoft.Json

2.	Подключение к существующей базе данных.
В Консоль диспетчера пакетов вводится 	
	Scaffold-DbContext "Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=password"
Далее провайдер 
	Npgsql.EntityFrameworkCore.PostgreSQL	(к сожалению ctrl+c  не работает)