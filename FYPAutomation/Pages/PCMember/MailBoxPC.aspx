<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MailBoxPC.aspx.cs" MasterPageFile="~/comsats/MailBoxPC.Master" Inherits="FYPAutomation.Pages.PCMember.MailBoxPC" %>

<%@ Register Src="~/UserControls/PCMember/CtrlMailBoxPC.ascx" TagPrefix="uc1" TagName="CtrlMail" %>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlMail runat="server" ID="CtrlMail" />
</asp:Content>
