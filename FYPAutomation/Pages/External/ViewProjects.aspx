<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/External.Master" CodeBehind="ViewProjects.aspx.cs" Inherits="FYPAutomation.Pages.External.ViewProjects" %>

<%@ Register Src="~/UserControls/External/ViewProjects.ascx" TagPrefix="uc1" TagName="ViewProjects" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">   
    <uc1:ViewProjects runat="server" ID="ViewProject" />
</asp:Content>