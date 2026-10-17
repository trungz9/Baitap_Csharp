using WinFormsApp2.data.entity;

namespace WinFormsApp2.data.DAO;

public class ClassDataAccess : DataHelper
{
    public ClassDataAccess()
    {
    }

    public List<ClassModel> GetAll()
    {
        return Select(
            "SELECT `Code`, `Name` FROM `class` ORDER BY `Code`;",
            reader => new ClassModel
            {
                Code = reader.GetString("Code"),
                Name = reader.GetString("Name")
            });
    }

    public ClassModel? GetByCode(string code)
    {
        return Select(
            "SELECT `Code`, `Name` FROM `class` WHERE `Code` = @Code LIMIT 1;",
            reader => new ClassModel
            {
                Code = reader.GetString("Code"),
                Name = reader.GetString("Name")
            },
            Parameter("@Code", code)).FirstOrDefault();
    }

    public void Add(ClassModel classModel)
    {
        InsertUpdateDelete(
            "INSERT INTO `class` (`Code`, `Name`) VALUES (@Code, @Name);",
            Parameter("@Code", classModel.Code),
            Parameter("@Name", classModel.Name));
    }

    public void Update(ClassModel classModel)
    {
        InsertUpdateDelete(
            "UPDATE `class` SET `Name` = @Name WHERE `Code` = @Code;",
            Parameter("@Name", classModel.Name),
            Parameter("@Code", classModel.Code));
    }

    public bool HasStudents(string code)
    {
        return ExecuteScalar<long>(
            "SELECT COUNT(*) FROM `student` WHERE `ClassCode` = @Code;",
            Parameter("@Code", code)) > 0;
    }

    public bool Delete(string code)
    {
        return InsertUpdateDelete(
            "DELETE FROM `class` WHERE `Code` = @Code;",
            Parameter("@Code", code)) > 0;
    }
}
