﻿<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/comsats.Master" AutoEventWireup="true" CodeBehind="ViewPresentationSchedule.aspx.cs" Inherits="FYPAutomation.Pages.Admin.PresentationSchedule" %>

<%@ Register Src="~/UserControls/General/CtrlViewOnlyPresentationSchedule.ascx" TagPrefix="uc1" TagName="CtrlViewOnlyPresentationSchedule" %>




<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlViewOnlyPresentationSchedule runat="server" ID="CtrlViewOnlyPresentationSchedule" />
</asp:Content>

