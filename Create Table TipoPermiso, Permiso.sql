Create Table TipoPermiso (
Id int identity(1,1) Primary Key,
Descripcion varchar(250) Not Null,
)

Create Table Permiso (
Id int identity(1,1) Primary Key,
NombreEmpleado varchar(100) Not Null,
ApellidosEmpleado  varchar(100) Not Null,
TipoPermiso  int Not Null ,
FechaPermiso DateTime Not Null
Constraint FK_TipoPermiso Foreign Key (TipoPermiso) References TipoPermiso(Id)
)

Insert Into TipoPermiso (Descripcion) Values ('Enfermedad')
Insert Into TipoPermiso (Descripcion) Values ('Diligencias')
Insert Into TipoPermiso (Descripcion) Values ('Otros')
Select Id, Descripcion From TipoPermiso
