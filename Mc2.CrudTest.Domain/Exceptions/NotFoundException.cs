﻿namespace Mc2.CrudTest.Domain.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base( message) { }

    }
}
