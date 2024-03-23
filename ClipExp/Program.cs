using ClipExp.Services;
using System.Windows;

namespace ClipExp;

internal class Program
{
    [STAThreadAttribute]
    static void Main(string[] args)
    {
        Clipboard.Clear();

        StorageService storageService = new();
        ClipboardService clipboardService = new();

        ClipContent from= storageService.Read("SampleText.zip");
        clipboardService.PasteContent(from);

        
        if (clipboardService.CheckForContent())
        {
            ClipContent? to = clipboardService.GetContent();
            if (to == null)
            {
                return;
            }
            storageService.Write(to);

            Console.WriteLine("copied");
        }


        Console.WriteLine("Hello, World!");
    }
}
