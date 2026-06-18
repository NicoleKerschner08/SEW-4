using System.Text;

public class EncodingService
{
    public string ToAscii(string txt)
    {
        var bytes = Encoding.UTF8.GetBytes(txt);
        return string.Join(" ", bytes);
    }
}