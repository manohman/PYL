using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace PYL.Model
{
    public class DataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service

            var item = new DataItem("Welcome to MVVM Light");
            callback(item, null);
        }

        public IList<Player> GetPlayers()
        {
            var players = new List<Player>(4)
            {
                new Player("Player1", Key.A),
                new Player("Player2", Key.B),
                new Player("Player3", Key.C),
                new Player("Player4", Key.D)
            };

            return players;

        }
    }
}