using WinFormsApp2.data.entity;
using MySqlConnector;

namespace WinFormsApp2.data.DAO;

public class StudentDataAccess : DataHelper
{
    public StudentDataAccess()
    {
    }

    public List<Student> GetAll()
    {
        return QueryStudents("");
    }

    public Student? GetById(string studentId)
    {
        return QueryStudents(" WHERE s.`StudentId` = @StudentId", Parameter("@StudentId", studentId))
            .FirstOrDefault();
    }

    public List<Student> GetByClassCode(string classCode)
    {
        return QueryStudents(" WHERE s.`ClassCode` = @ClassCode", Parameter("@ClassCode", classCode));
    }

    public List<Student> SearchByStudentId(string keyword)
    {
        return QueryStudents(
            " WHERE s.`StudentId` LIKE @Keyword",
            Parameter("@Keyword", $"%{keyword}%"));
    }

    public List<Student> Search(string field, string keyword)
    {
        var column = field switch
        {
            "StudentId" => "s.`StudentId`",
            "FullName" => "s.`FullName`",
            "Email" => "s.`Email`",
            "Class" => "s.`ClassCode`",
            _ => null
        };

        return column is null
            ? GetAll()
            : QueryStudents($" WHERE {column} LIKE @Keyword", Parameter("@Keyword", $"%{keyword}%"));
    }

    public void Add(Student student)
    {
        InsertUpdateDelete(
            "INSERT INTO `student` (`StudentId`, `FullName`, `Email`, `DateOfBirth`, `Phone`, `Score`, `Status`, `ClassCode`) " +
            "VALUES (@StudentId, @FullName, @Email, @DateOfBirth, @Phone, @Score, @Status, @ClassCode);",
            StudentParameters(student));
    }

    public void Update(Student student)
    {
        InsertUpdateDelete(
            "UPDATE `student` SET `FullName` = @FullName, `Email` = @Email, `DateOfBirth` = @DateOfBirth, " +
            "`Phone` = @Phone, `Score` = @Score, `Status` = @Status, `ClassCode` = @ClassCode WHERE `StudentId` = @StudentId;",
            StudentParameters(student));
    }

    public bool Delete(string studentId)
    {
        return InsertUpdateDelete(
            "DELETE FROM `student` WHERE `StudentId` = @StudentId;",
            Parameter("@StudentId", studentId)) > 0;
    }

    private List<Student> QueryStudents(string whereClause, params MySqlParameter[] parameters)
    {
        return Select(
            "SELECT s.`StudentId`, s.`FullName`, s.`Email`, s.`DateOfBirth`, s.`Phone`, s.`Score`, s.`Status`, " +
            "s.`ClassCode`, c.`Name` AS `ClassName` FROM `student` s " +
            "LEFT JOIN `class` c ON c.`Code` = s.`ClassCode`" + whereClause + " ORDER BY s.`StudentId`;",
            reader =>
            {
                var student = new Student
                {
                    StudentId = reader.GetString("StudentId"),
                    FullName = reader.GetString("FullName"),
                    Email = reader.GetString("Email"),
                    DateOfBirth = reader.GetDateTime("DateOfBirth"),
                    Phone = reader.GetString("Phone"),
                    Score = reader.GetDouble("Score"),
                    Status = reader.GetString("Status")
                };

                if (!reader.IsDBNull(reader.GetOrdinal("ClassCode")))
                {
                    student.Class = new ClassModel
                    {
                        Code = reader.GetString("ClassCode"),
                        Name = reader.IsDBNull(reader.GetOrdinal("ClassName")) ? string.Empty : reader.GetString("ClassName")
                    };
                    student.Class.Students.Add(student);
                }

                return student;
            },
            parameters);
    }

    private static MySqlParameter[] StudentParameters(Student student)
    {
        return new[]
        {
            Parameter("@StudentId", student.StudentId),
            Parameter("@FullName", student.FullName),
            Parameter("@Email", student.Email),
            Parameter("@DateOfBirth", student.DateOfBirth.Date),
            Parameter("@Phone", student.Phone),
            Parameter("@Score", student.Score),
            Parameter("@Status", student.Status),
            Parameter("@ClassCode", student.Class?.Code)
        };
    }
}
