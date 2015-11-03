using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PYL.Model
{
    public class SquareSelectorService : ISquareSelectorService
    {
        private ISerialWriter SerialWriter { get; set; }
        private const double SELECTION_INTERVAL = 250;

        private Timer _selectionTimer;
        private Random _random;
        private int _currentSquareIndex;
        private IList<ISquare> _squares; 


        public SquareSelectorService(ISerialWriter serialWriter)
        {
            SerialWriter = serialWriter;
            _random = new Random();
            _selectionTimer = new Timer(SELECTION_INTERVAL);
            _selectionTimer.Elapsed += SelectionTimerOnElapsed;
            _selectionTimer.Start();
            _squares = new List<ISquare>();

            _squares.Add(new Square(500, -1, 0));
            _squares.Add(new Square(0, 3, 0));
            _squares.Add(new Square(250, -1, 0));
            _squares.Add(new Square(1000, -1, 0));
            _squares.Add(new Square(10, -1, 1));
            _squares.Add(new Square(100, -1, 0));
            _squares.Add(new Square(300, -1, 0));
            _squares.Add(new Square(400, -1, 0));
            _squares.Add(new Square(00, -1, 1));


        }

        private void SelectionTimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            _selectionTimer.Stop();

            _currentSquareIndex = _random.Next(0, _squares.Count);

            SerialWriter.WriteIndex(_currentSquareIndex);
            _selectionTimer.Start();


        }

        public void StopSquare(Player currentPlayer)
        {
            _selectionTimer.Stop();
            Console.WriteLine(_currentSquareIndex);

            _squares[_currentSquareIndex].Adjust(currentPlayer);

            

            _selectionTimer.Start();
        }

//        public void Dispose()
//        {
//            Dispose(true);
//            _selectionTimer.Stop();
//            _selectionTimer.Dispose();
//        }
    }

    public interface ISquareSelectorService
    {
        void StopSquare(Player currentPlayer);
    }


}
