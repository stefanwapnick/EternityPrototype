using System.Windows;
using Eternity.Business.Factories;
using Eternity.Business.Services;
using Eternity.Client.ViewModels;

namespace Eternity.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var engine = new ShuntingYardCalculatorEngine(
                new CalculationFactory(),
                new ShuntingYardParser()
                );

            this.DataContext = new MainWindowViewModel(engine);
        }
    }
}
