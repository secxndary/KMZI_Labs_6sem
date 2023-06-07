using System;

namespace KMZI_Lab14
{
    public class Program
    {
        static void Main(string[] args)
        {
            var fileNameOpen = @"C:\Users\valda\source\repos\semester#6\КМЗИ\KMZI_Lab14\KMZI_Lab14\Images\sample.bmp";
            var fileNameEncryptByRows = @"C:\Users\valda\source\repos\semester#6\КМЗИ\KMZI_Lab14\KMZI_Lab14\Images\ecnrypted_by_rows.bmp";
            var fileNameEncryptByColumns = @"C:\Users\valda\source\repos\semester#6\КМЗИ\KMZI_Lab14\KMZI_Lab14\Images\ecnrypted_by_columns.bmp";
            var fileNameMatrixSample = @"C:\Users\valda\source\repos\semester#6\КМЗИ\KMZI_Lab14\KMZI_Lab14\Images\matrix_sample.bmp";
            var fileNameMatrixEncryptByRows = @"C:\Users\valda\source\repos\semester#6\КМЗИ\KMZI_Lab14\KMZI_Lab14\Images\matrix_encrypt.bmp";
            var fileNameMatrixEncryptByColumns = @"C:\Users\valda\source\repos\semester#6\КМЗИ\KMZI_Lab14\KMZI_Lab14\Images\matrix_encrypt_columns.bmp";

            var openTextByRows = "ValdaitsevAlexanderDenisovich";
            var openTextByColumns = "Valdaitsev";


            Steganography.HideMessageByRows(fileNameOpen, openTextByRows, fileNameEncryptByRows);
            Steganography.HideMessageByColumns(fileNameOpen, openTextByColumns, fileNameEncryptByColumns);
            var resultByRows = Steganography.ExtractMessageByRows(fileNameEncryptByRows);
            var resultByColumns = Steganography.ExtractMessageByColumns(fileNameEncryptByColumns);
           
            Console.WriteLine($"Text by rows: {resultByRows}");
            Console.WriteLine($"Text by columns: {resultByColumns}");

            Steganography.GetColorMatrix(fileNameOpen, fileNameMatrixSample);
            Steganography.GetColorMatrix(fileNameEncryptByRows, fileNameMatrixEncryptByRows);
            Steganography.GetColorMatrix(fileNameEncryptByColumns, fileNameMatrixEncryptByColumns);
        }
    }
}
