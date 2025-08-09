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

            List<AIRequest.Content> contents = new List<AIRequest.Content>();

            AIRequest aIRequest = new AIRequest()
            {
                tools = new List<AIRequest.Tool>()
                {
                    new AIRequest.Tool()
                    {
                        functionDeclarations = new List<AIRequest.Functiondeclaration>()
                        {
                            new AIRequest.Functiondeclaration()
                            {
                                name="Tools.Schedule.ScheduleTool",
                                description="這是一個可以用來作為行程預約安排的函數，你會需要傳入與會人員以及要安排的會議主旨和日期時間，讓該函數可以自動預約行程",
                                parameters=new AIRequest.Parameters()
                                {
                                    type="object",
                                    properties=new AIRequest.Properties()
                                    {
                                        attendees=new AIRequest.Attendees()
                                        {
                                            type = "array",
                                            items=new AIRequest.Items(){ type="string"},
                                            description="是一個陣列，可以傳入一個或多個的與會人員"
                                        },
                                        date=new AIRequest.Date()
                                        {
                                            type="string",
                                            description="要預約的日期，其中日期格式必須為 yyyy-MM-dd (例如:2025-07-26))"
                                        },
                                        time=new AIRequest.Time()
                                        {
                                            type="string",
                                            description="要預約的時間，請使用24小時制來標示 (例如:23:13)"
                                        },
                                        topic=new AIRequest.Topic()
                                        {
                                            type="string",
                                            description="此次會議的主旨"
                                        }
                                    },
                                    required=new string[]{"attendees", "date", "time", "topic" }
                                }
                            },
                             new AIRequest.Functiondeclaration()
                             {
                                 name="Tools.Light.LightTool",
                                 description="這是一個用來設定燈光的函數，你會需要傳入亮度及色溫。",
                                 parameters=new AIRequest.Parameters()
                                 {
                                     type="object",
                                     properties=new AIRequest.Properties()
                                     {
                                         brightness=new Brightness()
                                         {
                                             type="integer",
                                             description= "燈光的亮度，這是一個整數數字，必須為0-100，(例如:25)"
                                         },
                                         colorTemperature=new ColorTemperature()
                                         {
                                            type= "string",
                                            @enum= new List<string>(){"daylight", "cool", "warm" },
                                            description= "燈光的色溫，是一個陣列，可以傳入你想要的色溫模式，(例如:暖光)",
                                         }
                                     },
                                     required=new string[]{ "brightness", "colorTemperature" }
                                 }
                             }
                        },

                    }
                },

                contents = contents
            };

            aIRequest.contents.Add(new AIRequest.Content("model", "作為一個AI助理，目前能幫忙設定燈光亮度與色溫，並且還能預約行程，你只能針對當前擁有的函數功能來協助使用者解決問題，除此之外的問題都不應該回答。此外，使用者也會告訴你各種不同的燈光模式，你需要根據不同模式下的情境直接給予一個最合適的燈光參數值"));

            Console.WriteLine("您好，有什麼需要幫忙的嗎?");
            while (true)
            {
                string userInput = Console.ReadLine();
                aIRequest.contents.Add(new AIRequest.Content("user", userInput));

                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent");
                request.Headers.Add("x-goog-api-key", "AIzaSyAugP0UJN206bblH15_8FuetidN95bezWU");
                string content = JsonConvert.SerializeObject(aIRequest);
                request.Content = new StringContent(content);
                var response = await client.SendAsync(request);

                string responseString = await response.Content.ReadAsStringAsync();
                var aIResponse = JsonConvert.DeserializeObject<AIResponse>(responseString);


                if (aIResponse.candidates[0].content.parts[0].functionCall != null)
                {
                    var toolCall = aIResponse.candidates[0].content.parts[0].functionCall;
                    Type type = Type.GetType("AI練習." + toolCall.name);
                    var tool = (ToolsFunction)Activator.CreateInstance(type, new object[] { toolCall.args });
                    tool.UseTools();
                    aIRequest.contents.Add(new AIRequest.Content("model", "已幫您執行完成:" + JsonConvert.SerializeObject(toolCall)));

                }
                else
                {
                    Console.WriteLine(aIResponse.candidates[0].content.parts[0].text);
                    aIRequest.contents.Add(new AIRequest.Content("model", aIResponse.candidates[0].content.parts[0].text));
                }
                Console.ReadKey();
            }
        }


    }
}
