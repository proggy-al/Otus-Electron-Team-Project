namespace GMS.Core.BusinessLogic.Exceptions
{
    public class ContractAlreadyApprovedException : Exception
    {
        public ContractAlreadyApprovedException(object key)
            : base($"Contract [{key}] already approved.") { }
    }
}
