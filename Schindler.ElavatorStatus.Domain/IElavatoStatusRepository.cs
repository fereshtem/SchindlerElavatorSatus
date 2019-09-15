using System;
using System.Collections.Generic;

namespace Schindler.ElavatorStatus.Domain
{
    public interface IElavatoStatusRepository
    {
        ElavatorStatus InsertStatus(ElavatorStatus elavatorStatus);
        ElavatorStatus GetElavatorStatus(Guid id);
        List<ElavatorStatus> GetStatuses();
        void UpdateElavatorStatus(ElavatorStatus elavatorStatus);
        void DeleteElavatorStatus(Guid id);
    }
}
