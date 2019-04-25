delete  from Patente
delete  from Familia
delete  from Familia_Patente

DBCC CHECKIDENT (Patente, RESEED, 0)
DBCC CHECKIDENT (Familia, RESEED, 0)
DBCC CHECKIDENT (Familia_Patente, RESEED, 0)

INSERT INTO Patente (codigo) VALUES 
('ADM_CLIENTES_ALTA'),
('ADM_CLIENTES_BAJA'),
('ADM_CLIENTES_VER'),
('ADM_CLIENTES_MODIF'),

('ADM_USUARIOS_ALTA'),
('ADM_USUARIOS_BAJA'),
('ADM_USUARIOS_VER'),
('ADM_USUARIOS_MODIF'),
('ADM_USUARIOS_PERM')


INSERT INTO Familia (descripcion) values 
('ADMIN_SEGURIDAD'), 
('ADMIN_USUARIOS'),
('ADMIN_EMPLEADOS'),
('ADMIN_CLIENTES'),
('ADMIN_ACTIVIDADES'),
('ADMIN_RECURSOS')    

insert into Familia_Patente (familiaFK, patenteFK) values 
(4,1),
(4,2),
(4,3),
(4,4),
(2,5),
(2,6),
(2,7),
(2,8),
(2,9),
(2,10)