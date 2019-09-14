using System;

namespace Schindler.ElavatorStatus.Domain
{
    public class ElavatorStatus
    {
        public ElavatorStatus(StatusType status)
        {
            Id = Guid.NewGuid();
            Status = status;
            Date = DateTime.UtcNow;
        }
        public Guid Id { get; set; }
        public StatusType Status { get; set; }
        public DateTime Date { get; set; }
    }
}
