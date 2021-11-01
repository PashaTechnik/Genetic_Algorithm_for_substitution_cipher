using System;
using System.IO;

namespace Genetic_Algorithm_for_substitution_cipher
{
    class Program
    {
        private static String encryptedText =
            "addtheabilitytodecipheranykindofpolyalphabeticsubstitutioncipherstheoneusedintheciphertex" +
            "tsherehastwentysixindependentrandomlychosenmonoalphabeticsubstitutionpatternsforeachlette" +
            "rfromenglishalphabetitisclearthatyoucannolongerrelyonthesamesimpleroutineofguessingthekey" +
            "byexhaustivesearchwhichyouprobablyusedtodecipherthepreviousparagraphwilltheindexofcoincid" +
            "encestillworkasasuggestionyoucantrytodividethemessageinpartsbythenumberofcharactersinakey" +
            "andapplyfrequencyanalysistoeachofthemcanyoufindawaytousehigherorderfrequencystatisticswit" +
            "hthistypeofcipherthenextmagicalwordwilltaketothenextlabenZoybitlyslashtwocapitalycapitalZ" +
            "capitalblcapitalycapita";
        
        static void Main(string[] args)
        {

            // using (StreamReader sr = new StreamReader("/Users/admin/Desktop/english_quadrigrams.txt", System.Text.Encoding.Default))
            // {
            //     string line;
            //     while ((line = sr.ReadLine()) != null)
            //     {
            //         string[] point = line.Split(" ");
            //         var power = 0.0;
            //         try
            //         {
            //             power = Math.Pow(Double.Parse(point[1]), int.Parse(point[2])*-1);
            //             NGramms.Quadrigrams.Add( point[0].ToLower(), power);
            //         }
            //         catch (Exception e)
            //         {
            //             NGramms.Quadrigrams.Add( point[0].ToLower(), Double.Parse(point[1]));
            //         }
            //     }
            // }

            Substitution a = new Substitution();
            a.SolveCipher();

            Console.WriteLine("result");
            Console.WriteLine(a.charToSubstitute);
            Console.WriteLine(a.CurrentFitness);
            Console.WriteLine(a.Subtitute(Substitution.basedText.ToLower(), a.charToSubstitute));

            double coincidence = 0.0;
            for (int i = 0; i < encryptedText.Length; i++)
            {
                if (encryptedText[i] == a.Subtitute(Substitution.basedText.ToLower(), a.charToSubstitute)[i])
                {
                    coincidence += 1.0 / encryptedText.Length;
                }
            }
            
            Console.WriteLine(coincidence);
        }
    }
}