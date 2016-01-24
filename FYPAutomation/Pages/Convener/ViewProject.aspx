<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/convenor.Master" AutoEventWireup="true" CodeBehind="ViewProject.aspx.cs" Inherits="FYPAutomation.Pages.Convener.ViewProject" %>
<%@ Register Src="~/UserControls/Convener/CtrlViewProjectsForConvener.ascx" TagPrefix="uc1" TagName="CtrlViewProjectsForConvener" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlViewProjectsForConvener runat="server" ID="CtrlViewProjectsForConvener" />
</asp:Content>

