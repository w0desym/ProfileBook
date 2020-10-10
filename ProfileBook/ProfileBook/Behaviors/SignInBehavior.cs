using Syncfusion.XForms.Buttons;
using Syncfusion.XForms.DataForm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

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
            
            signInForm.AutoGeneratingDataFormItem += SignInForm_AutoGeneratingDataFormItem;
            signInForm.Validated += SignInForm_Validated;
        }

        private void SignInForm_Validated(object sender, ValidatedEventArgs e)
        {
            button.IsEnabled = (sender as SfDataForm).ItemManager.DataFormItems.TrueForAll(x => (x as DataFormItem).IsValid);
        }

        private void SignInForm_AutoGeneratingDataFormItem(object sender, AutoGeneratingDataFormItemEventArgs e)
        {
            if (e.DataFormItem.Name == "CheckPassword")
                e.DataFormItem.IsVisible = false;
        }
    }
}
