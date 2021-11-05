using System.Collections.Generic;

namespace Genetic_Algorithm_for_substitution_cipher
{
    public class NGramms
    {
        public static Dictionary<char, double> Letters = new Dictionary<char, double>
        {
            {'e', 12.575645},
            {'t', 9.085226},
            {'a', 8.000395},
            {'o', 7.591270},
            {'i', 6.920007},
            {'n', 6.903785},
            {'s', 6.340880},
            {'h', 6.236609},
            {'r', 5.959034},
            {'d', 4.317924},
            {'l', 4.057231},
            {'u', 2.841783},
            {'c', 2.575785},
            {'m', 2.560994},
            {'f', 2.350463},
            {'w', 2.224893},
            {'g', 1.982677},
            {'y', 1.900888},
            {'p', 1.795742},
            {'b', 1.535701},
            {'v', 0.981717},
            {'k', 0.739906},
            {'x', 0.179556},
            {'j', 0.145188},
            {'q', 0.117571},
            {'z', 0.079130},
        };
        public static Dictionary<string, double> Bigrams = new Dictionary<string, double>
        {
            {"th", 3.882543},
            {"he", 3.681391},
            {"in", 2.283899},
            {"er", 2.178042},
            {"an", 2.140460},
            {"re", 1.749394},
            {"nd", 1.571977},
            {"on", 1.418244},
            {"en", 1.383239},
            {"at", 1.335523},
            {"ou", 1.285484},
            {"ed", 1.275779},
            {"ha", 1.274742},
            {"to", 1.169655},
            {"or", 1.151094},
            {"it", 1.134891},
            {"is", 1.109877},
            {"hi", 1.092302},
            {"es", 1.092301},
            {"ng", 1.053385},
        };
        public static Dictionary<string, double> Trirams = new Dictionary<string, double>
        {
            // {"the", 3.508232},
            // {"and", 1.593878},
            // {"ing", 1.147042},
            // {"her", 0.822444},
            // {"hat", 0.650715},
            // {"his", 0.596748},
            // {"tha", 0.593593},
            // {"ere", 0.560594},
            // {"for", 0.555372},
            // {"ent", 0.530771},
            // {"ion", 0.506454},
            // {"ter", 0.461099},
            // {"was", 0.460487},
            // {"you", 0.437213},
            // {"ith", 0.431250},
            // {"ver", 0.430732},
            // {"all", 0.422758},
            // {"wit", 0.397290},
            // {"thi", 0.394796},
            // {"tio", 0.378058},
        };
        public static Dictionary<string, double> Quadrigrams = new Dictionary<string, double>
        {
            // {"that", 0.761242},
            // {"ther", 0.604501},
            // {"with", 0.573866},
            // {"tion", 0.551919},
            // {"here", 0.374549},
            // {"ould", 0.369920},
            // {"ight", 0.309440},
            // {"have", 0.290544},
            // {"hich", 0.284292},
            // {"whic", 0.283826},
            // {"this", 0.276333},
            // {"thin", 0.270413},
            // {"they", 0.262421},
            // {"atio", 0.262386},
            // {"ever", 0.260695},
            // {"from", 0.258580},
            // {"ough", 0.253447},
            // {"were", 0.231089},
            // {"hing", 0.229944},
            // {"ment", 0.223347},
        };
    }
}
