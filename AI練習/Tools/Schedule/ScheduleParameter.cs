using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AI練習.AIRequest;

namespace AI練習.Tools.Schedule
{
    internal class ScheduleParameter : Parameters
    {
        public override object properties => new
        {
            attendees = new PropertyDetail()
            {
                type = "array",
                items = new AIRequest.Items() { type = "string" },
                description = "是一個陣列，可以傳入一個或多個的與會人員"
            },
            date = new PropertyDetail()
            {
                type = "string",
                description = "要預約的日期，其中日期格式必須為 yyyy-MM-dd (例如:2025-07-26))"
            },
            time = new PropertyDetail()
            {
                type = "string",
                description = "要預約的時間，請使用24小時制來標示 (例如:23:13)"
            },
            topic = new PropertyDetail()
            {
                type = "string",
                description = "此次會議的主旨"
            }

        };

        public override string[] required => new string[] { "attendees", "date", "time", "topic" };
    }
}
