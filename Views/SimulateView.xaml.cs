using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace RPSLS_Avalonia.Views
{
    public class SimulateView : UserControl
    {
        public SimulateView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}