using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.Redis;

namespace RedisDotNetDemo
{
    class HashDemo
    {
        public static void Start()
        {
            var redisMangement = new RedisManagerPool("127.0.0.1:6379");
            var client = redisMangement.GetClient();
            client.SetEntryInHash("test", "123", "aaaaa");
            List<string> listKeys = client.GetHashKeys("test");
            Console.WriteLine("keys in test");
            foreach (var VARIABLE in listKeys)
            {
                Console.WriteLine(VARIABLE);
            }
            List<string> listValue = client.GetHashValues("test");
            Console.WriteLine("test 里的所有值");
            foreach (var VARIABLE in listValue)
            {
                Console.WriteLine(VARIABLE);
            }
            string value = client.GetValueFromHash("test", listKeys[0]);
            Console.WriteLine("test 下的key"+listKeys[0]+"对应的值"+value);

        }
    }
}
