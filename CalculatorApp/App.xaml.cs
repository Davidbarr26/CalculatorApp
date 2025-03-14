namespace CalculatorApp
{
    public partial class App : Application
    {
        // Constructor to initialize the application
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        // Method to create the main window
        protected override Window CreateWindow(IActivationState? activationState)
        {
            Window window = new Window(new AppShell());

            // Set Start up windows size
            window.Width = 400;
            window.Height = 640;

            return window;
        }
    }
}
