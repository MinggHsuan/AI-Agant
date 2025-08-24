using AI練習.Models;
using AI練習.Tools;
using AI練習.Tools.Light;
using AI練習.Tools.Schedule;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static AI練習.AIRequest;

namespace AI練習
{
    internal class AIAgent
    {
        AIRequest aIRequest = null;
        AIResponse aIResponse = null;

        public AIAgent()
        {
            aIRequest = new AIRequest();
            // 使用LINQ 去反找程序集中，只有ToolDeclaration的類別，並且 new 出來 (Activator.CreateInstance)
            // 並且添加到 tools 裡面，完成整個 AIRequest摺疊收合

        }
        public void AddPrompt(AgentType agentType, string text)
        {
            aIRequest.AddPrompt(agentType.ToString(), text);
        }
        public async Task<AIResult> GetResult()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent");
            request.Headers.Add("x-goog-api-key", "AIzaSyAugP0UJN206bblH15_8FuetidN95bezWU");
            string content = JsonConvert.SerializeObject(aIRequest);
            request.Content = new StringContent(content);
            var response = await client.SendAsync(request);

            string responseString = await response.Content.ReadAsStringAsync();
            aIResponse = JsonConvert.DeserializeObject<AIResponse>(responseString);
            AIResult result = new AIResult(aIResponse);
            if (!result.CanExcuteTool)
            {
                AddPrompt(AgentType.Model, result.ResponseText);
            }
            return result;
        }

    }
}
