using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ToolBox.Tools
{
    public static class TextBoxInputs
    {
        private static readonly Regex regex = new Regex("[^0-9]+");

        public static bool GetIsDigitOnly(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsDigitOnlyProperty);
        }

        public static void SetIsDigitOnly(DependencyObject obj, bool value)
        {
            obj.SetValue(IsDigitOnlyProperty, value);
        }

        public static readonly DependencyProperty IsDigitOnlyProperty = DependencyProperty.RegisterAttached(
            "IsDigitOnly",
            typeof(bool),
            typeof(TextBoxInputs),
            new UIPropertyMetadata(false, OnDigitOnlyChanged)
            );

        public static void OnDigitOnlyChanged (object sender, DependencyPropertyChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            bool isDigitOnly = (bool)(e.NewValue);

            if (isDigitOnly)
            {
                textBox.PreviewTextInput += BlockNonDigitsChars;
                // Add DataObject.Pasting to textBox
                DataObject.AddPastingHandler(textBox, TextBoxPasting);
            }
            else
            {
                textBox.PreviewTextInput -= BlockNonDigitsChars;
                DataObject.RemovePastingHandler(textBox, TextBoxPasting);
            }

        }

        private static void BlockNonDigitsChars(object sender, TextCompositionEventArgs e)
        {
            foreach (char chr in e.Text)
            {
                if (!Char.IsDigit(chr))
                    e.Handled = true;
            }
        }

        private static bool IsTextAllowed(string text)
        {
            return !regex.IsMatch(text);
        }

        private static void TextBoxPasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
    }
}
