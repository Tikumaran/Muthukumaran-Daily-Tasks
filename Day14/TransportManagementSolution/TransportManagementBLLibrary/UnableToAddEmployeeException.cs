using System;
using System.Collections.Generic;
using System.Text;

namespace TransportManagementBLLibrary
{
    public class UnableToAddEmployeeException : ApplicationException
    {
        string _message;
        public UnableToAddEmployeeException()
        {
            _message = "Unable to Add a Employee Bcz of ID Duplication.Try Again";
        }
        public override string Message => _message;
    }
}
