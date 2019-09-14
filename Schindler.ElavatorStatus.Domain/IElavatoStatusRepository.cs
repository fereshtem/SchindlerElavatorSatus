using System;
using System.Collections.Generic;
using System.Text;

namespace Schindler.ElavatorStatus.Domain
{
    public interface IElavatoStatusRepository
    {
        void InsertStatus(ElavatorStatus elavator);
        ElavatorStatus GetElavatorStatus(Guid id);
        List<ElavatorStatus> GetStatuses();
    }
}
