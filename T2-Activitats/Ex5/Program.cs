namespace Ex5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"Exercicis:" +
                $"\n[a] A" +
                $"\n[b] B");

            string? option = Console.ReadLine();

            Console.Clear();

            switch (option)
            {
                case "a" or "A":
                    A();
                    break;
                case "b" or "B":
                    B();
                    break;
                default:
                    Console.WriteLine("Opció no vàlida");
                    break;
            }
        }

        public static void A()
        {
            Thread th1 = new Thread(() => WriteHello(1));
            Thread th2 = new Thread(() => WriteHello(2));
            Thread th3 = new Thread(() => WriteHello(3));
            Thread th4 = new Thread(() => WriteHello(4));
            Thread th5 = new Thread(() => WriteHello(5));

            th1.Start();
            th2.Start();
            th3.Start();
            th4.Start();
            th5.Start();
        }

        public static void B()
        {
            Thread th1 = new Thread(() =>
            {
                Thread.Sleep(4000);
                WriteHello(1);
            });
            Thread th2 = new Thread(() =>
            {
                Thread.Sleep(3000);
                WriteHello(2);
            });
            Thread th3 = new Thread(() =>
            {
                Thread.Sleep(2000);
                WriteHello(3);
            });
            Thread th4 = new Thread(() =>
            {
                Thread.Sleep(1000);
                WriteHello(4);
            });
            Thread th5 = new Thread(() => WriteHello(5));

            th1.Start();
            th2.Start();
            th3.Start();
            th4.Start();
            th5.Start();
        }

        public static void WriteHello(int th)
        {
            Console.WriteLine($"Hola! Soc el fil número {th}");
        }
    }
}
