namespace PYL.Model
{
    public class Square : ISquare
    {
        private readonly int _scoreAdjust;
        private readonly int _turnAdjust;
        private readonly int _whammyAdjust;


        public Square(int scoreAdjust, int turnAdjust, int whammyAdjust)
        {
            _scoreAdjust = scoreAdjust;
            _turnAdjust = turnAdjust;
            _whammyAdjust = whammyAdjust;
        }


        public void Adjust(Player player)
        {
            if (_whammyAdjust > 0)
            {
                player.Score = 0;
                player.TurnsLeft += -1;
            }
            else
            {
                player.Score += _scoreAdjust;
                player.TurnsLeft += _turnAdjust;
            }


            player.Whammies += _whammyAdjust;
        }


        public int ScoreAdjust { get { return _scoreAdjust; }  }
        public int TurnAdjust { get { return _turnAdjust; }  }
        public int WhammyAdjust { get { return _whammyAdjust; } }


    }

    public interface ISquare
    {
        void Adjust(Player player);

        int ScoreAdjust { get;  }
        int TurnAdjust { get;  }
        int WhammyAdjust { get; }
    }
}