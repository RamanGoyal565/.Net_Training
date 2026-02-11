create trigger prevent_table_drop
on database
for drop_table
as
begin
Print 'You cannot drop tables in this database.';
rollback;
end
drop trigger prevent_table_drop on database;
drop table CollegeMaster

create table Employee_Audit(
EmpId int not null,
Action nvarchar(50) not null,
ActionDate date not null);

create trigger trigAfterInsertEmployee
on EmployeeMaster
after insert
as
begin 
set nocount on;
insert into employee_Audit(EmpId,Action,ActionDate) Select 
i.Id,'Insert',GetDate()
from inserted as i;
end

insert into EmployeeMaster values(6,'Vasudev',100000,10000,23,15000)
select * from Employee_Audit;
