using System;
using System.Collections.Generic;
using System.Linq;

namespace Genetic_Algorithm_for_substitution_cipher
{
    public class SubstitutionWithKey
    {
        
        public char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        
        public double CurrentFitness;
        
        public List<char[]> charToSubstitute;
        
        static String part1 = "ULOKPTDJTTKOMZRTSOKJJDUTBMTFMMJMJMAOJJFFQPKKIXZKIIZLJYNOLUBJJOMFFOPKTUUUBQJ" +
                       "LBJJLKKBJIHFOZFIZUBNZKJFJQOUQPPJJBJTJKJLXZZYBKXQKKORKZSMJZHMMJHZQRKZSMJZRYIJZMPN" +
                       "UJOIHJQKJFJJQBRNBPMJTFHBZBBBKZSJRJKKKHBBUTKKLFKUJXJEJMJJITZSQMJLBFTJEKLLMMOUJZOS" +
                       "KPJQBKJFTFOZMFIQPFIBIKLKFQLIEXMLUZUZUZVBE";
        static String part2 = "MYYTDOZYOOAKKDOHEEZOUZVLOEDKTEJEHTTEKNEBHKQTKPQTZUIMOYEEOEELTEJJBKTNOMDEKTKD" +
                             "LJYJHBLROYBVIDOEJEMDUEEJERDIEDAYLYMYHAHDIEABKKEZHLTKEYKIDDERYMIETKEYKIDOLMYDYYYY" +
                             "EMYYHDZENUOYKKETEKOKIYTETOKZILMHJONKMTOYTKKKNKYKYYZJEVIQZIMDEKNCBOKEUENYWOYKJLET" +
                             "YYDTYREHADMKEMIAKKTKKOMBKEEDOIEYYYYYYJK";
        static String part3 = "URRYYUHUMLOZAYRQRRGIDAOMWRTZAOORAAIPIOPUHYAOZGAOYIAKYTISXYUHGOHAOAIMUUAIYWZ" +
                             "RTISAKITAIUIHARRYGYYIXJUOZPPADYIUTYSFORHUADOIYZYTWKXAPHRITYIOUDOKXAPHRITAODQPMR" +
                             "FUBDUYARRPRHIDZDOKJORJOPAUKWOUHISYZAIZIRPPPZZZYQGZDYROROOAYOOTDIOAJGZYIUHUHQGZZ" +
                             "AHARDTKFRWAHUXXOUHAAIOZZRLUZOORTRAXTXTXTOO";
        static String part4 = "PXCYZYYNYTHCVBPLUMQDNTTQNQUCZJXKCZZPJCLNPYZTNQZTNSESUHEULGGAGSNLHGHKUQTRUK" +
                             "NZJDURUSOTTLTRXNLUELCTSCGTNNNYYTGZJNENTNRPLUSTLNKOCUSGLTKQNXRGMNTUSGLTKQNUTQXU" +
                             "YQNJENOYOKRCKSRZUNYYCAKLQNVOKSSOQJUZUYYNTKNNONNCTNQNNMJXKSSGNYHHWUTLNSNYXNNOHN" +
                             "QLLTQYZNHYGUNXHPUUTNGCTZTNNULUNHHHLKHCGCICCEH";
        public static List<String> partsOfText = new List<string>();
        
