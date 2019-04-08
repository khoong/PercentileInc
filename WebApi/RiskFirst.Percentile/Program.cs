using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RiskFirst.Percentile
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Times taken to fetech data from WebApi and convert to array.
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();

            //var MyArray = (GetValues()).ToArray<double>();

            //stopwatch.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            //Console.Out.Flush();
            #endregion

            var MyArray = (GetValues()).ToArray<double>();
            Console.WriteLine("Percentile(array, 0.995) = {0}", PercentileInc(MyArray, 0.995));

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }


        /// <summary>
        /// Initiate a call to WebApi and get dataset for percentile calculation.
        /// </summary>
        /// <returns>A collection of "double" values</dobule></returns>
        public static IEnumerable<double> GetValues()
        {
            var serializer = new JsonSerializer();
            var client = new HttpClient();
            var header = new MediaTypeWithQualityHeaderValue("application/json");

            client.DefaultRequestHeaders.Accept.Add(header);

            // Note: port number might vary.
            using (var stream = client.GetStreamAsync("http://localhost:63011/api/percentile").Result)
            using (var sr = new StreamReader(stream))
            using (var jr = new JsonTextReader(sr))
            {
                while (jr.Read())
                {
                    if (jr.TokenType != JsonToken.StartArray && jr.TokenType != JsonToken.EndArray)
                        yield return serializer.Deserialize<double>(jr);
                }
            }
        }

        /// <summary>
        /// Compute the percentile of a dataset.
        /// Disclosure: PercentileInc function was extracted from https://stackoverflow.com/questions/8137391/percentile-calculation
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="excelPercentile"></param>
        /// <returns>Percentile</returns>
        public static double PercentileInc(double[] sequence, double excelPercentile)
        {
            Array.Sort(sequence);
            int N = sequence.Length;
            double n = (N - 1) * excelPercentile + 1;

            if (n == 1d) return sequence[0];
            else if (n == N) return sequence[N - 1];
            else
            {
                int k = (int)n;
                double d = n - k;
                return sequence[k - 1] + d * (sequence[k] - sequence[k - 1]);
            }
        }
    }
}
