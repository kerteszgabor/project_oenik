using System;
namespace project.Domain.Exceptions
{
    public class EntityNotFoundException<T> : Exception
    {
        public EntityNotFoundException()
        {
        }

        public override string Message
        {
            get
            {
                return $"Error: entity of type {typeof(T)} was not found.";
            }
        }
    }
}
