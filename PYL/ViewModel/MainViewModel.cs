using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PYL.Model;

namespace PYL.ViewModel
{

    public class MainViewModel : ViewModelBase
    {


        private readonly IDataService _dataService;
        private readonly ISquareSelectorService _squareSelectorService;

        private Player _currentPlayer;
        private ObservableCollection<Player> _players;

        public RelayCommand SelectSquareCommand { get; private set; }
        public RelayCommand StartNewGameCommand { get; private set; }
        /// <summary>
        ///     Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService, ISquareSelectorService squareSelectorService)
        {
            _dataService = dataService;
            _squareSelectorService = squareSelectorService;
            this.SelectSquareCommand = new RelayCommand(this.SelectSquare);
            this.StartNewGameCommand = new RelayCommand(this.StartNewGame);

        }

        private void SelectSquare()
        {
            if (_currentPlayer.TurnsLeft > 0 && _currentPlayer.Whammies < 4)
            {
                _squareSelectorService.StopSquare(_currentPlayer);
            }

        }

        public Player CurrentPlayer
        {
            get { return _currentPlayer; }
            set { Set(() => CurrentPlayer, ref _currentPlayer, value); }
        }

        public ObservableCollection<Player> Players
        {
            get
            {
                _players = new ObservableCollection<Player>(_dataService.GetPlayers());
                return _players;
            }
        }

        public void StartNewGame()
        {
            foreach (var player in _players)
            {
                player.Reset();
            }
        }


        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}