using AI練習.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace AI練習
{
    internal class AIRequest
    {
        public List<Content> contents { get; set; }
        public List<Tool> tools { get; set; } = new List<AIRequest.Tool>();
        public AIRequest()
        {
            this.contents = new List<AIRequest.Content>();
            tools.Add(new AIRequest.Tool());
        }

        public void AddPrompt(string role, string text)
        {
            contents.Add(new Content(role, text));
        }
        public class Content
        {
            public string role { get; set; }
            public List<Part> parts { get; set; } = new List<Part>();
            public Content(string role, string text)
            {
                this.role = role;
                parts.Add(new AIRequest.Part(text));
            }

        }

        public class Part
        {
            public object text { get; set; }
            public Part(object text)
            {
                this.text = text;
            }
        }

        public class Tool
        {
            public List<ToolDeclaration> functionDeclarations { get; set; } = new List<ToolDeclaration>();

            public Tool()
            {
                var types = Assembly.GetExecutingAssembly().DefinedTypes
                .Where(x => x.Name.EndsWith("Declaration"))
                .Where(x => x.Name != "ToolDeclaration")
                .Select(x =>
                {
                    return (ToolDeclaration)Activator.CreateInstance(Type.GetType(x.FullName));

                });
                functionDeclarations.AddRange(types);

            }
        }


        public class Properties
        {
            public PropertyDetail attendees { get; set; }
            public PropertyDetail date { get; set; }
            public PropertyDetail time { get; set; }
            public PropertyDetail topic { get; set; }
            public PropertyDetail brightness { get; set; }
            public PropertyDetail colorTemperature { get; set; }
        }

        public class Items
        {
            public string type { get; set; }
        }
        public class Topic
        {
            public string type { get; set; }
            public string description { get; set; }
        }

        public class PropertyDetail
        {
            public string type { get; set; }
            public string description { get; set; }
            public Items items { get; set; }
            public List<string> @enum { get; set; }
        }

    }
}
