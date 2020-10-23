using Syncfusion.XForms.DataForm;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ProfileBook
{
    public class SignInBehavior : Behavior<ContentPage>
    {
        SfDataForm signInForm;
        Button button;

        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);

            signInForm = bindable.FindByName<SfDataForm>("signInForm");
            button = bindable.FindByName<Button>("signInButton");

            signInForm.AutoGenerateItems = false;

            var items = new ObservableCollection<DataFormItemBase>();
            items.Add(new DataFormTextItem()
            {
                Name = "Login",
                Editor = "Text",
                LabelText = App.LocalizedResources["LoginField"],
                ValidationLabelStyle = new LabelStyle() { FontSize = 14 },
                TextInputLayoutSettings = new TextInputLayoutSettings() { ReserveSpaceForAssistiveLabels = true }
            }); ;
            items.Add(new DataFormTextItem()
            {
                Name = "Password",
                Editor = "Password",
                LabelText = App.LocalizedResources["PasswordField"],
                EnablePasswordVisibilityToggle = true,
                ValidationLabelStyle = new LabelStyle() { FontSize = 14 },
                TextInputLayoutSettings = new TextInputLayoutSettings() { ReserveSpaceForAssistiveLabels = true }
            });

            signInForm.Items = items;

            signInForm.Validated += SignInForm_Validated;
        }

        //private void SignInForm_AutoGeneratingDataFormItem(object sender, AutoGeneratingDataFormItemEventArgs e)
        //{
        //    if (e.DataFormItem.Name == "Id")
        //        e.Cancel = true;
        //    if (e.DataFormItem.Name == "Confirm")
        //        e.Cancel = true;
        //    if (e.DataFormItem.Name == "Password")
        //    {
        //        (e.DataFormItem as DataFormTextItem).EnablePasswordVisibilityToggle = true;
        //    }
        //}


        private void SignInForm_Validated(object sender, ValidatedEventArgs e)
        {
            button.IsEnabled = (sender as SfDataForm).ItemManager.DataFormItems.TrueForAll(x => (x as DataFormItem).IsValid);
        }
    }
}
