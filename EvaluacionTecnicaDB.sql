
select * 
from Roles as R
Inner Join Usuarios as U
On U.RoleId = R.Id


select * 
from Usuarios as U
Left join Roles as R
On r.Id = U.RoleId

Insert into Roles
(Nombre, IsActive, IsDeleted)
Values 
('ADMIN', 1, 0),
('DESARROLLADOR', 1, 0)

Insert into Usuarios
(RoleId, Nombre, Apellido, Usuario_Nombre, Contraseña, Cedula, Fecha_Nacimiento,  IsActive, IsDeleted)
Values 
(2,'Simetrica', 'Consulting', 'ADMIN', 'ADMIN', '25322522135', '01-01-1990', 1, 0),
(3,'Nombre_Desarrollador', 'Consulting', 'DESARROLLADOR', 'Aplicante', '0000000000', '05-25-2000', 1, 0)