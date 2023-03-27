namespace GMS.Core.BusinessLogic.Exceptions
{
    public class AccessDeniedException : Exception
    {
        public AccessDeniedException(string name)
            : base($"You don't have permission to access this {name}.") { }
    }
}
