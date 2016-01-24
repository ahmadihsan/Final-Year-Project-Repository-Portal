<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/convenor.Master" AutoEventWireup="true" CodeBehind="AddPCMember.aspx.cs" Inherits="FYPAutomation.Pages.Convener.AddPCMember" %>

<%@ Register Src="~/UserControls/Convener/CtrlAddPcMembers.ascx" TagPrefix="uc1" TagName="CtrlAddPcMembers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlAddPcMembers runat="server" ID="CtrlAddPcMembers" />
</asp:Content>
