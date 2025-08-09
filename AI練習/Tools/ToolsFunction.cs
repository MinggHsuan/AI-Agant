using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AI練習.AIRequest;

namespace AI練習.Tools
{
    internal abstract class ToolsFunction
    {
        protected AIResponse.Args args;

        public ToolsFunction(AIResponse.Args args)
        {
            this.args = args;
        }
        public abstract void UseTools();

    }
}
