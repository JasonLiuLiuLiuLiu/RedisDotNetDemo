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
            //DemoRedis.StartDemo();
            // StringDemo.Start();
           // HashDemo.Start();
           //ListDemo.Start();
            SetDemo.Start();
        }
    }
}
