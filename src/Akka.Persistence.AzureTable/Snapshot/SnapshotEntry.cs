//-----------------------------------------------------------------------
// <copyright file="SnapshotEntry.cs" company="Akka.NET Project">
//     Copyright (C) 2009-2016 Lightbend Inc. <http://www.lightbend.com>
//     Copyright (C) 2013-2016 Akka.NET project <https://github.com/akkadotnet/akka.net>
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.WindowsAzure.Storage.Table;

namespace Akka.Persistence.AzureTable.Snapshot
{
    public class SnapshotEntry : TableEntity
    {
        public SnapshotEntry() { }

        public SnapshotEntry(string persistenceId, long sequenceNr, long snapshotTimestamp, string manifest, byte[] payload)
        {
            PartitionKey = persistenceId?.ReplaceDisallowedChars();
            RowKey = ToRowKey(sequenceNr);

            SnapshotTimestamp = snapshotTimestamp;
            Manifest = manifest;
            Payload = payload;
        }

        public long SnapshotTimestamp { get; set; }

        public string Manifest { get; set; }

        public byte[] Payload { get; set; }

        public static string ToRowKey(long version)
        {
            return version.ToString().PadLeft(10, '0');
        }
    }
}