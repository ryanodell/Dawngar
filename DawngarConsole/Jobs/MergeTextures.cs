using System.Text.RegularExpressions;

namespace DawngarConsole;

public class MergeTextures : IJob
{
    private static Regex _numericRegex = new Regex(@"\d");
    private string INPUT_DIRECTORY = "/home/midwestmystic/Pictures/DawnLike";
    private string OUTPUT_DIRECTORY = "/home/midwestmystic/Pictures/DawnLikeMerged";

    public bool Execute(string[] args)
    {
        string[] dawnlikeDirectory = Directory.GetDirectories(INPUT_DIRECTORY);
        foreach (var directory in dawnlikeDirectory)
        {
            string? dirName = directory.Split("/")?.Last();
            if (!string.IsNullOrEmpty(dirName))
            {
                _validateDirectoryExists(dirName);
            }
            else
            {
                throw new InvalidOperationException("Directories are formatted incorrectly. Confirm '/' has been provided");
            }
            IDictionary<string, List<string>> fileDictionary = new Dictionary<string, List<string>>();
            string[] listOfFiles = Directory.GetFiles(directory, "*.png");
            foreach (var fileNameStr in listOfFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(fileNameStr);
                if (_containsNumbers(fileName))
                {
                    fileName = fileName.Substring(0, fileName.Length - 1);
                }
                if (fileDictionary.ContainsKey(fileName))
                {
                    var currentList = fileDictionary[fileName];
                    currentList.Add(fileNameStr);
                }
                else
                {
                    fileDictionary.Add(fileName, new List<string>() { fileNameStr });
                }
            }
            foreach (var dict in fileDictionary)
            {
                var finalFileName = $"{OUTPUT_DIRECTORY}/{dirName}/{dict.Key}.png";
                Image<Rgba32>? image1 = null;
                Image<Rgba32>? image2 = null;
                foreach (var image in dict.Value)
                {
                    if (image1 == null)
                    {
                        image1 = Image.Load<Rgba32>(image);
                    }
                    else
                    {
                        image2 = Image.Load<Rgba32>(image);
                    }
                }
                Image<Rgba32>? mergedImage = null;
                if (image1 == null)
                {
                    continue;
                }
                if (image2 != null)
                {
                    mergedImage = new Image<Rgba32>(image1.Width + image2.Width, Math.Max(image1.Height, image2.Height));
                    mergedImage.Mutate(x => x.DrawImage(image1, 1f));
                    mergedImage.Mutate(x => x.DrawImage(image2, new Point(image1.Width, 0), 1f));
                }
                else
                {
                    mergedImage = new Image<Rgba32>(image1.Width, image1.Height);
                    mergedImage.Mutate(x => x.DrawImage(image1, 1f));
                }
                mergedImage.Save(finalFileName);
                Console.WriteLine($"{finalFileName} - Successfully Created");
            }
        }
        return true;
    }

    private bool _containsNumbers(string str) => _numericRegex.Match(str).Success;

    private void _validateDirectoryExists(string? dirName)
    {
        string outputDirectoryName = $"{OUTPUT_DIRECTORY}/{dirName}";
        if (!Directory.Exists(outputDirectoryName))
        {
            Console.WriteLine($"{dirName} doesn't exist, creating it..");
            Directory.CreateDirectory(outputDirectoryName);
        }
        else
        {
            Console.WriteLine($"{outputDirectoryName} already exists");
        }
    }
}