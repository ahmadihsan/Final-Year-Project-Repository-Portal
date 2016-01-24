<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/convenor.Master" AutoEventWireup="true" CodeBehind="ProjectWithComments.aspx.cs" Inherits="FYPAutomation.Pages.Convener.ProjectWithComments" %>

<%@ Register Src="~/UserControls/Convener/CtrlProjectsWithComments.ascx" TagPrefix="uc1" TagName="CtrlProjectsWithComments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlProjectsWithComments runat="server" id="CtrlProjectsWithComments" />
</asp:Content>
