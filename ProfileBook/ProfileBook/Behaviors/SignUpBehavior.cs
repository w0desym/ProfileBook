using Syncfusion.XForms.Buttons;
using Syncfusion.XForms.DataForm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ProfileBook
{
    public class SignUpBehavior : Behavior<ContentPage>
    {
        SfDataForm signUpForm;
        SfButton button;

        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            signUpForm = bindable.FindByName<SfDataForm>("signUpForm");
            button = bindable.FindByName<SfButton>("signUpButton");

            signUpForm.AutoGenerateItems = false;

            var items = new ObservableCollection<DataFormItemBase>();
            items.Add(new DataFormTextItem() { Name = "Login", Editor = "Text" });
            items.Add(new DataFormTextItem() { Name = "Password", Editor = "Password", EnablePasswordVisibilityToggle = true });
            items.Add(new DataFormTextItem() { Name = "Confirm", Editor = "Password", EnablePasswordVisibilityToggle = true });

            signUpForm.Items = items;

            signUpForm.Validated += SignUpForm_Validated;
        }
        private void SignUpForm_Validated(object sender, ValidatedEventArgs e)
        {
            button.IsEnabled = (sender as SfDataForm).ItemManager.DataFormItems.TrueForAll(x => (x as DataFormItem).IsValid);
        }

    }
}
