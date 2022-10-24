using Demo3.Shared;

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Demo 3 - producing numbers");
Console.WriteLine("--------------------------");
Console.ResetColor();
Producer generalProducer = new Producer("localhost", "demo3", 10);
int i = 0;
for(i=0; i < 1000; i++)
{
    generalProducer.SendMessage(i.ToString());
}
Console.WriteLine($"Produced {i} messages");
Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();