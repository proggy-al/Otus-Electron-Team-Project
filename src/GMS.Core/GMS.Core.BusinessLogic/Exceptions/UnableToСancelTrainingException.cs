namespace GMS.Core.BusinessLogic.Exceptions
{
    public class UnableToСancelTrainingException : Exception
    {
        public UnableToСancelTrainingException(int hoursNoLaterThan)
            : base($"Training can be canceled up to {hoursNoLaterThan} hours in advance.") { }
    }
}
