using System;
using ServiceStack;
using ServiceStack.Text;
using ServiceStack.Redis;
using ServiceStack.DataAnnotations;

namespace RedisDotNetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var redisManger = new RedisManagerPool("127.0.0.1:6379");
            var redis = redisManger.GetClient();
            var redisTodos = redis.As<Todo>();
            var  newTodo=new Todo
            {
                Id = redisTodos.GetNextSequence(),
                Content = "Learn Redis",
                Order = 1,
            };
            redisTodos.Store(newTodo);
            Todo saveTodo = redisTodos.GetById(newTodo.Id);
            "Saved Todo: {0}".Print(saveTodo.Dump());

            saveTodo.Done = true;
            redisTodos.Store(saveTodo);

            var updateTodo = redisTodos.GetById(newTodo.Id);
            "Updated Todo: {0}".Print(updateTodo.Dump());

            redisTodos.DeleteById(newTodo.Id);

            var remainingTodos = redisTodos.GetAll();
            "No more Todos:".Print(remainingTodos.Dump());

            Console.ReadLine();
        }
    }
}
