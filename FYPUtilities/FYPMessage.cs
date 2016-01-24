using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYPUtilities
{

    public static class FYPMessage
    {
        public static void ShowMessage(ref Label lblMessage, bool successStatus, string message)
        {
            lblMessage.CssClass = successStatus ? "Success" : "Failure";
            lblMessage.Visible = true;
            lblMessage.Text = message;
        }
        public static void MakeLabelInvisible(ref Label lblMessage)
        {
            lblMessage.CssClass = "";
            lblMessage.Text = "";
        }
        private static void ShowPopUpMessage(string title,string message,Page page)
        {
            var rd = FYPDate.UniqueStringFromDate();
            string script = string.Format(@"ShowPopup('{0}','{1}');",title,message);
            page.ClientScript.RegisterStartupScript(page.GetType(),rd,script,true);
        }
        public static void ShowPopUpMessage(string title, List<string> messages, Page page,bool ajax, string subTitle = null)
        {
            var rd = new Random(DateTime.Now.Millisecond);
            if(messages.Count==0)
                ShowPopUpMessage(title,"No Message",page);
            else
            {
                var compiledMessage = new StringBuilder();
                compiledMessage.AppendFormat("<ul>");
                if(subTitle!=null)
                {
                    compiledMessage.AppendFormat("<li>{0}<ul>",subTitle);
                }
                foreach (string message in messages)
                {
                    compiledMessage.AppendFormat("<li>{0}</li>", message);
                }
                if(subTitle!=null)
                {
                    compiledMessage.AppendFormat("</ul></li>");
                }
                compiledMessage.Append("</ul>");
                if(ajax)
                    ShowPopUpAjaxMessage(title, compiledMessage.ToString(), page);
                else
                    ShowPopUpMessage(title, compiledMessage.ToString(), page);
                
            }
        }
        private static void ShowPopUpAjaxMessage(string title, string message, Page page)
        {
            var rd = FYPDate.UniqueStringFromDate();
            string script = string.Format(@"ShowPopup('{0}','{1}');", title, message);
            //string script = string.Format(@"alert('{0}');", "Hello");
            ScriptManager.RegisterStartupScript(page, page.GetType(), rd, script, true);
        }

        public static void ShowBootStrapPopUp(string divId,Page pg,bool ajax)
        {
            var sb = new System.Text.StringBuilder();
            var rd = FYPDate.UniqueStringFromDate();
            sb.Append(string.Format("$('#{0}').modal('show')",divId));
            
            if(ajax)
            {
                ScriptManager.RegisterStartupScript(pg, pg.GetType(),rd, sb.ToString(),true);
            }
            else
            {
                pg.ClientScript.RegisterStartupScript(pg.GetType(), rd, sb.ToString(),true);
            }
    
        }
        public static void HideBootStrapModalPopup(string divId, Page pg, bool ajax)
        {
            var sb = new System.Text.StringBuilder();
            var rd = FYPDate.UniqueStringFromDate();
            sb.Append(string.Format("$('#{0}').modal('hide')", divId));
            if (ajax)
            {
                ScriptManager.RegisterStartupScript(pg, pg.GetType(), rd, sb.ToString(), true);
            }
            else
            {

                pg.ClientScript.RegisterStartupScript(pg.GetType(), rd, sb.ToString(), true);
            }
    
        }
        public static void  ShowMessageAndHidePopup(string title, List<string> messages, Page page, bool ajax,string subTitle=null)
        {
            var rd = FYPDate.UniqueStringFromDate();
            if (messages.Count == 0)
                ShowPopUpMessage(title, "No Message", page);
            else
            {
                var compiledMessage = new StringBuilder();
                compiledMessage.AppendFormat("<ul>");
                if (subTitle != null)
                {
                    compiledMessage.AppendFormat("<li>{0}<ul>", subTitle);
                }
                foreach (string message in messages)
                {
                    compiledMessage.AppendFormat("<li>{0}</li>", message);
                }
                if (subTitle != null)
                {
                    compiledMessage.AppendFormat("</ul></li>");
                }
                compiledMessage.Append("</ul>");
                if (ajax)
                {
                    string script = string.Format(@"ShowPopup('{0}','{1}');$('.modal-backdrop').remove();", title, compiledMessage.ToString());
                    //string script = string.Format(@"alert('{0}');", "Hello");
                    ScriptManager.RegisterStartupScript(page, page.GetType(), rd, script, true);
                }
                  
                else
                {

                    string script = string.Format(@"ShowPopup('{0}','{1}');$('.modal-backdrop').remove();", title, compiledMessage.ToString());
                    page.ClientScript.RegisterStartupScript(page.GetType(), rd, script, true);
                }
                    

            }
        }
        #region Commented
        //public static void ShowMessageAndBootStrapPopup(string title, List<string> messages, Page page, bool ajax, string divPopupId, string subTitle = null)
        //{
        //    var rd = FYPDate.UniqueStringFromDate();
        //    if (messages.Count == 0)
        //        ShowPopUpMessage(title, "No Message", page);
        //    else
        //    {
        //        var compiledMessage = new StringBuilder();
        //        compiledMessage.AppendFormat("<ul>");
        //        if (subTitle != null)
        //        {
        //            compiledMessage.AppendFormat("<li>{0}<ul>", subTitle);
        //        }
        //        foreach (string message in messages)
        //        {
        //            compiledMessage.AppendFormat("<li>{0}</li>", message);
        //        }
        //        if (subTitle != null)
        //        {
        //            compiledMessage.AppendFormat("</ul></li>");
        //        }
        //        compiledMessage.Append("</ul>");
        //        if (ajax)
        //        {
        //            string script = string.Format(@"ShowPopup('{0}','{1}');$('#{2}').modal('show');", title,
        //                                          compiledMessage.ToString(), divPopupId);
        //            ScriptManager.RegisterStartupScript(page, page.GetType(), rd, script, true);
        //        }

        //        else
        //        {

        //            string script = string.Format(@"ShowPopup('{0}','{1}');$('.modal-backdrop').remove();", title,
        //                                          compiledMessage.ToString());
        //            page.ClientScript.RegisterStartupScript(page.GetType(), rd, script, true);
        //        }


        //    }
        //}
        #endregion
        public static void RunClientScript(string innerScript,bool ajax,Page page)
        {
            var rd = FYPDate.UniqueStringFromDate();
            if (ajax)
            {
                ScriptManager.RegisterStartupScript(page, page.GetType(), rd, innerScript, true);
            }

            else
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), rd, innerScript, true);
            }

        }
        private static string RedirectionScript(string url)
        {
            return string.Format("window.location = \"{0}\"", url);
        }
        public static void RedirectToUrl(string url,bool ajax,Page pg)
        {
            RunClientScript(RedirectionScript(url),ajax,pg);
        }
    }
}
