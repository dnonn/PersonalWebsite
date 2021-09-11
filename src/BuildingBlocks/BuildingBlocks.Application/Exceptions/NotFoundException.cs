using System;

namespace BuildingBlocks.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, int id)
            : base($"Unable to locate {name} with an id of {id}.")
        { }
        
        public NotFoundException(string name, string hashId)
            : base($"Unable to locate {name} with an id of {hashId}.")
        { }
    }
}
