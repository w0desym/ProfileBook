using SQLite;
using Syncfusion.XForms.DataForm;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ProfileBook
{


    public class Profile : INotifyPropertyChanged
    {
        public Profile()
        {

        }
        private int id;
        private int match_id;

        private string img;
        private string nickname;
        private string name;
        private string description;
        private DateTime dateTime;

        [PrimaryKey, AutoIncrement, Display(AutoGenerateField = false)]
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        [Display(AutoGenerateField = false)]
        public int Match_id
        {
            get { return match_id; }
            set
            {
                match_id = value;
                OnPropertyChanged("Match_id");
            }
        }
        [Display(AutoGenerateField = false)]
        public string Img
        {
            get { return img; }
            set
            {
                img = value;
                OnPropertyChanged("Img");
            }
        }
        public string Nickname
        {
            get { return nickname; }
            set
            {
                nickname = value;
                OnPropertyChanged("Nickname");
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        [DataType(DataType.MultilineText)]
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }
        [Display(AutoGenerateField = false)]
        public DateTime DateTime
        {
            get { return dateTime; }
            set
            {
                dateTime = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
