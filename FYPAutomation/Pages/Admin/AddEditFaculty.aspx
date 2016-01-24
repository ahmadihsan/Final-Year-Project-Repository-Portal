<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/comsats.Master" AutoEventWireup="true" CodeBehind="AddEditFaculty.aspx.cs" Inherits="FYPAutomation.Pages.admin.AddEditFaculty" EnableViewState="true" %>

<%@ Register Src="~/UserControls/Admin/CtrlAddEditFaculty.ascx" TagPrefix="uc1" TagName="CtrlAddEditFaculty" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlAddEditFaculty runat="server" id="CtrlAddEditFaculty" />
</asp:Content>
