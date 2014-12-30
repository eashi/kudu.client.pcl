using System;

namespace Kudu.Core.PCL.Commands
{
    public interface ICommandExecutor
    {
        CommandResult ExecuteCommand(string command, string workingDirectory);

        void ExecuteCommandAsync(string command, string workingDirectory);
        void CancelCommand();

        event Action<CommandEvent> CommandEvent;
    }
}
