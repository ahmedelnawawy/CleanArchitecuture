using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Core.Common.Exceptions
{
    public class EntityIsAlreadyExists : ValidationExceptionBase
    {
        public override string ErrorTemplate => "{0}_Is Already Exists";

        public EntityIsAlreadyExists(string entityName) : base(new[] { entityName })
        {
        }
    }
}
