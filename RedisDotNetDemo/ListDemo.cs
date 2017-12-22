using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.Redis;

namespace RedisDotNetDemo
{
    class ListDemo
    {//Redis的list类型其实就是一个每个子元素都是string类型的双向链表。我们可以通过push,pop操作从链表的头部或者尾部添加删除元素
        public static void Start()
        {
            var redisMangement = new RedisManagerPool("127.0.0.1:6379");
            var client = redisMangement.GetClient();

            //队列的使用   //先进先出
            client.EnqueueItemOnList("name","zhangsan");
            client.EnqueueItemOnList("name","lisi");
            long count = client.GetListCount("name");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(client.DequeueItemFromList("name"));
            }


            //栈的使用 //先进后出
            client.PushItemToList("name2","wangwu");
            client.PushItemToList("name2","maliu");
            long count2 = client.GetListCount("name2");
            for (int i = 0; i < count2; i++)
            {
                Console.WriteLine(client.PopItemFromList("name2"));
            }
        }
    }
}
