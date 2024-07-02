using System;
using System.IO;

class Program
{
    static readonly string FilePath = "data.txt";

    static void CreateFile(string filePath)
    {
        File.Create(filePath).Close();
    }

    static void WriteToFile(string filePath, string content)
    {
        File.WriteAllText(filePath, content);
    }

    static void ReadFromFile(string filePath)
    {
        string content = File.ReadAllText(filePath);
        Console.WriteLine(content);
    }

    static void AppendToFile(string filePath, string content)
    {
        File.AppendAllText(filePath, content);
    }

    static void DeleteFile(string filePath)
    {
        File.Delete(filePath);
    }

    static void Main(string[] args)
    {
        // Tạo tệp mới
        CreateFile(FilePath);

        // Ghi nội dung vào tệp
        string sampleContent = "This is sample content.";
        WriteToFile(FilePath, sampleContent);

        // Đọc nội dung tệp
        ReadFromFile(FilePath);

        // Nối thêm nội dung vào tệp
        string additionalContent = "\nThis is additional content.";
        AppendToFile(FilePath, additionalContent);

        // Đọc nội dung tệp đã được cập nhật
        ReadFromFile(FilePath);

        // Xóa tệp
        DeleteFile(FilePath);
    }
}