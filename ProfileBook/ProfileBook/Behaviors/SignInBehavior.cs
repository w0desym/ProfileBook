using Syncfusion.XForms.Buttons;
using Syncfusion.XForms.DataForm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml.Diagnostics;

namespace ProfileBook
{
    public class SignInBehavior : Behavior<ContentPage>
    {
        SfDataForm signInForm;
        SfButton button;


        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);

            signInForm = bindable.FindByName<SfDataForm>("signInForm");
            button = bindable.FindByName<SfButton>("signInButton");
            
            signInForm.AutoGenerateItems = false;

            var items = new ObservableCollection<DataFormItemBase>();
            items.Add(new DataFormTextItem() { Name = "Login", Editor = "Text" });
            items.Add(new DataFormTextItem() { Name = "Password", Editor = "Password", EnablePasswordVisibilityToggle = true });

            signInForm.Items = items;

            signInForm.Validated += SignInForm_Validated;      
        }
        private void SignInForm_Validated(object sender, ValidatedEventArgs e)
        {
            button.IsEnabled = (sender as SfDataForm).ItemManager.DataFormItems.TrueForAll(x => (x as DataFormItem).IsValid);
        }
    }
}
