using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel.Composition;

namespace ToolBox.ViewModels
{
    public class ImportModule
    {
        [ImportMany(typeof(ResourceDictionary))]
        public IEnumerable<Lazy<ResourceDictionary, IDictionary<string, object>>> ResourceDictionaryList { get; set; }
    }
}
