select Sum(Canteen.Bill) as TotalBill from Canteen inner join EmployeeMaster on 
Canteen.EmpId=EmployeeMaster.ID where EmployeeMaster.Name='Sandeep';

Select Sum(Canteen.Bill) as TotalBill from Canteen inner join EmployeeMaster on
Canteen.EmpId=EmployeeMaster.ID where EmployeeMaster.Name='Sandeep' 
and Canteen.Date='2026-01-23';

Select EmployeeMaster.Name from EmployeeMaster inner join Canteen 
on Canteen.EmpId=EmployeeMaster.ID group by (EmployeeMaster.Name) having sum(Canteen.Bill)=(select Max(total) from
(Select Sum(Canteen.Bill) as total from Canteen group By(Canteen.EmpId))t);
