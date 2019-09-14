using System;
using System.Collections.Generic;
using System.Text;

namespace Schindler.ElavatorStatus.Domain
{
    public interface IElavatoStatusRepository
    {
        void InsertStatus(ElavatorStatus elavatorStatus);
        ElavatorStatus GetElavatorStatus(Guid id);
        List<ElavatorStatus> GetStatuses();
        void UpdateElavatorStatus(ElavatorStatus elavatorStatus);
        void DeleteElavatorStatus(Guid id);
    }
}
