use master
go

if db_id('empresa') is not null
begin
	drop database empresa
end
go

create database empresa
go

use empresa
go

create table empleado(
idempleado int primary key identity(1,1),
razonsocial varchar(100),
fechanacimiento date,
edad int,
salario real
)
go

create procedure insertar_empleado
@razonsocial varchar(100),
@fechanacimiento date,
@edad int,
@salario real
as
insert into empleado(razonsocial, fechanacimiento, edad, salario)
values(@razonsocial, @fechanacimiento, @edad, @salario)
go

create procedure modificar_empleado
@idempleado int,
@razonsocial varchar(100),
@fechanacimiento date,
@edad int,
@salario real
as
update empleado set
razonsocial = @razonsocial,
fechanacimiento = @fechanacimiento,
edad = @edad,
salario = @salario
where idempleado = @idempleado
go

create procedure consultar_empleado
@razonsocial varchar(100)
as
select * from empleado
where razonsocial like '%'+@razonsocial+'%'
go

create procedure buscar_empleado
@idempleado int
as
select * from empleado
where idempleado = @idempleado
go

create procedure eliminar_empleado
@idempleado int
as
delete from empleado where idempleado = @idempleado
go

select * from empleado