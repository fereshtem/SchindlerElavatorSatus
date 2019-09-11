using System;

namespace Schindler.ElavatorStatus.Domain
{
    public class Elavator
    {
        public int Id { get; set; }
        public StatusType Status { get; set; }
        public DateTime Date { get; set; }
    }
}
