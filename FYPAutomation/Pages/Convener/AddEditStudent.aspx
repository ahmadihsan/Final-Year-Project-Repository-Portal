<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/convenor.Master" AutoEventWireup="true" CodeBehind="AddEditStudent.aspx.cs" Inherits="FYPAutomation.Pages.Convener.AddEditStudent" %>

<%@ Register Src="~/UserControls/Admin/CtrlAddEditStudent.ascx" TagPrefix="uc1" TagName="CtrlAddEditStudent" %>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlAddEditStudent runat="server" id="CtrlAddEditStudent" />
</asp:Content>
