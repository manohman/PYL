using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYL.Model {
    public class ConfigParser : IConfigParser {

        private ConfigSetting _configSetting;

        public ConfigParser() {


            string executingDirectory = System.AppDomain.CurrentDomain.BaseDirectory;

            string path = Path.Combine(executingDirectory, Constants.ConfigFileName);

            string configString = File.ReadAllText(path);

            //ConfigSetting configSetting = new ConfigSetting();

            //File.WriteAllText(path, JsonConvert.SerializeObject(configSetting, Formatting.Indented));
            //_configSetting = JsonConvert.DeserializeObject<ConfigSetting>(configString);

            var result = JsonConvert.DeserializeObject<dynamic>(configString);


            List<ISquare> squares = new List<ISquare>();
            foreach (var square in result.Squares) {
                squares.Add(new Square((int)square.ScoreAdjust, (int)square.TurnAdjust, (int)square.WhammyAdjust));
            }
            string com = result.ComPort;

            _configSetting = new ConfigSetting(squares, com);

        }

        public ConfigSetting ConfigSetting {
            get {
                return _configSetting;
            }

        }
    }

    public interface IConfigParser {
        ConfigSetting ConfigSetting { get; }
    }
}
