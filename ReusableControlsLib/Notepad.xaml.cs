using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace ReusableControlsLib;

/// <summary>
/// Interaction logic for Notepad.xaml
/// </summary>
public partial class Notepad : UserControl
{
    public Notepad()
    {
        InitializeComponent();



        CodeParagraph.Inlines.Add(new Run("Code line 1" + Environment.NewLine) { Background = Brushes.Red,  });
        CodeParagraph.Inlines.Add(new Run("Code line 2" + Environment.NewLine) { Background = Brushes.Transparent });
        CodeParagraph.Inlines.Add(new Run("Code line 3" + Environment.NewLine) { Background = Brushes.Blue });
        CodeParagraph.Inlines.Add(new Run("Code line 4" + Environment.NewLine) { Background = Brushes.Gray });
        CodeParagraph.Inlines.Add(new Run("Code line 5" + Environment.NewLine) { Background = Brushes.Purple });
        CodeParagraph.Inlines.Add(new Run("Code line 6" + Environment.NewLine) { Background = Brushes.Transparent });
        CodeParagraph.Inlines.Add(new Run("Code line 7" + Environment.NewLine) { Background = Brushes.Transparent });

        ActiveLineHighlighter.Visibility = Visibility.Collapsed;
    }

    private void DrawHighlightBox(double height)
    {
        ActiveLineHighlighter.Height = height;

        ActiveLineHighlighter.Visibility = Visibility.Visible;
    }
}
