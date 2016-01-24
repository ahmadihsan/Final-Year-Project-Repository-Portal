<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/comsats.Master" AutoEventWireup="true" CodeBehind="ViewWeeklySchedule.aspx.cs" Inherits="FYPAutomation.Pages.Admin.ViewWeeklySchedule" %>

<%@ Register Src="~/UserControls/General/CtrlViewMySchedule.ascx" TagPrefix="uc1" TagName="CtrlViewMySchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlViewMySchedule runat="server" id="CtrlViewMySchedule" />
</asp:Content>
