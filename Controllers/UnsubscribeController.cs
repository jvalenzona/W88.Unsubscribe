using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Text.RegularExpressions;
using W88.Unsubscribe.Models;

namespace W88.Unsubscribe.Controllers
{
    public class UnsubscribeController : Controller
    {
        #region Private variables
        private Dictionary<string, string> successViewTranslations = new Dictionary<string, string>()
        {
            {"SuccessMsgEN", "Unsubscribed Successful"},
            {"SuccessMsgCN", "取消订阅成功"},
            {"SuccessMsgID", "Berhenti Langganan Berhasil"},
            {"SuccessMsgTH", "ยกเลิกการสมัครสำเร็จ"},
            {"SuccessMsgVN", "Đã Huỷ Đăng Ký Thành Công"},

            {"ClickHereMsgEN",  "Click here"},
            {"ClickHereMsgCN",  "点击这里"},
            {"ClickHereMsgID",  "Klik di sini"},
            {"ClickHereMsgTH",  "คลิกที่นี่"},
            {"ClickHereMsgVN",  "Nhấp vào đây"},

            {"SubscribeBackMsgEN",  "to subscribe back."},
            {"SubscribeBackMsgCN",  "重新订阅"},
            {"SubscribeBackMsgID",  "untuk berlangganan lagi."},
            {"SubscribeBackMsgTH",  "เพื่อสมัครอีกครั้ง"},
            {"SubscribeBackMsgVN",  "để đăng ký lại."},

        };

        private Dictionary<string, string> unsubscribeViewTranslations = new Dictionary<string, string>()
        {
            {"UnsubscribeMsgEN", "Do you want to unsubscribe?"},
            {"UnsubscribeMsgCN", "您确定要取消订阅吗?"},
            {"UnsubscribeMsgID", "Anda ingin berhenti berlangganan?"},
            {"UnsubscribeMsgTH", "คุณต้องการที่จะยกเลิกการสมัคร?"},
            {"UnsubscribeMsgVN", "Bạn muốn huỷ đăng ký?"},

            {"UnsubscribeBtnEN", "UNSUBSCRIBE"},
            {"UnsubscribeBtnCN", "取消订阅"},
            {"UnsubscribeBtnID", "BERHENTI LANGGANAN"},
            {"UnsubscribeBtnTH", "ยกเลิกการสมัคร"},
            {"UnsubscribeBtnVN", "HUỶ ĐĂNG KÝ"},

            {"EmailPlaceholderEN", "Email address"},
            {"EmailPlaceholderCN", "电子邮件地址"},
            {"EmailPlaceholderID", "Alamat email"},
            {"EmailPlaceholderTH", "ที่อยู่อีเมล"},
            {"EmailPlaceholderVN", "Địa chỉ email"}
        };

        #endregion

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Successful(string lang)
        {
            return View(GetSuccessViewTranslation(lang));
        }

        [HttpPost]
        public JsonResult Unsubscribe(string email)
        {
            bool isSuccess = false;

            if (!string.IsNullOrEmpty(email))
             isSuccess = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

         
            return Json(isSuccess);
        }

        public UnsubscribeSuccessViewModel GetSuccessViewTranslation(string language)
        {
            UnsubscribeSuccessViewModel vm = new UnsubscribeSuccessViewModel();
            string lang = !string.IsNullOrEmpty(language) ? language.ToUpper() : "EN";
            var trans = successViewTranslations.Where(x => x.Key.EndsWith(lang));
            if (trans != null)
            {
                vm.UnSubscribeSuccess = trans.FirstOrDefault(x => x.Key == $"SuccessMsg{lang}").Value;
                vm.ClickHere = trans.FirstOrDefault(x => x.Key == $"ClickHereMsg{lang}").Value;
                vm.SubscribeBack = trans.FirstOrDefault(x => x.Key == $"SubscribeBackMsg{lang}").Value;
            }

            return vm;
        }

        #region Partial views
        public IActionResult _SuccessView(UnsubscribeSuccessViewModel model)
        {
            return PartialView(model);
        }

        public IActionResult _UnsubscribeFormView(UnsubscribeFormViewModel model)
        {
            return PartialView(model);
        }

        #endregion
    }
}
