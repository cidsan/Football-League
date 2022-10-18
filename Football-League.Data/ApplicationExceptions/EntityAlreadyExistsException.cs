using System;

namespace Football_League.Data.ApplicationExceptions
{
    public class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException(string message) : base(message)
        {
        }
    }
}
