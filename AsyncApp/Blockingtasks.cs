// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Runtime.CompilerServices;
namespace AsyncApp;
class Blockingtasks
{
    static void Main1(string[] args)
    {
        Stopwatch sw = Stopwatch.StartNew();
        sw.Start();
        Console.WriteLine("Sending to Processors!");
        var resultVisa = processVisa(new Reqeust { Amount = 1, CardNumber = "4234567890123456", CarName = "Visa name", CVV = 123, Expiry = "10/2026" });
        var resultMC = processMC(new Reqeust { Amount = 2, CardNumber = "5234567890123456", CarName = "MC name", CVV = 123, Expiry = "11/2026" });
        var resultAmex = processAmex(new Reqeust { Amount = 3, CardNumber = "323456789012345", CarName = "Amex name", CVV = 123, Expiry = "12/2026" });

        //var cardTasks = new List<Task> { resultVisa, resultMC, resultAmex };
        //while (cardTasks.Count > 0)
        //{
        //    Task finishedTask = await Task.WhenAny(cardTasks);
        //    if (finishedTask == resultVisa)
        //    {
        //        Console.WriteLine("Received response from Visa..");
        //    }
        //    else if (finishedTask == resultMC)
        //    {
        //        Console.WriteLine("Received response from MC..");            
        //    }
        //    else if (finishedTask == resultAmex)
        //    {
        //        Console.WriteLine("Received response from Amex..");
        //    }
        //    await finishedTask;
        //    cardTasks.Remove(finishedTask);
        //}

        sw.Stop();
        Console.WriteLine($"Time Elapsed {sw.ElapsedMilliseconds} miliseconds");
    }

    public static  Result processVisa(Reqeust reqeust)
    {
        Console.WriteLine("sending it to Visa..");
         Task.Delay(10000).Wait();
        return new Result { IsSuccess = true, ResponseID = 123, TransactionID = 123 };
    }
    public static  Result processMC(Reqeust reqeust)
    {
        Console.WriteLine("sending it to MC..");
         Task.Delay(10000).Wait();
        return new Result { IsSuccess = true, ResponseID = 456, TransactionID = 456 };
    }
    public static Result processAmex(Reqeust reqeust)
    {
        Console.WriteLine("sending it to Amex..");
        Task.Delay(10000).Wait();
        return new Result { IsSuccess = true, ResponseID = 987, TransactionID = 987 };
    }
    public class Reqeust
    {
        public string CardNumber { get; set; }
        public int CVV { get; set; }
        public string CarName { get; set; }
        public string Expiry { get; set; }
        public decimal Amount { get; set; }
    }

    public class Result
    {
        public int TransactionID { get; set; }
        public int ResponseID { get; set; }
        public bool IsSuccess { get; set; }
    }
}
