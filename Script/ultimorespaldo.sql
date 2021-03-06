USE [KosturasDB]
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Notas], [Calle], [Email], [Ciudad], [Codigopostal], [TelefonoPrincipal], [TelefonoDos], [Telefonotres], [Abreviatura], [TotalOrden], [Fecha], [EmpleadoInserta], [Visitas], [FechaModificacion], [Empleadoactualiza]) VALUES (1, N'Brainer Hidalgo', N'GAne', N'San Juan', N'branerhidalgo@gmail.com', N'Grecia', N'88888', N'84097899', N'545555', N'5456666', N'Sr', N'', N'', N'', N'34', N'15/02/2019 13:10:58', N'Rosa')
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Notas], [Calle], [Email], [Ciudad], [Codigopostal], [TelefonoPrincipal], [TelefonoDos], [Telefonotres], [Abreviatura], [TotalOrden], [Fecha], [EmpleadoInserta], [Visitas], [FechaModificacion], [Empleadoactualiza]) VALUES (2, N'Raul', N'Notas', N'Calle', N'quer@hotmail.com', N'Ciudad', N'Codigo Postal', N'84759899', N'Teléfono 2', N'Telefono 3', N'', N'', N'', N'', N'3', N'', N'')
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Notas], [Calle], [Email], [Ciudad], [Codigopostal], [TelefonoPrincipal], [TelefonoDos], [Telefonotres], [Abreviatura], [TotalOrden], [Fecha], [EmpleadoInserta], [Visitas], [FechaModificacion], [Empleadoactualiza]) VALUES (3, N'prueba', N'Notas', N'Calle', N'quer@hotmail.com', N'Ciudad', N'Codigo Postal', N'845766555', N'Teléfono 2', N'Telefono 3', N'', N'', N'', N'', N'6', N'', N'')
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Notas], [Calle], [Email], [Ciudad], [Codigopostal], [TelefonoPrincipal], [TelefonoDos], [Telefonotres], [Abreviatura], [TotalOrden], [Fecha], [EmpleadoInserta], [Visitas], [FechaModificacion], [Empleadoactualiza]) VALUES (4, N'Braulio Branes', N'prueba', N'Calle', N'prueba@hotamail.com', N'Ciudad', N'Codigo Postal', N'85789878', N'2444444', N'Telefono 3', N'', N'', N'', N'', N'13', N'', N'')
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Notas], [Calle], [Email], [Ciudad], [Codigopostal], [TelefonoPrincipal], [TelefonoDos], [Telefonotres], [Abreviatura], [TotalOrden], [Fecha], [EmpleadoInserta], [Visitas], [FechaModificacion], [Empleadoactualiza]) VALUES (5, N'Quervin', N'gdfggdf', N'dgfgdfdfg', N'quer@prueba.com', N'gdfgfddfg', N'gfdgfddfg', N'8478999', N'gfdgfdf', N'gdfgdfdgf', N'', N'', N'', N'', N'1', N'', N'')
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Notas], [Calle], [Email], [Ciudad], [Codigopostal], [TelefonoPrincipal], [TelefonoDos], [Telefonotres], [Abreviatura], [TotalOrden], [Fecha], [EmpleadoInserta], [Visitas], [FechaModificacion], [Empleadoactualiza]) VALUES (1001, N'Mario', N'Notas', N'Calle', N'prueba@hotamail.com', N'Ciudad', N'Codigo Postal', N'84789999', N'Teléfono 2', N'Telefono 3', N'', N'', N'', N'', N'1', N'', N'')
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Notas], [Calle], [Email], [Ciudad], [Codigopostal], [TelefonoPrincipal], [TelefonoDos], [Telefonotres], [Abreviatura], [TotalOrden], [Fecha], [EmpleadoInserta], [Visitas], [FechaModificacion], [Empleadoactualiza]) VALUES (1002, N'Mario', N'', N'Calle', N'gane@hotamail.com', N'Ciudad', N'Codigo Postal', N'84789999', N'Teléfono 2', N'Telefono 3', N'', N'', N'', N'', N'1', N'', N'')
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Notas], [Calle], [Email], [Ciudad], [Codigopostal], [TelefonoPrincipal], [TelefonoDos], [Telefonotres], [Abreviatura], [TotalOrden], [Fecha], [EmpleadoInserta], [Visitas], [FechaModificacion], [Empleadoactualiza]) VALUES (1003, N'Marcos', N'', N'', N'Prueba', N'', N'', N'87897898', N'', N'', N'', N'', N'', N'', N'1', N'', N'')
SET IDENTITY_INSERT [dbo].[Clientes] OFF
INSERT [dbo].[Productos] ([CodigoId], [Nombre], [Categoria], [Provedor], [PrecioCompra], [PrecioVenta], [Cantidad], [Imagen], [Ventas_VentaId]) VALUES (12345, N'Jugo', N'Refresco', N'Coca-Cola', 800, 1200, 5, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarrasProductos\12345.png', NULL)
INSERT [dbo].[Estados] ([EstadoId], [Nombre]) VALUES (1, N'Pedidos Completados')
INSERT [dbo].[Estados] ([EstadoId], [Nombre]) VALUES (2, N'Recogida pero no págada en su totalidad')
INSERT [dbo].[Estados] ([EstadoId], [Nombre]) VALUES (3, N'Cotizacion/Recerva')
INSERT [dbo].[Estados] ([EstadoId], [Nombre]) VALUES (4, N'Recogida Y el Saldo Pendiente Pagado')
INSERT [dbo].[Estados] ([EstadoId], [Nombre]) VALUES (5, N'No Recogida Y el Saldo Pendiente Pagado')
INSERT [dbo].[Estados] ([EstadoId], [Nombre]) VALUES (6, N'No Recogida Y el Saldo no  Pagado')
SET IDENTITY_INSERT [dbo].[Ordenes] ON 

INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (2036, N'2036', CAST(N'2019-02-11T00:00:00.000' AS DateTime), N'17:30', N'', N'13/2/2019 ', 4165, 2000, 2165, N'Rosa', 1, 1, N'Rosa', N'Rosa')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (2037, N'2037', CAST(N'2019-02-11T17:07:33.650' AS DateTime), N'16:30', N'', N'13/2/2019 ', 4505, 4505, 0, N'Rosa', 4, 1, N'Rosa', N'Rosa')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (2038, N'', CAST(N'2019-02-12T09:57:03.377' AS DateTime), N'', N'', N'', 0, 0, 0, N'', NULL, 6, N'', N'')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (2039, N'', CAST(N'2019-02-12T10:00:47.067' AS DateTime), N'', N'', N'', 0, 0, 0, N'', NULL, 6, N'', N'')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (2040, N'', CAST(N'2019-02-12T10:02:06.497' AS DateTime), N'', N'', N'', 0, 0, 0, N'', NULL, 6, N'', N'')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (2041, N'', CAST(N'2019-02-12T10:03:15.010' AS DateTime), N'', N'', N'', 0, 0, 0, N'', NULL, 6, N'', N'')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (2042, N'', CAST(N'2019-02-12T10:07:28.827' AS DateTime), N'', N'', N'', 0, 0, 0, N'', NULL, 6, N'', N'')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (2043, N'', CAST(N'2019-02-12T10:09:11.900' AS DateTime), N'', N'', N'', 0, 0, 0, N'', NULL, 6, N'', N'')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (2044, N'', CAST(N'2019-02-12T10:11:43.837' AS DateTime), N'', N'', N'', 0, 0, 0, N'', NULL, 6, N'', N'')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (2045, N'', CAST(N'2019-02-12T10:15:09.360' AS DateTime), N'', N'', N'', 5300, 0, 0, N'', NULL, 6, N'', N'')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (2046, N'2046', CAST(N'2019-02-12T10:19:01.673' AS DateTime), N'17:30', N'', N'14/2/2019 ', 5300, 2000, 3300, N'Rosa', 1002, 6, N'', N'')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (2047, N'2047', CAST(N'2019-02-12T10:22:34.977' AS DateTime), N'17:30', N'', N'14/2/2019 ', 1600, 1000, 600, N'Rosa', 1003, 6, N'', N'')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (2048, N'2048', CAST(N'2019-02-14T11:15:38.283' AS DateTime), N'17:30', N'', N'16/2/2019 ', 3700, 3700, 0, N'Rosa', 1, 1, N'Rosa', N'Rosa')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (2049, N'2049', CAST(N'2019-02-14T11:27:19.527' AS DateTime), N'17:30', N'', N'16/2/2019 ', 1600, 1600, 0, N'Rosa', 1, 1, N'Rosa', N'Rosa')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (2050, N'2050', CAST(N'2019-02-14T11:31:53.767' AS DateTime), N'17:45', N'', N'16/2/2019 ', 1600, 1600, 0, N'Rosa', 1, 1, N'Rosa', N'Rosa')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (2051, N'2051', CAST(N'2019-02-14T11:54:45.090' AS DateTime), N'17:30', N'', N'16/2/2019 ', 9800, 5000, 4800, N'Rosa', 1, 1, N'Arturo', N'Arturo')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (2052, N'2052', CAST(N'2019-02-14T12:05:43.863' AS DateTime), N'17:30', N'', N'16/2/2019 ', 9800, 6000, 3800, N'Rosa', 1, 1, N'Arturo', N'Arturo')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (2053, N'2053', CAST(N'2019-02-14T12:20:03.587' AS DateTime), N'15:00', N'', N'16/2/2019 ', 1600, 1600, 0, N'Rosa', 1, 1, N'Rosa', N'Rosa')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (3048, N'3048', CAST(N'2019-02-15T11:35:13.487' AS DateTime), N'17:30', N'', N'17/2/2019 ', 5300, 3000, 2300, N'Rosa', 1, 1, N'Rosa', N'Rosa')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (3049, N'3049', CAST(N'2019-02-15T11:43:29.350' AS DateTime), N'17:30', N'', N'17/2/2019 ', 4500, 3000, 1500, N'Rosa', 1, 1, N'Rosa', N'Rosa')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (3050, N'3050', CAST(N'2019-02-15T11:47:22.603' AS DateTime), N'17:30', N'', N'17/2/2019 ', 5300, 3000, 2300, N'Rosa', 1, 1, N'Rosa', N'Rosa')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (3051, N'3051', CAST(N'2019-02-15T12:00:59.377' AS DateTime), N'15:00', N'', N'17/2/2019 ', 4500, 4000, 500, N'Rosa', 1, 1, N'Rosa', N'Rosa')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (3052, N'3052', CAST(N'2019-02-15T12:39:12.410' AS DateTime), N'17:30', N'', N'17/2/2019 ', 9125, 6000, 3125, N'Arturo', 1, 1, N'Rosa', N'Rosa')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (3053, N'3053', CAST(N'2019-02-15T13:12:38.377' AS DateTime), N'17:45', N'', N'17/2/2019 ', 4500, 3000, 1500, N'Rosa', 1, 1, N'Rosa', N'Rosa')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (3054, N'3054', CAST(N'2019-02-15T13:34:45.417' AS DateTime), N'15:00', N'', N'15/2/2019', 9800, 4000, 5800, N'Rosa', 1, 6, N'', N'')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (3055, N'', CAST(N'2019-02-15T15:42:31.807' AS DateTime), N'', N'', N'', 0, 0, 0, N'', NULL, 6, N'', N'')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (3056, N'3056', CAST(N'2019-02-15T15:42:45.630' AS DateTime), N'15:00', N'', N'17/2/2019 ', 8700, 4000, 4700, N'Rosa', 1, 6, N'', N'')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (4048, N'4048', CAST(N'2019-02-16T11:49:18.410' AS DateTime), N'17:30', N'', N'18/2/2019 ', 6000, 4000, 2000, N'Rosa', 1, 1, N'Rosa', N'Rosa')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (4049, N'4049', CAST(N'2019-02-18T10:50:16.020' AS DateTime), N'17:30', N'', N'20/2/2019 ', 4500, 3000, 1500, N'Rosa', 1, 6, N'', N'')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (4050, N'4050', CAST(N'2019-02-18T11:12:11.073' AS DateTime), N'17:30', N'', N'20/2/2019 ', 6000, 3000, 3000, N'Rosa', 1, 6, N'', N'')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (4051, N'4051', CAST(N'2019-02-18T11:19:21.173' AS DateTime), N'17:30', N'', N'20/2/2019 ', 6000, 4000, 2000, N'Rosa', 1, 6, N'', N'')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (4052, N'4052', CAST(N'2019-02-18T11:30:55.653' AS DateTime), N'17:45', N'', N'20/2/2019 ', 4000, 2000, 2000, N'Arturo', 1, 6, N'', N'')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (4053, N'4053', CAST(N'2019-02-18T11:38:52.440' AS DateTime), N'17:45', N'', N'20/2/2019 ', 6000, 6000, 0, N'Rosa', 1, 5, N'', N'')
INSERT [dbo].[Ordenes] ([OrdenId], [NumeroOrden], [FeEnt], [HoraSalida], [Localizacion], [FechaSalida], [TotalOrden], [CantidadPagada], [CantidadRestante], [EmpleadoRealizo], [ClienteId], [EstadoId], [EmpleadoActualizo], [EmpleadoCompleto]) VALUES (4054, N'4054', CAST(N'2019-02-18T13:39:11.823' AS DateTime), N'15:00', N'', N'20/2/2019 ', 7825, 7825, 0, N'Rosa', 1, 5, N'', N'')
SET IDENTITY_INSERT [dbo].[Ordenes] OFF
SET IDENTITY_INSERT [dbo].[CodigoBarras] ON 

INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (1032, 2036, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\2036.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (1033, 2037, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\2037.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (1034, 2038, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\2038.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (1035, 2039, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\2039.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (1036, 2040, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\2040.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (1037, 2041, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\2041.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (1038, 2042, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\2042.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (1039, 2043, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\2043.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (1040, 2044, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\2044.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (1041, 2045, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\2045.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (1042, 2046, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\2046.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (1043, 2047, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\2047.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (1044, 2048, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\2048.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (1045, 2049, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\2049.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (1046, 2050, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\2050.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (1047, 2051, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\2051.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (1048, 2052, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\2052.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (1049, 2053, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\2053.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (2044, 3048, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\3048.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (2045, 3049, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\3049.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (2046, 3050, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\3050.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (2047, 3051, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\3051.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (2048, 3052, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\3052.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (2049, 3053, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\3053.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (2050, 3054, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\3054.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (2051, 3055, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\3055.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (2052, 3056, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\3056.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (3044, 4048, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\4048.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (3045, 4049, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\4049.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (3046, 4050, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\4050.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (3047, 4051, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\4051.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (3048, 4052, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\4052.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (3049, 4053, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\4053.png')
INSERT [dbo].[CodigoBarras] ([CodigoId], [OrdenId], [Imagen]) VALUES (3050, 4054, N'C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\4054.png')
SET IDENTITY_INSERT [dbo].[CodigoBarras] OFF
SET IDENTITY_INSERT [dbo].[MediosPagoes] ON 

INSERT [dbo].[MediosPagoes] ([MedioPagoId], [FormaPago], [CodigosCuentas], [VisualizarOrden], [TipoMedio], [AbrirCajon], [IncluirTotal]) VALUES (1, N'Efectivo', N'', N'0', N'Prueba', 1, 1)
INSERT [dbo].[MediosPagoes] ([MedioPagoId], [FormaPago], [CodigosCuentas], [VisualizarOrden], [TipoMedio], [AbrirCajon], [IncluirTotal]) VALUES (3, N'Tarjeta', N'', N'0', N'Tarjeta', 1, 1)
SET IDENTITY_INSERT [dbo].[MediosPagoes] OFF
SET IDENTITY_INSERT [dbo].[Pagos] ON 

INSERT [dbo].[Pagos] ([PagoId], [Fecha], [Monto], [EmpleadoRealizo], [Puntos], [MedioPagoId], [OrdenId]) VALUES (1013, CAST(N'2019-02-11T00:00:00.000' AS DateTime), 2000, N'Rosa', N'0', 3, 2036)
INSERT [dbo].[Pagos] ([PagoId], [Fecha], [Monto], [EmpleadoRealizo], [Puntos], [MedioPagoId], [OrdenId]) VALUES (1014, CAST(N'2019-02-11T00:00:00.000' AS DateTime), 4505, N'Rosa', N'0', 3, 2037)
INSERT [dbo].[Pagos] ([PagoId], [Fecha], [Monto], [EmpleadoRealizo], [Puntos], [MedioPagoId], [OrdenId]) VALUES (1015, CAST(N'2019-02-12T00:00:00.000' AS DateTime), 2000, N'Rosa', N'0', 3, 2046)
INSERT [dbo].[Pagos] ([PagoId], [Fecha], [Monto], [EmpleadoRealizo], [Puntos], [MedioPagoId], [OrdenId]) VALUES (1016, CAST(N'2019-02-12T00:00:00.000' AS DateTime), 1000, N'Rosa', N'0', 3, 2047)
INSERT [dbo].[Pagos] ([PagoId], [Fecha], [Monto], [EmpleadoRealizo], [Puntos], [MedioPagoId], [OrdenId]) VALUES (1017, CAST(N'2019-02-14T00:00:00.000' AS DateTime), 3700, N'Rosa', N'0', 3, 2048)
INSERT [dbo].[Pagos] ([PagoId], [Fecha], [Monto], [EmpleadoRealizo], [Puntos], [MedioPagoId], [OrdenId]) VALUES (1018, CAST(N'2019-02-14T00:00:00.000' AS DateTime), 1600, N'Rosa', N'0', 3, 2049)
INSERT [dbo].[Pagos] ([PagoId], [Fecha], [Monto], [EmpleadoRealizo], [Puntos], [MedioPagoId], [OrdenId]) VALUES (1019, CAST(N'2019-02-14T00:00:00.000' AS DateTime), 1600, N'Rosa', N'0', 3, 2050)
INSERT [dbo].[Pagos] ([PagoId], [Fecha], [Monto], [EmpleadoRealizo], [Puntos], [MedioPagoId], [OrdenId]) VALUES (1020, CAST(N'2019-02-14T00:00:00.000' AS DateTime), 5000, N'Rosa', N'0', 3, 2051)
INSERT [dbo].[Pagos] ([PagoId], [Fecha], [Monto], [EmpleadoRealizo], [Puntos], [MedioPagoId], [OrdenId]) VALUES (1021, CAST(N'2019-02-14T00:00:00.000' AS DateTime), 6000, N'Rosa', N'0', 3, 2052)
INSERT [dbo].[Pagos] ([PagoId], [Fecha], [Monto], [EmpleadoRealizo], [Puntos], [MedioPagoId], [OrdenId]) VALUES (1022, CAST(N'2019-02-14T00:00:00.000' AS DateTime), 1600, N'Rosa', N'0', 1, 2053)
INSERT [dbo].[Pagos] ([PagoId], [Fecha], [Monto], [EmpleadoRealizo], [Puntos], [MedioPagoId], [OrdenId]) VALUES (2017, CAST(N'2019-02-15T00:00:00.000' AS DateTime), 3000, N'Rosa', N'0', 3, 3048)
INSERT [dbo].[Pagos] ([PagoId], [Fecha], [Monto], [EmpleadoRealizo], [Puntos], [MedioPagoId], [OrdenId]) VALUES (2018, CAST(N'2019-02-15T00:00:00.000' AS DateTime), 3000, N'Rosa', N'0', 1, 3049)
INSERT [dbo].[Pagos] ([PagoId], [Fecha], [Monto], [EmpleadoRealizo], [Puntos], [MedioPagoId], [OrdenId]) VALUES (2019, CAST(N'2019-02-15T00:00:00.000' AS DateTime), 3000, N'Rosa', N'0', 1, 3050)
INSERT [dbo].[Pagos] ([PagoId], [Fecha], [Monto], [EmpleadoRealizo], [Puntos], [MedioPagoId], [OrdenId]) VALUES (2020, CAST(N'2019-02-15T00:00:00.000' AS DateTime), 4000, N'Rosa', N'0', 3, 3051)
INSERT [dbo].[Pagos] ([PagoId], [Fecha], [Monto], [EmpleadoRealizo], [Puntos], [MedioPagoId], [OrdenId]) VALUES (2021, CAST(N'2019-02-15T00:00:00.000' AS DateTime), 6000, N'Arturo', N'0', 3, 3052)
INSERT [dbo].[Pagos] ([PagoId], [Fecha], [Monto], [EmpleadoRealizo], [Puntos], [MedioPagoId], [OrdenId]) VALUES (2022, CAST(N'2019-02-15T00:00:00.000' AS DateTime), 3000, N'Rosa', N'0', 1, 3053)
INSERT [dbo].[Pagos] ([PagoId], [Fecha], [Monto], [EmpleadoRealizo], [Puntos], [MedioPagoId], [OrdenId]) VALUES (2023, CAST(N'2019-02-15T00:00:00.000' AS DateTime), 4000, N'Rosa', N'0', 1, 3054)
INSERT [dbo].[Pagos] ([PagoId], [Fecha], [Monto], [EmpleadoRealizo], [Puntos], [MedioPagoId], [OrdenId]) VALUES (2024, CAST(N'2019-02-15T00:00:00.000' AS DateTime), 4000, N'Rosa', N'0', 3, 3056)
INSERT [dbo].[Pagos] ([PagoId], [Fecha], [Monto], [EmpleadoRealizo], [Puntos], [MedioPagoId], [OrdenId]) VALUES (3017, CAST(N'2019-02-16T00:00:00.000' AS DateTime), 4000, N'Rosa', N'0', 1, 4048)
INSERT [dbo].[Pagos] ([PagoId], [Fecha], [Monto], [EmpleadoRealizo], [Puntos], [MedioPagoId], [OrdenId]) VALUES (3018, CAST(N'2019-02-18T00:00:00.000' AS DateTime), 3000, N'Valeria', N'0', 3, 4049)
INSERT [dbo].[Pagos] ([PagoId], [Fecha], [Monto], [EmpleadoRealizo], [Puntos], [MedioPagoId], [OrdenId]) VALUES (3019, CAST(N'2019-02-18T00:00:00.000' AS DateTime), 3000, N'Rosa', N'0', 3, 4050)
INSERT [dbo].[Pagos] ([PagoId], [Fecha], [Monto], [EmpleadoRealizo], [Puntos], [MedioPagoId], [OrdenId]) VALUES (3020, CAST(N'2019-02-18T00:00:00.000' AS DateTime), 4000, N'Rosa', N'0', 3, 4051)
INSERT [dbo].[Pagos] ([PagoId], [Fecha], [Monto], [EmpleadoRealizo], [Puntos], [MedioPagoId], [OrdenId]) VALUES (3021, CAST(N'2019-02-18T00:00:00.000' AS DateTime), 2000, N'Arturo', N'0', 1, 4052)
INSERT [dbo].[Pagos] ([PagoId], [Fecha], [Monto], [EmpleadoRealizo], [Puntos], [MedioPagoId], [OrdenId]) VALUES (3022, CAST(N'2019-02-18T00:00:00.000' AS DateTime), 6000, N'Rosa', N'0', 1, 4053)
SET IDENTITY_INSERT [dbo].[Pagos] OFF
SET IDENTITY_INSERT [dbo].[Prendas] ON 

INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3002, N'Blusa', N'1', N'0', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\blusa.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3003, N'Camisa', N'1', N'2', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\camisa mangas.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3004, N'T-Shirt', N'1', N'3', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\camisa.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3005, N'Enagua', N'1', N'4', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\enagua.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3006, N'Pantalon', N'1', N'5', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\pantalon.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3007, N'Jeans', N'1', N'6', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\jeans.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3008, N'Shorts', N'1', N'7', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\short.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3009, N'Jumper', N'1', N'8', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\jumper.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3010, N'Vestido Casual', N'1', N'9', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\vestido casual.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3011, N'Vestido Fiesta', N'1', N'10', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\vestido fiesta.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3012, N'Enteriso', N'1', N'11', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\enterizo.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3013, N'Vestido Bano', N'1', N'12', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\traje bano.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3014, N'Body/Leotardo', N'1', N'13', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\body-Leotardo.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3015, N'Corset o faja', N'1', N'14', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\corset-faja.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3016, N'Jacket', N'1', N'15', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\jacket.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3017, N'Cardigan', N'1', N'16', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\cardigan.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3018, N'Abrigo/Gabard', N'1', N'17', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\abrigo.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3019, N'Saco', N'1', N'18', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\saco.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3020, N'Chaleco', N'1', N'19', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\chaleco.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3021, N'Jacket Cuero', N'1', N'20', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\jacket cuero.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3022, N'Pantalon Cuero', N'1', N'21', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\cuero pantalon.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3023, N'Enagua Cuero', N'1', N'22', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\enagua cuero.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3024, N'Chaleco Cuero', N'1', N'23', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\chaleco cuero.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3025, N'Cortina/Mantel', N'1', N'24', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\cortina-mantel.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3026, N'Licras', N'1', N'25', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\licra.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3027, N'Carteras/Bolsos', N'1', N'26', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\carteras-bolsos.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3028, N'Edredon', N'1', N'27', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\edredon.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3029, N'Corbatas', N'1', N'29', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\Corbatas.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3030, N'Bufanda', N'1', N'29', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\bufanda.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3031, N'Sombrero', N'1', N'30', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\sombrero.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3032, N'Cinturon', N'1', N'31', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\cinturon.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3033, N'Traje', N'1', N'32', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\traje.png')
INSERT [dbo].[Prendas] ([PrendaId], [TipoRopa], [piezas], [NumeroPrenda], [Imagen]) VALUES (3034, N'Wash & Fold', N'1', N'33', N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\wash & fold.png')
SET IDENTITY_INSERT [dbo].[Prendas] OFF
SET IDENTITY_INSERT [dbo].[TemDetallesOrdenPrendas] ON 

INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (3046, 1, 3003, 2036)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (3047, 1, 3002, 2037)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (3048, 1, 3002, 2042)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (3049, 1, 3003, 2042)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (3050, 1, 3002, 2044)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (3051, 1, 3002, 2045)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (3052, 1, 3002, 2046)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (3053, 1, 3002, 2047)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (3054, 1, 3002, 2048)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (3055, 1, 3002, 2049)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (3056, 1, 3002, 2050)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (3057, 1, 3003, 2051)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (3058, 1, 3002, 2051)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (3059, 1, 3002, 2052)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (3060, 1, 3003, 2052)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (3061, 1, 3002, 2053)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (4054, 1, 3002, 3048)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (4055, 1, 3003, 3049)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (4056, 1, 3002, 3050)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (4057, 1, 3003, 3051)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (4058, 1, 3002, 3052)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (4059, 1, 3003, 3052)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (4060, 1, 3003, 3053)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (4061, 1, 3002, 3053)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (4062, 1, 3003, 3054)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (4063, 1, 3002, 3054)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (4064, 1, 3002, 3056)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (4065, 1, 3003, 3056)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (4066, 1, 3002, 3056)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (5054, 1, 3003, 4048)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (5055, 1, 3002, 4048)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (5056, 1, 3003, 4049)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (5057, 1, 3002, 4050)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (5058, 1, 3002, 4051)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (5059, 1, 3003, 4052)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (5060, 1, 3003, 4053)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (5061, 1, 3003, 4054)
INSERT [dbo].[TemDetallesOrdenPrendas] ([DetalleOrdenPrendaId], [Cantidad], [PrendaId], [OrdenId]) VALUES (5062, 1, 3002, 4054)
SET IDENTITY_INSERT [dbo].[TemDetallesOrdenPrendas] OFF
SET IDENTITY_INSERT [dbo].[Servicios] ON 

INSERT [dbo].[Servicios] ([ServiciosId], [VisualizarServicio], [NombreServicio], [Prefijo], [Impuesto], [Descuentos], [Afiliado], [Alerta], [Habilitar], [ImprimirEtiqueta], [Imagen]) VALUES (2002, N'0', N'Alteraciones', N'A', N'-1', N'0', N'0', 1, 1, 1, N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\alteraciones.png')
INSERT [dbo].[Servicios] ([ServiciosId], [VisualizarServicio], [NombreServicio], [Prefijo], [Impuesto], [Descuentos], [Afiliado], [Alerta], [Habilitar], [ImprimirEtiqueta], [Imagen]) VALUES (2003, N'1', N'Bordado', N'B', N'-1', N'0', N'0', 1, 1, 1, N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\bordado.png')
INSERT [dbo].[Servicios] ([ServiciosId], [VisualizarServicio], [NombreServicio], [Prefijo], [Impuesto], [Descuentos], [Afiliado], [Alerta], [Habilitar], [ImprimirEtiqueta], [Imagen]) VALUES (2004, N'3', N'Confeccion', N'C', N'-1', N'0', N'0', 1, 1, 1, N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\confecciones.png')
INSERT [dbo].[Servicios] ([ServiciosId], [VisualizarServicio], [NombreServicio], [Prefijo], [Impuesto], [Descuentos], [Afiliado], [Alerta], [Habilitar], [ImprimirEtiqueta], [Imagen]) VALUES (2005, N'4', N'Dry Cleaning', N'D', N'-1', N'0', N'0', 1, 1, 1, N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\dry-cleaning.png')
INSERT [dbo].[Servicios] ([ServiciosId], [VisualizarServicio], [NombreServicio], [Prefijo], [Impuesto], [Descuentos], [Afiliado], [Alerta], [Habilitar], [ImprimirEtiqueta], [Imagen]) VALUES (2006, N'5', N'Teñido', N'T', N'-1', N'0', N'0', 1, 1, 1, N'C:\Users\Erickxon\Desktop\Nueva carpeta\Nueva carpeta\Kosturas\Imagenes\tenido.png')
SET IDENTITY_INSERT [dbo].[Servicios] OFF
SET IDENTITY_INSERT [dbo].[Tareas] ON 

INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3003, N'Acortar Manga', N'1', 3002, 2002, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3004, N'Estrechar', N'2', 3002, 2002, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3005, N'Dry Cleaninig', N'35', 3002, 2005, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3006, N'Ruedo', N'0', 3002, 2002, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3007, N'Ensanchar', N'3', 3002, 2002, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3008, N'Boton', N'4', 3002, 2002, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3009, N'Reparar', N'24', 3002, 2002, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3010, N'Planchar', N'10', 3002, 2002, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3011, N'Bordado', N'40', 3002, 2003, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3012, N'Confecionar', N'30', 3002, 2004, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3013, N'Zippers', N'5', 3002, 2002, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3014, N'Reparar Ruedo', N'6', 3002, 2002, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3015, N'Ojal', N'7', 3002, 2002, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3016, N'Escote', N'9', 3002, 2002, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3017, N'Bolsa', N'0', 3002, 2002, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3018, N'Cuello', N'0', 3002, 2002, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3019, N'Repasar Costura', N'39', 3002, 2002, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3020, N'Urgercia', N'38', 3002, 2002, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3021, N'Copas', N'10', 3002, 2002, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3022, N'Teñido', N'50', 3002, 2006, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3023, N'Compra de Materiales', N'60', 3002, 2004, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3024, N'Mangas', N'1', 3003, 2002, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3025, N'Estrechar', N'2', 3003, 2002, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3026, N'Subir Ruedo', N'3', 3003, 2002, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3027, N'Zipper', N'4', 3003, 2002, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3028, N'Ensanchar', N'5', 3003, 2002, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3029, N'Boton', N'15', 3003, 2002, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3030, N'Ojal', N'7', 3003, 2002, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3031, N'Reparar', N'24', 3003, 2002, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3032, N'Dry Cleaning', N'35', 3003, 2005, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3033, N'Planchar', N'20', 3003, 2002, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3034, N'Wash+Iron', N'36', 3003, 2005, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3035, N'Bordado', N'40', 3003, 2003, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3036, N'Bolsa', N'0', 3003, 2002, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3037, N'Cuello', N'0', 3003, 2002, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3038, N'Reparar Costura', N'39', 3003, 2002, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3039, N'Confecionar', N'70', 3003, 2004, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3040, N'Compra Materiales', N'60', 3003, 2004, N'')
INSERT [dbo].[Tareas] ([TareaId], [NombreTareas], [NumeroTarea], [PrendaId], [ServiciosId], [Imagen]) VALUES (3041, N'Teñido', N'50', 3003, 2006, N'')
SET IDENTITY_INSERT [dbo].[Tareas] OFF
SET IDENTITY_INSERT [dbo].[DetalleTareas] ON 

INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3003, 3003, N'Corta', N'1', 3700, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3004, 3003, N'Larga', N'0', 3800, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3005, 3003, N'Larga con Puntos', N'0', 4800, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3006, 3004, N'Costados', N'0', 4900, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3007, 3004, N'Hombros', N'0', 4900, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3008, 3004, N'Mangas', N'0', 3500, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3009, 3004, N'Costados con Forro', N'0', 6900, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3010, 3005, N'Dry Cleaning', N'0', 0, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3011, 3006, N'Maquina', N'0', 3700, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3012, 3006, N'Con Abertura', N'0', 4300, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3013, 3006, N'Cover', N'0', 3700, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3014, 3006, N'A mano', N'0', 4300, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3015, 3007, N'Normal', N'0', 4900, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3016, 3007, N'Una Quilla', N'0', 5900, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3017, 3007, N'Dos Quillas', N'0', 9500, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3018, 3008, N'Boton', N'0', 500, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3019, 3008, N'Broche', N'0', 500, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3020, 3008, N'Gafete/GAncho', N'0', 500, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3021, 3009, N'Reparar', N'0', 0, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3022, 3010, N'Planchar', N'0', 3500, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3023, 3010, N'Plancha cuello Con Almidon', N'0', 4500, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3024, 3011, N'Pequeño 3cm', N'0', 700, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3025, 3011, N'Mediano 10cm', N'0', 1000, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3026, 3011, N'Grande', N'0', 1200, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3027, 3011, N'Especial(Precio a definir)', N'0', 0, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3028, 3011, N'Urgencia', N'0', 1500, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3029, 3012, N'Casual', N'0', 8000, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3030, 3012, N'Vestir', N'2', 100000, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3031, 3012, N'Sencilla sin manga', N'2', 6000, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3032, 3012, N'Urgencia', N'3', 1500, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3033, 3013, N'Normal', N'0', 4300, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3034, 3013, N'Invisible', N'0', 4900, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3035, 3014, N'Reparar Ruedo', N'0', 1600, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3036, 3015, N'Ojal', N'0', 1000, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3037, 3016, N'Modificar', N'0', 5300, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3038, 3017, N'Hacer Bolsa', N'0', 2800, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3039, 3018, N'Cuello Normal', N'0', 5300, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3040, 3018, N'Cuello Completo', N'0', 6000, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3041, 3019, N'Repasar costura', N'0', 1600, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3042, 3020, N'Urgencia', N'0', 1500, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3043, 3021, N'Sencillas', N'0', 2500, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3044, 3022, N'Teñido de Prendas', N'0', 0, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3045, 3023, N'Compra de Tela', N'0', 0, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3046, 3023, N'Otros MAteriales', N'0', 0, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3047, 3024, N'Convertir Mnaga Corta', N'0', 3700, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3048, 3024, N'Acortar MAnga LArga con Puño', N'0', 4800, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3049, 3024, N'Cambiar MAnga 1', N'0', 7000, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3050, 3024, N'Cambiar Manga 2', N'0', 14000, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3051, 3025, N'Costados', N'0', 4900, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3052, 3025, N'Hombros', N'0', 4900, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3053, 3025, N'Mangas', N'0', 3500, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3054, 3026, N'Recto', N'0', 3700, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3055, 3026, N'Abertura', N'0', 4300, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3056, 3026, N'Cover', N'0', 3700, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3057, 3026, N'A mano', N'0', 4300, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3058, 3027, N'Normal', N'0', 4300, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3059, 3027, N'Invisible', N'0', 4300, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3060, 3028, N'Una Quilla Atras', N'0', 4900, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3061, 3028, N'Normal', N'0', 4900, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3062, 3028, N'Dos Quillas Costados', N'0', 9500, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3063, 3029, N'Boton', N'0', 500, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3064, 3030, N'Ojal', N'0', 1000, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3065, 3031, N'Reparar', N'0', 0, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3066, 3032, N'Dry Cleaning', N'0', 0, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3067, 3033, N'Aplanchar', N'0', 4500, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3068, 3034, N'Wash+Iron', N'0', 0, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3069, 3035, N'peque 3 cm', N'0', 700, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3070, 3035, N'Mediano 10cm', N'0', 1000, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3071, 3035, N'Grande', N'0', 1200, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3072, 3035, N'Especial', N'0', 0, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3073, 3036, N'Hacer Bolsa', N'0', 2800, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3074, 3037, N'Cuello Normal', N'0', 5300, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3075, 3037, N'Cuello Completo', N'0', 6300, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3076, 3038, N'Reparar Costura', N'0', 1600, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3077, 3038, N'1 Metro', N'0', 2000, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3078, 3038, N'Vestir', N'0', 10000, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3079, 3038, N'Tirantes', N'0', 6000, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3080, 3039, N'Vestir', N'0', 10000, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3081, 3039, N'Casual', N'0', 8000, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3082, 3040, N'Compra Tela', N'0', 0, N'15', N'')
INSERT [dbo].[DetalleTareas] ([DetalleTareaId], [TareaId], [DetalleTareas], [NumeroDetalleTarea], [Precio], [TiempoRespuesta], [Imagen]) VALUES (3083, 3040, N'Otros Materiales', N'0', 0, N'15', N'')
SET IDENTITY_INSERT [dbo].[DetalleTareas] OFF
SET IDENTITY_INSERT [dbo].[TemDetallesOrdenes] ON 

INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (3046, 0, 0, 4900, 15, N'dejar Un poco corto', 1, N'Rosa', 3060, NULL, 3046)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (3047, 0, 0, 5300, 15, N'', 1, N'Rosa', 3039, NULL, 3047)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (3048, 0, 0, 500, 0, N'', 0, N'', 3018, NULL, 3048)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (3049, 0, 0, 3700, 0, N'', 0, N'', 3047, NULL, 3049)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (3050, 0, 0, 3700, 0, N'', 0, N'', 3003, NULL, 3050)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (3051, 0, 0, 5300, 0, N'', 0, N'', 3039, NULL, 3051)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (3052, 0, 0, 5300, 0, N'', 0, N'', 3039, NULL, 3052)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (3053, 0, 0, 1600, 0, N'', 0, N'', 3041, NULL, 3053)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (3054, 0, 0, 3700, 0, N'', 1, N'Rosa', 3003, NULL, 3054)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (3055, 0, 0, 1600, 0, N'', 1, N'Rosa', 3035, NULL, 3055)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (3056, 0, 0, 1600, 0, N'', 1, N'Rosa', 3035, NULL, 3056)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (3057, 0, 0, 4500, 0, N'', 1, N'Arturo', 3067, NULL, 3057)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (3058, 0, 0, 5300, 0, N'', 1, N'Arturo', 3039, NULL, 3058)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (3059, 0, 0, 5300, 0, N'', 1, N'Arturo', 3039, NULL, 3059)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (3060, 0, 0, 4500, 0, N'', 1, N'Arturo', 3067, NULL, 3060)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (3061, 0, 0, 1600, 0, N'', 1, N'Rosa', 3035, NULL, 3061)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (4054, 0, 0, 5300, 0, N'', 1, N'Rosa', 3039, NULL, 4054)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (4055, 0, 0, 4500, 0, N'', 1, N'Rosa', 3067, NULL, 4055)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (4056, 0, 0, 5300, 0, N'', 1, N'Rosa', 3039, NULL, 4056)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (4057, 0, 0, 4500, 0, N'', 1, N'Rosa', 3067, NULL, 4057)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (4058, 0, 0, 5300, 0, N'', 1, N'Rosa', 3039, NULL, 4058)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (4059, 0, 0, 4500, 15, N'', 1, N'Rosa', 3067, NULL, 4059)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (4060, 0, 0, 4500, 0, N'', 1, N'Rosa', 3067, NULL, 4060)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (4061, 0, 0, 0, 0, N'', 1, N'Rosa', 3044, NULL, 4061)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (4062, 0, 0, 4500, 0, N'', 0, N'', 3067, NULL, 4062)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (4063, 0, 0, 5300, 0, N'', 0, N'', 3039, NULL, 4063)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (4064, 0, 0, 0, 0, N'', 0, N'', 3044, NULL, 4064)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (4065, 0, 0, 700, 0, N'', 0, N'', 3069, NULL, 4065)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (4066, 0, 0, 8000, 0, N'', 0, N'', 3029, NULL, 4066)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (5054, 0, 0, 4500, 0, N'', 1, N'Rosa', 3067, NULL, 5054)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (5055, 0, 0, 1500, 0, N'', 1, N'Rosa', 3028, NULL, 5055)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (5056, 0, 0, 4500, 0, N'', 0, N'', 3067, 4, 5056)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (5057, 0, 0, 6000, 0, N'', 0, N'', 3010, 4, 5057)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (5058, 0, 0, 6000, 0, N'', 0, N'', 3010, 4, 5058)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (5059, 0, 0, 4000, 0, N'', 0, N'', 3066, 4, 5059)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (5060, 0, 0, 6000, 0, N'', 0, N'', 3066, 4, 5060)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (5061, 0, 0, 4500, 15, N'', 0, N'', 3067, NULL, 5061)
INSERT [dbo].[TemDetallesOrdenes] ([DetalleOrdenesId], [Duracion], [Prioridad], [Precio], [Descuento], [Descripcion], [Estado], [EmpleadoActualizo], [DetalleTareaId], [AfiliadoId], [DetalleOrdenPrendaId]) VALUES (5062, 0, 0, 4000, 0, N'', 0, N'', 3010, 4, 5062)
SET IDENTITY_INSERT [dbo].[TemDetallesOrdenes] OFF
SET IDENTITY_INSERT [dbo].[Empleadoes] ON 

INSERT [dbo].[Empleadoes] ([EmpleadoId], [Nombre], [Apellidos], [Alias], [Email], [Activo], [Usuario], [Clave], [SucursalId], [Rol], [RecibirInforme], [ResivirNotifica], [EditPagina], [EditSegundaPagina], [ApcederTarjeta], [EditCreditoClinte], [EditPuntosClinte], [AbrirCajon], [desdelunes], [desdemartes], [desdemiercoles], [desdejueves], [desdeviernes], [desdesabado], [desdedomingo], [hastalunes], [hastamartes], [hastamiercoles], [hastajueves], [hastaviernes], [hastasabado], [hastadomingo]) VALUES (1007, N'Arturo', N'Quesada', N'Arturo', N'r2qp@live.com', 1, N'aquesada05', N'5555', N'1', N'A', 1, 1, 1, 0, 0, 0, 0, 1, CAST(N'07:00:00' AS Time), CAST(N'07:00:00' AS Time), CAST(N'07:00:00' AS Time), CAST(N'07:00:00' AS Time), CAST(N'07:00:00' AS Time), CAST(N'07:00:00' AS Time), CAST(N'07:00:00' AS Time), CAST(N'17:00:00' AS Time), CAST(N'17:00:00' AS Time), CAST(N'17:00:00' AS Time), CAST(N'17:00:00' AS Time), CAST(N'17:00:00' AS Time), CAST(N'17:00:00' AS Time), CAST(N'17:00:00' AS Time))
INSERT [dbo].[Empleadoes] ([EmpleadoId], [Nombre], [Apellidos], [Alias], [Email], [Activo], [Usuario], [Clave], [SucursalId], [Rol], [RecibirInforme], [ResivirNotifica], [EditPagina], [EditSegundaPagina], [ApcederTarjeta], [EditCreditoClinte], [EditPuntosClinte], [AbrirCajon], [desdelunes], [desdemartes], [desdemiercoles], [desdejueves], [desdeviernes], [desdesabado], [desdedomingo], [hastalunes], [hastamartes], [hastamiercoles], [hastajueves], [hastaviernes], [hastasabado], [hastadomingo]) VALUES (1008, N'Rosa', N'Abarca Elizondo', N'Rosa', N'Rosa.abarca@kosturas.com', 1, N'Rosaabarca', N'1234', N'1', N'E', 0, 0, 1, 0, 0, 0, 0, 1, CAST(N'15:00:00' AS Time), CAST(N'15:00:00' AS Time), CAST(N'15:00:00' AS Time), CAST(N'15:00:00' AS Time), CAST(N'15:00:00' AS Time), CAST(N'15:00:00' AS Time), CAST(N'09:00:00' AS Time), CAST(N'17:00:00' AS Time), CAST(N'17:00:00' AS Time), CAST(N'17:00:00' AS Time), CAST(N'17:00:00' AS Time), CAST(N'17:00:00' AS Time), CAST(N'17:00:00' AS Time), CAST(N'17:00:00' AS Time))
INSERT [dbo].[Empleadoes] ([EmpleadoId], [Nombre], [Apellidos], [Alias], [Email], [Activo], [Usuario], [Clave], [SucursalId], [Rol], [RecibirInforme], [ResivirNotifica], [EditPagina], [EditSegundaPagina], [ApcederTarjeta], [EditCreditoClinte], [EditPuntosClinte], [AbrirCajon], [desdelunes], [desdemartes], [desdemiercoles], [desdejueves], [desdeviernes], [desdesabado], [desdedomingo], [hastalunes], [hastamartes], [hastamiercoles], [hastajueves], [hastaviernes], [hastasabado], [hastadomingo]) VALUES (1009, N'Valeria', N'Ramirez Hernandez', N'Valeria', N'vrhdez.98@gmail.com', 1, N'Valeriaramirez', N'3594', N'1', N'C', 0, 0, 1, 0, 0, 0, 0, 1, CAST(N'12:00:00' AS Time), CAST(N'12:00:00' AS Time), CAST(N'12:00:00' AS Time), CAST(N'12:00:00' AS Time), CAST(N'12:00:00' AS Time), CAST(N'12:00:00' AS Time), CAST(N'09:00:00' AS Time), CAST(N'19:00:00' AS Time), CAST(N'19:00:00' AS Time), CAST(N'19:00:00' AS Time), CAST(N'19:00:00' AS Time), CAST(N'19:00:00' AS Time), CAST(N'19:00:00' AS Time), CAST(N'17:00:00' AS Time))
INSERT [dbo].[Empleadoes] ([EmpleadoId], [Nombre], [Apellidos], [Alias], [Email], [Activo], [Usuario], [Clave], [SucursalId], [Rol], [RecibirInforme], [ResivirNotifica], [EditPagina], [EditSegundaPagina], [ApcederTarjeta], [EditCreditoClinte], [EditPuntosClinte], [AbrirCajon], [desdelunes], [desdemartes], [desdemiercoles], [desdejueves], [desdeviernes], [desdesabado], [desdedomingo], [hastalunes], [hastamartes], [hastamiercoles], [hastajueves], [hastaviernes], [hastasabado], [hastadomingo]) VALUES (1010, N'Lidia', N'Zumbado Chacon', N'Lidia', N'Lidiazumbado@gmail.com', 1, N'Lidiazumbado', N'1966', N'1', N'E', 1, 1, 1, 0, 1, 1, 0, 1, CAST(N'09:00:00' AS Time), CAST(N'09:00:00' AS Time), CAST(N'09:00:00' AS Time), CAST(N'09:00:00' AS Time), CAST(N'09:00:00' AS Time), CAST(N'09:00:00' AS Time), CAST(N'09:00:00' AS Time), CAST(N'16:00:00' AS Time), CAST(N'16:00:00' AS Time), CAST(N'16:00:00' AS Time), CAST(N'16:00:00' AS Time), CAST(N'16:00:00' AS Time), CAST(N'17:00:00' AS Time), CAST(N'17:00:00' AS Time))
INSERT [dbo].[Empleadoes] ([EmpleadoId], [Nombre], [Apellidos], [Alias], [Email], [Activo], [Usuario], [Clave], [SucursalId], [Rol], [RecibirInforme], [ResivirNotifica], [EditPagina], [EditSegundaPagina], [ApcederTarjeta], [EditCreditoClinte], [EditPuntosClinte], [AbrirCajon], [desdelunes], [desdemartes], [desdemiercoles], [desdejueves], [desdeviernes], [desdesabado], [desdedomingo], [hastalunes], [hastamartes], [hastamiercoles], [hastajueves], [hastaviernes], [hastasabado], [hastadomingo]) VALUES (1011, N'Grethel', N'Silva Avila', N'Grethel', N'sivagre1229@gmail.com', 1, N'Grethel', N'7777', N'1', N'E', 0, 0, 1, 0, 0, 0, 0, 1, CAST(N'09:00:00' AS Time), CAST(N'09:00:00' AS Time), CAST(N'09:00:00' AS Time), CAST(N'09:00:00' AS Time), CAST(N'09:00:00' AS Time), CAST(N'09:00:00' AS Time), CAST(N'09:00:00' AS Time), CAST(N'16:00:00' AS Time), CAST(N'16:00:00' AS Time), CAST(N'16:00:00' AS Time), CAST(N'17:00:00' AS Time), CAST(N'16:00:00' AS Time), CAST(N'16:00:00' AS Time), CAST(N'17:00:00' AS Time))
INSERT [dbo].[Empleadoes] ([EmpleadoId], [Nombre], [Apellidos], [Alias], [Email], [Activo], [Usuario], [Clave], [SucursalId], [Rol], [RecibirInforme], [ResivirNotifica], [EditPagina], [EditSegundaPagina], [ApcederTarjeta], [EditCreditoClinte], [EditPuntosClinte], [AbrirCajon], [desdelunes], [desdemartes], [desdemiercoles], [desdejueves], [desdeviernes], [desdesabado], [desdedomingo], [hastalunes], [hastamartes], [hastamiercoles], [hastajueves], [hastaviernes], [hastasabado], [hastadomingo]) VALUES (1012, N'Leonor', N'Rocha Bermudez', N'Leonor', N'joscoto01@gmail.com', 1, N'Leonorrocha', N'1647', N'1', N'E', 0, 0, 1, 0, 0, 0, 0, 1, CAST(N'12:00:00' AS Time), CAST(N'12:00:00' AS Time), CAST(N'12:00:00' AS Time), CAST(N'12:00:00' AS Time), CAST(N'12:00:00' AS Time), CAST(N'10:00:00' AS Time), CAST(N'09:00:00' AS Time), CAST(N'19:00:00' AS Time), CAST(N'19:00:00' AS Time), CAST(N'19:00:00' AS Time), CAST(N'19:00:00' AS Time), CAST(N'19:00:00' AS Time), CAST(N'19:00:00' AS Time), CAST(N'17:00:00' AS Time))
INSERT [dbo].[Empleadoes] ([EmpleadoId], [Nombre], [Apellidos], [Alias], [Email], [Activo], [Usuario], [Clave], [SucursalId], [Rol], [RecibirInforme], [ResivirNotifica], [EditPagina], [EditSegundaPagina], [ApcederTarjeta], [EditCreditoClinte], [EditPuntosClinte], [AbrirCajon], [desdelunes], [desdemartes], [desdemiercoles], [desdejueves], [desdeviernes], [desdesabado], [desdedomingo], [hastalunes], [hastamartes], [hastamiercoles], [hastajueves], [hastaviernes], [hastasabado], [hastadomingo]) VALUES (1013, N'Brainer', N'Hidalgo', N'Brai', N'brainerhidalgo@amarusystems.com', 1, N'brai', N'2511', N'1', N'A', 0, 0, 1, 0, 0, 0, 0, 1, CAST(N'07:00:00' AS Time), CAST(N'07:00:00' AS Time), CAST(N'07:00:00' AS Time), CAST(N'07:00:00' AS Time), CAST(N'07:00:00' AS Time), CAST(N'07:00:00' AS Time), CAST(N'07:00:00' AS Time), CAST(N'17:00:00' AS Time), CAST(N'17:00:00' AS Time), CAST(N'17:00:00' AS Time), CAST(N'17:00:00' AS Time), CAST(N'17:00:00' AS Time), CAST(N'17:00:00' AS Time), CAST(N'17:00:00' AS Time))
SET IDENTITY_INSERT [dbo].[Empleadoes] OFF
SET IDENTITY_INSERT [dbo].[Sucursals] ON 

INSERT [dbo].[Sucursals] ([SucursalId], [Nombre], [Activa], [Empleado_EmpleadoId]) VALUES (1, N'dsd<s<sd', 1, NULL)
INSERT [dbo].[Sucursals] ([SucursalId], [Nombre], [Activa], [Empleado_EmpleadoId]) VALUES (3, N'rtwetyuruy', 0, NULL)
INSERT [dbo].[Sucursals] ([SucursalId], [Nombre], [Activa], [Empleado_EmpleadoId]) VALUES (4, N'rt6y3e6u7ytyu8', 0, NULL)
INSERT [dbo].[Sucursals] ([SucursalId], [Nombre], [Activa], [Empleado_EmpleadoId]) VALUES (5, N'hgfyyrtyuuitrf', 0, NULL)
INSERT [dbo].[Sucursals] ([SucursalId], [Nombre], [Activa], [Empleado_EmpleadoId]) VALUES (6, N'rtwe', 0, NULL)
INSERT [dbo].[Sucursals] ([SucursalId], [Nombre], [Activa], [Empleado_EmpleadoId]) VALUES (7, N'rtwetyuruy', 1, NULL)
SET IDENTITY_INSERT [dbo].[Sucursals] OFF
SET IDENTITY_INSERT [dbo].[Afiliadoes] ON 

INSERT [dbo].[Afiliadoes] ([AfiliadoId], [Nombre], [Telefono], [CodigoPostal], [Ciudad], [Calle], [Porsentaje], [Activo], [NumeroOrden], [Correo]) VALUES (3, N'f', N'f', N'f', N'f', N'f', N'f', 1, N'f', N'f')
INSERT [dbo].[Afiliadoes] ([AfiliadoId], [Nombre], [Telefono], [CodigoPostal], [Ciudad], [Calle], [Porsentaje], [Activo], [NumeroOrden], [Correo]) VALUES (4, N'Dry Cleaning', N'f', N'f', N'f', N'f', N'15', 1, N'f', N'f')
SET IDENTITY_INSERT [dbo].[Afiliadoes] OFF
SET IDENTITY_INSERT [dbo].[CierreCajas] ON 

INSERT [dbo].[CierreCajas] ([CierreId], [MontoInicial], [FechaApertura], [FechaCierre], [TotalDiferencia], [EmpleadoCerro], [Notas], [CantidadMonedas5], [CantidadMonedas10], [CantidadMonedas25], [CantidadMonedas50], [CantidadMonedas100], [CantidadMonedas500], [CantidadBilletes1000], [CantidadBilletes2000], [CantidadBilletes5000], [CantidadBilletes10000], [CantidadBilletes20000], [CantidadBilletes50000], [CantidadActualEfectivo], [CantidadIngresoEfectivo], [DiferenciaEfectivo], [CantidadActualTarjetas], [CantidadIngresoTarjetas], [DiferenciaTarjetas], [CantidadActualCheques], [CantidadIngresoCheques], [DiferenciaCheques], [CantidadActualTransferencia], [CantidadIngresoTransferencia], [DiferenciaTransferencia], [CantidadActualOtros], [CantidadIngresoOtros], [DiferenciaOtros]) VALUES (1, 50000, CAST(N'2019-01-23T00:00:00.000' AS DateTime), CAST(N'2019-01-23T00:00:00.000' AS DateTime), 0, N'Rosa', N'', N'7', N'4', N'5', N'2', N'2', N'3', N'7', N'3', N'3', N'2', N'0', N'0', N'0,00', N'0,00 ', N'0,00', N'0,00 ', N'13855,00', N'13855,00', N'0,00 ', N' 0,00 ', N'0,00 ', N'0,00 ', N'0,00 ', N' 0,00 ', N'0,00 ', N' 0,00 ', N' 0,00 ')
INSERT [dbo].[CierreCajas] ([CierreId], [MontoInicial], [FechaApertura], [FechaCierre], [TotalDiferencia], [EmpleadoCerro], [Notas], [CantidadMonedas5], [CantidadMonedas10], [CantidadMonedas25], [CantidadMonedas50], [CantidadMonedas100], [CantidadMonedas500], [CantidadBilletes1000], [CantidadBilletes2000], [CantidadBilletes5000], [CantidadBilletes10000], [CantidadBilletes20000], [CantidadBilletes50000], [CantidadActualEfectivo], [CantidadIngresoEfectivo], [DiferenciaEfectivo], [CantidadActualTarjetas], [CantidadIngresoTarjetas], [DiferenciaTarjetas], [CantidadActualCheques], [CantidadIngresoCheques], [DiferenciaCheques], [CantidadActualTransferencia], [CantidadIngresoTransferencia], [DiferenciaTransferencia], [CantidadActualOtros], [CantidadIngresoOtros], [DiferenciaOtros]) VALUES (2, 50000, CAST(N'2019-01-23T00:00:00.000' AS DateTime), CAST(N'2019-01-23T00:00:00.000' AS DateTime), 0, N'Rosa', N'', N'5', N'5', N'5', N'0', N'8', N'0', N'9', N'0', N'0', N'4', N'0', N'0', N'0,00', N'0,00 ', N'0,00', N'0,00 ', N'13855,00', N'13855,00', N'0,00 ', N' 0,00 ', N'0,00 ', N'0,00 ', N'0,00 ', N' 0,00 ', N'0,00 ', N' 0,00 ', N' 0,00 ')
INSERT [dbo].[CierreCajas] ([CierreId], [MontoInicial], [FechaApertura], [FechaCierre], [TotalDiferencia], [EmpleadoCerro], [Notas], [CantidadMonedas5], [CantidadMonedas10], [CantidadMonedas25], [CantidadMonedas50], [CantidadMonedas100], [CantidadMonedas500], [CantidadBilletes1000], [CantidadBilletes2000], [CantidadBilletes5000], [CantidadBilletes10000], [CantidadBilletes20000], [CantidadBilletes50000], [CantidadActualEfectivo], [CantidadIngresoEfectivo], [DiferenciaEfectivo], [CantidadActualTarjetas], [CantidadIngresoTarjetas], [DiferenciaTarjetas], [CantidadActualCheques], [CantidadIngresoCheques], [DiferenciaCheques], [CantidadActualTransferencia], [CantidadIngresoTransferencia], [DiferenciaTransferencia], [CantidadActualOtros], [CantidadIngresoOtros], [DiferenciaOtros]) VALUES (3, 50000, CAST(N'2019-01-24T00:00:00.000' AS DateTime), CAST(N'2019-01-24T00:00:00.000' AS DateTime), 0, N'Arturo', N'', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'1', N'0,00 ', N'0,00 ', N'0,00', N'13855,00', N'13855,00', N'0,00 ', N'0,00 ', N' 0,00 ', N'0,00 ', N'0,00 ', N'0,00 ', N' 0,00 ', N' 0,00 ', N' 0,00 ', N'0,00 ')
INSERT [dbo].[CierreCajas] ([CierreId], [MontoInicial], [FechaApertura], [FechaCierre], [TotalDiferencia], [EmpleadoCerro], [Notas], [CantidadMonedas5], [CantidadMonedas10], [CantidadMonedas25], [CantidadMonedas50], [CantidadMonedas100], [CantidadMonedas500], [CantidadBilletes1000], [CantidadBilletes2000], [CantidadBilletes5000], [CantidadBilletes10000], [CantidadBilletes20000], [CantidadBilletes50000], [CantidadActualEfectivo], [CantidadIngresoEfectivo], [DiferenciaEfectivo], [CantidadActualTarjetas], [CantidadIngresoTarjetas], [DiferenciaTarjetas], [CantidadActualCheques], [CantidadIngresoCheques], [DiferenciaCheques], [CantidadActualTransferencia], [CantidadIngresoTransferencia], [DiferenciaTransferencia], [CantidadActualOtros], [CantidadIngresoOtros], [DiferenciaOtros]) VALUES (1003, 50000, CAST(N'2019-02-11T11:08:15.250' AS DateTime), CAST(N'2019-02-11T11:01:07.913' AS DateTime), 0, N'Rosa', N'', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'1', N'0,00 ', N'0,00 ', N'0,00', N'0,00 ', N'0,00 ', N'0,00 ', N' 0,00 ', N' 0,00 ', N'0,00 ', N'0,00 ', N'0,00 ', N'0,00 ', N' 0,00 ', N' 0,00 ', N'0,00 ')
SET IDENTITY_INSERT [dbo].[CierreCajas] OFF
INSERT [dbo].[ConfiguracionEnvioCorreos] ([ConfiguracionId], [NombreEmpresa], [Emcabezado], [Dirrecion], [Horario], [PiePagina], [DirrecionLinea1], [DirrecionLinea2], [Telefono], [PaginaWeb], [NumeroEmpresa], [MontoInicialCaja], [CantidadDineroPorHora], [STPMinutos], [CorreoEmpresa], [SMSEmpresa], [ActivoCorreo], [ActivoSMS]) VALUES (1, N'Kosturas', N'{Logo}
Factura Comercial
Kosturas Latinoamerica S.A 
Ced Jur. 3-101-708154
Dir: De la Embajada Americana en 
Rohrmoser 150 metros al Este
Tel: +(506) 2290-7475
Email: Kosturas@outlook.com', N'Estimado Cliente
Su orden ha sido procesada y se le notificara 
cuando este lista para ser retirada.
Denos sus sugerencias en nuestra pagina web ', N'Lun-Vier  9:00 AM-7:00 PM
Sab       9:00 AM-5:00 PM
Dom       Cerrado', N'La(s) prenda(s) se retendra(n) por un mes unicamente.', N'Rohrmoser, de la Embajada Americana', N'150 metros al oeste', N'+506 2290-7475', N'www.Kosturas.net  ', N'', 50000, 11000, N'240', N'Kosturas@outlook.com', N'', 1, 1)
SET IDENTITY_INSERT [dbo].[ImpresionesAutomaticas] ON 

INSERT [dbo].[ImpresionesAutomaticas] ([ImpresionesId], [NumeroImprecion], [TipoImpresion], [Precio], [CodigoBarras], [Servicio]) VALUES (1, N'1', N'Orden', 1, 1, N'Prueba')
INSERT [dbo].[ImpresionesAutomaticas] ([ImpresionesId], [NumeroImprecion], [TipoImpresion], [Precio], [CodigoBarras], [Servicio]) VALUES (2, N'1', N'Orden', 1, 1, N'Prueba')
INSERT [dbo].[ImpresionesAutomaticas] ([ImpresionesId], [NumeroImprecion], [TipoImpresion], [Precio], [CodigoBarras], [Servicio]) VALUES (3, N'gdfyhrt', N'Orden', 1, 1, N'Prueba')
INSERT [dbo].[ImpresionesAutomaticas] ([ImpresionesId], [NumeroImprecion], [TipoImpresion], [Precio], [CodigoBarras], [Servicio]) VALUES (4, N'gdfyhrt', N'Orden', 1, 1, N'Prueba')
INSERT [dbo].[ImpresionesAutomaticas] ([ImpresionesId], [NumeroImprecion], [TipoImpresion], [Precio], [CodigoBarras], [Servicio]) VALUES (5, N'youiuio', N'Orden', 1, 1, N'Prueba')
INSERT [dbo].[ImpresionesAutomaticas] ([ImpresionesId], [NumeroImprecion], [TipoImpresion], [Precio], [CodigoBarras], [Servicio]) VALUES (6, N'youiuio', N'Plantillas De Tienda Determinada', 1, 1, N'Prueba')
INSERT [dbo].[ImpresionesAutomaticas] ([ImpresionesId], [NumeroImprecion], [TipoImpresion], [Precio], [CodigoBarras], [Servicio]) VALUES (1002, N'rwetr', N'Plantillas De Tienda Determinada', 1, 1, N'{ NombreServicio = fgddfsgfdg }')
INSERT [dbo].[ImpresionesAutomaticas] ([ImpresionesId], [NumeroImprecion], [TipoImpresion], [Precio], [CodigoBarras], [Servicio]) VALUES (1003, N'hggfdjug', N'Plantilla Personalizada', 1, 1, N'{ Names = fgddfsgfdg }')
INSERT [dbo].[ImpresionesAutomaticas] ([ImpresionesId], [NumeroImprecion], [TipoImpresion], [Precio], [CodigoBarras], [Servicio]) VALUES (1004, N'ytteuy', N'Orden', 1, 1, N'2')
INSERT [dbo].[ImpresionesAutomaticas] ([ImpresionesId], [NumeroImprecion], [TipoImpresion], [Precio], [CodigoBarras], [Servicio]) VALUES (1005, N'ghyteydru', N'Orden', 1, 1, N'{ Names = yrtrtyrt }')
SET IDENTITY_INSERT [dbo].[ImpresionesAutomaticas] OFF
SET IDENTITY_INSERT [dbo].[Ofertas] ON 

INSERT [dbo].[Ofertas] ([OfertaId], [NumeroOferta], [Descripcion], [DescuentoPorsentaje], [ImporteDescuento], [Habilitar]) VALUES (1, N'0', N'Selecione Una Oferta', 0, N'0', 1)
INSERT [dbo].[Ofertas] ([OfertaId], [NumeroOferta], [Descripcion], [DescuentoPorsentaje], [ImporteDescuento], [Habilitar]) VALUES (2, N'2', N'5% Descuento', 5, N'0', 1)
INSERT [dbo].[Ofertas] ([OfertaId], [NumeroOferta], [Descripcion], [DescuentoPorsentaje], [ImporteDescuento], [Habilitar]) VALUES (3, N'3', N'10% Descuento', 10, N'0', 1)
INSERT [dbo].[Ofertas] ([OfertaId], [NumeroOferta], [Descripcion], [DescuentoPorsentaje], [ImporteDescuento], [Habilitar]) VALUES (4, N'4', N'15% Descuento', 15, N'0', 1)
INSERT [dbo].[Ofertas] ([OfertaId], [NumeroOferta], [Descripcion], [DescuentoPorsentaje], [ImporteDescuento], [Habilitar]) VALUES (5, N'5', N'20% Descuento', 20, N'fggffhg', 1)
SET IDENTITY_INSERT [dbo].[Ofertas] OFF
SET IDENTITY_INSERT [dbo].[OpcionesOrdenes] ON 

INSERT [dbo].[OpcionesOrdenes] ([OpcionesOrdenesId], [NumeroOpcion], [NombreOpcion], [TipoOpcion], [Precio]) VALUES (1, N'rtertyytrytr', N'viefrdtyrf', N'0', N'rtrttrtrytrye')
SET IDENTITY_INSERT [dbo].[OpcionesOrdenes] OFF
SET IDENTITY_INSERT [dbo].[Provedors] ON 

INSERT [dbo].[Provedors] ([ProvedorId], [idServicio], [MontoIngreso], [MontoPago], [FechaIngreso]) VALUES (1, 4, 0, 0, CAST(N'2019-02-18T00:00:00.000' AS DateTime))
INSERT [dbo].[Provedors] ([ProvedorId], [idServicio], [MontoIngreso], [MontoPago], [FechaIngreso]) VALUES (2, 4, 900, 5100, CAST(N'2019-02-18T00:00:00.000' AS DateTime))
INSERT [dbo].[Provedors] ([ProvedorId], [idServicio], [MontoIngreso], [MontoPago], [FechaIngreso]) VALUES (3, 4, 600, 3400, CAST(N'2019-02-18T00:00:00.000' AS DateTime))
INSERT [dbo].[Provedors] ([ProvedorId], [idServicio], [MontoIngreso], [MontoPago], [FechaIngreso]) VALUES (4, 4, 900, 5100, CAST(N'2019-02-18T00:00:00.000' AS DateTime))
INSERT [dbo].[Provedors] ([ProvedorId], [idServicio], [MontoIngreso], [MontoPago], [FechaIngreso]) VALUES (5, 4, 600, 3400, CAST(N'2019-02-18T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Provedors] OFF
INSERT [dbo].[Templeis] ([TempleiId], [TempleiSMS], [TempleiEmail], [DirrecTempleiFactura], [DirrecTempleiVenta], [DirrecTempleiFacturaMaciva], [SubTempleiFactura], [SubTempleiVenta], [SubTempleiFacturaMaciva]) VALUES (1, N'Estimada(o) {FirstName}

Las siguientes ordenes fueron completadas y puede retirarlas en nuestra sucursal de Rohormoser: {OrderId(s)}

Muchas gracias,

{BusinessName}', N'Kosturas Rohrmoser
 <br />

Estimada(o) {ClientName}
 <br />

Las siguientes ordenes de trabajo han sido completadas y estan listas para ser retiradas por usted en nuestra sucursal de Rohormoser: {OrderId(s)}
 <br />
Muchas gracias y que tenga un buen dia,
Por favor no responda a este correo.
 <br />
{BusinessName}
 <br />
{AddressLine1}
 <br />
{AddressLine2}
 <br />
P: {BusinessPhone}
 <br />
W: {BusinessWebsite}
 <br />
E: {BusinessEmail}', N'{BusinessName}
 <br />
{AddressLine1}
 <br />
{AddressLine2}
 <br />
{BusinessWebsite}
 <br />
{BusinessPhone}
 <br />
{BusinessEmail}
 <br />

 <hr />
Factura Comercial
 <hr />
 <br />
Nombre del Cliente: {FirstName}
 <br />
 <hr />
 <br />
Orden Codigo : {OrderId(s)}
 <br />
Detalle de la Orden:
 <br />
{OrderDetails}
 <br />
 <hr />
 <br />
Total:                                                                                      {TotalPrice}
 <br />

Monto Cancelado :                                                                {AmountPaid}
 <br />
Pendiente de Cancelar :                                                         {AmountLeft}
 <br />

Muchas gracias por preferirnos, que tenga un buen dia.
', N'{BusinessName}
 <br />
{AddressLine1}
 <br />
{AddressLine2}
 <br />
{BusinessWebsite}
 <br />
{BusinessEmail}
 <br />
{BusinessPhone}
 <br />
ABN: {BusinessNumber}
 <br />
---------------------------------------------------------------------------------------------
 <br />
                                                              Tax Invoice
 <br />
---------------------------------------------------------------------------------------------
 <br />
Customer Name: {FirstName}
 <br />
---------------------------------------------------------------------------------------------
 <br />
Sale No:{SaleNo}
 <br />

{SaleDetails}
 <br />
---------------------------------------------------------------------------------------------
 <br />
Total:                                                                                    {TotalPrice}
 <br />

Amount Paid:                                                                              {AmountPaid}
 <br />
Amount Left:                                                                              {AmountLeft}', N'{BusinessName}
 <br />
{AddressLine1}
 <br />
{AddressLine2}
 <br />
{BusinessWebsite}
 <br />
{BusinessEmail}
 <br />
{BusinessPhone}
 <br />
---------------------------------------------------------------------------------------------
 <br />
                                                              Invoice
 <br />
---------------------------------------------------------------------------------------------
 <br />
Customer Name: {FirstName}
 <br />
---------------------------------------------------------------------------------------------
 <br />
Order ID: {OrderId(s)}
 <br />

Order Details:
 <br />

{OrderDetails}
 <br />
---------------------------------------------------------------------------------------------
 <br />
Total:                                                                                           {TotalPrice}
 <br />

Amount Paid:                                                                              {AmountPaid}
 <br />
Amount Left:                                                                               {AmountLeft}


', N'Factura Comercial. Kosturas', N'Comprobante de Venta, Kosturas', N'Comprobante de orden: {InvoiceNo} >>> {FromDate} - {ToDate}; DueDate:{PaymentDueDate}')
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([UsuarioId], [Nombre], [Clave], [Perfil]) VALUES (1, N'Brainer', N'ganazo123', N'Administrador')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
