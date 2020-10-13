using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProfileBook
{
    public class User : INotifyPropertyChanged
    {
        private int id;
        private string login;
        private string password;
        private string checkPassword;

        public User()
        {

        }

        [PrimaryKey, AutoIncrement, Display(AutoGenerateField = false)]
        public int Id
        {
            get { return this.id; }
            set
            {
                this.id = value;
                //App.CurrentUser = id++;
            }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field should not be empty")]
        [StringLength(30, ErrorMessage = "Login should not exceed 30 characters")]
        public string Login
        {
            get { return this.login; }
            set
            {
                this.login = value;
                this.RaisePropertyChanged("Login");
            }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field should not be empty")]
        [StringLength(30, ErrorMessage = "Password should not exceed 30 characters")]
        public string Password
        {
            get { return this.password; }
            set
            {
                this.password = value;
                this.RaisePropertyChanged("Password");
            }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field should not be empty")]
        [Display(Name = "Password Again")]
        public string CheckPassword
        {
            get { return this.checkPassword; }
            set
            {
                this.checkPassword = value;
                this.RaisePropertyChanged("CheckPassword");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(String Name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(Name));
        }
    }
}
