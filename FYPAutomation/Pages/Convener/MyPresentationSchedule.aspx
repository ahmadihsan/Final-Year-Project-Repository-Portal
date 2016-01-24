<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/convenor.Master" AutoEventWireup="true" CodeBehind="MyPresentationSchedule.aspx.cs" Inherits="FYPAutomation.Pages.Convener.MyPresentationSchedule" %>

<%@ Register Src="~/UserControls/General/CtrlMyPresentationSchedule.ascx" TagPrefix="uc1" TagName="CtrlMyPresentationSchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlMyPresentationSchedule runat="server" id="CtrlMyPresentationSchedule" />
</asp:Content>
