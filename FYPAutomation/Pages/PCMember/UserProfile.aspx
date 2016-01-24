<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/PCMember.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="FYPAutomation.Pages.PCMember.UserProfile" %>

<%@ Register Src="~/UserControls/Admin/CtrlUserProfile.ascx" TagPrefix="uc1" TagName="CtrlUserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlUserProfile runat="server" id="CtrlUserProfile" />
</asp:Content>
