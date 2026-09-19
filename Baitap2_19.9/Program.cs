class Program
{
    static void Main(string[] args)
    {
        StudentDAO dao = new StudentDAO();


        // =========================
        // ADD STUDENT
        // =========================

        Student s1 = new Student(
            "SV001",
            "Nguyen Van An",
            20,
            "an@gmail.com",
            3.5
        );

        Student s2 = new Student(
            "SV002",
            "Tran Thi Binh",
            21,
            "binh@gmail.com",
            3.8
        );

        dao.Add(s1);
        dao.Add(s2);


        // =========================
        // TEST VALIDATION
        // =========================

        Student s3 = new Student(
            "A",
            "",
            10,
            "abc",
            5
        );

        dao.Add(s3);


        // =========================
        // GET ALL
        // =========================

        Console.WriteLine("\nDanh sách Student:");

        foreach (Student s in dao.GetAlls())
        {
            Console.WriteLine(s);
        }


        // =========================
        // GET BY ID
        // =========================

        Console.WriteLine("\nTìm Student SV001:");

        Student student = dao.GetById("SV001");

        if (student != null)
        {
            Console.WriteLine(student);
        }


        // =========================
        // GET BY NAME
        // =========================

        Console.WriteLine("\nTìm Student có tên An:");

        List<Student> result = dao.GetByName("An");

        foreach (Student s in result)
        {
            Console.WriteLine(s);
        }


        // =========================
        // EDIT
        // =========================

        Student editStudent = new Student(
            "SV001",
            "Nguyen Van An Updated",
            22,
            "an_new@gmail.com",
            3.9
        );

        dao.Edit(editStudent);


        // =========================
        // DELETE
        // =========================

        dao.Delete("SV002");


        Console.WriteLine("\nDanh sách sau khi sửa/xóa:");

        foreach (Student s in dao.GetAlls())
        {
            Console.WriteLine(s);
        }
    }
}