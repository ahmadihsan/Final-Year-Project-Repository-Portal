<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/comsats.Master" AutoEventWireup="true" CodeBehind="AddMileStone.aspx.cs" Inherits="FYPAutomation.Pages.Admin.AddMileStone" %>

<%@ Register Src="~/UserControls/Admin/CtrlAddMileStone.ascx" TagPrefix="uc1" TagName="CtrlAddMileStone" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlAddMileStone runat="server" id="CtrlAddMileStone" />
</asp:Content>
