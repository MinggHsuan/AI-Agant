using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AI練習.AIRequest;

namespace AI練習.Tools
{
    internal abstract class ToolDeclaration
    {
        public abstract string name { get; }
        public abstract string description { get; }
        public abstract Parameters parameters { get; }
    }
}
