using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GeydirmeWord
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void copyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(wordpad.Selection.Text))
            {
                Clipboard.SetText(wordpad.Selection.Text);
            }            
        }

        private void cutBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(wordpad.Selection.Text))
            {
                Clipboard.SetText(wordpad.Selection.Text);
                wordpad.Selection.Text = "";
            }
        }

        private void selectAllBtn_Click(object sender, RoutedEventArgs e)
        {
            wordpad.SelectAll();
        }

        private void pasteBtn_Click(object sender, RoutedEventArgs e)
        {
            string text = Clipboard.GetText();
            if (string.IsNullOrEmpty(wordpad.Selection.Text))
            {
                wordpad.AppendText(text);
            }
            else
            {
                wordpad.Selection.Text = text;
            }
        }

        private void okBtn_Click(object sender, RoutedEventArgs e)
        {
            string filePath = FilePathBox.Text;
            string text = File.ReadAllText(filePath);
            if (string.IsNullOrEmpty(wordpad.Selection.Text))
            {
                wordpad.AppendText(text);
            }
            else
            {
                wordpad.Selection.Text = text;
            }
        }
    }
}