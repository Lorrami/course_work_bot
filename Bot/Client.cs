using System.Net.Http.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Telegram.Bot.Types;

namespace Bot
{
    public class Client
    {
        public static List<GameData> Result = new List<GameData>();
        public List<GameData> GetGamesList()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:7200/GamesList"),
            };
            var response = client.SendAsync(request);
            var body = response.Result.Content.ReadAsStringAsync();

            var array = JArray.Parse(body.Result);
            Result = array.ToObject<List<GameData>>();
            return Result;
        }

        public void PutUserParams(UserParams userParams)
        {
            var client = new HttpClient();
            var response = client.PostAsJsonAsync("https://localhost:7200/UserParams", userParams).Result;
        }
        public GameData GetGameByUserParams()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:7200/GetGameByUserParams"),
            };
            var response = client.SendAsync(request);
            var body = response.Result.Content.ReadAsStringAsync();

            var game = JObject.Parse(body.Result);
            var result = game.ToObject<GameData>();
            return result;
        }
        public void PutUserGenres(List<string> genres)
        {
            var client = new HttpClient();
            var response = client.PostAsJsonAsync("https://localhost:7200/UserGenres", genres).Result;
        }
        public List<GameData> GetGameByGenres()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:7200/GetGameByUserGenres"),
            };
            var response = client.SendAsync(request);
            var body = response.Result.Content.ReadAsStringAsync();

            var game = JArray.Parse(body.Result);
            var result = game.ToObject<List<GameData>>();
            return result;
        }

        public async Task<List<GameData>> GetGamesFromDB(Message message)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:7200/DynamoDb?chatId="+message.Chat.Id),
            };
            var response = await client.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();

            var game = JArray.Parse(body);
            var result = game.ToObject<List<GameData>>();
            return result;
        } 
        
        public void PutGamesIntoDB(Message message, string key)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri("https://localhost:7200/DynamoDb?chatId=" + message.Chat.Id + "&key=" + key),
            };
            var response = client.SendAsync(request);
        } 
        
        public void DeleteGameFromDB(Message message)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri("https://localhost:7200/DynamoDb?chatId=" + message.Chat.Id),
            };
            var response = client.SendAsync(request);
        } 
    }
}
