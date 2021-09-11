using BuildingBlocks.Application.Interfaces;
using System;

namespace BuildingBlocks.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
