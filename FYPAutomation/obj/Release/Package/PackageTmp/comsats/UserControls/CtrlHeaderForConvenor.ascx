<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlHeaderForConvenor.ascx.cs" Inherits="WebApplication1.comsats.CtrlHeaderForConvenor" %>
<%@ Import Namespace="FYPUtilities" %>
<%@ Register Src="~/comsats/UserControls/CtrlMenuControlForConvenor.ascx" TagPrefix="uc1" TagName="CtrlMenuControlForConvenor" %>

<div class="headup_wrap">
    <div class="headup">
        <div id="centeredmenu">
            <ul>
                <li style="display: <%= FYPSession.IsUserLoggedIn()? "block":"none" %>"><a href="<%= VirtualPathUtility.ToAbsolute("~/pages/Convener/default.aspx") %>">Home</a></li>
                <li style="display: <%= FYPSession.IsUserLoggedIn()? "block":"none" %>"><a href="<%=FYPSession.IsUserLoggedIn()?VirtualPathUtility.ToAbsolute(string.Format("~/Pages/Convener/UserProfile.aspx?UId={0}",FYPSession.GetLoggedUser().UserId)):string.Empty%>">My Account</a></li>

                <li><a href="<%=  FYPSession.IsUserLoggedIn()? VirtualPathUtility.ToAbsolute("~/pages/login?cmd=logout"):"#" %>"><%= FYPSession.IsUserLoggedIn()?"Log out":"Log In"  %></a></li>
                <li style="display: <%= FYPSession.IsUserLoggedIn()? "block":"none" %>; color: white">welcome:<%=FYPSession.IsUserLoggedIn()?FYPSession.GetLoggedUser().Name:string.Empty%></li>
            </ul>
        </div>
    </div>
</div>
<div class="header_wrap">
    <div class="header">
    </div>
</div>
<div class="menu_bar_wrap_convenor">
    <div class="menu_bar_convenor">
        <uc1:CtrlMenuControlForConvenor runat="server" ID="CtrlMenuControlForConvenor" />
    </div>
</div>
