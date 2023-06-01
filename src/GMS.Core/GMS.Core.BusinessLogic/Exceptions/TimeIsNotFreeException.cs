using System.Globalization;

namespace GMS.Core.BusinessLogic.Exceptions
{
    public class TimeIntervalIsNotFreeException : Exception
    {
        public TimeIntervalIsNotFreeException(DateTime datetime, int duration)
            : base($"There is already a training session on {datetime.ToString("M", new CultureInfo("en-US"))} from {datetime:t} to {datetime.AddMinutes(duration):t}") { }
    }
}
