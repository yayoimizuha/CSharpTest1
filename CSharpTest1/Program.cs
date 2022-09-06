namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Func1("https://example.com/").Result);
        }

        static async Task<string> Func1(string args)
        {
            HttpClient client = new();
            string requestBody = "";
            try
            {
                HttpResponseMessage response = await client.GetAsync(args);
                response.EnsureSuccessStatusCode();
                requestBody = await response.Content.ReadAsStringAsync();
            }catch(HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
            return requestBody;
        }
    }
}