using Microsoft.AspNetCore.Mvc;
using W88.Unsubscribe.Models;

namespace W88.Unsubscribe.Controllers
{
    public class SubscribeController : Controller
    {
        private Dictionary<string, string> successViewTranslations = new Dictionary<string, string>()
        {
            {"SuccessMsgEN", "Subscription Successful"},
            {"SuccessMsgCN", "订阅成功"},
            {"SuccessMsgID", "Berlangganan Berhasil"},
            {"SuccessMsgTH", "การสมัครสำเร็จ"},
            {"SuccessMsgVN", "Đăng Ký Theo Dõi Thành Công"},

            {"ClickHereMsgEN",  "Click here"},
            {"ClickHereMsgCN",  "点击这里"},
            {"ClickHereMsgID",  "Klik di sini"},
            {"ClickHereMsgTH",  "คลิกที่นี่"},
            {"ClickHereMsgVN",  "Nhấp vào đây"},

            {"UnsubscribeBackMsgEN",  "to unsubscribe."},
            {"UnsubscribeBackMsgCN",  "取消订阅"},
            {"UnsubscribeBackMsgID",  "untuk berhenti langganan."},
            {"UnsubscribeBackMsgTH",  "เพื่อยกเลิกสมัคร"},
            {"UnsubscribeBackMsgVN",  "để hủy đăng ký."},

        };

        public IActionResult Successful(string lang)
        {
            return View(GetSuccessViewTranslation(lang));
        }

        public SuccessViewModel GetSuccessViewTranslation(string language)
        {
            SuccessViewModel vm = new SuccessViewModel();
            string lang = !string.IsNullOrEmpty(language) ? language.ToUpper() : "EN";
            var trans = successViewTranslations.Where(x => x.Key.EndsWith(lang));
            if (trans != null)
            {
                vm.SuccessMessage = trans.FirstOrDefault(x => x.Key == $"SuccessMsg{lang}").Value;
                vm.ClickHere = trans.FirstOrDefault(x => x.Key == $"ClickHereMsg{lang}").Value;
                vm.RevertBack = trans.FirstOrDefault(x => x.Key == $"UnsubscribeBackMsg{lang}").Value;
                vm.RevertBackUrl = $"/unsubscribe/successful?lang={lang}";
                vm.IsUnsubscribe = false;
            }

            return vm;
        }
    }
}
