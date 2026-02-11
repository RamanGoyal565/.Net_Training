---1) print the phone number of the room number 1 students ( more students)

SELECT CollegeMaster.Phone
FROM CollegeMaster INNER JOIN Hostel ON CollegeMaster.Id = Hostel.CollegeId
WHERE (Hostel.RoomNo = 1);
---2) List the room number of all female/male students

SELECT Hostel.RoomNo
FROM CollegeMaster INNER JOIN Hostel ON CollegeMaster.Id = Hostel.CollegeId
WHERE (CollegeMaster.Gender = 'Male');

SELECT Hostel.RoomNo
FROM CollegeMaster INNER JOIN Hostel ON CollegeMaster.Id = Hostel.CollegeId
WHERE (CollegeMaster.Gender = 'Female');
---3) How many students scored 100 they are belongs to hostel student

Select COUNT(*) from CollegeMaster 
INNER JOIN Hostel ON CollegeMaster.Id = Hostel.CollegeId 
WHERE CollegeMaster.M1=100 
OR CollegeMaster.M2=100 OR CollegeMaster.M3=100;
---4) how many students staying in the room no 2 and print their full information.

Select * from CollegeMaster 
inner join Hostel on 
CollegeMaster.Id=Hostel.CollegeId 
where Hostel.RoomNo=2;
---5) what is the average M1 mark for the room no 2 students.

Select AVG(CollegeMaster.M1) from CollegeMaster 
Inner join Hostel on CollegeMaster.Id=Hostel.CollegeId
where Hostel.RoomNo=2;


Drop table [dbo].[Hostel];

