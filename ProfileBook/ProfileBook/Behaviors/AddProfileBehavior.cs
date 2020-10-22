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
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);

            addProfileForm = bindable.FindByName<SfDataForm>("addProfileForm");

            addProfileForm.AutoGenerateItems = false;

            var items = new ObservableCollection<DataFormItemBase>();
            items.Add(new DataFormTextItem()
            {
                Name = "Nickname",
                Editor = "Text",
                LabelText = App.LocalizedResources["NicknameField"]
            });
            items.Add(new DataFormTextItem()
            {
                Name = "Name",
                Editor = "Text",
                LabelText = App.LocalizedResources["NameField"]
            });
            items.Add(new DataFormTextItem()
            {
                Name = "Description",
                Editor = "Text",
                LabelText = App.LocalizedResources["DescriptionField"]
            });

            addProfileForm.Items = items;
        }
    }
}
