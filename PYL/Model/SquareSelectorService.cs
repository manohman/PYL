using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PYL.Model
{
    public class SquareSelectorService : ISquareSelectorService, IDisposable
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


            File.WriteAllText(@"c:\json.txt", JsonConvert.SerializeObject(_squares, Formatting.Indented));




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

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _selectionTimer.Stop();
                    _selectionTimer.Dispose();
                    _selectionTimer = null;
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SquareSelectorService() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

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
