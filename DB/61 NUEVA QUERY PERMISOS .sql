delete  from Patente
delete  from Familia
delete  from Familia_Patente
--delete from Usuario_Patente
GO
DBCC CHECKIDENT (Patente, RESEED, 0)
DBCC CHECKIDENT (Familia, RESEED, 0)
DBCC CHECKIDENT (Familia_Patente, RESEED, 0)
--DBCC CHECKIDENT (Usuario_Patente, RESEED, 0)
GO
INSERT INTO Patente (codigo) VALUES 
('UnLpiJjJgx5ew9857jn4PRH5PP8XAEYSGltRz2iP9UlBCfYeN8CvwoBRUpjvps/8'), --ADM_CLIENTES_ALTA
('UnLpiJjJgx5ew9857jn4PZF4x1Mr3bjJRb8WiG7BnVk1Zar5cLFvWO1HwzBp2Wa4'), --ADM_CLIENTES_BAJA
('UnLpiJjJgx5ew9857jn4PbmKVXeHboFdn/H5jd2ks4xZFXfCPoEJkXfbTd72MN93'), --ADM_CLIENTES_VER
('UnLpiJjJgx5ew9857jn4PfxWeaVz3ja4PL5883XUCMmoiRHBgV8KdkXvkdkxh1X+'), --ADM_CLIENTES_MODIF

('lgLZ0mGuXGL1v471mriwO3le3YcEumEMWWgsfvctjuPxnZZ3YtlSO2IwaySurau4'), --ADM_USUARIOS_ALTA
('lgLZ0mGuXGL1v471mriwO7JuIeQxEiIg3q7z57RQcodt0PGwvuktwXmchXtppktv'), --ADM_USUARIOS_BAJA
('lgLZ0mGuXGL1v471mriwO/s33MyKo2bOySQBTwMfcP/nbE2g9N4wHZIA2GwIcNkj'), --ADM_USUARIOS_VER
('lgLZ0mGuXGL1v471mriwO4NhL5hLPPxORGZISvF1CXHBs/o/exmJz6AxLArt7ZZM'), --ADM_USUARIOS_MODIF
('lgLZ0mGuXGL1v471mriwO47aUV2vluyTP4wTvzcapb+KWfIT8+BiOWfx5YK9Rivg'), --ADM_USUARIOS_PERM
('lgLZ0mGuXGL1v471mriwO6+s0XPi/ZyOgsWGG/7HNGzI8UMRecKKprQSFI78P9n7wJtnhjwZ6Txzo3x7onm7qw=='), --ADM_USUARIOS_DESBLOQUEAR

('XRphK+7s3+dq3EYCnEtlCQQOhCZgst5po1XW/oHX7WEW++7SVoB5cZRBJ7Fn5GBe95Y+MCUYNsdIvFWfU2MQDA=='), --ADM_SEGURIDAD_CREAR_FAMILIA
('XRphK+7s3+dq3EYCnEtlCTAduiUTlxDH6cFtI+n+ZMdd6x0tWu4DdA0NgsUM3qCHsclc5Wl7WKzxTjW1XkLEtQ=='), --ADM_SEGURIDAD_BAJA_FAMILIA
('XRphK+7s3+dq3EYCnEtlCYTCyI05oZ3AWT/Hum4DCzo4U6uxr4mKtIB/+c1t31eGughQlVHc8p62ckhhzoOHag=='), --ADM_SEGURIDAD_MODIFICAR_FAMILIA
('XRphK+7s3+dq3EYCnEtlCZS4RqoDo5Ypd67tgQNQR5koR4vTTKUSkCEa5DMx7YObVvj3iM5xxpmb/URlZIiGBMrZ0FvFw/7ULqQ5HbYOinM='), --ADM_SEGURIDAD_CONSULTAR_BITACORA
('XRphK+7s3+dq3EYCnEtlCQQOhCZgst5po1XW/oHX7WEW++7SVoB5cZRBJ7Fn5GBe95Y+MCUYNsdIvFWfU2MQDA=='), --ADM_SEGURIDAD_CREAR_FAMILIA
('XRphK+7s3+dq3EYCnEtlCbuODKxDuTkHcgB9/qxcWsd+c9bKrYDBv5TKyJdx4mYWaOWeijA2WL1aK8xW4mv7lg=='), --ADM_SEGURIDAD_GENERAR_BACKUP

