using System;
using System.Collections.Generic;
using System.Text;

namespace Schindler.ElavatorStatus.Domain
{
    public class ElavatorStatusRepository : IElavatoStatusRepository
    {
        #region Fields
        private readonly Dictionary<Guid, ElavatorStatus> _elavtorStatus;
        #endregion
        public ElavatorStatusRepository()
        {
            _elavtorStatus = new Dictionary<Guid, ElavatorStatus>();
        }
        public ElavatorStatus GetElavatorStatus(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<ElavatorStatus> GetStatuses()
        {
            throw new NotImplementedException();
        }

        public void InsertStatus(ElavatorStatus elavatorStatus)
        {

            if (!_elavtorStatus.ContainsKey(elavatorStatus.Id))
            {
                _elavtorStatus.Add(elavatorStatus.Id, new ElavatorStatus(elavatorStatus.Status));
            }
            else
            {
                ElavatorStatus existedStatus = _elavtorStatus[elavatorStatus.Id];
                if (existedStatus != null)
                {
                    throw new Exception();
                }
            }
        }
    }
}
