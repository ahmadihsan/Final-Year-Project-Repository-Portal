<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/convenor.Master" AutoEventWireup="true" CodeBehind="PresentationSchedule.aspx.cs" Inherits="FYPAutomation.Pages.Convener.PresentationSchedule" %>

<%@ Register Src="~/UserControls/General/CtrlPresentationSchedule.ascx" TagPrefix="uc1" TagName="CtrlPresentationSchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlPresentationSchedule runat="server" id="CtrlPresentationSchedule" />
</asp:Content>
