using System;

namespace Receipt_service.Core.Models
{
    public class DateTimeProvider
    {
        public virtual DateTime Now { get; } = DateTime.Now;
    }
}