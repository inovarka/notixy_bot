using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotixyBotApp.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Notixy Telegram bot";
        }
    }
}