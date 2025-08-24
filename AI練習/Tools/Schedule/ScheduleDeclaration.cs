using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI練習.Tools.Schedule
{
    internal class ScheduleDeclaration : ToolDeclaration
    {
        public override string name => "Tools.Schedule.ScheduleTool";

        public override string description => "這是一個可以用來作為行程預約安排的函數，你會需要傳入與會人員以及要安排的會議主旨和日期時間，讓該函數可以自動預約行程";

        public override Parameters parameters => new ScheduleParameter();
    }
}
