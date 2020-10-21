using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ProfileBook.Views
{
    public partial class SignInPage : ContentPage
    {
        public SignInPage()
        {
            InitializeComponent();

            signInButton.IsEnabled = false;
        }
    }
}
