using System;
using System.Collections.Generic;
using System.Linq;

namespace Genetic_Algorithm_for_substitution_cipher
{
    public class SubstitutionWithKey
    {
        
        public char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        
        public double CurrentFitness;
        
        public char[] charToSubstitute;
        
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
    }
}