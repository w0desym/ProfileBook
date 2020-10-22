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
using Xamarin.Forms;

namespace ProfileBook
{
    public class User : BaseModel, INotifyPropertyChanged, IDataErrorInfo
    {
        #region Fields

        private string login;
        private string password;
        private string confirm;
        #endregion

        #region Properties
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

        #region Validation
        public string this[string name]
        {
            get
            {
                if (name.Equals("Password"))
                {
                    if (string.IsNullOrEmpty(Password))
                        return App.LocalizedResources["ErrorPasswordEmpty"];
                    if (Password.Length < 8 || Password.Length > 16)
                        return App.LocalizedResources["ErrorPasswordLength"];
                    if (Validation.MatchesRequirements(Password) != true)
                        return App.LocalizedResources["ErrorPasswordUppercase"];
                    return string.Empty;
                }
                else if (name.Equals("Login"))
                {
                    if (Validation.StartsWithNumber(Login) == true)
                        return App.LocalizedResources["ErrorLoginStartsWithNumber"];
                    if (string.IsNullOrEmpty(Login))
                        return App.LocalizedResources["ErrorLoginEmpty"];
                    if (Login.Length < 4 || Login.Length > 16)
                        return App.LocalizedResources["ErrorLoginLength"];
                    return string.Empty;
                }
                else if (name.Equals("Confirm"))
                {
                    if (Validation.PasswordsMatch(Password, Confirm) != true)
                        return App.LocalizedResources["ErrorPasswordsMatch"];
                    return string.Empty;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        #endregion
    }
}
