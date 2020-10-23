using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;

namespace ProfileBook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupImagePage : PopupPage
    {
        public PopupImagePage(string imgPath)
        {
            InitializeComponent();
            imagePopup.Source = imgPath;
        }
    }
}