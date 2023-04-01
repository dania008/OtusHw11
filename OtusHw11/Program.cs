namespace OtusHw11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OtusDictionary dict = new OtusDictionary();
            dict.Add(1, "value1");
            dict.Add(2, "value2");
            dict[3] = "value3";
            Console.WriteLine(dict[1]);  
            Console.WriteLine(dict[2]);  
            Console.WriteLine(dict[3]);
        }
    }
}