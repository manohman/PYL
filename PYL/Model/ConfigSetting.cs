using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYL.Model {

    public class ConfigSetting {
        private IList<Square> _squares;
        private string _comPort;

        public ConfigSetting() {

            _squares = new List<Square>();

            //_squares.Add(new Square(500, -1, 0));
            //_squares.Add(new Square(0, 3, 0));
            //_squares.Add(new Square(250, -1, 0));
            //_squares.Add(new Square(1000, -1, 0));
            //_squares.Add(new Square(10, -1, 1));
            //_squares.Add(new Square(100, -1, 0));
            //_squares.Add(new Square(300, -1, 0));
            //_squares.Add(new Square(400, -1, 0));
            //_squares.Add(new Square(00, -1, 1));

            //_comPort = "Com1";

        }

        public string ComPort { get { return _comPort; } }

        public IList<Square> Squares {
            get { return _squares; }
        }




    }
}
