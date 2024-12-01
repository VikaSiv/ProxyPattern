using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Proxy
{
    public class Proxy : ISubject
    {
        private readonly RealSubject _realSubject;
        private readonly Dictionary<string, (string result, DateTime cacheTime)> _cache = new();
        private readonly TimeSpan _cacheLifetime = TimeSpan.FromSeconds(10); 

        public Proxy(RealSubject realSubject)
        {
            _realSubject = realSubject;
        }

        public string Request(string request)
        {
            if (!CheckAccess())
            {
                return "Proxy: Доступ запрещен.";
            }
 
            if (_cache.TryGetValue(request, out var cachedData))
            {
                if (DateTime.Now - cachedData.cacheTime < _cacheLifetime)
                {
                    Console.WriteLine("Proxy: Использую данные из кэша.");
                    return cachedData.result;
                }
                else
                {
                    Console.WriteLine("Proxy: Кэш устарел, удаляю запись.");
                    _cache.Remove(request);
                }
            }

            Console.WriteLine("Proxy: Перенаправляю запрос к RealSubject.");
            var result = _realSubject.Request(request);

            _cache[request] = (result, DateTime.Now);
            return result;
        }

        private bool CheckAccess()
        {
 
            Console.WriteLine("Proxy: Проверка прав доступа...");
            return DateTime.Now.Second % 2 == 0; 
        }
    }
}
