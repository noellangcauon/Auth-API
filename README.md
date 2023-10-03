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
GO <br>
SET ANSI_NULLS ON <br>
GO <br>
SET QUOTED_IDENTIFIER ON <br>
GO <br>
CREATE TABLE [dbo].[tbl_user]( <br>
	[Id] [uniqueidentifier] NOT NULL, <br>
	[Username] [nvarchar](max) NOT NULL, <br>
	[EmployeeNumber] [nvarchar](max) NOT NULL, <br>
	[FirstName] [nvarchar](max) NOT NULL, <br>
	[LastName] [nvarchar](max) NOT NULL, <br>
	[Salt] [nvarchar](max) NOT NULL, <br>
	[Hash] [nvarchar](max) NOT NULL, <br>
	[IsLogin] [bit] NOT NULL <br>
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY] <br>
GO <br>
INSERT [dbo].[tbl_user] ([Id], [Username], [EmployeeNumber], [FirstName], [LastName], [Salt], [Hash], [IsLogin]) VALUES (N'83ce1196-8406-46b0-965b-d7962bab0743', N'rbaluyut', N'0000001', N'Richard', N'Baluyut', <br>N'9OdzW+aGmaN4Yw0lZcWdDrNzZb9HH64r0EpuvQHGW0rdwftrBUGLq3eKZdeTDyl+mpCS7lGYPIyzjK8K7M8gFKaSo2iFcQ==', N'pdhw1J98Za/YfGnNFWZmZ8TCgj6nQMxbFJLPNN+Rjx+AVkIKLa0CPKO9LYBUYPV3Zc14GaFYOf/wzZbU66wmwggRBb1KnQ==', 1) <br>
GO <br>
```
