namespace ANCD.Application.Messages.CommandsQueries
{
    public sealed class CommandResult
    {
        public bool IsSuccess { get; private set; }

        public IReadOnlyCollection<string> Errors => _errors?.ToList().AsReadOnly();

        private ICollection<string> _errors;

        public static CommandResult Success()
        {
            var result = new CommandResult();
            result.IsSuccess = true;
            return result;
        }

        public static CommandResult Fail(string error)
        {
            var commandQueryResul = new CommandResult();
            commandQueryResul._errors = new List<string>(1);
            commandQueryResul._errors.Add(error);
            return commandQueryResul;
        }

        public static CommandResult Fail(ICollection<string> errors)
        {
            var commandQueryResul = new CommandResult();
            commandQueryResul._errors = errors;
            return commandQueryResul;
        }
    }
}
