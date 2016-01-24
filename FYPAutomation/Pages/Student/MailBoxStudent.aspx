<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MailBoxStudent.aspx.cs" MasterPageFile="~/comsats/StudentMailBox.Master" Inherits="FYPAutomation.Pages.Student.MailBoxStudent" %>

<%@ Register Src="~/UserControls/Student/CtrlMailBoxStudent.ascx" TagPrefix="uc1" TagName="CtrlMail" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlMail runat="server" ID="CtrlMail" />
</asp:Content>
