using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBankingSystem.domain.Exceptions
{
    public class NotFoundException(string message) : Exception(message)
    {
    }
}
