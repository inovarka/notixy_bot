using System.Net;
using Telegram.Bot;
using Telegram.Bot.Types;
using Newtonsoft.Json.Linq;

namespace NotixyBotApp.Models.Commands
{
    public class CovidCommand : Command
    {
        public override string Name => "covid";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            string info;

            var country = message.Text.Replace("/covid ", "");

            if (country == "/covid")
            {
                info = "Please enter country after /covid command";
            }
            else
                info = GetCovid(country);
            
            await client.SendTextMessageAsync(chatId, info, replyToMessageId: messageId);
        }

        public string GetCovid (string country)
        {
            var url = "https://api.coronastatistics.live/countries/" + country;

            WebClient client = new WebClient();
            string jsonData = client.DownloadString(url);

            var details = JObject.Parse(jsonData);
           
            if(details["country"].ToString().ToLower() != country.ToLower())
                return "Please enter valid country";

            string covidCountry = string.Concat("Results for : ", details["country"]);
            string covidTotalCases = string.Concat("Total cases : ", details["cases"]);
            string covidTotalActive = string.Concat("Total active : ", details["active"]);
            string covidTotalRecovered = string.Concat("Total recovered : ", details["recovered"]);
            string covidTotalDeaths = string.Concat("Total deaths : ", details["deaths"]);
            string covidTodayCases = string.Concat("Today cases : ", details["todayCases"]);
            string covidTodayDeaths = string.Concat("Today deaths : ", details["todayDeaths"]);

            string covidData = $"❗\n{covidCountry}\n{covidTotalCases}\n{covidTotalActive}\n{covidTotalRecovered}\n{covidTotalDeaths}\n{covidTodayCases}\n{covidTodayDeaths}";
            return covidData;
        }
    }
}