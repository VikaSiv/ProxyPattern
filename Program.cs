using System;
using System.Threading.Tasks;
using ProxyPattern.Proxy;


namespace ProxyPatternExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var realSubject = new RealSubject();
            var proxy = new Proxy(realSubject);

            Console.WriteLine("Клиент: Выполняю запрос через Proxy...");
            Console.WriteLine(proxy.Request("Запрос1"));

            Console.WriteLine("\nКлиент: Повторяю запрос через Proxy...");
            Console.WriteLine(proxy.Request("Запрос1"));

            Console.WriteLine("\nКлиент: Жду несколько секунд и повторяю запрос...");
            await Task.Delay(11000); 
            Console.WriteLine(proxy.Request("Запрос1"));

            Console.WriteLine("\nКлиент: Пробую другой запрос...");
            Console.WriteLine(proxy.Request("Запрос2"));
        }
    }
}
