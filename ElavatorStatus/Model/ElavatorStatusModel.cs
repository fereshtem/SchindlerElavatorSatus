using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Schindler.ElavatorStatus.WebService.Model
{
    [DataContract(Name = "ElavatorStatus")]
    public class ElavatorStatusModel
    {
        [DataMember(Name = "ElevatorId")]
        public Guid Id { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember(Name = "LastUpdated")]
        public DateTime Date { get; set; }
    }
}
