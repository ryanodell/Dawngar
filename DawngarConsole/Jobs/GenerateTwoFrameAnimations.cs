using SixLabors.ImageSharp.Drawing.Processing;
using System.Text.Json;

namespace DawngarConsole;
public class GenerateTwoFrameAnimations : IJob
{
    protected bool createVisuals = false;
    protected const int TILE_SIZE = 16;
    private string INPUT_DIRECTORY = "/home/midwestmystic/Pictures/DawnLikeMerged";
    private string ANIMATIONS_DIRECTORY = "Animations";
    protected readonly string F_Rules = "Characters:*;GUI:*;Items:=Chest;Objects:!Fence/Floor/Tile/Wall";

    public bool Execute(string[] args)
    {
        string[] unitSplit = F_Rules.Split(Tokens.TRANSLATION_UNIT);
        string fullAnimationsDirectory = $"{INPUT_DIRECTORY}/{ANIMATIONS_DIRECTORY}";
        if (!Directory.Exists(fullAnimationsDirectory))
        {
            Directory.CreateDirectory(fullAnimationsDirectory);
        }
        foreach (var unit in unitSplit)
        {
            List<string> filesToProcess = new List<string>();
            string directoryName = unit.Split(Tokens.DIRECTORY_RULES)[0];
            char rule = char.Parse(unit.Substring(unit.IndexOf(Tokens.DIRECTORY_RULES) + 1, 1));
            switch (rule)
            {
                case Tokens.ALL:
                    {
                        filesToProcess.AddRange(Directory.GetFiles($"{INPUT_DIRECTORY}/{directoryName}", "*.png"));
                        break;
                    }
                case Tokens.EQUAL when unit.Split(Tokens.EQUAL).Length > 1:
                    {
                        var individual = unit.Split(Tokens.EQUAL)[1].Split(Tokens.FILE_SEPERATOR);
                        foreach (var item in individual)
                        {
                            filesToProcess.Add($"{INPUT_DIRECTORY}/{directoryName}/{item}.png");
                        }
                        break;
                    }
                case Tokens.NOT_EQUAL when unit.Split(Tokens.NOT_EQUAL).Length > 1:
                    {
                        var individual = unit.Split(Tokens.NOT_EQUAL)[1].Split(Tokens.FILE_SEPERATOR);
                        string[] files = Directory.GetFiles($"{INPUT_DIRECTORY}/{directoryName}", "*.png");
                        foreach (var item in files)
                        {
                            string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(item);
                            if (!individual.Contains(fileNameWithoutExtension))
                            {
                                filesToProcess.Add(item);
                            }
                        }
                        break;
                    }
                default:
                    Console.WriteLine("Invalid rule");
                    break;
            }
            string entityDirectory = $"{fullAnimationsDirectory}/{directoryName}";
            if (!Directory.Exists(entityDirectory) && createVisuals)
            {
                Directory.CreateDirectory(entityDirectory);
            }
            Dictionary<string, List<object>> animationData = new Dictionary<string, List<object>>();
            var bluePen = new SixLabors.ImageSharp.Drawing.Processing.Pen(Color.Blue, 1f);
            var redPen = new SixLabors.ImageSharp.Drawing.Processing.Pen(Color.Red, 1f);
            foreach (var imagePath in filesToProcess)
            {
                string fileName = System.IO.Path.GetFileName(imagePath);
                string outputPath = $"{INPUT_DIRECTORY}/{ANIMATIONS_DIRECTORY}/{directoryName}/{fileName}";
                using (var canvaseReference = Image.Load<Rgba32>(imagePath))
                using (var canvas = Image.Load<Rgba32>(imagePath))
                {
                    var rows = canvas.Height / TILE_SIZE;
                    var columns = canvas.Width / TILE_SIZE;
                    var offset = columns / 2;
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            if (j < offset)
                            {
                                RectangleF rec1 = new RectangleF(j * TILE_SIZE, i * TILE_SIZE, TILE_SIZE, TILE_SIZE);
                                RectangleF rec2 = new RectangleF(j * TILE_SIZE + (offset * TILE_SIZE), i * TILE_SIZE, TILE_SIZE, TILE_SIZE);
                                if (!canvaseReference.IsSectionBlank(rec1) && !canvaseReference.IsSectionBlank(rec2) 
                                        && !canvaseReference.AreTheSame(rec1, rec2))
                                {
                                    var key = $"{j}_{i}";
                                    if (!animationData.ContainsKey(key))
                                    {
                                        animationData.Add(key, new List<object>());
                                    }
                                    animationData[key].Add(new { X = rec1.X, Y = rec1.Y });
                                    animationData[key].Add(new { X = rec2.X, Y = rec2.Y });
                                    canvas.Mutate(ctx => ctx.Draw(bluePen, rec1));
                                    canvas.Mutate(ctx => ctx.Draw(redPen, rec2));
                                }
                            }
                        }
                    }
                    if(createVisuals) 
                    {
                        canvas.Save(outputPath);
                    }
                    string json = JsonSerializer.Serialize(animationData);
                    File.WriteAllText($"{INPUT_DIRECTORY}/{ANIMATIONS_DIRECTORY}/{Path.GetFileNameWithoutExtension(fileName)}.json", json);
                }
                Console.WriteLine($"{Path.GetFileNameWithoutExtension(fileName)} Completed without error");
            }
        }
        return true;
    }

    private static class Tokens
    {
        public const char TRANSLATION_UNIT = ';';
        public const char DIRECTORY_RULES = ':';
        public const char ALL = '*';
        public const char FILE_SEPERATOR = '/';
        public const char NOT_EQUAL = '!';
        public const char EQUAL = '=';
    }
}


