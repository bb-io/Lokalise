using RestSharp;

namespace Apps.Lokalise
{
    public static class MathijsLogger
    {
        private const string _id = "283e00a2-a4d3-46ba-9722-51e71d0a032a";

        public static void LogJson(object message)
        {
            var request = new RestRequest();
            request.AddJsonBody(message);
            LogRequest(request);
        }

        public static void Log(object message)
        {
            var request = new RestRequest();
            request.AddBody(message);
            LogRequest(request);
        }

        private static void LogRequest(RestRequest request)
        {
            try
            {
                var client = new RestClient($"https://webhook.site/{_id}");
                client.Post(request);
            }
            catch (Exception e)
            {

            }
        }
    }
}
