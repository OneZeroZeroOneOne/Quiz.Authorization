using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Authorization.Utilities.Exceptions
{
    public enum ExceptionEnum
    {
        InvalidCredentials = 1,
        SecurityKeyIsNull = 2,
        AuthorizationHeaderNotExist = 3,
    }
}
