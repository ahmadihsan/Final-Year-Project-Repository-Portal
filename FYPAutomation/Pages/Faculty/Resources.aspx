<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/Faculty.Master" AutoEventWireup="true" CodeBehind="Resources.aspx.cs" Inherits="FYPAutomation.Pages.Faculty.Resources" %>

<%@ Register Src="~/UserControls/General/CtrlResourcesDownload.ascx" TagPrefix="uc1" TagName="CtrlResourcesDownload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlResourcesDownload runat="server" ID="CtrlResourcesDownload" />
</asp:Content>
