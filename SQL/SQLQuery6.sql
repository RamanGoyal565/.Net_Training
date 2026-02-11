Create PROC USP_GetStudentName
As
Begin
	Select * From CollegeMaster
End

EXEC USP_GetStudentName;

Create Procedure USP_GetStudentNameByDept
	@dept NVARCHAR(50),
	@StudentCount int output
	As
	begin
	select @StudentCount = COUNT(*) from CollegeMaster where Department = @dept
	End;


DECLARE @Count INT;

EXEC USP_GetStudentNameByDept 
@dept='BTech', 
@StudentCount = @Count OUTPUT;

Select @Count;

Create PROC USP_GetHostelStudentName
as
Begin
	Select cm.Name, Coalesce(bh.RoomNo,gh.RoomNo)as RoomNo 
	From CollegeMaster cm
	left Join BoysHostel bh ON cm.Id = bh.StudentId
	left join GirlsHostel gh ON cm.Id = gh.StudentId
	where bh.RoomNo IS NOT NULL OR gh.RoomNo IS NOT NULL
End

Exec USP_GetHostelStudentName;

Create PROC USP_GetHostelStudentNameByRoomNo
	@RoomNo Int
	as
	Begin
	Select cm.Name, Coalesce(bh.RoomNo,gh.RoomNo)as RoomNo
	from CollegeMaster cm
	left Join BoysHostel bh ON cm.Id = bh.StudentId
	left join GirlsHostel gh ON cm.Id = gh.StudentId
	where Coalesce(bh.RoomNo,gh.RoomNo) = @RoomNo
	End

Exec USP_GetHostelStudentNameByRoomNo
@RoomNo = 310;


Alter proc USP_CheckAndUpdate100Marks
as
begin
Declare @count int
Select @count=count(*) from CollegeMaster
where M1=100 or M2=100 or M3=100
if(@count<4) 
begin
update CollegeMaster set M2=100,Total=M1+M2+M3 where location='UP' or location='Punjab';
update [dbo].[CollegeMaster] set Grade='A' where M1>=60 and M2>=60 and M3>=60;
update [dbo].[CollegeMaster] set Grade='B' where (M1<60 or M2<60 or M3<60) and(M1>=35 and M2>=35 and M3>=35);
update [dbo].[CollegeMaster] set Grade='F' where M1<35 or M2<35 or M3<35;
end
select * from CollegeMaster;
end
Select * from CollegeMaster;
exec USP_CheckAndUpdate100Marks;

ALTER TABLE Hostel WITH NOCHECK
ADD CONSTRAINT chk_room_limit CHECK (RoomNo <= 100);
Alter proc USP_AddingHostelStudents
@RoomNo int,
@StudentId int
as
begin
insert into Hostel (RoomNo,StudentID) values(@RoomNo,@StudentId);
end
exec USP_AddingHostelStudents @RoomNo=98, @StudentId=2;

ALTER TABLE CollegeMaster WITH NOCHECK
ADD CONSTRAINT Gender CHECK (Gender in ('Male','Female'))
ALTER TABLE CollegeMaster WITH NOCHECK
ADD CONSTRAINT M1 CHECK (M1 between 0 and 100)
ALTER TABLE CollegeMaster WITH NOCHECK
ADD CONSTRAINT M2 CHECK (M2 between 0 and 100)
ALTER TABLE CollegeMaster WITH NOCHECK
ADD CONSTRAINT M3 CHECK (M3 between 0 and 100)
ALTER TABLE CollegeMaster WITH NOCHECK
ADD CONSTRAINT Total CHECK (Total=M1+M2+M3 and Total between 0 and 300)
ALTER TABLE CollegeMaster WITH NOCHECK
ADD CONSTRAINT Grade CHECK (Grade in ('A','B','F'))


select DATEADD(year,1,getdate());

update CollegeMaster set age=DateDiff(year,DOB,GETDATE()); 
select * from CollegeMaster;

alter table CollegeMaster add DOB date;

Create Proc GetNameByDOBMonth
@MonthName nvarchar(20)
as 
begin
select name from CollegeMaster
where  MONTH(DOB)=MONTH(CONVERT(DATETIME,'01-'+@MonthName+'-2000'))
end

exec GetNameByDOBMonth @MonthName='March';