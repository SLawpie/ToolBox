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
using System.ComponentModel.Composition;

namespace Globalization
{
    /// <summary>
    /// Logika interakcji dla klasy pl_PL.xaml
    /// </summary>
    [ExportMetadata("Culture", "pl-PL")]
    [Export(typeof(ResourceDictionary))]
    public partial class PL : ResourceDictionary
    {
        public PL()
        {
            InitializeComponent();
        }
    }
}
