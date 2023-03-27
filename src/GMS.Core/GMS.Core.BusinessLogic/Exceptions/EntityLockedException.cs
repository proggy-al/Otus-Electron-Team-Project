namespace GMS.Core.BusinessLogic.Exceptions
{
    public class EntityLockedException : Exception
    {
        public EntityLockedException(string name, object key)
            : base($"{name} [{key}] deleted and read-only.") { }
    }
}
