<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/convenor.Master" AutoEventWireup="true" CodeBehind="AddProject.aspx.cs" Inherits="FYPAutomation.Pages.Convener.AddProject" %>

<%@ Register Src="~/UserControls/Admin/CtrlAddProject.ascx" TagPrefix="uc1" TagName="CtrlAddProject" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlAddProject runat="server" id="CtrlAddProject" />
</asp:Content>
