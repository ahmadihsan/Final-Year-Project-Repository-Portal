<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/PCMember.Master" AutoEventWireup="true" CodeBehind="PCRemarks.aspx.cs" Inherits="FYPAutomation.Pages.PCMember.PCRemarks" %>

<%@ Register Src="~/UserControls/General/CtrlCommentsToSupervisor.ascx" TagPrefix="uc1" TagName="CtrlCommentsToSupervisor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlCommentsToSupervisor runat="server" ID="CtrlCommentsToSupervisor" />
</asp:Content>
