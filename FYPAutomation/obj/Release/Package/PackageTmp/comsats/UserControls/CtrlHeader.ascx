<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlHeader.ascx.cs" Inherits="WebApplication1.comsats.CtrlHeader" %>
<%@ Import Namespace="FYPUtilities" %>
<%@ Register Src="~/comsats/UserControls/CtrlMenuControl.ascx" TagPrefix="uc1" TagName="CtrlMenuControl" %>

<div class="headup_wrap">
    <div class="headup">
        <div id="centeredmenu">
            <ul>
                <li style="display: <%= FYPSession.IsUserLoggedIn()? "block":"none" %>"><a href="<%= VirtualPathUtility.ToAbsolute("~/pages/Admin/default.aspx") %>">Home</a></li>
                <li style="display: <%= FYPSession.IsUserLoggedIn()? "block":"none" %>"><a href="<%=FYPSession.IsUserLoggedIn()?VirtualPathUtility.ToAbsolute(string.Format("~/Pages/Admin/UserProfile.aspx?UId={0}",FYPSession.GetLoggedUser().UserId)):string.Empty%>">My Account</a></li>

                <li><a href="<%=  FYPSession.IsUserLoggedIn()? VirtualPathUtility.ToAbsolute("~/pages/login?cmd=logout"):"#" %>"><%= FYPSession.IsUserLoggedIn()?"Log out":"Log In"  %></a></li>
                <li style="display: <%= FYPSession.IsUserLoggedIn()? "block":"none" %>;color: white">welcome:<%=FYPSession.IsUserLoggedIn()?FYPSession.GetLoggedUser().Name:string.Empty%></li>
            </ul>
        </div>
    </div>
</div>
<div class="header_wrap">
    <div class="header">
    </div>
</div>
<div class="menu_bar_wrap">
    <div class="menu_bar">
        <uc1:CtrlMenuControl runat="server" ID="CtrlMenuControl" />
    </div>
</div>
