using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Threading;
using System.Xml;

namespace ListBoxItemContainerStyle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            MyModel = new ObservableCollection<int> { 1, 2, 3, 4 };
            InitializeComponent();
        }

        public ObservableCollection<int> MyModel { get; set; }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            // Display listbox control template.
            hcc1.Content = WpfToXaml(lb.Template);

            // Display listbox item panel template.
            hcc2.Content = WpfToXaml(lb.ItemsPanel);

            // Display listbox item template.
            hcc3.Content = WpfToXaml(lb.ItemTemplate);

            // Display listbox item container style.
            hcc4.Content = WpfToXaml(lb.ItemContainerStyle);

            ListBoxItem lbi = lb.ItemContainerGenerator.ContainerFromItem(lb.Items[0]) as ListBoxItem;

            // Display listboxitem control template.
            hcc5.Content = WpfToXaml(lbi.Template);

            return;
        }

        string WpfToXaml(DispatcherObject dispObj)
        {
            if (dispObj != null)
            {
                // Get the XAML for the template.
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.NewLineOnAttributes = true;
                StringBuilder sb = new StringBuilder();
                XmlWriter writer = XmlWriter.Create(sb, settings);
                XamlWriter.Save(dispObj, writer);

                return sb.ToString();
            }
            else
            {
                return "NULL";
            }
        }
    }
}
