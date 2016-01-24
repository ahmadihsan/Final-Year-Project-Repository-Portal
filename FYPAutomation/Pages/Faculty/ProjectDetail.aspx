<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/Faculty.Master" AutoEventWireup="true" CodeBehind="ProjectDetail.aspx.cs" Inherits="FYPAutomation.Pages.Faculty.ProjectDetail" %>

<%@ Register Src="~/UserControls/Admin/CtrlProjectDetail.ascx" TagPrefix="uc1" TagName="CtrlProjectDetailFac" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlProjectDetailFac runat="server" id="CtrlProjectDetailFac" />
</asp:Content>
