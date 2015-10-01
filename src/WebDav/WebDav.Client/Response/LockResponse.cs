﻿
using System.Collections.Generic;
using System.Linq;

namespace WebDav
{
    public class LockResponse : WebDavResponse
    {
        public LockResponse(int statusCode)
            : this(statusCode, null, new List<ActiveLock>())
        {
        }

        public LockResponse(int statusCode, IEnumerable<ActiveLock> activeLocks)
            : this(statusCode, null, activeLocks)
        {
        }

        public LockResponse(int statusCode, string description)
            : this(statusCode, description, new List<ActiveLock>())
        {
        }

        public LockResponse(int statusCode, string description, IEnumerable<ActiveLock> activeLocks)
            : base(statusCode, description)
        {
            Guard.NotNull(activeLocks, "activeLocks");
            ActiveLocks = activeLocks.ToList();
        }

        public IReadOnlyCollection<ActiveLock> ActiveLocks { get; private set; }

        public override string ToString()
        {
            return string.Format("LOCK response - StatusCode: {0}, Description: {1}", StatusCode, Description);
        }
    }
}