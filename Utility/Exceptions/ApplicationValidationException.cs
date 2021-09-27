using System;
namespace Utility.Exceptions
{
    public class ApplicationValidationException : Exception
    {
        public ApplicationValidationException(string mesage) : base(mesage)
        {
            
            
        }
    }
}