using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModel.Commands
{
    class AsyncCommand : Command
    {
        private readonly Func<Task> _Execute;
        private readonly Func<object, bool> _CanExecute;
        public AsyncCommand(Func<Task> Execute, Func<object, bool> CanExecute = null)
        {
            _Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _CanExecute = CanExecute;
        }
        protected override bool CanExecute(object p) => _CanExecute?.Invoke(p) ?? true;
        protected override void Execute(object p) => Task.Run(() => _Execute());
    }

}
