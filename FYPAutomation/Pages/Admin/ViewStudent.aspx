<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/comsats.Master" AutoEventWireup="true" CodeBehind="ViewStudent.aspx.cs" Inherits="FYPAutomation.Pages.Admin.ViewStudent" %>

<%@ Register Src="~/UserControls/Admin/CtrlViewStudent.ascx" TagPrefix="uc1" TagName="CtrlViewStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlViewStudent runat="server" id="CtrlViewStudent" />
</asp:Content>
