<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/comsats.Master" AutoEventWireup="true" CodeBehind="PCManager.aspx.cs" Inherits="FYPAutomation.Pages.Admin.PCManager" %>

<%@ Register Src="~/UserControls/Convener/CtrlPCMemberManager.ascx" TagPrefix="uc1" TagName="CtrlPCMemberManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlPCMemberManager runat="server" id="CtrlPCMemberManager" />
</asp:Content>
