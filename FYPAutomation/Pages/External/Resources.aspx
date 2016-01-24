<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/comsats/External.Master" CodeBehind="Resources.aspx.cs" Inherits="FYPAutomation.Pages.External.Resources" %>

<%@ Register Src="~/UserControls/General/CtrlResourcesDownload.ascx" TagPrefix="uc1" TagName="CtrlResourcesDownload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlResourcesDownload runat="server" ID="CtrlResourcesDownload" />
</asp:Content>