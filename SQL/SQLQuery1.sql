Alter table [dbo].[CollegeMaster] add Gender nvarchar(10);
select * from [dbo].[CollegeMaster];
update [dbo].[CollegeMaster] set Gender='Male';
Alter table [dbo].[CollegeMaster] add M1 decimal(10,2);
Alter table [dbo].[CollegeMaster] add M2 decimal(10,2);
Alter table [dbo].[CollegeMaster] add M3 decimal(10,2);
Alter table [dbo].[CollegeMaster] add Total decimal(10,2);
select Name from [dbo].[CollegeMaster] where (M1=100 or M2=100 or M3=100) and Gender='Male' and Department='Btech' ;
Alter table [dbo].[CollegeMaster] add Grade nvarchar(2);
update [dbo].[CollegeMaster] set Grade='A' where M1>=60 and M2>=60 and M3>=60;
update [dbo].[CollegeMaster] set Grade='B' where (M1<60 or M2<60 or M3<60) and(M1>=35 and M2>=35 and M3>=35);
update [dbo].[CollegeMaster] set Grade='F' where M1<35 or M2<35 or M3<35;
update [dbo].[CollegeMaster] set Total=M1+M2+M3;
Select count(*) from [dbo].[CollegeMaster] where Grade='F' and Department='MCA';
Select sum(M1) from [dbo].[CollegeMaster];
Select Min(M2) from [dbo].[CollegeMaster];
Select MAX(M2) from [dbo].[CollegeMaster];
Select AVG(M2) from [dbo].[CollegeMaster];
select * from [dbo].[CollegeMaster] where Grade	in ('A','B');

Select [dbo].[CollegeMaster].Name,[dbo].[Hostel].RoomNo from [dbo].[CollegeMaster] 
inner join [dbo].[Hostel] on [dbo].[CollegeMaster].ID=[dbo].[Hostel].CollegeID 
where [dbo].[CollegeMaster].M1=100 or [dbo].[CollegeMaster].M2=100 or [dbo].[CollegeMaster].M3=100;
