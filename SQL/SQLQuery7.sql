CREATE FUNCTION GetDepartmentName(@name nvarchar(50))
RETURNS TABLE 
AS
RETURN 
(
	SELECT * from CollegeMaster WHERE Name= @name
);
Select * from GetDepartmentName('Raman');

create function HighestM2()
returns int as 
begin
   declare @maxM2 int
   select @maxM2 = max(M2) from CollegeMaster
   return @maxM2
end
Select HighestM2() as 'Highest M2 Score';

alter table Student add constraint PrimaryKey Primary key(rollNumber,mobile);


create table #student(id int, name nvarchar(50));
create table ##student(id int, name nvarchar(50));
select * from #student;
select * from ##student;

insert into #student values(1,'Raman'),(2,'Rachit')
insert into ##student values(1,'Raman'),(2,'Rachit')

Alter Proc USP_BonusCalculation
as
begin
create table #BonusTemp(EmployeeID int,Salary int,Bonus int);
insert into #BonusTemp(EmployeeID,Salary) select ID,Salary from EmployeeMaster;
update #BonusTemp set Bonus= Salary*15/100;
select * from #BonusTemp;
end
exec USP_BonusCalculation;


Alter Procedure USP_StudentPassByGrace
@grace int,
@GracePass int output,
@Pass int output
as
begin
create table #PassCalculator(Id int,M1 int);
insert into #PassCalculator(Id,M1) select Id,M1 from CollegeMaster;
update #PassCalculator set M1= M1 + @grace where M1<35;
select @Pass=count(*) from CollegeMaster where M1>=35;
select @GracePass=count(*) from #PassCalculator where M1>=35;
end

declare @GracePass int, @Pass int
Exec USP_StudentPassByGrace 
@grace=6,@GracePass=@GracePass output,@Pass= @Pass output
Select @GracePass as 'Pass after Grace', @Pass as 'Pass before Grace';