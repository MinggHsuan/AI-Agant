using AI練習.Models;
using AI練習.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static AI練習.AIRequest;

namespace AI練習
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            AIAgent aIAgent = new AIAgent();
            aIAgent.AddPrompt(AgentType.Model, "作為一個AI助理，目前能幫忙設定燈光亮度與色溫，並且還能預約行程，你只能針對當前擁有的函數功能來協助使用者解決問題，除此之外的問題都不應該回答。此外，使用者也會告訴你各種不同的燈光模式，你需要根據不同模式下的情境直接給予一個最合適的燈光參數值");
            Console.WriteLine("您好，有什麼需要幫忙的嗎?");
            while (true)
            {
                aIAgent.AddPrompt(AgentType.User, Console.ReadLine());
                AIResult result = await aIAgent.GetResult();

                if (!result.CanExcuteTool)
                {
                    Console.WriteLine(result.ResponseText);
                    continue;
                }
                result.RunTool();
                break;
            }

            Console.ReadKey();
        }


    }
}
