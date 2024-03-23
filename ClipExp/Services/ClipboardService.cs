using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClipExp.Services;
internal class ClipboardService
{
    const string contentType = "ClipExt";
    public bool CheckForContent(string contentType = contentType)
    {
        return Clipboard.ContainsData(contentType);
    }

    public void PasteContent(ClipContent content)
    {
        DataObject data = new DataObject();
        data.SetData(contentType, content);
        Clipboard.SetDataObject(data);

    }
    public ClipContent? GetContent( )
    {
        object? clipData = Clipboard.GetData(contentType);
        ClipContent? to = clipData as ClipContent;
        return to;
    }
}
