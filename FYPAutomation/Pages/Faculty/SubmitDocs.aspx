<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/Faculty.Master" AutoEventWireup="true" CodeBehind="SubmitDocs.aspx.cs" Inherits="FYPAutomation.Pages.Faculty.SubmitDocs" %>

<%@ Register Src="~/UserControls/Faculty/CtrlDocSubmission.ascx" TagPrefix="uc1" TagName="CtrlDocSubmission" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlDocSubmission runat="server" id="CtrlDocSubmission" />
</asp:Content>
