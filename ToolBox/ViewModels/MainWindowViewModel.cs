using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ToolBox.Commands;
using ToolBox.Models;

namespace ToolBox.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string moduleName = "Module Name";
        private Visibility buttonMenuOpenVisibility = Visibility.Visible;
        private Visibility buttonMenuCloseVisibility = Visibility.Collapsed;

        public MainWindowViewModel()
        {
            LoadResources();
            SelectedLanguage = LanguageList.FirstOrDefault();
            PreviousLanguage = SelectedLanguage;
        }

        public string ModuleName
        {
            get
            {
                return moduleName;
            }
            set
            {
                ModuleName = value;
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

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            //if (PropertyChanged != null)
            //{
            //    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            //}
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Languages _selectedLanguage;
        public Languages SelectedLanguage
        {
            get { return _selectedLanguage; }
            set
            {
                _selectedLanguage = value;
                NotifyPropertyChanged("SelectedLanguage");
            }
        }

        private Languages _previousLanguage;
        public Languages PreviousLanguage
        {
            get { return _previousLanguage; }
            set
            {
                _previousLanguage = value;
                NotifyPropertyChanged("PreviousLanguage");
            }
        }


        private List<Languages> _languageList;
        public List<Languages> LanguageList
        {
            get { return _languageList; }
            set
            {
                _languageList = value;
                NotifyPropertyChanged("LanguageList");
            }
        }

        private void LoadResources()
        {
            LanguageList = new List<Languages>();
            LanguageList.Add(new Languages() { Code = "en-US", Name = "EN" });
            LanguageList.Add(new Languages() { Code = "pl-PL", Name = "PL" });
        }

    }
}
