namespace GMS.Core.BusinessLogic.Exceptions
{
    public class NotExistException : Exception
    {
        public NotExistException(string name, object key)
            : base($"{name} [{key}] does not exist.") { }
    }
}
