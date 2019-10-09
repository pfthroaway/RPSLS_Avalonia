using ReactiveUI;
using RPSLS_Avalonia.Services;
using System.Collections.Generic;

namespace RPSLS_Avalonia.Models
{
    public class RPSLSGame : ReactiveObject
    {
        private Element? PlayerSelection;
        private Element? ComputerSelection;

        private readonly List<GameResult> PossibleResults = new List<GameResult>
        {
            new GameResult(Element.Rock, Element.Paper, Element.Paper, "Paper covers rock."),
            new GameResult(Element.Rock, Element.Scissors, Element.Rock, "Rock crushes scissors."),
            new GameResult(Element.Rock, Element.Lizard, Element.Rock, "Rock crushes lizard."),
            new GameResult(Element.Rock, Element.Spock,Element.Spock, "Spock vaporizes rock."),
            new GameResult(Element.Paper, Element.Scissors, Element.Scissors, "Scissors cuts paper."),
            new GameResult(Element.Paper, Element.Lizard, Element.Lizard, "Lizard eats paper."),
            new GameResult(Element.Paper, Element.Spock, Element.Paper, "Paper disproves Spock."),
            new GameResult(Element.Scissors, Element.Lizard, Element.Scissors, "Scissors decapitates lizard."),
            new GameResult(Element.Scissors, Element.Spock,Element.Spock, "Spock smashes scissors."),
            new GameResult(Element.Lizard, Element.Spock, Element.Lizard, "Lizard poisons Spock.")
        };

        #region Gameplay

        /// <summary>Starts a new round.</summary>
        /// <param name="selectedElement">Element the player has selected.</param>
        public GameResult Play(Element selectedElement)
        {
            PlayerSelection = selectedElement;
            ComputerSelection = (Element)RandomNumberGenerator.GenerateRandomNumber(0, 4);
            if (PlayerSelection == ComputerSelection)
                return new GameResult(PlayerSelection, ComputerSelection, PlayerSelection, "Tie game.");
            GameResult ActualResult = PossibleResults.Find(result => (result.Selection1 == PlayerSelection && result.Selection2 == ComputerSelection) || (result.Selection1 == ComputerSelection && result.Selection2 == PlayerSelection));

            return PlayerSelection == ActualResult.Winner ? Win(ActualResult.ResultText) : Lose(ActualResult.ResultText);
        }

        #region Game Results

        /// <summary>The game resulted in a win for the player.</summary>
        /// <param name="result">Text to be displayed</param>
        private GameResult Win(string result) => new GameResult(PlayerSelection, ComputerSelection, PlayerSelection, $"{result} You win!");

        /// <summary>The game resulted in a loss for the player.</summary>
        /// <param name="result">Text to be displayed</param>
        private GameResult Lose(string result) => new GameResult(PlayerSelection, ComputerSelection, ComputerSelection, $"{result} You lose.");

        #endregion Game Results

        #endregion Gameplay
    }
}