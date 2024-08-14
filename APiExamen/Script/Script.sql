

-- Usa la base de datos creada
USE Examen;

create table  Producto (

   id_producto int identity(1,1) primary key,
   descripcion varchar(50),
   fecha_registro dateTime,
   fecha_modificacio datetime,
   activo bit

);


create table Datos_Producto (
	id_dato_producto  int identity(1,1) primary key,
    id_producto int,  
	tasa decimal(10,2),
	nombre varchar(50),
	interes decimal(10,2)
   foreign KEY(id_producto) REFERENCES Producto(id_producto)
)

declare @id_producto int;

insert into Producto values('Tajeta Credito',GETDATE(),null,1)

set  @id_producto = SCOPE_IDENTITY();

insert into Datos_Producto values(@id_producto,64.5,'Clasica',35.2)
insert into Datos_Producto values(@id_producto,75.5,'Nueva',30.2)
insert into Datos_Producto values(@id_producto,80.1,'Platino',35.2)
insert into Datos_Producto values(@id_producto,35.5,'Oro',75.3)

insert into Producto values('Tajeta Debito',GETDATE(),null,1)

set  @id_producto = SCOPE_IDENTITY();

insert into Datos_Producto values(@id_producto,0.5,'Nomina',5.2)
insert into Datos_Producto values(@id_producto,0.5,'Digital',0.2)

insert into Producto values('Credito Nomina',GETDATE(),null,1)

set  @id_producto = SCOPE_IDENTITY();

insert into Datos_Producto values(@id_producto,25.5,'Nomina',7.2)

insert into Producto values('Credito Personal',GETDATE(),null,1)

set  @id_producto = SCOPE_IDENTITY();

insert into Datos_Producto values(@id_producto,35.5,'Personal',7.2)

Select 

 a.descripcion as tipo_producto,
 b.nombre as nombre_producto,
 b.tasa,
 b.interes
from  Producto a 
join Datos_Producto b on b.id_producto = a.id_producto
