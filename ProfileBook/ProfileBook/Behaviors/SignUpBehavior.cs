using ProfileBook.Resources;
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
        Button button;
        public LocalizedResources Resources
        {
            get;
            private set;
        }
        protected override void OnAttachedTo(ContentPage bindable)
        {
            Resources = new LocalizedResources(typeof(AppResources), App.Language);
            base.OnAttachedTo(bindable);
            signUpForm = bindable.FindByName<SfDataForm>("signUpForm");
            button = bindable.FindByName<Button>("signUpButton");

            signUpForm.AutoGenerateItems = false;

            var items = new ObservableCollection<DataFormItemBase>();
            items.Add(new DataFormTextItem()
            {
                Name = "Login",
                Editor = "Text",
                LabelText = Resources["LoginField"],
                ValidationLabelStyle = new LabelStyle() { FontSize = 14 },
                TextInputLayoutSettings = new TextInputLayoutSettings() { ReserveSpaceForAssistiveLabels = true }
            });
            items.Add(new DataFormTextItem()
            {
                Name = "Password",
                Editor = "Password",
                LabelText = Resources["PasswordField"],
                EnablePasswordVisibilityToggle = true,
                ValidationLabelStyle = new LabelStyle() { FontSize = 14 },
                TextInputLayoutSettings = new TextInputLayoutSettings() { ReserveSpaceForAssistiveLabels = true }
            });
            items.Add(new DataFormTextItem()
            {
                Name = "Confirm",
                Editor = "Password",
                EnablePasswordVisibilityToggle = true,
                LabelText = Resources["ConfirmField"],
                ValidationLabelStyle = new LabelStyle() { FontSize = 14 },
                TextInputLayoutSettings = new TextInputLayoutSettings() { ReserveSpaceForAssistiveLabels = true }
            });

            signUpForm.Items = items;

            //signUpForm.AutoGeneratingDataFormItem += SignUpForm_AutoGeneratingDataFormItem;
            signUpForm.Validated += SignUpForm_Validated;

        }

        //private void SignUpForm_AutoGeneratingDataFormItem(object sender, AutoGeneratingDataFormItemEventArgs e)
        //{
            //if (e.DataFormItem.Name == "Id")
            //    e.Cancel = true;
            //if (e.DataFormItem.Name == "Password")
            //{
            //    (e.DataFormItem as DataFormTextItem).EnablePasswordVisibilityToggle = true;
            //}
        //}

        private void SignUpForm_Validated(object sender, ValidatedEventArgs e)
        {
            button.IsEnabled = (sender as SfDataForm).ItemManager.DataFormItems.TrueForAll(x => (x as DataFormItem).IsValid);
        }


    }
}
