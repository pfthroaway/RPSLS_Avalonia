namespace RPSLS_Avalonia.Models
{
    public class Simulation
    {
        public int Games { get; set; }
        public bool Reset { get; set; }

        public Simulation(int games, bool reset)
        {
            Games = games;
            Reset = reset;
        }
    }
}