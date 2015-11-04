using System.Windows;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Threading;
using PYL.Model;

namespace PYL
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            DispatcherHelper.Initialize();

            SimpleIoc.Default.Register<ISquareSelectorService, SquareSelectorService>();
            SimpleIoc.Default.Register<ISerialWriter, SerialWriter>();
            SimpleIoc.Default.Register<IConfigParser, ConfigParser>();

        }
    }
}
