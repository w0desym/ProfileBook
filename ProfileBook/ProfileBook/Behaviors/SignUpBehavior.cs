using Syncfusion.XForms.Buttons;
using Syncfusion.XForms.DataForm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProfileBook
{
    public class SignUpBehavior : Behavior<ContentPage>
    {
        SfDataForm signUpForm;
        //SfButton button;

        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            signUpForm = bindable.FindByName<SfDataForm>("signUpForm");
            //button = bindable.FindByName<SfButton>("signUpButton");

            signUpForm.AutoGeneratingDataFormItem += SignUpForm_AutoGeneratingDataFormItem;
            signUpForm.Validated += SignUpForm_Validated;
        }

        private void SignUpForm_AutoGeneratingDataFormItem(object sender, AutoGeneratingDataFormItemEventArgs e)
        {
            if (e.DataFormItem.Name == "Id")
                e.DataFormItem.IsVisible = false;
        }

        private void SignUpForm_Validated(object sender, ValidatedEventArgs e)
        {
            //button.IsEnabled = (sender as SfDataForm).ItemManager.DataFormItems.TrueForAll(x => (x as DataFormItem).IsValid);
        }
    }
}
