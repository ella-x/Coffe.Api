Create table Records
(
id  int IDENTITY(1,1) not null,
Type nvarchar(20) not null,
Bean varchar(10),
Location varchar(10) not null,
DateCreated varchar(10),
NoOfShots varchar(10) not null,
Score int not null,
Price int not null
)