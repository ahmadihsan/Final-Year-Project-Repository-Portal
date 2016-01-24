<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/PCMember.Master" CodeBehind="AddProject.aspx.cs" Inherits="FYPAutomation.Pages.PCMember.AddProject" EnableViewState="true" %>
<%@ Register Src="~/UserControls/General/CtrlAddProject.ascx" TagPrefix="uc1" TagName="CtrlAddProject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent"  runat="server">
    <uc1:CtrlAddProject Id="CtrlAddProject" runat="server" />
</asp:Content>


