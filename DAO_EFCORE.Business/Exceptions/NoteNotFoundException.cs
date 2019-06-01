using System;

namespace DAO_EFCORE.Business.Exceptions
{
    public class NoteNotFoundException : ApplicationException
    {
        public NoteNotFoundException(string message) : base(message)
        {
        }
    }
}
