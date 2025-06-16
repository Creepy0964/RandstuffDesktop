using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Runtime.InteropServices.Marshalling;

namespace RandstuffDesktop
{
    public class Randstuff
    {
        public static async Task<string> RunCurl(string url)
        {
            var curlPath = "curl";
            var arguments = $"-H \"Content-Type: application/x-www-form-urlencoded\" -H \"x-requested-with: XMLHttpRequest\" -H \"user-agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.82 Safari/537.36\" {url}";

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = curlPath,
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            using var process = new Process { StartInfo = psi };
            psi.StandardOutputEncoding = Encoding.UTF8;
            process.Start();

            string output = await process.StandardOutput.ReadToEndAsync();
            string error = await process.StandardError.ReadToEndAsync();

            await process.WaitForExitAsync();
            if (string.IsNullOrWhiteSpace(output))
            {
                MessageBox.Show("Output is empty");
            }

            return output;
        }

        public async Task<string> GetRandomJoke()
        {
            var joke = await RunCurl("https://randstuff.ru/joke/generate/");

            var jsonJoke = JsonSerializer.Deserialize<JokeResp>(joke);

            return jsonJoke.joke.text;
        }

        public async Task<string> GetRandomFact()
        {
            var joke = await RunCurl("https://randstuff.ru/fact/generate/");

            var jsonJoke = JsonSerializer.Deserialize<FactResp>(joke);

            return jsonJoke.fact.text;
        }

        public async Task<string> GetRandomWisdom()
        {
            var joke = await RunCurl("https://randstuff.ru/saying/generate/");

            var jsonJoke = JsonSerializer.Deserialize<SayingResp>(joke);

            return jsonJoke.saying.text;
        }

        public async Task<string> GetRandomAsk(string question = "Есть ли смысл жизни?")
        {
            var joke = await RunCurl($"--request POST --data \"question={question}\" https://randstuff.ru/ask/generate/");

            var jsonJoke = JsonSerializer.Deserialize<AskResp>(joke);

            return jsonJoke.ask.prediction.Replace("<br>", " ");
        }

        public async Task<Question> GetRandomQuestion()
        {
            var joke = await RunCurl("https://randstuff.ru/question/generate/");

            var jsonJoke = JsonSerializer.Deserialize<QuestionResp>(joke);

            return jsonJoke.question;
        }

        public async Task<string> GetRandomNumber(int count = 1, int start = 1, int end = 100, string? numlist = null, int numunique = 0, int tz = -480)
        {
            if(count > 1000 || start < -9999999 || end > 999999999) return "Нельзя вводить количество больше 1000, а лимит меньше -9999999 и больше 999999999!";
            string num;
            if(numlist == null) num = await RunCurl($"--request POST --data \"count={count}&start={start}&end={end}&unique={numunique}&tz={tz}\" https://randstuff.ru/number/generate/");
            else num = await RunCurl($"--request POST --data \"count={count}&start={start}&end={end}&list={numlist}&unique={numunique}&tz={tz}\" https://randstuff.ru/number/generate/");

            Number jsonNum = null;
            NumberList jsonNumList = null;
            if (count <= 1) jsonNum = JsonSerializer.Deserialize<Number>(num);
            else jsonNumList = JsonSerializer.Deserialize<NumberList>(num);

            if (jsonNumList == null) return jsonNum.number.ToString();
            else return string.Join(", ", jsonNumList.number);
        }

        public async Task<string> GetRandomPassword(int length = 8, int numbers = 0, int symbols = 0)
        {
            if (length < 6 || length > 16) return "Нельзя вводить длину меньше 6 или больше 16!";
            var joke = await RunCurl($"--request POST --data \"length={length}&numbers={numbers}&symbols={symbols}\" https://randstuff.ru/password/generate/");

            var jsonJoke = JsonSerializer.Deserialize<Password>(joke);

            return jsonJoke.password;
        }

        public class JokeResp { public Joke joke { get; set; } public string share { get; set; } }
        public class Joke { public string id { get; set; } public string text { get; set; } }
        public class FactResp { public Fact fact { get; set; } public string share { get; set; } }
        public class Fact { public string id { get; set; } public string text { get; set; } }
        public class SayingResp { public Saying saying { get; set; } public string share { get; set; } }
        public class Saying { public string id { get; set; } public string text { get; set; } }
        public class AskResp { public Ask ask { get; set; } }
        public class Ask { public string prediction { get; set; } }
        public class QuestionResp { public Question question { get; set; } }
        public class Question { public string id { get; set; } public string text { get; set; } public string answer1 { get; set; } public string answer2 { get; set; } public string answer3 { get; set; } public string answer4 { get; set; } }
        public class Password { public string password { get; set; } }
        public class Number { public int number { get; set; } public string save { get; set; } }
        public class NumberList { public int[] number { get; set; } public string save { get; set; } }
    }
}
