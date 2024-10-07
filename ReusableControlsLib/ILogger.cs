using System.Windows.Media;

namespace ReusableControlsLib;

public interface ILogger
{
    public enum Options
    {
        None = 0,
        Bold = 1,
        Italic = 1 << 1,
        Underline = 1 << 2,
        Strikethrough = 1 << 3,

        BoldAndItalic = Bold | Italic,
        BoldAndUnderlined = Bold | Underline,
        ItalicAndUnderlined = Italic | Underline,
    }

    public void Log(string message, Brush color, Options options);
    public void Log(string message);
    public void Log(string message, Brush color);
    public void Log(string message, Options options);

    public void LogLine(string message, Brush color, Options options);
    public void LogLine(string message);
    public void LogLine(string message, Brush color);
    public void LogLine(string message, Options options);
}
