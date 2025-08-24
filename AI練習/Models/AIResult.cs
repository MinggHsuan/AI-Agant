using AI練習.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI練習.Models
{
    internal class AIResult
    {
        AIResponse response;
        public string ResponseText;
        public bool CanExcuteTool;
        public AIResult(AIResponse response)
        {
            this.response = response;
            this.ResponseText = response.candidates[0].content.parts[0].text;
            this.CanExcuteTool = response.candidates[0].content.parts[0].functionCall != null;

        }

        public void RunTool()
        {
            var toolCall = response.candidates[0].content.parts[0].functionCall;
            Type type = Type.GetType("AI練習." + toolCall.name);
            var tool = (ToolsFunction)Activator.CreateInstance(type, new object[] { toolCall.args });
            tool.UseTools();
        }
    }
}
