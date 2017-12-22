using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.Redis;
using ServiceStack.Text;

namespace RedisDotNetDemo
{
    class DemoRedis
    {
        public static void StartDemo()
        {
            var redisManger = new RedisManagerPool("127.0.0.1:6379");      //Redis的连接字符串
            var redis = redisManger.GetClient();                           //获取一个Redis Client
            var redisTodos = redis.As<Todo>();
            var newTodo = new Todo                                          //实例化一个Todo类
            {
                Id = redisTodos.GetNextSequence(),
                Content = "Learn Redis",
                Order = 1,
            };
            redisTodos.Store(newTodo);                                    //把newTodo实例保存到数据库中    增     
            Todo saveTodo = redisTodos.GetById(newTodo.Id);               //根据Id查询        查
            "Saved Todo: {0}".Print(saveTodo.Dump());

            saveTodo.Done = true;                                         //改
            redisTodos.Store(saveTodo);

            var updateTodo = redisTodos.GetById(newTodo.Id);            //查
            "Updated Todo: {0}".Print(updateTodo.Dump());

            redisTodos.DeleteById(newTodo.Id);                           //删除

            var remainingTodos = redisTodos.GetAll();
            "No more Todos:".Print(remainingTodos.Dump());

            Console.ReadLine();
        }
    }
}
