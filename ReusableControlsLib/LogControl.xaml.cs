using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using static ReusableControlsLib.ILogger;

namespace ReusableControlsLib;

public partial class LogControl : UserControl, INotifyPropertyChanged, ILogger
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    private Paragraph textBuffer;
    public Paragraph TextBuffer
    {
        get => textBuffer;
        set => SetField(ref textBuffer, value);
    }

    public LogControl()
    {
        InitializeComponent();

        TextBuffer = new Paragraph();
        LogTextBox.DataContext = this;
        LogTextBox.Document = new FlowDocument(TextBuffer);
    }

    public void Log(string message, Brush color, Options options)
    {
        Inline line = new Run(message) { Foreground = color };

        if (options.HasFlag(Options.Bold))
            line = new Bold(line);

        if (options.HasFlag(Options.Italic))
            line = new Italic(line);

        if (options.HasFlag(Options.Underline))
            line = new Underline(line);

        if (options.HasFlag(Options.Strikethrough))
            line.TextDecorations = TextDecorations.Strikethrough;

        TextBuffer.Inlines.Add(line);
        LogTextBox.ScrollToEnd();
    }

    public void Log(string message) => Log(message, Brushes.Black, Options.None);
    public void Log(string message, Brush color) => Log(message, color, Options.None);
    public void Log(string message, Options options) => Log(message, Brushes.Black, options);

    public void LogLine(string message, Brush color, Options options) => Log(message + Environment.NewLine, color, options);
    public void LogLine(string message) => LogLine(message, Brushes.Black, Options.None);
    public void LogLine(string message, Brush color) => LogLine(message, color, Options.None);
    public void LogLine(string message, Options options) => LogLine(message, Brushes.Black, options);
}
