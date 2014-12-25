using System;

namespace Wykop.ApiProvider.Model.Operations
{
    public class EntryAddResult
    {
        internal EntryAddResult()
        {
        }

        public bool HasEntryBeenAdded { get; internal set; }
        internal int? AddedEntryId { get; set; }

        public int GetAddedEntryId()
        {
            if (AddedEntryId == null)
                throw new InvalidOperationException("Entry wasn't added.");

            return AddedEntryId.Value;
        }
    }
}