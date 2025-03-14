namespace CalculatorApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

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