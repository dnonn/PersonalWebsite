using System;

namespace BuildingBlocks.Application.Exceptions
{
    public class HashIdDecodingException : ApplicationException
    {
        public HashIdDecodingException(string hashId)
            : base($"Unable to decode {hashId}.")
        { }
    }
}
