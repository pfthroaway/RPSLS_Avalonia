using Avalonia;
using Avalonia.Markup.Xaml;

namespace RPSLS_Avalonia
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
