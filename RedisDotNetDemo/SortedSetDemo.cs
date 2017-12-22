using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.Redis;

namespace RedisDotNetDemo
{
    //区别是set不是自动有序的，而sorted set可以通过用户额外提供一个优先级(score)的参数来为成员排序，并且是插入有序的，即自动排序。
    //当你需要一个有序的并且不重复的集合列表，那么可以选择sorted set数据结构， 
    class SortedSetDemo
    {
        public static void Start()
        {
            var redisMangement = new RedisManagerPool("127.0.0.1:6379");
            var client = redisMangement.GetClient();
            client.AddItemToSortedSet("a5", "ffff");
            client.AddItemToSortedSet("a5", "bbbb");
            client.AddItemToSortedSet("a5", "gggg");
            client.AddItemToSortedSet("a5", "cccc");
            client.AddItemToSortedSet("a5", "waaa");
            System.Collections.Generic.List<string> list = client.GetAllItemsFromSortedSet("a5");
            foreach (string str in list)
            {
                Console.WriteLine(str);
            }
        }
    }
}
