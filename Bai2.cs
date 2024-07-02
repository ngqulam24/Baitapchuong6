using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public double Grade { get; set; }
}

public class StudentManager
{
    public static List<Student> ReadStudentsFromCsv(string filePath)
    {
        var students = new List<Student>();

        using (var reader = new StreamReader(filePath))
        {
            // Bỏ qua tiêu đề
            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                var student = new Student
                {
                    Id = int.Parse(values[0]),
                    Name = values[1],
                    Age = int.Parse(values[2]),
                    Grade = double.Parse(values[3])
                };

                students.Add(student);
            }
        }

        return students;
    }



    public static void WriteStudentsToCsv(string filePath, IEnumerable<Student> students)
    {
        using (var writer = new StreamWriter(filePath))
        {
            // Ghi tiêu đề
            writer.WriteLine("Id,Name,Age,Grade");

            foreach (var student in students)
            {
                writer.WriteLine($"{student.Id},{student.Name},{student.Age},{student.Grade}");
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var students = StudentManager.ReadStudentsFromCsv("students.csv");
        StudentManager.WriteStudentsToCsv("students_output.csv", students);
    }
}