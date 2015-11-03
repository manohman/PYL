using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYL.Model
{
    public class SerialWriter : ISerialWriter
    {
        public void WriteIndex(int currentSquareIndex)
        {
            
        }
    }

    public interface ISerialWriter {
        void WriteIndex(int currentSquareIndex);
    }
}
