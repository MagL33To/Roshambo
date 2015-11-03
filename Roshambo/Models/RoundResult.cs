using Roshambo.Enums;

namespace Roshambo.Models
{
    public class RoundResult
    {
        public MoveType Player1Move { get; set; }
        public bool Player1IsHuman { get; set; }
        public MoveType Player2Move { get; set; }
        public ResultType Result { get; set; }

        public string ResultText
        {
            get
            {
                switch (Result)
                {
                    case ResultType.Win:
                        return $"{Player1Move} beats {Player2Move.ToString().ToLower()}! {(Player1IsHuman ? "You win" : "CPU1 wins")}!";
                    case ResultType.Draw:
                        return $"Both players played {Player1Move.ToString().ToLower()}. Draw.";
                    case ResultType.Lose:
                        return $"{Player2Move} beats {Player1Move.ToString().ToLower()}! {(Player1IsHuman ? "CPU wins" : "CPU2 wins")}!";
                    default:
                        return "Uhhhh...";
                }
            }
        }
    }
}