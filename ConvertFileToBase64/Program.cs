using SixLabors.ImageSharp.Formats.Gif;

namespace ConvertFileToBase64
{
    using System;
    using System.IO;
    using SixLabors.ImageSharp;
    using SixLabors.ImageSharp.Formats;
    using SixLabors.ImageSharp.PixelFormats;
    internal class Program
    {
        static void Main(String[] args)
        {
            string dosyaYolu1 = "";
            string Param = "";
            string dosyaYolu = "";

            if (args[0] != null)
            {
                Param = args[0];
            }

            if (args[1] != null)
            {
                dosyaYolu = args[1];
            }


            if (args[2] != null)
            {
                dosyaYolu1 = args[2];
            }

            if (Param == "-f" || Param == "-F")

            {
                try
                {
                    string base64String = DosyayiBase64eDonustur(dosyaYolu);
                    Console.WriteLine(base64String);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata oluştu: " + ex.Message);
                }
            }


            if (Param == "-p" || Param == "-P")

            {
                try
                {
                  
                    string base64Data = File.ReadAllText(dosyaYolu);

                  
                    byte[] imageData = Convert.FromBase64String(base64Data);

                     
                    using (Image<Rgba32> image = Image.Load<Rgba32>(imageData))
                    {
                        image.Save(dosyaYolu1, new GifEncoder());
                    }

                    Console.WriteLine("GIF dosyası başarıyla kaydedildi.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata: " + ex.Message);
                }
            }


            if (Param == "Help" || Param == "HELP")

            {
                Console.WriteLine(
                    "1. Parametere > -P (Base64.txt,SaveFilePath) > Gönderilen Base64 veriyi Gif Formatında Kaydeder.");
                Console.WriteLine(
                    "2. Parametere > -F (ZipFilePath,-F) > Gönderilen Ziplenmiş Dosyayı Base64 Geri Döner. ");
                return;
            }
        }

        static string DosyayiBase64eDonustur(string dosyaYolu)
        {
            byte[] dosyaBytes = File.ReadAllBytes(dosyaYolu);


            string base64String = Convert.ToBase64String(dosyaBytes);

            return base64String;
        }

 
    }
}