using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDocumentsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var r1 = new Run("Hello world");
            par1.Inlines.Add(r1);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using(FileStream stream = File.Open(path.Text, FileMode.Create))
            {
                if(viewer.Document != null)
                {
                    XamlWriter.Save(viewer.Document, stream);
                }
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream stream = File.Open(path.Text, FileMode.Open))
            {
                FlowDocument document = XamlReader.Load(stream) as FlowDocument;
                if(document != null)
                {
                    viewer.Document = document;
                }
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            viewer.ClearValue(FlowDocumentScrollViewer.DocumentProperty);
        }
    }
}
