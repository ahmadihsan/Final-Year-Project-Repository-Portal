<%@ Page Language="C#" MasterPageFile="~/comsats/External.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="FYPAutomation.Pages.External.UserProfile" %>

<%@ Register Src="~/UserControls/External/UserProfile.ascx" TagPrefix="uc1" TagName="UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:UserProfile runat="server" id="CtrlUserProfile" />
</asp:Content>