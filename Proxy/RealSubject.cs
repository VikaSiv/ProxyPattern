using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Proxy
{
    public class RealSubject : ISubject
    {
        public string Request(string request)
        {
            Console.WriteLine($"RealSubject: Обрабатываю запрос '{request}'...");
            return $"Результат для запроса: {request}";
        }
    }
}
