
create database DBCRUD
go

use DBCRUD
go

CREATE TABLE Usuario(
IdUsuario int primary key identity,
Nombres varchar(40),
Apellidos varchar(40),
FechaNacimiento date,
Genero varchar(40),
Direccion varchar(40),
EstadoCivil varchar(40),
DPI varchar(13),
FechaRegistro datetime default getdate()
)

go
