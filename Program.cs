using HW6.Delegates;

int count = 0;
var numbers = new string[] { "1,9", "1,999", "1,99", "1,9991", "1,9", "1,999", "1,9989", "1,99", "1,999", "1,99999" };

var max = numbers.GetMax(ConvertParametr);
Console.WriteLine($"Коллекция чисел: [{string.Join("; ", numbers)}]");
Console.WriteLine($"Максимальное значение: [{max}] \n");

static float ConvertParametr(string x)
{
    return (float)Convert.ToDouble(x);
}


string path = Directory.GetCurrentDirectory();
var fileDetector = new FileDetector(path);
fileDetector.FileFound += FileDetector_FileFound;

Console.WriteLine($"Директория: {path}");
fileDetector.Detect();

// Поиск максимальных значений
var file = fileDetector.GetMaxLenthFile();
Console.WriteLine($"Самый большой файл: [{file.Name}]  {file.Length / 1024} КБ");



fileDetector.FileFound -= FileDetector_FileFound;

Console.ReadKey();


 void FileDetector_FileFound(object? sender, FileArgs e)
{
    
    Console.WriteLine($"{++count}. [{e.Name}]  {e.Length / 1024} КБ");
    Console.WriteLine("Нажмите Y, чтобы остановить перебор >>> ");

    if (Console.ReadKey().Key == ConsoleKey.Y)
        ((FileDetector)sender)._stopDetection = true;
      
}

