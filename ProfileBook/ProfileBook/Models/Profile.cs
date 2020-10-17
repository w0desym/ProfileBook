using SQLite;
using Syncfusion.XForms.DataForm;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ProfileBook
{
    public class Profile : BaseModel, INotifyPropertyChanged
    {
        #region Fields
        private int match_id;

        private string imgPath;
        private string nickname;
        private string name;
        private string description;
        private DateTime dateTime;
        #endregion

        #region Constructor
        public Profile()
        {

        }
        #endregion

        #region Properties with DataAnnotations
        [Display(AutoGenerateField = false)]
        public int Match_id
        {
            get { return match_id; }
            set
            {
                match_id = value;
                RaisePropertyChanged("Match_id");
            }
        }
        [Display(AutoGenerateField = false)]
        public string ImgPath
        {
            get { return imgPath; }
            set
            {
                imgPath = value;
                RaisePropertyChanged("ImgPath");
            }
        }
        public string Nickname
        {
            get { return nickname; }
            set
            {
                nickname = value;
                RaisePropertyChanged("Nickname");
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }
        [StringLength(120)]
        [DataType(DataType.MultilineText)]
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                RaisePropertyChanged("Description");
            }
        }
        [Display(AutoGenerateField = false)]
        public DateTime DateTime
        {
            get { return dateTime; }
            set
            {
                dateTime = value;
                RaisePropertyChanged("DateTime");
            }
        }
        #endregion
    }
}
