using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AI練習.AIRequest;

namespace AI練習.Tools
{

    public abstract class Parameters
    {
        public string type { get; set; } = "object";
        public abstract object properties { get; }
        public abstract string[] required { get; }
    }
}
