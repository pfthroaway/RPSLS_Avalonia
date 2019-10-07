namespace RPSLS_Avalonia.Models
{
    /// <summary>Represents the result of a game.</summary>
    public class GameResult
    {
        /// <summary>The player's current selection.</summary>
        public Element? PlayerSelection { get; set; }

        /// <summary>The computer's current selection.</summary>
        public Element? ComputerSelection { get; set; }

        /// <summary>Winner of the game</summary>
        public string Winner { get; set; }

        /// <summary>Text regarding the result of the game</summary>
        public string ResultText { get; set; }

        /// <summary>Initializes an instance of <see cref="GameResult"/> by assigning values to Properties.</summary>
        /// <param name="playerSelection">The player's current selection</param>
        /// <param name="computerSelection">The computer's current selection</param>
        /// <param name="winner">Winner of the game</param>
        /// <param name="resultText">Text regarding the result of the game</param>
        public GameResult(Element? playerSelection, Element? computerSelection, string winner, string resultText)
        {
            PlayerSelection = playerSelection;
            ComputerSelection = computerSelection;
            Winner = winner;
            ResultText = resultText;
        }
    }
}