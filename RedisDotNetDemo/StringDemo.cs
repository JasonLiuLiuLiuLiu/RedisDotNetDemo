using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.Redis;
using ServiceStack.Text;

namespace RedisDotNetDemo
{
    class StringDemo
    {
        public static void Start()
        {
            var redisMangement = new RedisManagerPool("127.0.0.1:6379");
            var client = redisMangement.GetClient();

            client.Set<int>("pwd", 111);
            int pwd = client.Get<int>("pwd");
            Console.WriteLine(pwd);
            var todoTools = client.As<Todo>();
            Todo todo=new Todo(){Content = "123",Id =todoTools.GetNextSequence(),Order = 1};
            client.Set<Todo>("todo", todo);
            Todo getTodo = client.Get<Todo>("todo");
            //"todo xinxi".Print(getTodo.Dump());
            Console.WriteLine(getTodo.Content);

            List<Todo> list=new List<Todo>(){new Todo(){Content = "123"},new Todo(){Content = "234"}};

            client.Set("list", list);
            List<Todo> getList = client.Get<List<Todo>>("list");

            foreach (var VARIABLE in getList)
            {
                Console.WriteLine(VARIABLE.Content);
            }
            Console.ReadLine();
        }
    }
}
