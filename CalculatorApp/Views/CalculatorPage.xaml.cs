using CalculatorApp.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace CalculatorApp.Views;

public partial class CalculatorPage : ContentPage
{
    // Constructor to initialize the page and set the binding context
    public CalculatorPage()
    {
        InitializeComponent();
        BindingContext = new CalculatorPageViewModel();
    }
}
