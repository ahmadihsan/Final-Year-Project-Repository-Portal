<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/PCMember.Master" AutoEventWireup="true" CodeBehind="ViewMyProjects.aspx.cs" Inherits="FYPAutomation.Pages.PCMember.ViewMyProjects" %>
<%@ Register Src="~/UserControls/PCMember/CtrlMyProjectsPCM.ascx" TagPrefix="uc1" TagName="CtrlMyProjectsPCM" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlMyProjectsPCM runat="server" id="CtrlMyProjectsPCM" />
</asp:Content>
