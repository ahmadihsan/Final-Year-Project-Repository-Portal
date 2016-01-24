<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/PCMember.Master" AutoEventWireup="true" CodeBehind="ViewProjects.aspx.cs" Inherits="FYPAutomation.Pages.PCMember.ViewProjects" %>

<%@ Register Src="~/UserControls/PCMember/CtrlViewProjectsForPC.ascx" TagPrefix="uc1" TagName="CtrlViewProjectsForPC" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlViewProjectsForPC runat="server" ID="CtrlViewProjectsForPC" />
</asp:Content>
