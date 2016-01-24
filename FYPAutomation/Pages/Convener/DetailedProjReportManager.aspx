<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/convenor.Master" AutoEventWireup="true" CodeBehind="DetailedProjReportManager.aspx.cs" Inherits="FYPAutomation.Pages.Convener.DetailedProjReportManager" %>

<%@ Register Src="~/UserControls/General/CtrlShowProjectListForReport.ascx" TagPrefix="uc1" TagName="CtrlShowProjectListForReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlShowProjectListForReport runat="server" id="CtrlShowProjectListForReport" />
</asp:Content>
