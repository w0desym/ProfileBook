using Syncfusion.XForms.DataForm;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ProfileBook
{
    public class SignUpBehavior : Behavior<ContentPage>
    {
        SfDataForm signUpForm;
        Button button;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            signUpForm = bindable.FindByName<SfDataForm>("signUpForm");
            button = bindable.FindByName<Button>("signUpButton");

            signUpForm.AutoGenerateItems = false;

            var items = new ObservableCollection<DataFormItemBase>();
            items.Add(new DataFormTextItem()
            {
                Name = "Login",
                Editor = "Text",
                LabelText = App.LocalizedResources["LoginField"],
                ValidationLabelStyle = new LabelStyle() { FontSize = 14 },
                TextInputLayoutSettings = new TextInputLayoutSettings() { ReserveSpaceForAssistiveLabels = true }
            });
            items.Add(new DataFormTextItem()
            {
                Name = "Password",
                Editor = "Password",
                LabelText = App.LocalizedResources["PasswordField"],
                EnablePasswordVisibilityToggle = true,
                ValidationLabelStyle = new LabelStyle() { FontSize = 14 },
                TextInputLayoutSettings = new TextInputLayoutSettings() { ReserveSpaceForAssistiveLabels = true }
            });
            items.Add(new DataFormTextItem()
            {
                Name = "Confirm",
                Editor = "Password",
                EnablePasswordVisibilityToggle = true,
                LabelText = App.LocalizedResources["ConfirmField"],
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
