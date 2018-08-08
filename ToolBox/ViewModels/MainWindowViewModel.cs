using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ToolBox.Commands;
using WPFLocalizeExtension.Engine;
using WPFLocalizeExtension.Extensions;
using ToolBox.Models;
using ToolBox.Resources.Localization;
using System.Windows.Controls;

namespace ToolBox.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string moduleName = "Module Name";

        private Visibility buttonMenuOpenVisibility = Visibility.Visible;
        private Visibility buttonMenuCloseVisibility = Visibility.Collapsed;

        public MainWindowViewModel()
        {
            Languages = new ObservableCollection<Language>()
            {
                new Language(){Id=0, Code="EN", CultureCode="en-US", Name="English"},
                new Language(){Id=1, Code="PL", CultureCode="pl=PL", Name="polski"}
            };

            //BindPropertyToResource(nameof(ModuleName), nameof(Translation.langDefaultModuleName));
            BindPropertyToResource(nameof(ModuleName), nameof(Translation.langFiltrationArea));
        }

        protected void BindPropertyToResource(string propertyName, string resourceKey)
        {
            WPFLocalizeExtension.Providers.ResxLocalizationProvider resxLocalizationProvider
                = WPFLocalizeExtension.Providers.ResxLocalizationProvider.Instance;

            WPFLocalizeExtension.Providers.ResxLocalizationProvider.SetDefaultAssembly(resxLocalizationProvider, System.Reflection.Assembly.GetCallingAssembly().GetName().Name);
            WPFLocalizeExtension.Providers.ResxLocalizationProvider.SetDefaultDictionary(resxLocalizationProvider, nameof(Translation));

            var targetProperty = this.GetType().GetProperty(propertyName);
            var locBinding = new WPFLocalizeExtension.Extensions.LocTextExtension(resourceKey);

            locBinding.SetBinding(this, targetProperty);
        }

        public string ModuleName
        {
            get
            {
                return moduleName;
            }
            set
            {
                moduleName = value;
                NotifyPropertyChanged();
            }
        }

        private Uri displayPage;

        public Uri  DisplayPage
        {
            get
            {
                return displayPage;
            }
            set
            {
                if (Equals(displayPage, value))
                {
                    return;
                }

                this.displayPage = value;
                NotifyPropertyChanged("DisplayPage");
            }
        }

        public Visibility ButtonMenuOpenVisibility
        {
            get { return buttonMenuOpenVisibility; }
            set
            {
                buttonMenuOpenVisibility = value;
                NotifyPropertyChanged();
            }
        }


        public Visibility ButtonMenuCloseVisibility
        {
            get { return buttonMenuCloseVisibility; }
            set
            {
                buttonMenuCloseVisibility = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand ButtonExit
        {
            get
            {
                return new RelayCommand(ButtonExitExecute);
            }
        }

        private void ButtonExitExecute()
        {
            Application.Current.Shutdown();
        }

        public ICommand ButtonMenuOpenClick
        {
            get
            {
                return new RelayCommand(ButtonMenuOpenExecute);
            }
        }

        public ICommand ButtonMenuCloseClick
        {
            get
            {
                return new RelayCommand(ButtonMenuCloseExecute);
            }
        }

        public ICommand ButtonFiltrationAreaClick
        {
            get
            {
                return new RelayCommand(ButtonFiltrationAreaExecute);
            }
        }

        public ICommand ButtonHomeClick
        {
            get
            {
                return new RelayCommand(ButtonHomeClickExecute);
            }
        }

        private void ButtonMenuOpenExecute()
        {
            ButtonMenuCloseVisibility = Visibility.Visible;
            ButtonMenuOpenVisibility = Visibility.Collapsed;
        }

        private void ButtonMenuCloseExecute()
        {
            ButtonMenuCloseVisibility = Visibility.Collapsed;
            ButtonMenuOpenVisibility = Visibility.Visible;
        }

        private void ButtonFiltrationAreaExecute()
        {
            BindPropertyToResource(nameof(ModuleName), nameof(Translation.langFiltrationArea));
            DisplayPage = new Uri(@"Pages\FiltrationArea.xaml", UriKind.RelativeOrAbsolute);
        }

        private void ButtonHomeClickExecute()
        {
            BindPropertyToResource(nameof(ModuleName), nameof(Translation.langDefaultModuleName));
            DisplayPage = new Uri(@"Pages\Home.xaml", UriKind.RelativeOrAbsolute);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            //if (PropertyChanged != null)
            //{
            //    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            //}
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Language> languages;

        public ObservableCollection<Language> Languages
        {
            get { return languages; }
            set
            {
                languages = value;
                NotifyPropertyChanged();
            }
        }

        private Language singleLanguage;

        public Language SingleLanguage
        {
            get { return singleLanguage; }
            set
            {
                singleLanguage = value;
                NotifyPropertyChanged("ModuleName");
                
                SwitchCulture culture = new SwitchCulture();
                culture.Switch(singleLanguage.CultureCode, out string cultureName);
            }
        }
    }
}
