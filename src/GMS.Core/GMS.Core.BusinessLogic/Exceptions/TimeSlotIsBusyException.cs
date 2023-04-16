using System.Globalization;

namespace GMS.Core.BusinessLogic.Exceptions
{
    public class TimeslotIsBusyException : Exception
    {
        public TimeslotIsBusyException(string timeslotName, DateTime dateTime)
            : base($"Timeslot \"{timeslotName}\" on {dateTime.ToString("M", new CultureInfo("en-US"))} is busy.") { }
    }
}
