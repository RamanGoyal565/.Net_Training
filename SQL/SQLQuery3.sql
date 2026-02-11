SELECT    *
FROM Library INNER JOIN
BookMaster ON Library.BookId = BookMaster.Id INNER JOIN
CollegeMaster Left JOIN BoysHostel ON CollegeMaster.Id = BoysHostel.StudentId Left JOIN
GirlsHostel ON CollegeMaster.Id = GirlsHostel.StudentId ON Library.StudentId = CollegeMaster.Id
where (BoysHostel.StudentId IS NOT NULL OR GirlsHostel.StudentId IS NOT NULL);

SELECT CollegeMaster.Name, Coalesce(GirlsHostel.RoomNo, BoysHostel.RoomNo) AS RoomNo
FROM Library INNER JOIN BookMaster ON Library.BookId = BookMaster.Id INNER JOIN
CollegeMaster ON Library.StudentId = CollegeMaster.Id 
LEFT JOIN BoysHostel ON CollegeMaster.Id = BoysHostel.StudentId LEFT JOIN
GirlsHostel ON CollegeMaster.Id = GirlsHostel.StudentId 
WHERE (BookMaster.Name = 'Java') and (BoysHostel.StudentId IS NOT NULL 
OR GirlsHostel.StudentId IS NOT NULL);

SELECT Count(Library.BookId) AS NumberOfBooks
FROM CollegeMaster INNER JOIN Library ON CollegeMaster.Id = Library.StudentId
WHERE (CollegeMaster.M1 = 100) OR
(CollegeMaster.M2 = 100) OR (CollegeMaster.M3 = 100);

SELECT COUNT(Distinct(COALESCE (BoysHostel.StudentId, GirlsHostel.StudentId))) AS NumberOfStudents
FROM  BoysHostel Right JOIN CollegeMaster ON BoysHostel.StudentId = CollegeMaster.Id Left JOIN
GirlsHostel ON CollegeMaster.Id = GirlsHostel.StudentId inner JOIN
Library ON CollegeMaster.Id = Library.StudentId
WHERE (BoysHostel.RoomNo = 310) OR (GirlsHostel.RoomNo = 310);

SELECT CollegeMaster.Department
FROM BookMaster INNER JOIN Library ON BookMaster.Id = Library.BookId INNER JOIN
 CollegeMaster AS CollegeMaster ON Library.StudentId = CollegeMaster.Id
WHERE (BookMaster.Name = 'Python');

SELECT CollegeMaster.Phone
FROM CollegeMaster INNER JOIN Library ON Library.StudentId = CollegeMaster.Id inner join
BookMaster ON Library.BookId = BookMaster.Id
WHERE (BookMaster.Name = 'Java');