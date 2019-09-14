using System;
using System.Collections.Generic;
using System.Text;
using Schindler.ElavatorStatus.Domain.Extensions;

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

        public void DeleteElavatorStatus(Guid id)
        {
            var item = GetElavatorStatus(id);
            if (item != null)
            {
                _elavtorStatus.Remove(id);
            }
        }

        public ElavatorStatus GetElavatorStatus(Guid id)
        {
            ElavatorStatus item = null;

            if (_elavtorStatus.ContainsKey(id))
            {
                item = _elavtorStatus[id];
            }

            return item;
        }

        public List<ElavatorStatus> GetStatuses()
        {
            List<ElavatorStatus> elavatorStatuses = new List<ElavatorStatus>();

            foreach (KeyValuePair<Guid, ElavatorStatus> obj in _elavtorStatus)
            {
                elavatorStatuses.Add(obj.Value);
            }

            return elavatorStatuses;
        }

        public void InsertStatus(ElavatorStatus elavatorStatus)
        {
            if (!_elavtorStatus.ContainsKey(elavatorStatus.Id))
            {
                _elavtorStatus.Add(elavatorStatus.Id, elavatorStatus);
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

        public void UpdateElavatorStatus(ElavatorStatus elavatorStatus)
        {
            elavatorStatus.IfNotNull();
            if (!_elavtorStatus.ContainsKey(elavatorStatus.Id))
            {
                return;
            }
            _elavtorStatus[elavatorStatus.Id].UpdateElavatorStatus(elavatorStatus);
        }
    }
}
