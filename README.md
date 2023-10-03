# Auth-API
* C# - Clean Architecture <br>
* Jwt <br>
* Rfc2898DeriveBytes <br>
* AutoMapper <br>

## Config
* Change the DB Connection in appsettings.json <br>
* saltiness = 70 <br>
* nIterations = 10101 <br>

## Endpoints
* Login <br>
* Login using Active Directory <br>
* Logout <br>
* GenerateToken <br>
* GenerateSalt <br>
* HashPassword <br>

## Run SQL Script
```
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_user](
	[Id] [uniqueidentifier] NOT NULL, 
	[Username] [nvarchar](max) NOT NULL, 
	[EmployeeNumber] [nvarchar](max) NOT NULL, 
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL, 
	[Salt] [nvarchar](max) NOT NULL,
	[Hash] [nvarchar](max) NOT NULL, 
	[IsLogin] [bit] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY] 
GO 
INSERT [dbo].[tbl_user] ([Id], [Username], [EmployeeNumber], [FirstName], [LastName], [Salt], [Hash], [IsLogin]) VALUES (N'83ce1196-8406-46b0-965b-d7962bab0743', N'rbaluyut', N'0000001', N'Richard', N'Baluyut', N'9OdzW+aGmaN4Yw0lZcWdDrNzZb9HH64r0EpuvQHGW0rdwftrBUGLq3eKZdeTDyl+mpCS7lGYPIyzjK8K7M8gFKaSo2iFcQ==', N'pdhw1J98Za/YfGnNFWZmZ8TCgj6nQMxbFJLPNN+Rjx+AVkIKLa0CPKO9LYBUYPV3Zc14GaFYOf/wzZbU66wmwggRBb1KnQ==', 1) 
GO 
```
