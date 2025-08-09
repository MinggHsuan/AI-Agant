using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI練習.Tools.Schedule
{
    internal class ScheduleTool : ToolsFunction
    {
        public ScheduleTool(AIResponse.Args args) : base(args)
        {
        }

        public override void UseTools()
        {
            Console.WriteLine($"已經幫您設定完成。日期:{args.date}," +
                $"時間:{args.time},與會人員:{String.Join(",", args.attendees)},主旨:{args.topic}");

        }
    }
}
