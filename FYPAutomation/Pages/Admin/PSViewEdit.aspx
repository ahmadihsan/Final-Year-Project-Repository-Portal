<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/comsats.Master" AutoEventWireup="true" CodeBehind="PSViewEdit.aspx.cs" Inherits="FYPAutomation.Pages.Admin.PSViewEdit" %>

<%@ Register Src="~/UserControls/General/CtrlViewEditPresentationSchedule.ascx" TagPrefix="uc1" TagName="CtrlViewEditPresentationSchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlViewEditPresentationSchedule runat="server" id="CtrlViewEditPresentationSchedule" />
</asp:Content>
