using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace RPSLS_Avalonia.Views
{
    public class GameView : UserControl
    {
        public GameView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}