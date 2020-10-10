using SQLite;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ProfileBook
{
    //public class Profile : INotifyPropertyChanged
    //{
    //    private string name;
    //    private string description;

    //    [PrimaryKey, AutoIncrement, Column("_id")]
    //    public int Id { get; set; }
    //    public string Name
    //    {
    //        get { return name; }
    //        set
    //        {
    //            name = value;
    //            OnPropertyChanged("Name");
    //        }
    //    }

    //    public string Description
    //    {
    //        get { return description; }
    //        set
    //        {
    //            description = value;
    //            OnPropertyChanged("Description");
    //        }
    //    }

    //    public event PropertyChangedEventHandler PropertyChanged;

    //    public void OnPropertyChanged(string name)
    //    {
    //        if (this.PropertyChanged != null)
    //            this.PropertyChanged(this, new PropertyChangedEventArgs(name));
    //    }
    //}

    public class Profile : INotifyPropertyChanged
    {
        public Profile()
        {

        }

        private int id;
        private string name;

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

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
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
