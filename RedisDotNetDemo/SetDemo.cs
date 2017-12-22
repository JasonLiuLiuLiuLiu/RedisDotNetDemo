using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.Redis;

namespace RedisDotNetDemo
{
    class SetDemo
    {//它是string类型的无序集合。set是通过hash table实现的，添加，删除和查找,对集合我们可以取并集，交集，差集.
        public static void Start()
        {
            var redisMangement = new RedisManagerPool("127.0.0.1:6379");
            var client = redisMangement.GetClient();
            //对Set类型进行操作

            client.AddItemToSet("a3", "ddd");
            client.AddItemToSet("a3", "ccc");
            client.AddItemToSet("a3", "tttt");
            client.AddItemToSet("a3", "sssh");
            client.AddItemToSet("a3", "hhhh");

            HashSet<string> hashSet = client.GetAllItemsFromSet("a3");
            foreach (var VARIABLE in hashSet)
            {
                Console.WriteLine(VARIABLE);
            }

            //求并集
            client.AddItemToSet("a4", "hhhh");
            client.AddItemToSet("a4", "h777");
            HashSet<string> hashSetUnion = client.GetUnionFromSets(new string[] {"a3", "a4"});
            Console.WriteLine("并集");
            foreach (var VARIABLE in hashSetUnion)
            {
                Console.WriteLine(VARIABLE);
            }

            //求交集
            HashSet<string> hashsetInter = client.GetIntersectFromSets(new string[] { "a3","a4" });
            Console.WriteLine("交集");
            foreach (var VARIABLE in hashsetInter)
            {
                Console.WriteLine(VARIABLE);
            }
            //求差集
            HashSet<string> hashsetDifference = client.GetDifferencesFromSet("a3", new string[] { "a4" });
            Console.WriteLine("差集");
            foreach (var VARIABLE in hashsetDifference)
            {
                Console.WriteLine(VARIABLE);
            }
        }
    }
}
