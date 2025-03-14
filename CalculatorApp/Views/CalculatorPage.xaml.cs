using CalculatorApp.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace CalculatorApp.Views;

    public partial class CalculatorPage : ContentPage
    {
        public CalculatorPage()
        {
            InitializeComponent();
            BindingContext = new CalculatorPageViewModel();
        }   
    }
