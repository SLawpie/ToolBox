using System;
using System.Collections.Generic;
using System.Globalization;
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
using ToolBox.Commands;
using ToolBox.Tools;
using ToolBox.Converters;
using WPFLocalizeExtension.Extensions;
using ToolBox.ViewModels;

namespace ToolBox
{
    /// <summary>
    /// Logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        public void WindowMouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SwitchCulture culture = new SwitchCulture();
            //culture.Switch(CultureInfo.CurrentCulture.Name, out string cultureName);
            culture.Switch("en-US", out string cultureName);
            ComboBoxSelectLanguage.SelectedIndex = 0;
            //culture.Switch("pl-PL", out string cultureName);
            
            ContentPage.Navigate(new System.Uri("pack://application:,,,/ToolBox;component/Pages/FiltrationArea.xaml", UriKind.Absolute));

        }

        private void ButtonMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (GridMenu.Width == 250)
            {
                ButtonCloseMenu.Visibility = Visibility.Collapsed;
                ButtonOpenMenu.Visibility = Visibility.Visible;
                ButtonCloseMenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }
    }
}
