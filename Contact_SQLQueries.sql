
Create Table Contact(
   ContactId int identity(1,1) primary Key,
    FirstName nvarchar (50),
      SurName nvarchar (50),
   ContactNumber Nvarchar(10),
   BirthDate DateTime , 
   UpdateDate DateTime default getDate()
);

Create Table ContactType(
 ContactTypeId int identity(1,1) primary Key,
 Description Nvarchar (120)
);

Create Table ContactDetail(
ContactDetailId int identity(1,1) primary Key,
 Description Nvarchar (120),
 ContactTypeId int FOREIGN KEY REFERENCES ContactType(ContactTypeId),
 ContactId int FOREIGN KEY REFERENCES Contact(ContactId)

);
