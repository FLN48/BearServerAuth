# Выполнение миграций выполнялось с помощью команд:

Приложение использует два (и более) контекста . Для применения изменений в модели к базе данных,
необходимо выполнить миграцию. Для этого в консоли диспетчера пакетов пишется коменда:
	"EntityFrameworkCore\Add-Migration InitialIdentityDB -Context CustomIdentityDbContext -OutputDir Migrations\MigrationsIdentity"

где "InitialIdentityDB" - название миграции 
где "CustomIdentityDbContext" - контекст данных
где "Migrations\MigrationsIdentity" - путь для хранения миграций

Для обновления бд используется команда: 
	"EntityFrameworkCore\update-database -Context CustomIdentityDbContext"

P.S Команды "Add-Migration" и "update-database есть, как в Entity Framework Core, так и в Entity Framework 6
И в проекте разные ссылки у них. У одной "using Microsoft.EntityFrameworkCore", "у другой using System.Data.Entity;"
Из этого всего команды принимают разные аргументы(параметры), поэтому перед командой указывается "EntityFrameworkCore\"

Файл конфигураций походу для EntityFrameworkCore не нужен