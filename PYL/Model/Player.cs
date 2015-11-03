using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;

namespace PYL.Model
{
    public class Player : ObservableObject
    {

        private string _name;
        private int _score;
        private int _turnsLeft;
        private int _whammies;
        private Key _commandKey;

        public Player(string name, Key commandKey)
        {
            _name = name;
            _commandKey = commandKey;
            _turnsLeft = 5;
            _whammies = 0;
            _score = 0;
        }

        public string Name
        {
            get { return _name; }
            set { Set<string>(() => this.Name, ref _name, value); }
        }

        public int Score
        {
            get { return _score; }
            set { Set<int>(() => this.Score, ref _score, value); }
        }

        public int TurnsLeft
        {
            get { return _turnsLeft; }
            set
            {
                var changed = Set<int>(() => this.TurnsLeft, ref _turnsLeft, value);
                if (changed)
                {
                    RaisePropertyChanged(propertyName: "IsActive");
                }

            }
        }

        public int Whammies
        {
            get { return _whammies; }
            set
            {
                bool changed = Set<int>(() => this.Whammies, ref _whammies, value);
                if (changed)
                {
                    RaisePropertyChanged("IsActive");
                }
            }

        }

        public Key CommandKey
        {
            get { return _commandKey; }
            set { Set<Key>(() => this.CommandKey, ref _commandKey, value); }
        }

        public bool IsActive
        {
            get { return TurnsLeft > 0 && Whammies < 4; }
        }

        public void Reset()
        {
            Initialize();

        }

        private void Initialize()
        {
            TurnsLeft = 5;
            Score = 0;
            Whammies = 0;
        }
    }
}
