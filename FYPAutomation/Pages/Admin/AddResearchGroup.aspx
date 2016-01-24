<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/comsats.Master" AutoEventWireup="true" CodeBehind="AddResearchGroup.aspx.cs" Inherits="FYPAutomation.Pages.Admin.AddResearchGroup" %>

<%@ Register Src="~/UserControls/Admin/CtrlAddResearchGroup.ascx" TagPrefix="uc1" TagName="CtrlAddResearchGroup" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlAddResearchGroup runat="server" id="CtrlAddResearchGroup" />
</asp:Content>
