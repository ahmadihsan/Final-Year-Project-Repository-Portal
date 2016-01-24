<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/comsats.Master" AutoEventWireup="true" CodeBehind="AddArchiveRecord.aspx.cs" Inherits="FYPAutomation.Pages.Admin.AddArchiveRecord"%>
<%@ Register Src="~/UserControls/General/CtrlAddArchiveRecords.ascx" TagPrefix="uc1" TagName="CtrlAddArchiveRecords" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<uc1:CtrlAddArchiveRecords runat="server" ID="CtrlAddArchiveRecords" />
    </asp:Content>
