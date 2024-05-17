using RecordLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyRecordsApp
{
    public class RecordManager
    {
        private readonly List<Record> _records;

        public RecordManager()
        {
            _records = new List<Record>();
        }

        public IEnumerable<Record> GetRecords() => _records;

        public Record CreateRecord(string content)
        {
            var record = new Record
            {
                Id = _records.Any() ? _records.Max(r => r.Id) + 1 : 1,
                Content = content,
                Date = DateTime.Now.Date
            };
            _records.Add(record);

            var filePath = $"Records_{record.Date:yyyyMMdd}.txt";
            var recordContent = $"Id: {record.Id}, Content: {record.Content}, Date: {record.Date}\n";
            FileHelper.SaveRecordToFile(filePath, recordContent);

            return record;
        }
    }
}
