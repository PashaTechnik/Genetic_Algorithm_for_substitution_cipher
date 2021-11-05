using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Genetic_Algorithm_for_substitution_cipher
{
    public class Simulated_annealing
    {
        
        public char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        
        public double CurrentFitness;
        
        public char[] charToSubstitute;
        
        public void FindBestPath()
        {
            Random rnd = new Random();

            int iteration = -1;
            double proba;
            double alpha = 0.999;
            double temperature = 300.0;
            double epsilon = 0.001;
            double delta;

            var startChars = CreateStartPopulation();
            
            Console.WriteLine(startChars);

            while (temperature > epsilon)
            {
                iteration++;
                int p1 = 0, p2 = 0;
                while (p1 == p2)
                {
                    p1 = rnd.Next(0, alphabet.Length - 1);
                    p2 = rnd.Next(0, alphabet.Length - 1);
                }

                char[] tempChars = (char[])startChars.Clone();
                var tempChar = tempChars[p1];
                tempChars[p1] = tempChars[p2];
                tempChars[p2] = tempChar;


                // double fitness1 = Substitution.CalculateFitness(tempChars);
                // double fitness2 = Substitution.CalculateFitness(startChars);
                
                double fitness1 = Substitution.CalculateFitness(tempChars);
                double fitness2 = Substitution.CalculateFitness(startChars);

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
                    Console.WriteLine(Substitution.CalculateFitness(startChars));

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
        
        public char[] CreateStartPopulation()
        {
            Random rnd = new Random();
            Dictionary<Char, int> dictionary = new Dictionary<char, int>();
        
            string startString = "";
            foreach (var character in Substitution.basedText.ToLower())
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
    }
}