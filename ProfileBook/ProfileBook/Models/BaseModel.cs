using ProfileBook.Resources;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProfileBook
{
    public class BaseModel
    {
        #region Fields
        protected ISettingsManager SettingsManager { get; private set; }
        private int id;
        #endregion

        #region Properties
        [PrimaryKey, AutoIncrement, Display(AutoGenerateField = false)]
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                RaisePropertyChanged("Id");
            }
        }
        #endregion

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(String Name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(Name));
        }
        #endregion
    }
}
