namespace KMZI_Lab15
{
    public class Lab15Main
    {
        public static void Main()
        {
            var openText = "qw";
            Steganography.HideMessage(openText);
            Steganography.ShowMessage();
        }
    }
}