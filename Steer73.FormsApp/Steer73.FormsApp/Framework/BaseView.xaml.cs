using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Steer73.FormsApp.Framework
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaseView : ContentPage
    {
        public BaseView()
        {
            InitializeComponent();
        }
        
        public static readonly BindableProperty MainContentProperty =
            BindableProperty.Create(nameof(MainContent), typeof(View), typeof(BaseView));

        public View MainContent
        {
            get => (View)GetValue(MainContentProperty);
            set => SetValue(MainContentProperty, value);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (MainContent == null)
            {
                return;
            }
            SetInheritedBindingContext(MainContent, BindingContext);
        }
    }
}