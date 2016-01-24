<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/PCMember.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FYPAutomation.Pages.PCMember.Default" %>

<%@ Register Src="~/UserControls/PCMember/CtrlPCMemberDashBoard.ascx" TagPrefix="uc1" TagName="CtrlPCMemberDashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlPCMemberDashBoard runat="server" id="CtrlPCMemberDashBoard" />
</asp:Content>
