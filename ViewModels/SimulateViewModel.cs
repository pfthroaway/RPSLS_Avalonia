using ReactiveUI;
using RPSLS_Avalonia.Models;
using RPSLS_Avalonia.Services;
using System.Reactive;

namespace RPSLS_Avalonia.ViewModels
{
    public class SimulateViewModel : ViewModelBase
    {
        private string _games;
        private bool _reset;

        /// <summary>Contents of TxtSimulate</summary>
        public string Games
        {
            get => _games;
            set => this.RaiseAndSetIfChanged(ref _games, value);
        }

        /// <summary>Is BlnReset checked?</summary>
        public bool Reset
        {
            get => _reset;
            set => this.RaiseAndSetIfChanged(ref _reset, value);
        }

        public SimulateViewModel()
        {
            var okEnabled = this.WhenAnyValue(
                   x => x.Games,
                   x => !string.IsNullOrWhiteSpace(x) && Int32Helper.Parse(x) != 0);
            Ok = ReactiveCommand.Create(
                () => new Simulation(Int32Helper.Parse(Games), Reset), okEnabled);
            Cancel = ReactiveCommand.Create(() => { });
        }

        public Simulation Simulate(Simulation sim) => sim;

        public ReactiveCommand<Unit, Simulation> Ok { get; }
        public ReactiveCommand<Unit, Unit> Cancel { get; }
    }
}