using DesafioPOO.Models;

// TODO: Realizar os testes com as classes Nokia e Iphone

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Smartphone Nokia");
        Smartphone nokia = new Nokia(numero: "123456", modelo: "Modelo 1", imei: "111111", memoria: 128);
        nokia.Ligar();
        nokia.InstalarAplicativo("WhatsApp");

        Console.WriteLine("\n");

        Console.WriteLine("Smartphone IPhone");
        Smartphone iphone = new Iphone(numero: "654321", modelo: "Modelo 2", imei: "999999", memoria: 128);
        iphone.Ligar();
        iphone.InstalarAplicativo("Instagram");
    }
}