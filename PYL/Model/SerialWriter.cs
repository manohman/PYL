using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace PYL.Model
{
    public class SerialWriter : ISerialWriter, IDisposable
    {
        SerialPort _serialPort = new System.IO.Ports.SerialPort();

        public SerialWriter()
        {
            _serialPort.PortName = "COM2";
            _serialPort.BaudRate = 9600;
            _serialPort.Handshake = System.IO.Ports.Handshake.None;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.ReadTimeout = 2000;
            _serialPort.WriteTimeout = 50;

            _serialPort.Open();


            
        }


        public void WriteIndex(int currentSquareIndex)
        {
            _serialPort.WriteLine(currentSquareIndex.ToString());

        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    
                    _serialPort.Dispose();
                    _serialPort = null;
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SerialWriter() {
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
    }

    public interface ISerialWriter {
        void WriteIndex(int currentSquareIndex);
    }
}
