with AvgM2ByDept as
(
	select Department, avg(M2) as AvgM2
	from dbo.CollegeMaster
	group by Department
)
Select * from AvgM2ByDept

Select distinct(m3) from CollegeMaster
order by m3 desc
offset 2 rows
fetch next 1 row only;

with DeptWiseMaxM1 as
(
	select Department,sum(M1) as TotalM1
	from CollegeMaster
	group by Department
)
Select Max(TotalM1) from DeptWiseMaxM1;