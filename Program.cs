var path = args[0];
var insensitive = "";
var file = args[1];
var text = args[2];
if (args.Length == 4)
{
    insensitive = args[3];
}
int foundLines = 0;
int foundFiles = 0;
int occurences = 0;

if (path == "-i")
{
    path = args[1];
    file = args[2];
    insensitive = args[0];
    text = args[3];
}
else if (file == "-i")
{
    path = args[0];
    file = args[2];
    insensitive = args[1];
    text = args[3];
}
else if (text == "-i")
{
    path = args[0];
    file = args[1];
    insensitive = args[2];
    text = args[3];
}

var names = Directory.GetFiles(path, file);

if (insensitive == "-i")
{
    for (int i = 0; i < names.Length; i++)
    {
        var lines = File.ReadAllLines(names[i]);
        var words = File.ReadAllText(names[i]).Split(" ");
        if (File.ReadAllText(names[i]).ToLower().Contains(text.ToLower()))
        {
            System.Console.WriteLine(names[i]);
            foundFiles++;
            for (int x = 0; x < lines.Length; x++)
            {
                if (lines[x].ToLower().Contains(text.ToLower()))
                {
                    System.Console.WriteLine($"{x + 1}: {lines[x].Replace(text, $">>>{text.ToUpper()}<<<", StringComparison.InvariantCultureIgnoreCase)}");
                    foundLines++;
                }
            }
            for (int y = 0; y < words.Length; y++)
            {
                if (words[y].ToLower().Contains(text.ToLower()))
                {
                    occurences++;
                }
            }
        }
    }
}
else
{
    for (int i = 0; i < names.Length; i++)
    {
        var lines = File.ReadAllLines(names[i]);
        var words = File.ReadAllText(names[i]).Split(" ");
        if (File.ReadAllText(names[i]).Contains(text))
        {
            System.Console.WriteLine(names[i]);
            foundFiles++;
            for (int x = 0; x < lines.Length; x++)
            {
                if (lines[x].Contains(text))
                {
                    System.Console.WriteLine($"{x + 1}: {lines[x].Replace(text, $">>>{text.ToUpper()}<<<")}");
                    foundLines++;
                }
            }
            for (int y = 0; y < words.Length; y++)
            {
                if (words[y].Contains(text))
                {
                    occurences++;
                }
            }
        }
    }
}

System.Console.WriteLine("SUMMARY");
System.Console.WriteLine($"Number of the found Files: {foundFiles}");
System.Console.WriteLine($"Number of the found Lines: {foundLines}");
System.Console.WriteLine($"Number of occurences: {occurences}");

