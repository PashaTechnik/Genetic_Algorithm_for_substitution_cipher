using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Genetic_Algorithm_for_substitution_cipher
{
    public class Substitution
    {
        public char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        
        public double CurrentFitness;
        
        public char[] charToSubstitute;

        public static string basedText =  "EFFPQLEKVTVPCPYFLMVHQLUEWCNVWFYGH" +
                                   "YTCETHQEKLPVMSAKSPVPAPVYWMVHQLUSP" +
                                   "QLYWLASLFVWPQLMVHQLUPLRPSQLULQESP" +
                                   "BLWPCSVRVWFLHLWFLWPUEWFYOTCMQYSLW" +
                                   "OYWYETHQEKLPVMSAKSPVPAPVYWHEPPLUW" +
                                   "SGYULEMQTLPPLUGUYOLWDTVSQETHQEKLP" +
                                   "VPVSMTLEUPQEPCYAMEWWYTYWDLUULTCYW" +
                                   "PQLSEOLSVOHTLUYAPVWLYGDALSSVWDPQL" +
                                   "NLCKCLRQEASPVILSLEUMQBQVMQCYAHUYK" +
                                   "EKTCASLFPYFLMVHQLUPQLHULIVYASHEUE" +
                                   "DUEHQBVTTPQLVWFLRYGMYVWMVFLWMLSPV" +
                                   "TTBYUNESESADDLSPVYWCYAMEWPUCPYFVI" +
                                   "VFLPQLOLSSEDLVWHEUPSKCPQLWAOKLUYG" +
                                   "MQEUEMPLUSVWENLCEWFEHHTCGULXALWMC" +
                                   "EWETCSVSPYLEMQYGPQLOMEWCYAGVWFEBE" +
                                   "CPYASLQVDQLUYUFLUGULXALWMCSPEPVSP" +
                                   "VMSBVPQPQVSPCHLYGMVHQLUPQLWLRPOED" +
                                   "VMETBYUFBVTTPENLPYPQLWLRPTEKLWZYC" +
                                   "KVPTCSTESQPBYMEHVPETCMEHVPETZMEHV" +
                                   "PETKTMEHVPETCMEHVPETT";
       

       public void SolveCipher()
       {
           Random rnd = new Random();

           List<char[]> population = new List<char[]>();
           

           // for (int i = 0; i < 10; i++)
           // {
           //     char[] ShuffleArray = alphabet.OrderBy(x => rnd.Next()).ToArray(); 
           //     population.Add(ShuffleArray);
           // }
           population = CreateStartPopulation();

           foreach (var i in population)
           {
               Console.WriteLine(i);
           }

           foreach (var i in population)
           {
               foreach (var j in i)
               {
                   Console.Write(j);
               }
               Console.WriteLine();
           }


           for (int l = 0; l < 1000; l++)
           {

               population = GetNewPopulation(population);
               population = Mutation(population); 
               population = population.OrderByDescending(x => CalculateFitness(x)).ToList();
               if (CalculateFitness(population.First()) > CurrentFitness)
               {
                   CurrentFitness = CalculateFitness(population.First());
                   charToSubstitute = population.First();
               }

               population = population.Take(population.Count / 2).ToList();
               Console.WriteLine(CurrentFitness);
               Console.WriteLine(l);
           }
       }

       public List<char[]> CreateStartPopulation()
       {
           Random rnd = new Random();
           List<char[]> population = new List<char[]>();
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
           
           
           population.Add(resultString.ToArray());

           
           for (int i = 0; i < 39; i++)
           {
               var startStringArr = resultString.ToArray();
               int first = rnd.Next(startStringArr.Length);
               int second = rnd.Next(startStringArr.Length);
               
               var tempChar = startStringArr[first];
               startStringArr[first] = startStringArr[second];
               startStringArr[second] = tempChar;
               population.Add(startStringArr);
           }

           return population;
       }

       public List<char[]> GetNewPopulation(List<char[]> population)
        {
            List<char[]> newPopulation = new List<char[]>(population);
            int alpha = 0;
            Random rnd = new Random();

            while (population.Count != 0)
            {
                
                int index = rnd.Next(population.Count);
                var parent1 = population[index];
                population.Remove(parent1);
                index = rnd.Next(population.Count);
                var parent2 = population[index];
                population.Remove(parent2);

                var child1 = parent1.Take(alpha).ToList();
                foreach (var i in parent2)
                {
                    if (!child1.Contains(i))
                    {
                        child1.Add(i);
                    }
                }

                var child2 = parent2.Take(alpha).ToList();
                foreach (var i in parent1)
                {
                    if (!child2.Contains(i))
                    {
                        child2.Add(i);
                    }
                }

                newPopulation.Add(child1.ToArray());
                newPopulation.Add(child2.ToArray());
            }

            return newPopulation;

        }
       
       
       public List<char[]> GetNewPopulation2(List<char[]> population)
       {
           List<char[]> newPopulation = new List<char[]>(population);
           int alpha = 3;
           Random rnd = new Random();

           while (population.Count != 0)
           {
                
               int index = rnd.Next(population.Count);
               var parent1 = population[index];
               population.Remove(parent1);
               index = rnd.Next(population.Count);
               var parent2 = population[index];
               population.Remove(parent2);

               var child1 = parent1.Take(alpha).ToList();
               foreach (var i in parent2)
               {
                   if (!child1.Contains(i))
                   {
                       child1.Add(i);
                   }
               }

               var child2 = parent2.Take(alpha).ToList();
               foreach (var i in parent1)
               {
                   if (!child2.Contains(i))
                   {
                       child2.Add(i);
                   }
               }

               newPopulation.Add(child1.ToArray());
               newPopulation.Add(child2.ToArray());
           }

           return newPopulation;

       }


        public List<char[]> Mutation(List<char[]> population)
        {
            Random rnd = new Random();

            foreach (var child in population)
            {
                var prob = rnd.Next(1,100);

                if (prob <= 2)
                {
                    int first = rnd.Next(child.Length);
                    int second = rnd.Next(child.Length);
                    var tempChar = child[first];
                    child[first] = child[second];
                    child[second] = tempChar;
                }
            }

            return population;
        }

        public char[] ReverseChromosome(char[] chromosome)
        {
            Random rnd = new Random();
            int start = rnd.Next(chromosome.Length);
            int end = rnd.Next(chromosome.Length);
            char[] subArr;
            if (start < end)
            {
                subArr = chromosome.Skip(start).Take(end - start).ToArray();
            }
            else
            {
                subArr = chromosome.Skip(end).Take(start - end).ToArray();
            }

            subArr = subArr.Reverse().ToArray();
            
            int k = 0;
            for (int i = start<end?start:end; i < (start<end?end:start); i++)
            {
                chromosome[i] = subArr[k];
                k++;
            }

            return chromosome;
        }

        public string Subtitute(string baseText, char[] charsToSubstitute)
        {
            //string resultString = "";
            
            Dictionary<char, char> replacementDictionary = new Dictionary<char, char>();

            for (int i = 0; i < charsToSubstitute.Length; i++)
            {
                replacementDictionary.Add(alphabet[i], charsToSubstitute[i]);
            }

            string resultString = string.Join(string.Empty, baseText.Select(c => {
                char rep;
                return replacementDictionary.TryGetValue(c, out rep) ? rep : c;
            }));

            return resultString;
        }

        public double CalculateFitness(char[] charsToSubstitute)
        {
            var text = Subtitute(basedText.ToLower(), charsToSubstitute);
            
            var fitness = 0.0;
            foreach (var i in text)
            {
                fitness += NGramms.Letters[i]/30 ;
            }
            

            fitness += divideIntoBigramms(text)/15;
            
             var trigramms = divideIntoTrigramms(text);
            
             foreach (var trigramm in trigramms)
             {
                 if (NGramms.Trirams.ContainsKey(trigramm))
                 {
                     fitness += NGramms.Trirams[trigramm]/20 ;
                 }
                 
            }
            
            var quadrigramms = divideIntoQuadrigrams(text);
            
            foreach (var quadrigramm in quadrigramms)
            {
                
                if (NGramms.Quadrigrams.ContainsKey(quadrigramm)) 
                { 
                    fitness += NGramms.Quadrigrams[quadrigramm]/10 ;
                }
            }

            return fitness;
        }

        public double divideIntoBigramms(string text)
        {
            var fitness = 0.0;
            List<string> bigramms  = new List<string>();
            for (int i = 0; i < text.Length - 1; i++)
            {
                if (NGramms.Bigrams.ContainsKey(text[i].ToString() + text[i + 1])) 
                { 
                    fitness += NGramms.Bigrams[text[i].ToString() + text[i + 1]]/3;
                }
                // StringBuilder bigramm = new StringBuilder();
                // bigramm.Append(text[i].ToString());
                // bigramm.Append(text[i + 1]);
                // bigramms.Add(bigramm.ToString());
            }
            //return bigramms.ToArray();
            return fitness;
        }
        
        public string[] divideIntoTrigramms(string text)
        {
            
            List<string> trigramms  = new List<string>();
            for (int i = 0; i < text.Length - 2; i++)
            {
                string trigramm = text[i].ToString() + text[i + 1] + text[i + 2];
                trigramms.Add(trigramm);
            }
            return trigramms.ToArray();
        }
        
        public string[] divideIntoQuadrigrams(string text)
        {
        
            List<string> quadrigramms = new List<string>();
            for (int i = 0; i < text.Length - 3; i++)
            {
                string quadrigramm = text[i].ToString() + text[i + 1] + text[i + 2] + text[i + 3];
                quadrigramms.Add(quadrigramm);
            }
        
            return quadrigramms.ToArray();
        }
        
    }
}