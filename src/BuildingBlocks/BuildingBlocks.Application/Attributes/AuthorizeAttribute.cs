using System;

namespace BuildingBlocks.Application.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class AuthorizeAttribute : Attribute
    {
        public string Roles { get; set; }

        public string Policy { get; set; }

        public AuthorizeAttribute() { }
    }
}
