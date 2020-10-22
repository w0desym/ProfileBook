using ProfileBook.Resources;
using Syncfusion.XForms.DataForm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ProfileBook
{
    public class AddProfileBehavior : Behavior<ContentPage>
    {
        SfDataForm addProfileForm;
        public LocalizedResources Resources
        {
            get;
            private set;
        }
        protected override void OnAttachedTo(ContentPage bindable)
        {
            Resources = new LocalizedResources(typeof(AppResources), App.Language);
            base.OnAttachedTo(bindable);

            addProfileForm = bindable.FindByName<SfDataForm>("addProfileForm");

            addProfileForm.AutoGenerateItems = false;

            var items = new ObservableCollection<DataFormItemBase>();
            items.Add(new DataFormTextItem()
            {
                Name = "Nickname",
                Editor = "Text",
                LabelText = Resources["NicknameField"]
            });
            items.Add(new DataFormTextItem()
            {
                Name = "Name",
                Editor = "Text",
                LabelText = Resources["NameField"]
            });
            items.Add(new DataFormTextItem()
            {
                Name = "Description",
                Editor = "Text",
                LabelText = Resources["DescriptionField"]
            });

            addProfileForm.Items = items;
        }
    }
}
