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

        #region Constructor
        public User()
        {

        }
        #endregion

        #region Properties with DataAnnotations
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
        [StringLength(16, ErrorMessage = "Password should have more than 8 and less than 16 characters", MinimumLength = 8)]
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
                    if (MatchesRequirements(Password) != true)
                        return "At least one uppercase, lowercase and number";
                    return string.Empty;
                }
                else if (name.Equals("Login"))
                {
                    if (StartsWithNumber(Login) == true)
                        return "Should not start with a number";
                    return string.Empty;
                }
                else if (name.Equals("Confirm"))
                {
                    if (PasswordsMatch() != true)
                        return "Passwords should match";
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
