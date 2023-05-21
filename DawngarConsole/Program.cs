using System.Text.RegularExpressions;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace DawngarConsole;

public class Program
{
    private static IJob? _job;
    public static void Main(string[] args)
    {
        if(args.Length == 0) 
        {
            Console.WriteLine("No arguments have been provided. Shutting down");
            return;
        }
        switch (args[0])
        {
            case "merge" :
                _job = new MergeTextures();
                break;
            case "twoframe" :
                _job = new GenerateTwoFrameAnimations();
                break;
            default:  
                _job = null;
                break;          
        }
        if(_job is null) 
        {
            Console.WriteLine("Failed to initialize job. Shutting down");
            return;
        }
        _job.Execute(args);
    }
}