using System;
using System.IO;

namespace HelloApp
{
  class Program
  {
    static void Main(string[] args)
    {
      string path = @"D:\Documents\антон\Test0";
      DirectoryInfo dirInfo = new DirectoryInfo(path);
      if (!dirInfo.Exists)
      {
        dirInfo.Create();
      }
      Console.WriteLine("Введите строку для записи в файл:");
      string text = Console.ReadLine();


      using (FileStream fstream = new FileStream($"{path}\\stringFile.txt", FileMode.OpenOrCreate))
      {
        byte[] array = System.Text.Encoding.Default.GetBytes(text);
        fstream.Write(array, 0, array.Length);
        Console.WriteLine("Строка записан в файл");
      }

      using (FileStream fstream = File.OpenRead($"{path}\\stringFile.txt"))
      {
        byte[] array = new byte[fstream.Length];
        fstream.Read(array, 0, array.Length);

        string textFromFile = System.Text.Encoding.Default.GetString(array);
        Console.WriteLine($"Строка из файла: {textFromFile}");
      }
      Console.WriteLine("Удаление файла");
     
      {
              path = @"D:\Documents\stringinFile.txt";
          FileInfo fileInf = new FileInfo(path);
          if (fileInf.Exists)
          {
            fileInf.Delete();
          }
          Console.WriteLine("Файл удален");
              }
      Console.ReadLine();
    }
  }
}
