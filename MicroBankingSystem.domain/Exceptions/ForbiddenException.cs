using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBankingSystem.domain.Exceptions
{
    public class ForbiddenException(string message) : Exception(message)
    {
    }
}
