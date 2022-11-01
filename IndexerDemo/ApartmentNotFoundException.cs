using System.Runtime.Serialization;

namespace IndexerDemo
{
    [Serializable]
    public class ApartmentNotFoundException : Exception
    {
        public ApartmentNotFoundException()
        {
        }

        public ApartmentNotFoundException(string? message) : base(message)
        {
        }

        public ApartmentNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ApartmentNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}