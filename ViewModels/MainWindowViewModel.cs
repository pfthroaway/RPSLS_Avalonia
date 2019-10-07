using ReactiveUI;
using System;
using RPSLS_Avalonia.Models;
using System.Reactive.Linq;

namespace RPSLS_Avalonia.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase content;

        public MainWindowViewModel()
        {
            Content = Game = new GameViewModel();
        }

        public ViewModelBase Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }

        public GameViewModel Game { get; }

        public void SimulateGames()
        {
            SimulateViewModel vm = new SimulateViewModel();

            Observable.Merge(
                vm.Ok,
                vm.Cancel.Select(_ => (Simulation)null))
                .Take(1)
                .Subscribe(model =>
                {
                    if (model != null)
                    {
                        Game.SimulateGames(model);
                    }

                    Content = Game;
                });

            Content = vm;
        }
    }
}