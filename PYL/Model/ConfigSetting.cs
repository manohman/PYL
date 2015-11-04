using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYL.Model {

    public class ConfigSetting {
        private IList<ISquare> _squares;
        private string _comPort;

        public ConfigSetting() { }

        public ConfigSetting(List<ISquare> squares, string com) {
            _squares = squares;
            _comPort = com;
        }

        public string ComPort { get { return _comPort; } }

        public IList<ISquare> Squares {
            get { return _squares; }
        }
    }
}
