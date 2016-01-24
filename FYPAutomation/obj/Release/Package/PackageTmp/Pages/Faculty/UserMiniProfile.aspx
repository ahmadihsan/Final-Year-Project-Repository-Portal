<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/Faculty.Master" AutoEventWireup="true" CodeBehind="UserMiniProfile.aspx.cs" Inherits="FYPAutomation.Pages.Faculty.UserMiniProfile" %>

<%@ Register Src="~/UserControls/General/CtrlUserProfileMini.ascx" TagPrefix="uc1" TagName="CtrlUserProfileMini" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlUserProfileMini runat="server" id="CtrlUserProfileMini" />
</asp:Content>