('CG8YkwXlNuqaDne0L3U7r+eQGrd712AhhZboK6oXBn1OP7vk+VZ/3ZZ25opbCdi8'), --ADM_PILOTOS_ALTA
('CG8YkwXlNuqaDne0L3U7r11PcBpoaPoo6YjJm9/lvQ9d/d3SWHjiOgmOQyAy/FA+'), --ADM_PILOTOS_BAJA
('CG8YkwXlNuqaDne0L3U7r4hX5ifHfixA3kEzoOk2Hr9uBEgOa4DdZv9pcpKSjO+l'), --ADM_PILOTOS_MODIF
('CG8YkwXlNuqaDne0L3U7r5yX0HavqX9/TSJGKxgAm4g='), --ADM_PILOTOS_VER

('DNFWdbb4hIMwHGF9P/Tgo6vjxbSUKjh12RKdmRv96ntc3dUUreTGpjhpwrWZEj+4'), --ADM_AVIONES_ALTA
('DNFWdbb4hIMwHGF9P/Tgo38APsmqtvD03vSLO/IUgM8GNBZufZPxeow0gndMgu98'), --ADM_AVIONES_BAJA
('DNFWdbb4hIMwHGF9P/Tgo/4A0cJis3A1lUG252K/5wEgcCylGc5TI+BompxcZ/by'), --ADM_AVIONES_MODIF
('DNFWdbb4hIMwHGF9P/Tgo+asbTE0ZIDR/PGnBECsptI='), --ADM_AVIONES_VER

('MvHWGbQMzQXhvtXo3WYluShGKFIClMKRnhdLVlr9RgKxVuCAe5LXYjjq/72WwJj+'), --ADM_ACTIVIDADES_ALTA
('MvHWGbQMzQXhvtXo3WYluShGKFIClMKRnhdLVlr9RgK89cs5mH0wjbelS20oNq2B'), --ADM_ACTIVIDADES_BAJA
('MvHWGbQMzQXhvtXo3WYluShGKFIClMKRnhdLVlr9RgKVsBvE2NY4DmMB+4wU0g0J7ZZq7DJyyjEEtktNhubPhQ=='), --ADM_ACTIVIDADES_VISUALIZAR
('MvHWGbQMzQXhvtXo3WYluShGKFIClMKRnhdLVlr9RgL8j/kyJ31DInNK+U/UvE2S'), --ADM_ACTIVIDADES_VER

('XRphK+7s3+dq3EYCnEtlCak8lSYHoAs3T9xgyHAfsMAkPCs0+O+pO//Rij82g6sywVXCP/pO3lI8/Gk0kS/dgA=='), --ADM_SEGURIDAD_RECALCULAR_DV
('XRphK+7s3+dq3EYCnEtlCak8lSYHoAs3T9xgyHAfsMB9gcbq+rBjRzUO5Q101vQP') --ADM_SEGURIDAD_RESTORE


INSERT INTO Familia (descripcion) values 
('MIxl4Z0gDVueoHvtoVjLSesccx02yP8zVUkUeBbcr0s='), --ADMIN_SEGURIDAD
('6I+dOEcTb+Ozloc9aKef7gJK06tEooekxQdSgVlYwa4='), --ADMIN_USUARIOS
('5IayziXUjEwCue6lSoHc2zVpXVxfKBNlQk9rJn+hQnQ='), --ADMIN_EMPLEADOS
('XZRebs4hLP3lE9pzqdiz3EImpgLODUJ6yZwp+VFvWXo='), --ADMIN_CLIENTES
('yFDr9FE2OWtMy43QIwrqfdhTKbKIopSGOQ27osg0oB797HyPWTNsAIFwU3TCZcbL'), --ADMIN_ACTIVIDADES
('0YJS1jZ8ge2TFYJXOuOfyb/JgezsHfcArfvA3Kg9mgU=') --ADMIN_RECURSOS

insert into Familia_Patente (familiaFK, patenteFK, dvh) values 

(4,1,150),
(4,2,152),
(4,3,154),
(4,4,156),

(2,5,156),
(2,6,158),
(2,7,160),
(2,8,162),
(2,9,164),
(2,10,292),

(1,11,294),
(1,12,297),
(1,13,300),
(1,14,303),
(1,15,306),
(1,16,309),

(3,17,314),
(3,18,317),
(3,19,320),
(3,20,295),

(6,21,301),
(6,22,304),
(6,23,307),
(6,24,310),

(5,25,312),
(5,26,315),
(5,27,318),
(5,28,321),

(1,29,320),
(1,30,295)

GO
