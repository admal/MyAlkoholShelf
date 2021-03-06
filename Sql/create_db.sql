USE [master]
GO
/****** Object:  Database [AlkoholShelfTesting]    Script Date: 23.07.2017 13:56:09 ******/
CREATE DATABASE [AlkoholShelfTesting]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AlkoholShelfTesting', FILENAME = N'C:\Users\Adam\AlkoholShelfTesting.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AlkoholShelfTesting_log', FILENAME = N'C:\Users\Adam\AlkoholShelfTesting_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AlkoholShelfTesting].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AlkoholShelfTesting] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AlkoholShelfTesting] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AlkoholShelfTesting] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AlkoholShelfTesting] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AlkoholShelfTesting] SET ARITHABORT OFF 
GO
ALTER DATABASE [AlkoholShelfTesting] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [AlkoholShelfTesting] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [AlkoholShelfTesting] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AlkoholShelfTesting] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AlkoholShelfTesting] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AlkoholShelfTesting] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AlkoholShelfTesting] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AlkoholShelfTesting] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AlkoholShelfTesting] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AlkoholShelfTesting] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AlkoholShelfTesting] SET  ENABLE_BROKER 
GO
ALTER DATABASE [AlkoholShelfTesting] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AlkoholShelfTesting] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AlkoholShelfTesting] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AlkoholShelfTesting] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AlkoholShelfTesting] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AlkoholShelfTesting] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AlkoholShelfTesting] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AlkoholShelfTesting] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AlkoholShelfTesting] SET  MULTI_USER 
GO
ALTER DATABASE [AlkoholShelfTesting] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AlkoholShelfTesting] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AlkoholShelfTesting] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AlkoholShelfTesting] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [AlkoholShelfTesting]
GO
/****** Object:  Table [dbo].[AlkoholInstance]    Script Date: 23.07.2017 13:56:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlkoholInstance](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[ModifiedTime] [datetime] NOT NULL,
	[Quantity] [int] NULL,
	[AlkoholRecipeId] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AlkoholRecipe]    Script Date: 23.07.2017 13:56:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlkoholRecipe](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Recipe] [text] NULL,
	[AdditionalInfo] [text] NULL,
	[PreparationPeriodTicks] [bigint] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
	[CreatedTime] [datetime] NOT NULL,
	[ModifiedTime] [datetime] NOT NULL,
	[AlkoholRecipeDefinitionId] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AlkoholRecipe_Ingredient]    Script Date: 23.07.2017 13:56:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlkoholRecipe_Ingredient](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AlkoholRecipeId] [bigint] NOT NULL,
	[IngredientId] [bigint] NOT NULL,
	[Quantity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AlkoholRecipeDefinition]    Script Date: 23.07.2017 13:56:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlkoholRecipeDefinition](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
	[CreatedById] [bigint] NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[ModifiedTime] [datetime] NOT NULL,
 CONSTRAINT [PK__AlkoholRecipeDefinition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ingredient]    Script Date: 23.07.2017 13:56:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredient](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[ModifiedTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ingredient_IngredientUnit]    Script Date: 23.07.2017 13:56:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredient_IngredientUnit](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IngredientId] [bigint] NOT NULL,
	[IngredientUnitId] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IngredientUnit]    Script Date: 23.07.2017 13:56:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IngredientUnit](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Symbol] [nvarchar](50) NULL,
	[Name] [nvarchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 23.07.2017 13:56:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[FirstName] [nvarchar](256) NULL,
	[LastName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[ModifiedTime] [datetime] NOT NULL,
	[CreatedBy] [bigint] NULL,
 CONSTRAINT [PK__User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User_Ingredient]    Script Date: 23.07.2017 13:56:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Ingredient](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[IngredientId] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User_IngredientUnit]    Script Date: 23.07.2017 13:56:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_IngredientUnit](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[IngredientUnitId] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[AlkoholInstance]  WITH CHECK ADD  CONSTRAINT [FK_AlkoholInstance_AlkoholRecipe] FOREIGN KEY([AlkoholRecipeId])
REFERENCES [dbo].[AlkoholRecipe] ([Id])
GO
ALTER TABLE [dbo].[AlkoholInstance] CHECK CONSTRAINT [FK_AlkoholInstance_AlkoholRecipe]
GO
ALTER TABLE [dbo].[AlkoholRecipe]  WITH CHECK ADD  CONSTRAINT [FK_AlkoholRecipe_AlkoholRecipeDefinition] FOREIGN KEY([AlkoholRecipeDefinitionId])
REFERENCES [dbo].[AlkoholRecipeDefinition] ([Id])
GO
ALTER TABLE [dbo].[AlkoholRecipe] CHECK CONSTRAINT [FK_AlkoholRecipe_AlkoholRecipeDefinition]
GO
ALTER TABLE [dbo].[AlkoholRecipe_Ingredient]  WITH CHECK ADD  CONSTRAINT [FK_AlkoholRecipe_Ingredient_AlkoholRecipe] FOREIGN KEY([AlkoholRecipeId])
REFERENCES [dbo].[AlkoholRecipe] ([Id])
GO
ALTER TABLE [dbo].[AlkoholRecipe_Ingredient] CHECK CONSTRAINT [FK_AlkoholRecipe_Ingredient_AlkoholRecipe]
GO
ALTER TABLE [dbo].[AlkoholRecipe_Ingredient]  WITH CHECK ADD  CONSTRAINT [FK_AlkoholRecipe_Ingredient_Ingredient] FOREIGN KEY([IngredientId])
REFERENCES [dbo].[Ingredient] ([Id])
GO
ALTER TABLE [dbo].[AlkoholRecipe_Ingredient] CHECK CONSTRAINT [FK_AlkoholRecipe_Ingredient_Ingredient]
GO
ALTER TABLE [dbo].[AlkoholRecipeDefinition]  WITH CHECK ADD  CONSTRAINT [FK_AlkoholRecipeDefinition_User] FOREIGN KEY([CreatedById])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[AlkoholRecipeDefinition] CHECK CONSTRAINT [FK_AlkoholRecipeDefinition_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK__User__CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK__User__CreatedBy]
GO
ALTER TABLE [dbo].[User_Ingredient]  WITH CHECK ADD  CONSTRAINT [FK_User_Ingredient_Ingredient] FOREIGN KEY([IngredientId])
REFERENCES [dbo].[Ingredient] ([Id])
GO
ALTER TABLE [dbo].[User_Ingredient] CHECK CONSTRAINT [FK_User_Ingredient_Ingredient]
GO
ALTER TABLE [dbo].[User_Ingredient]  WITH CHECK ADD  CONSTRAINT [FK_User_Ingredient_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[User_Ingredient] CHECK CONSTRAINT [FK_User_Ingredient_User]
GO
ALTER TABLE [dbo].[User_IngredientUnit]  WITH CHECK ADD  CONSTRAINT [FK_User_IngredientUnit_IngredientUnit] FOREIGN KEY([IngredientUnitId])
REFERENCES [dbo].[IngredientUnit] ([Id])
GO
ALTER TABLE [dbo].[User_IngredientUnit] CHECK CONSTRAINT [FK_User_IngredientUnit_IngredientUnit]
GO
ALTER TABLE [dbo].[User_IngredientUnit]  WITH CHECK ADD  CONSTRAINT [FK_User_IngredientUnit_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[User_IngredientUnit] CHECK CONSTRAINT [FK_User_IngredientUnit_User]
GO
USE [master]
GO
ALTER DATABASE [AlkoholShelfTesting] SET  READ_WRITE 
GO
