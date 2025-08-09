using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AI練習.AIRequest;

namespace AI練習.Tools.Light
{
    internal class LightTool : ToolsFunction
    {
        public LightTool(AIResponse.Args args) : base(args)
        {
        }

        public override void UseTools()
        {
            Console.WriteLine($"已經幫您設定完成。 亮度: {args.brightness}, 色溫: {args.colorTemperature}");
        }
    }
}
