using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYL.Model {
    public class ConfigParser : IConfigParser {

        public ConfigParser() {


            string executingDirectory = System.AppDomain.CurrentDomain.BaseDirectory;

            string path = Path.Combine(executingDirectory, "config.ini");

            string configString = File.ReadAllText(path);

            //ConfigSetting configSetting = new ConfigSetting();

            //File.WriteAllText(path, JsonConvert.SerializeObject(configSetting, Formatting.Indented));
            ConfigSetting configSetting = JsonConvert.DeserializeObject<ConfigSetting>(configString);

            var result = JsonConvert.DeserializeObject<dynamic>(configString);


            List<Square> squares3 = new List<Square>();
            foreach (var square in result.Squares) {
                squares3.Add(new Square(square.ScoreAdust, square.TurnAdjust, square.WhammyAdjust));
            }
            string com = result.ComPort;

            IList<Square> squares = configSetting.Squares;

        }


    }

    public interface IConfigParser {

    }
}
