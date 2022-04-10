// See https://aka.ms/new-console-template for more information
using Singleton;

Console.WriteLine("Singleton Pattern");

var instance1 = Logger.Instance;
var instance2 = Logger.Instance;

if(instance1 == instance2 && instance2 == Logger.Instance)
{
    Console.WriteLine("Instances are the same!");
}

instance1.Log("I am instance 1");
instance2.Log("I am instance 2");
