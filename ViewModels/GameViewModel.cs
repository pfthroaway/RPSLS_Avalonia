using ReactiveUI;
using RPSLS_Avalonia.Models;
using RPSLS_Avalonia.Services;
using System.Reactive;

namespace RPSLS_Avalonia.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        private RPSLSGame game;

        private int _playerWins, _computerWins, _tieGames;
        private Element? _playerSelection, _computerSelection;
        private string _result = "";

        #region Modifying Properties

        /// <summary>Games the player has won.</summary>
        public int PlayerWins
        {
            get => _playerWins;
            set { _playerWins = value; this.RaisePropertyChanged("PlayerWinsString"); }
        }

        /// <summary>Games the computer has won.</summary>
        public int ComputerWins
        {
            get => _computerWins;
            set { _computerWins = value; this.RaisePropertyChanged("ComputerWinsString"); }
        }

        /// <summary>Games that resulted in a tie.</summary>
        public int TieGames
        {
            get => _tieGames;
            set { _tieGames = value; this.RaisePropertyChanged("TieGamesString"); }
        }

        /// <summary>The player's current selection.</summary>
        public Element? PlayerSelection
        {
            get => _playerSelection;
            set { _playerSelection = value; this.RaisePropertyChanged("PlayerSelectionString"); }
        }

        /// <summary>The computer's current selection.</summary>
        public Element? ComputerSelection
        {
            get => _computerSelection;
            set { _computerSelection = value; this.RaisePropertyChanged("ComputerSelectionString"); }
        }

        /// <summary>The result of the current game.</summary>
        public string Result
        {
            get => _result;
            set { _result = value; this.RaisePropertyChanged("Result"); }
        }

        #endregion Modifying Properties

        #region Helper Properties

        /// <summary>Games the player has won with preceding text.</summary>
        public string PlayerWinsString => "Player Wins: " + PlayerWins.ToString("N0");

        /// <summary>Games the computer has won with preceding text.</summary>
        public string ComputerWinsString => "Computer Wins: " + ComputerWins.ToString("N0");

        /// <summary>Games that resulted in a tie with preceding text.</summary>
        public string TieGamesString => "Tie Games: " + TieGames.ToString("N0");

        /// <summary>The player's current selection.</summary>
        public string PlayerSelectionString => PlayerSelection.ToString();

        /// <summary>The computer's current selection.</summary>
        public string ComputerSelectionString => ComputerSelection.ToString();

        #endregion Helper Properties

        private void Play(Element selectedElement)
        {
            GameResult result = Game.Play(selectedElement);
            PlayerSelection = result.PlayerSelection;
            ComputerSelection = result.ComputerSelection;
            Result = result.ResultText;
            switch (result.Winner)
            {
                case "Player":

                    PlayerWins++;
                    break;

                case "Computer":
                    ComputerWins++;
                    break;

                case "Tie":
                    TieGames++;
                    break;
            }
        }

        /// <summary>Simulates an amount of games.</summary>
        /// <param name="sim">Simulation object holding the number of games to be simulated and whether the game scores should be reset.</param>
        internal void SimulateGames(Simulation sim)
        {
            if (sim.Reset)
                ResetScore();

            for (int i = 0; i < sim.Games; i++)
                Play((Element)RandomNumberGenerator.GenerateRandomNumber(0, 4));
        }

        /// <summary>Resets all wins/losses/ties.</summary>
        private void ResetScore()
        {
            PlayerWins = 0;
            ComputerWins = 0;
            TieGames = 0;
        }

        public GameViewModel()
        {
            Game = new RPSLSGame();

            Rock = ReactiveCommand.Create(() => Play(Element.Rock));
            Paper = ReactiveCommand.Create(() => Play(Element.Paper));
            Scissors = ReactiveCommand.Create(() => Play(Element.Scissors));
            Lizard = ReactiveCommand.Create(() => Play(Element.Lizard));
            Spock = ReactiveCommand.Create(() => Play(Element.Spock));
        }

        public RPSLSGame Game
        {
            get => game;
            private set => this.RaiseAndSetIfChanged(ref game, value);
        }

        public ReactiveCommand<Unit, Unit> Rock { get; }
        public ReactiveCommand<Unit, Unit> Paper { get; }

        public ReactiveCommand<Unit, Unit> Scissors { get; }
        public ReactiveCommand<Unit, Unit> Lizard { get; }
        public ReactiveCommand<Unit, Unit> Spock { get; }
    }
}