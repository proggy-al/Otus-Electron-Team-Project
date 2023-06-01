namespace GMS.Core.BusinessLogic.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string errorMsg)
            : base(errorMsg) { }
    }
}
