using System.Text.Json;
 
var options = new JsonSerializerOptions
{
    WriteIndented = true
};

string fileName = "software.json";
string jsonString = File.ReadAllText(fileName);

List<Software>? softwareList = JsonSerializer.Deserialize<List<Software>>(jsonString, options);

if (softwareList is null)
{
    Console.WriteLine("Не удалось прочитать файл software.json");
    return;
}

Console.WriteLine("Установленное ПО:");
foreach (var item in softwareList)
{
    Console.WriteLine($"- {item.Name} v{item.Version} | Установлено: {item.Installed} " + $"| Категория: {item.Category} | Теги: {string.Join(", ", item.Tags)}");
}

Console.WriteLine();
Console.WriteLine("Добавим новую программу.");

Console.Write("Название: ");
string name = Console.ReadLine() ?? string.Empty;

Console.Write("Версия: ");
string version = Console.ReadLine() ?? string.Empty;

Console.Write("Установлена? (true/false): ");
bool installed = bool.TryParse(Console.ReadLine(), out var parsedInstalled) && parsedInstalled;

Console.Write("Теги (через запятую): ");
string tagsInput = Console.ReadLine() ?? string.Empty;
List<string> tags = tagsInput
    .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
    .ToList();

Console.Write("Категория: ");
string category = Console.ReadLine() ?? string.Empty;

var newSoftware = new Software
{
    Name = name,
    Version = version,
    Installed = installed,
    Tags = tags,
    Category = category
};

softwareList.Add(newSoftware);

string updatedJson = JsonSerializer.Serialize(softwareList, options);
File.WriteAllText("software_updated.json", updatedJson);
Console.WriteLine();
Console.WriteLine("Готово!");
Console.WriteLine("Проверьте файл");

