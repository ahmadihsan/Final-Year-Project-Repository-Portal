﻿<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/comsats.Master" AutoEventWireup="true" CodeBehind="DetailedReport.aspx.cs" Inherits="FYPAutomation.Pages.Admin.DetailedReport" %>

<%@ Register Src="~/UserControls/General/CtrlDetailedReportOfProject.ascx" TagPrefix="uc1" TagName="CtrlDetailedReportOfProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlDetailedReportOfProject runat="server" ID="CtrlDetailedReportOfProject" />
</asp:Content>