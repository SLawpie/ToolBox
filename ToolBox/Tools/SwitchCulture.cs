using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using WPFLocalizeExtension.Engine;

namespace ToolBox.Tools
{
    public class SwitchCulture
    {
        public void Switch(string culture, out string cultureName)
        {
            CultureInfo ci = CultureInfo.InvariantCulture;
            try
            {
                ci = new CultureInfo(culture);
            }
            catch (CultureNotFoundException)
            {
                try
                {
                    // Try language without region
                    ci = new CultureInfo(culture.Substring(0, 2));
                }
                catch (Exception)
                {
                    ci = CultureInfo.InvariantCulture;
                }
            }
            finally
            {
                LocalizeDictionary.Instance.Culture = ci;
                cultureName = ci.EnglishName;
            }
        }
    }
}
