using System;


namespace KMZI_Lab14
{
    public class Program
    {
        static void Main(string[] args)
        {
            var inp = @"C:\Users\valda\source\repos\semester#6\КМЗИ\KMZI_Lab14\KMZI_Lab14\Images\sample.bmp";
            var res = @"C:\Users\valda\source\repos\semester#6\КМЗИ\KMZI_Lab14\KMZI_Lab14\Images\ecnrypted_by_rows.bmp";
            Steganography.EmbedMessage(inp, "ValdaitsevAlexanderDenisovich", res);
            Console.WriteLine("Embed completed");
            var resText = Steganography.ExtractMessage(res);
            Console.WriteLine($"Result text: {resText}");

            Steganography2.EmbedMessage(inp, "Valdaitsev", @"C:\Users\valda\source\repos\semester#6\КМЗИ\KMZI_Lab14\KMZI_Lab14\Images\ecnrypted_by_columns.bmp");
            Console.WriteLine($"Result text: {Steganography2.ExtractMessage(@"C:\Users\valda\source\repos\semester#6\КМЗИ\KMZI_Lab14\KMZI_Lab14\Images\ecnrypted_by_columns.bmp")}");

            /*
            RandomLSB.EmbedMessage(inp, "Super cool message for embed",  @"C:\course\leet\app\lab14\res2.bmp");
            Console.WriteLine($"Res2: {RandomLSB.ExtractMessage(@"C:\course\leet\app\lab14\res2.bmp")}");
            */

            Steganography.SaveLastBit(inp, @"C:\Users\valda\source\repos\semester#6\КМЗИ\KMZI_Lab14\KMZI_Lab14\Images\matrix_sample.bmp");
            Steganography.SaveLastBit(res, @"C:\Users\valda\source\repos\semester#6\КМЗИ\KMZI_Lab14\KMZI_Lab14\Images\matrix_encrypt.bmp");
        }
    }
}
