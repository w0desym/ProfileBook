using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProfileBook
{
    public class RegistrationInfo : INotifyPropertyChanged
    {
        private string login;
        private string password;
        private string checkPassword;

        public RegistrationInfo()
        {

        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field should not be empty")]
        [StringLength(30, ErrorMessage = "Login should not exceed 30 characters")]
        public string Login
        {
            get { return this.login; }
            set
            {
                this.login = value;
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
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
