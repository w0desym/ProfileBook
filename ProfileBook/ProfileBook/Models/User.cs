using ProfileBook.Resources;
using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace ProfileBook
{
    public class User : BaseModel, INotifyPropertyChanged, IDataErrorInfo
    {
        #region Fields

        private string login;
        private string password;
        private string confirm;
        #endregion
        public LocalizedResources Resources
        {
            get;
            private set;
        }
        #region Constructor

        public User()
        {
            Resources = new LocalizedResources(typeof(AppResources), App.Language);
        }
        #endregion

        #region Properties with DataAnnotations
        public string Login
        {
            get { return this.login; }
            set
            {
                this.login = value;
                this.RaisePropertyChanged("Login");
            }
        }
        public string Password
        {
            get { return this.password; }
            set
            {
                this.password = value;
                this.RaisePropertyChanged("Password");
            }
        }
        public string Confirm
        {
            get { return this.confirm; }
            set
            {
                this.confirm = value;
                this.RaisePropertyChanged("Confirm");
            }
        }

        [Display(AutoGenerateField = false)]
        public string Error
        {
            get
            {
                return string.Empty;
            }
        }
        #endregion

        #region Additional Validation
        public string this[string name]
        {
            get
            {
                if (name.Equals("Password"))
                {
                    if (string.IsNullOrEmpty(Password))
                        return Resources["ErrorPasswordEmpty"];
                    if (Password.Length < 8 || Password.Length > 16)
                        return Resources["ErrorPasswordLength"];
                    if (MatchesRequirements(Password) != true)
                        return Resources["ErrorPasswordUppercase"];
                    return string.Empty;
                }
                else if (name.Equals("Login"))
                {
                    if (StartsWithNumber(Login) == true)
                        return Resources["ErrorLoginStartsWithNumber"];
                    if (string.IsNullOrEmpty(Login))
                        return Resources["ErrorLoginEmpty"];
                    if (Login.Length < 4 || Login.Length > 16)
                        return Resources["ErrorLoginLength"];
                    return string.Empty;
                }
                else if (name.Equals("Confirm"))
                {
                    if (PasswordsMatch() != true)
                        return Resources["ErrorPasswordsMatch"];
                    return string.Empty;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        private bool MatchesRequirements(string value)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");

            return hasNumber.IsMatch(value) && hasUpperChar.IsMatch(value) && hasLowerChar.IsMatch(value);
        }
        private bool StartsWithNumber(string value)
        {
            var startsWithNumber = new Regex(@"^\d");

            return startsWithNumber.IsMatch(value);
        }
        private bool PasswordsMatch()
        {
            if (this.Confirm == this.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
