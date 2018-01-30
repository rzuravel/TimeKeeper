using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TimeKeeper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TimeKeeperVM _VM;

        public MainWindow()
        {
            _VM = new TimeKeeperVM();

            DataContext = _VM;

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _VM.OnAddTime();
        }

        private void TextBox_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is UIElement)
            {
                UIElement Element = sender as UIElement;
            }
        }

        private void ListBox_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            _VM.OnAddTime();
        }

        private void DockPanel_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border)
            {
                Border Element = sender as Border;
                if (Element.DataContext is TimeSpanRecordVM)
                {
                    _VM.OnRemoveTime(Element.DataContext as TimeSpanRecordVM);
                }
            }
        }
    }
}
