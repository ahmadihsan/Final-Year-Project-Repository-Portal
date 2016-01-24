<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/comsats.Master" AutoEventWireup="true" CodeBehind="AssignedDocs.aspx.cs" Inherits="FYPAutomation.Pages.Convener.AssignedDocs" %>

<%@ Register Src="~/UserControls/General/CtrlAssignedDocs.ascx" TagPrefix="uc1" TagName="CtrlAssignedDocs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlAssignedDocs runat="server" id="CtrlAssignedDocs" />
</asp:Content>