#region Original
// using System;

// namespace DawngarConsole;

// public class GenerateTwoFrameAnimations : IJob
// {
//     private string INPUT_DIRECTORY = "/home/midwestmystic/Pictures/DawnLikeMerged";
//     private string ANIMATIONS_DIRECTORY = "/Animations";
//     protected readonly string F_Rules = "Characters:*;GUI:*;Items:=Chest/Test;Objects:!Fence/Floor/Tile/Wall";
//     public bool Execute(string[] args)
//     {
//         string[] unitSplit = F_Rules.Split(Tokens.TRANSLATION_UNIT);
//         foreach(var unit in unitSplit) 
//         {
//             string directory = unit.Split(Tokens.DIRECTORY_RULES)[0];
//             var ruleIndex = unit.IndexOf(Tokens.DIRECTORY_RULES) + 1;
//             var rule = char.Parse(unit.Substring(ruleIndex, 1));
//             if(rule == Tokens.ALL) 
//             {
//                 string[] listOfFiles = Directory.GetFiles($"{INPUT_DIRECTORY}/{directory}", "*.png");
//                 Console.WriteLine("ALL");
//                 foreach(var file in listOfFiles) 
//                 {
//                     Console.WriteLine(file);
//                 }
//             }
//             if(rule == Tokens.EQUAL)
//             {
//                 Console.WriteLine("EQUAL");
//                 var lst = unit.Split(Tokens.EQUAL)[1];
//                 var individual = lst.Split(Tokens.FILE_SEPERATOR);
//                 foreach(var item in individual) {
//                     Console.WriteLine($"{INPUT_DIRECTORY}/{directory}/{item}.png");
//                 }
//             }
//             if(rule == Tokens.NOT_EQUAL)
//             {
//                 Console.WriteLine("NOT_EQUAL");
//                 var lst = unit.Split(Tokens.NOT_EQUAL)[1];
//                 var individual = lst.Split(Tokens.FILE_SEPERATOR);
//                 foreach(var item in individual) {
//                     Console.WriteLine($"{INPUT_DIRECTORY}/{directory}/{item}.png");
//                 }
//             }
//         }
//         return true;
//     }
//     private static class Tokens 
//     {
//         public const char TRANSLATION_UNIT = ';';
//         public const char DIRECTORY_RULES = ':';
//         public const char ALL = '*';
//         public const char FILE_SEPERATOR = '/';
//         public const char NOT_EQUAL = '!';
//         public const char EQUAL = '=';

//     }
// }

#endregion