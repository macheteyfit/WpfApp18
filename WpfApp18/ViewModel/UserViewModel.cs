using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using The_template_is_scanned_MVVM;
using WpfApp18.Model;

namespace WpfApp18.ViewModel
{
    internal class UserViewModel : INotifyPropertyChanged
    {
        private User _currentUser;
        public User CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                OnPropertyChanged("CurrentUser");
            }
        }

        private User _tempUser;
        public User TempUser
        {
            get { return _tempUser; }
            set
            {
                _tempUser = value;
                OnPropertyChanged("TempUser");
            }
        }

        public ICommand AddUser { get; set; }

        public UserViewModel()
        {
            CurrentUser = new User();
            TempUser = new User(); 
            AddUser = new DelegateCommand(AddUserHandler);
        }

        public void AddUserHandler(object obj)
        {
            CurrentUser = new User()
            {
                Email = TempUser.Email,
                Password = TempUser.Password,
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string param)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(param));
        }
    }
}