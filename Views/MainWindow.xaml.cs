using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace RPSLS_Avalonia.Views
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        //TODO SimulateView isn't centered.
        //TODO Unable to close window if SimulateView was opened. When returning to GameView, unable to close window until a Button has been clicked.
        //TODO It would be better if ClickMode on buttons was "Release", but it doesn't work.
    }
}