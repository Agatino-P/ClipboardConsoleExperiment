using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClipExp.Services;
public class StorageService
{
    private readonly string fromFolder;
    private readonly string toFolder;

    public StorageService(string fromFolder = "From\\", string toFolder = ".")
    {
        this.fromFolder = fromFolder;
        this.toFolder = toFolder;
        if(!Directory.Exists(fromFolder))
        {
            Directory.CreateDirectory(fromFolder);
        }
        if (!Directory.Exists(toFolder))
        {
            Directory.CreateDirectory(toFolder);
        }

    }

    public ClipContent Read(string name)
        {
        string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fromFolder, name);
        byte[] byteArray = File.ReadAllBytes(fullPath);
        return new ClipContent(name, byteArray);
    }

    public void Write(ClipContent clipContent)
    {
        File.WriteAllBytes(toFolder + clipContent.Name, clipContent.Bytes);
    }
}
