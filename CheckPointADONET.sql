create database RegistrationProfile

create table Account (
	[Login] nvarchar(15) primary key not null,
	[Password] nvarchar(60) not null
)

create table [Profile] (
	[Login] nvarchar(15) primary key not null,
	FirstName nvarchar(15) not null,
	Lastname nvarchar(15) not null,
	Email nvarchar(24),
	PathToImage nvarchar(max)
)

alter table [profile] 
add foreign key ([Login]) references Account([Login])

