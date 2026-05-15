using System;
using System.Windows.Input;
using XoshBank.Command;
using XoshBank.Desktop.ViewModels;
using XoshBank.Models;

namespace XoshBank.Command.Loans
{
    public class ExportLoansCommand : ICommand
    {
        private readonly LoansControlViewModel _viewModel;

        public ExportLoansCommand(LoansControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var exportCommand = new ExportCommand<LoanUIModel>();
            exportCommand.Execute(_viewModel.Loans);
        }
    }
}