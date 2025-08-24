using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AI練習.AIRequest;

namespace AI練習.Tools.Light
{
    internal class LightParameter : Parameters
    {
        public override object properties => new
        {
            brightness = new PropertyDetail()
            {
                type = "integer",
                description = "燈光的亮度，這是一個整數數字，必須為0-100，(例如:25)"
            },
            colorTemperature = new PropertyDetail()
            {
                type = "string",
                @enum = new List<string>() { "daylight", "cool", "warm" },
                description = "燈光的色溫，是一個陣列，可以傳入你想要的色溫模式，(例如:暖光)",
            }
        };
        public override string[] required => new string[] { "brightness", "colorTemperature" };
    }
}
