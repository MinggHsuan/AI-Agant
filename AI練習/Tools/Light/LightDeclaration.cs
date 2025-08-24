using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI練習.Tools.Light
{
    internal class LightDeclaration : ToolDeclaration
    {
        public override string name => "Tools.Light.LightTool";

        public override string description => "這是一個用來設定燈光的函數，你會需要傳入亮度及色溫。";

        public override Parameters parameters => new LightParameter();
    }
}
