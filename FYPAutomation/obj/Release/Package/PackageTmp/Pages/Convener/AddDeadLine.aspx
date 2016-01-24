<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/convenor.Master" AutoEventWireup="true" CodeBehind="AddDeadLine.aspx.cs" Inherits="FYPAutomation.Pages.Convener.AddDeadLine" %>

<%@ Register Src="~/UserControls/Admin/CtrlAddDeadLine.ascx" TagPrefix="uc1" TagName="CtrlAddDeadLine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlAddDeadLine runat="server" ID="CtrlAddDeadLine" />
</asp:Content>
