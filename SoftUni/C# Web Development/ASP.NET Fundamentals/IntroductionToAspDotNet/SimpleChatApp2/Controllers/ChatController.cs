namespace SimpleChatApp2.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SimpleChatApp2.Models.Message;

    public class ChatController : Controller
    {
        private static List<KeyValuePair<string, string>> messages = new();

        public IActionResult Show()
        {
            if (messages.Count < 1)
            {
                return View(new ChatViewModel());
            }

            var chatModel = new ChatViewModel()
            {
                Messages = messages.Select(m => new MessageViewModel()
                {
                    Sender = m.Key,
                    MessageText = m.Value
                }).ToList()
            };

            return View(chatModel);
        }

        [HttpPost]
        public IActionResult Send(ChatViewModel chatModel)
        {
            var msg = chatModel.CurrentMessage;
            messages.Add(new KeyValuePair<string, string>(msg.Sender, msg.MessageText));

            return RedirectToAction("Show");
        }
    }
}
