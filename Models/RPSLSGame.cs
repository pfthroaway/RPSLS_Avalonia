using ReactiveUI;
using RPSLS_Avalonia.Services;

namespace RPSLS_Avalonia.Models
{
    public class RPSLSGame : ReactiveObject
    {
        private Element? PlayerSelection;
        private Element? ComputerSelection;

        #region Gameplay

        /// <summary>Starts a new round.</summary>
        /// <param name="selectedElement">Element the player has selected.</param>
        public GameResult Play(Element selectedElement)
        {
            PlayerSelection = selectedElement;
            ComputerSelection = (Element)RandomNumberGenerator.GenerateRandomNumber(0, 4);

            switch (selectedElement)
            {
                case Element.Rock:
                    return Rock();

                case Element.Paper:
                    return Paper();

                case Element.Scissors:
                    return Scissors();

                case Element.Lizard:
                    return Lizard();

                case Element.Spock:
                    return Spock();
            }

            return null;
        }

        #region Game Results

        /// <summary>The game resulted in a win for the player.</summary>
        /// <param name="result">Text to be displayed</param>
        private GameResult Win(string result) => new GameResult(PlayerSelection, ComputerSelection, "Player", $"{result} You win!");

        /// <summary>The game resulted in a loss for the player.</summary>
        /// <param name="result">Text to be displayed</param>
        private GameResult Lose(string result) => new GameResult(PlayerSelection, ComputerSelection, "Computer", $"{result} You lose.");

        /// <summary>The game resulted in tie.</summary>
        private GameResult Tie() => new GameResult(PlayerSelection, ComputerSelection, "Tie", "Tie game.");

        #endregion Game Results

        /// <summary>The player selects Rock.</summary>
        private GameResult Rock()
        {
            switch (ComputerSelection)
            {
                case Element.Rock:
                    return Tie();

                case Element.Paper:
                    return Lose("Paper covers rock.");

                case Element.Scissors:
                    return Win("Rock smashes scissors.");

                case Element.Lizard:
                    return Win("Rock crushes lizard.");

                case Element.Spock:
                    return Lose("Spock vaporizes rock.");
            }

            return null;
        }

        /// <summary>The player selects Paper.</summary>
        private GameResult Paper()
        {
            switch (ComputerSelection)
            {
                case Element.Rock:
                    return Win("Paper covers rock.");

                case Element.Paper:
                    return Tie();

                case Element.Scissors:
                    return Lose("Scissors cuts paper.");

                case Element.Lizard:
                    return Lose("Lizard eats paper.");

                case Element.Spock:
                    return Win("Paper disproves Spock.");
            }

            return null;
        }

        /// <summary>The player selects Scissors.</summary>
        private GameResult Scissors()
        {
            switch (ComputerSelection)
            {
                case Element.Rock:
                    return Lose("Rock smashes scissors.");

                case Element.Paper:
                    return Win("Scissors cuts paper.");

                case Element.Scissors:
                    return Tie();

                case Element.Lizard:
                    return Win("Scissors decapitate lizard.");

                case Element.Spock:
                    return Lose("Spock smashes scissors.");
            }

            return null;
        }

        /// <summary>The player selects Lizard.</summary>
        private GameResult Lizard()
        {
            switch (ComputerSelection)
            {
                case Element.Rock:
                    return Lose("Rock crushes lizard.");

                case Element.Paper:
                    return Win("Lizard eats paper.");

                case Element.Scissors:
                    return Lose("Scissors decapitate lizard.");

                case Element.Lizard:
                    return Tie();

                case Element.Spock:
                    return Win("Lizard poisons Spock.");
            }

            return null;
        }

        /// <summary>The player selects Spock.</summary>
        private GameResult Spock()
        {
            switch (ComputerSelection)
            {
                case Element.Rock:
                    return Win("Spock vaporizes rock.");

                case Element.Paper:
                    return Lose("Paper disproves Spock.");

                case Element.Scissors:
                    return Win("Spock smashes scissors.");

                case Element.Lizard:
                    return Lose("Lizard poisons Spock.");

                case Element.Spock:
                    return Tie();
            }

            return null;
        }

        #endregion Gameplay
    }
}