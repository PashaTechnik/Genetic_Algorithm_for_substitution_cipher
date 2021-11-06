using System;
using System.Collections.Generic;
using System.IO;

namespace Genetic_Algorithm_for_substitution_cipher
{
    class Program
    {
        public static String encryptedText =
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

            using (StreamReader sr = new StreamReader("/Users/admin/Desktop/english_quadrigrams.txt", System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] point = line.Split(" ");
                    var power = 0.0;
                    try
                    {
                        power = Math.Pow(10, int.Parse(point[2])*-1);
                        power = power * Double.Parse(point[1]);
                        NGramms.Quadrigrams.Add( point[0].ToLower(), power);
                    }
                    catch (Exception e)
                    {
                        NGramms.Quadrigrams.Add( point[0].ToLower(), Double.Parse(point[1]));
                    }
                }
            }
            
            using (StreamReader sr = new StreamReader("/Users/admin/Desktop/english_trigrams.txt", System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] point = line.Split(";");
            
                    NGramms.Trirams.Add( point[0].ToLower(), double.Parse(point[1]));
                }
            }

            // Substitution a = new Substitution();
            // a.SolveCipher();
            //
            // Console.WriteLine("result");
            // Console.WriteLine(a.charToSubstitute);
            // Console.WriteLine(a.CurrentFitness);
            // Console.WriteLine(Substitution.Subtitute(Substitution.basedText.ToLower(), a.charToSubstitute));

            // Simulated_annealing cipher = new Simulated_annealing();
            // cipher.FindBestPath();
            //
            // Console.WriteLine("result");
            // Console.WriteLine(cipher.charToSubstitute);
            // Console.WriteLine(cipher.CurrentFitness);
            // Console.WriteLine(Substitution.Subtitute(Substitution.basedText.ToLower(), cipher.charToSubstitute));
            //
            //
            //
            // double coincidence = 0.0;
            // for (int i = 0; i < encryptedText.Length; i++)
            // {
            //     if (encryptedText[i] == Substitution.Subtitute(Substitution.basedText.ToLower(), a.charToSubstitute)[i])
            //     {
            //         coincidence += 1.0 / encryptedText.Length;
            //     }
            // }
            //
            // Console.WriteLine(coincidence);
            
            
            SubstitutionWithKey cipherWithKey = new SubstitutionWithKey();
            cipherWithKey.FindBestPath();
            Console.WriteLine("result");
            foreach (var i in cipherWithKey.charToSubstitute)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(cipherWithKey.CurrentFitness);
            
            List<String> parts = new List<string>();
            for (int i = 0; i < cipherWithKey.charToSubstitute.Count; i++)
            {
                var part = Substitution.Subtitute(SubstitutionWithKey.partsOfText[i].ToLower(), cipherWithKey.charToSubstitute[i]);
                parts.Add(part);
            }
            
            var text = SubstitutionWithKey.solveText(parts);
            Console.WriteLine(text);
            
        }
    }
}