using System;
using System.Windows.Input;
using Eternity.Business.Services;
using Eternity.Client.Commands;

namespace Eternity.Client.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private string _statusText;

        private readonly ICalculatorEngine _calculatorEngine;

        private string _inputText;

        public string StatusText
        {
            get => _statusText;
            set => SetProperty(ref _statusText, value);
        }

        public string InputText
        {
            get => _inputText;
            set => SetProperty(ref _inputText, value);
        }

        

        public MainWindowViewModel()
        {
        }

        public MainWindowViewModel(ICalculatorEngine engine)
        {
            _calculatorEngine = engine;
            InputText = string.Empty;
            StatusText = string.Empty;
        }

        public ICommand InputCharacterCommand => new CommandHandler((obj) => InputText += (string)obj);

        public ICommand ClearCommand => new CommandHandler((obj) => InputText = string.Empty);

        public ICommand DeleteCommand => new CommandHandler(Delete);

        private void Delete(object parameter)
        {
            InputText = InputText.Length > 0 ? InputText.Substring(0, InputText.Length - 1) : string.Empty;
        }

        public ICommand ExecuteComputationCommand => new CommandHandler(ExecuteComputation);

        private void ExecuteComputation(object parameter)
        {
            double result = _calculatorEngine.Compute(_inputText);
            StatusText = $"{InputText} = {result}";
            InputText = string.Empty;
        }

    }
}