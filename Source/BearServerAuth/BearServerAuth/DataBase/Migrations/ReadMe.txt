# ���������� �������� ����������� � ������� ������:

���������� ���������� ��� (� �����) ��������� . ��� ���������� ��������� � ������ � ���� ������,
���������� ��������� ��������. ��� ����� � ������� ���������� ������� ������� �������:
	"EntityFrameworkCore\Add-Migration InitialIdentityDB -Context CustomIdentityDbContext -OutputDir Migrations\MigrationsIdentity"

��� "InitialIdentityDB" - �������� �������� 
��� "CustomIdentityDbContext" - �������� ������
��� "Migrations\MigrationsIdentity" - ���� ��� �������� ��������

��� ���������� �� ������������ �������: 
	"EntityFrameworkCore\update-database -Context CustomIdentityDbContext"

P.S ������� "Add-Migration" � "update-database ����, ��� � Entity Framework Core, ��� � � Entity Framework 6
� � ������� ������ ������ � ���. � ����� "using Microsoft.EntityFrameworkCore", "� ������ using System.Data.Entity;"
�� ����� ����� ������� ��������� ������ ���������(���������), ������� ����� �������� ����������� "EntityFrameworkCore\"

���� ������������ ������ ��� EntityFrameworkCore �� �����