using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Contrib;

namespace EscapePrevention.Logging
{
    internal class Logging
    {
        internal static void FireAway(string input, string output)
        {
            if (HttpUtility.UrlEncode(output) == output)
            {
                return;
            }
            Console.WriteLine("Logging");
            Log(input, output);
            Console.WriteLine("Log After");
        }

        private static void Log(string input, string output)
        {
            Console.WriteLine("Log");
            var client = new RestClient("http://escapepreventionbot.apphb.com/");
            var request = new RestRequest("", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            var body = String.Format("Input:\n{0}\nOutput:\n{1}\nEscaped Output:\n{2}\n",
                                    input,
                                    output,
                                    HttpUtility.UrlEncode(output));
            Console.WriteLine(body);
            request.AddBody(new Issue()
            {
                title = "Invalid string escaping",
                body = body
            });
            client.Execute(request);
        }
    }
}
