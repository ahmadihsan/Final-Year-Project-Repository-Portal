<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/convenor.Master" AutoEventWireup="true" CodeBehind="MyProject.aspx.cs" Inherits="FYPAutomation.Pages.Convener.MyProject" %>
<%@ Register Src="~/UserControls/Convener/CtrlMyProjectsCon.ascx" TagPrefix="uc1" TagName="CtrlMyProjectsCon" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlMyProjectsCon runat="server" id="CtrlMyProjectsCon" />
</asp:Content>