        public static String solveText(List<String> texts)
        {
            var result = "";
            for (int i = 0; i < texts.Last().Length; i++)
            {
                foreach (var text in texts)
                {
                    result += text[i];
                }
            }

            return result;
        }
         public void FindBestPath()
        {
            Random rnd = new Random();

            int iteration = -1;
            double proba;
            double alpha = 0.999;
            double temperature = 30.0;
            double epsilon = 0.001;
            double delta;

            List<char[]> startChars = new List<char[]>();
            
            partsOfText.Add(part1);
            partsOfText.Add(part2);
            partsOfText.Add(part3);
            partsOfText.Add(part4);

            var startChars1 = CreateStartPopulation(part1);
            var startChars2 = CreateStartPopulation(part2);
            var startChars3 = CreateStartPopulation(part3);
            var startChars4 = CreateStartPopulation(part4);
            
            startChars.Add(startChars1);
            startChars.Add(startChars2);
            startChars.Add(startChars3);
            startChars.Add(startChars4);
            
            Console.WriteLine(startChars1); 
            Console.WriteLine(startChars2); 
            Console.WriteLine(startChars3); 
            Console.WriteLine(startChars4); 

            while (temperature > epsilon)
            {
                iteration++;
                int p1 = 0, p2 = 0;
                while (p1 == p2)
                {
                    p1 = rnd.Next(0, alphabet.Length - 1);
                    p2 = rnd.Next(0, alphabet.Length - 1);
                }

                List<char[]> tempChars = new List<char[]>(4);
                for (int i = 0; i < startChars.Count; i++)
                {
                    char[] tempChar = (char[])startChars[i].Clone();
                    tempChars.Add(tempChar);
                }
                for (int i = 0; i < startChars.Count; i++)
                {
                    var tempChar = tempChars[i][p1];
                    tempChars[i][p1] = tempChars[i][p2];
                    tempChars[i][p2] = tempChar;
                }


                
                double fitness1 = CalculateFitnessWithParts(tempChars, partsOfText);
                double fitness2 = CalculateFitnessWithParts(startChars, partsOfText);
                

                if (fitness1 < fitness2)
                {
                    if (fitness2 > CurrentFitness)
                    {
                        CurrentFitness = fitness2;
                        charToSubstitute = startChars;
                    }
                }
                else
                {
                    delta = fitness1 - fitness2;
                    if (ProbabilityCalc(Math.Exp(-delta / temperature)))
                    {
                        startChars = tempChars;
                        if (fitness1 > CurrentFitness)
                        {
                            CurrentFitness = fitness2;
                            charToSubstitute = startChars;
                        }
                    }
                }
                temperature *= alpha;

                if (iteration % 40 == 0)
                    Console.WriteLine(CalculateFitnessWithParts(charToSubstitute, partsOfText));

            }
            
        }

        public bool ProbabilityCalc(double prob)
        {
            Random random = new Random();
            int p = random.Next(1, 100);
            if (p < prob * 100)
            {
                return true;
            }
            return false;
        }
        
        public char[] CreateStartPopulation(string basedText)
        {
            Random rnd = new Random();
            Dictionary<Char, int> dictionary = new Dictionary<char, int>();
        
            string startString = "";
            foreach (var character in basedText.ToLower())
            {
                if (!dictionary.Keys.Contains(character))
                {
                    dictionary[character] = 1;
                }
                else
                {
                    dictionary[character] += 1;
                }
            }
        
            var sortedDict = from entry in dictionary orderby entry.Value ascending select entry;
            
            
            var dictArr1 = sortedDict.ToArray();
            var dictArr2 = NGramms.Letters.ToArray();
            
            string resultString = "";
        
            List<char> keyList = new List<char>();
        
            foreach (var i in dictArr1)
            {
                keyList.Add(i.Key);
            }
            foreach (var i in alphabet)
            {
                if (keyList.Contains(i))
                {
                    var index = keyList.IndexOf(i);
                    resultString += dictArr2[index].Key;
                }
                else
                {
                    resultString += i;
                }
            }
            return resultString.ToArray();
        }

        public double CalculateFitnessWithParts(List<char[]> charArraysToSubstitute, List<string> basedParts)
        {
            List<String> parts = new List<string>();


            for (int i = 0; i < charArraysToSubstitute.Count; i++)
            {
                var part = Substitution.Subtitute(basedParts[i].ToLower(), charArraysToSubstitute[i]);
                parts.Add(part);
            }

            var text = solveText(parts);
            var fitness = 0.0;
            foreach (var i in text)
            {
                fitness += NGramms.Letters[i] ;
            }
            

            fitness += Substitution.divideIntoBigramms(text)/2;
            
            //   var trigramms = divideIntoTrigramms(text);
            //
            //   foreach (var trigramm in trigramms)
            //   {
            //       if (NGramms.Trirams.ContainsKey(trigramm))
            //       {
            //           fitness += NGramms.Trirams[trigramm]/25;
            //       }
            //   }
            //
            // var quadrigramms = divideIntoQuadrigrams(text);
            //
            // foreach (var quadrigramm in quadrigramms)
            // {
            //     
            //     if (NGramms.Quadrigrams.ContainsKey(quadrigramm)) 
            //     { 
            //         fitness += NGramms.Quadrigrams[quadrigramm]/30 ;
            //     }
            // }

            return fitness;
        }

    }
}