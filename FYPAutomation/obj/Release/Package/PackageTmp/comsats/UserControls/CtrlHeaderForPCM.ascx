﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlHeaderForPCM.ascx.cs" Inherits="FYPAutomation.comsats.UserControls.CtrlHeaderForPCM" %>

<%@ Import Namespace="FYPUtilities" %>
<%@ Register Src="~/comsats/UserControls/CtrlMenuControlForPCM.ascx" TagPrefix="uc1" TagName="CtrlMenuControlForPCM" %>



<div class="headup_wrap">
    <div class="headup">
        <div id="centeredmenu">
            <ul>
                <li style="display: <%= FYPSession.IsUserLoggedIn()? "block":"none" %>"><a href="<%= VirtualPathUtility.ToAbsolute("~/pages/PCMember/default.aspx") %>">Home</a></li>
                <li style="display: <%= FYPSession.IsUserLoggedIn()? "block":"none" %>"><a href="<%=FYPSession.IsUserLoggedIn()?VirtualPathUtility.ToAbsolute(string.Format("~/Pages/PCMember/UserProfile.aspx?UId={0}",FYPSession.GetLoggedUser().UserId)):string.Empty%>">My Account</a></li>

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
<div class="menu_bar_wrap_student">
    <div class="menu_bar_student">
        <uc1:CtrlMenuControlForPCM runat="server" id="CtrlMenuControlForPCM" />
    </div>
</div>
