CREATE DATABASE [DB_SistemaRepositorios]

use [DB_SistemaRepositorios]
CREATE TABLE [dbo].[RepositoriosTeste](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NOT NULL,
	[Descricao] [nvarchar](max) NOT NULL,
	[Linguagem] [nvarchar](max) NOT NULL,
	[Dono] [nvarchar](max) NOT NULL,
	[DataAtualizacao] [datetime2](7) NULL,
	[Favorito] [bit] NULL)