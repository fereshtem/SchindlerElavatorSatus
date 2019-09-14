using System;
using Schindler.ElavatorStatus.Domain.Extensions;

namespace Schindler.ElavatorStatus.Domain
{
    public class ElavatorStatus
    {
        public ElavatorStatus(string status)
        {
            Id = Guid.NewGuid();
            Status = status.IfNotNullOrEmpty(); ;
            Date = DateTime.UtcNow;
        }
        public Guid Id { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }

        public void UpdateElavatorStatus(ElavatorStatus elavatorStatus)
        {
            elavatorStatus.IfNotNull();
            if (String.Compare(Status, elavatorStatus.Status) != 0)
            {
                Status = elavatorStatus.Status;
                Date = DateTime.UtcNow;
            }
        }
    }
}
