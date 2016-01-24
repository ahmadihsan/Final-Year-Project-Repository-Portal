<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/comsats.Master" AutoEventWireup="true" CodeBehind="MileStoneManager.aspx.cs" Inherits="FYPAutomation.Pages.Admin.MileStoneManager" %>

<%@ Register Src="~/UserControls/Admin/CtrlMStoneManager.ascx" TagPrefix="uc1" TagName="CtrlMStoneManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlMStoneManager runat="server" id="CtrlMStoneManager" />
</asp:Content>
