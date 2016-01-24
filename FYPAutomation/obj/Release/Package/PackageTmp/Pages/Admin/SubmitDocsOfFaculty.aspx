<%@ Page Title="" Language="C#" MasterPageFile="~/comsats/comsats.Master" AutoEventWireup="true" CodeBehind="SubmitDocsOfFaculty.aspx.cs" Inherits="FYPAutomation.Pages.Admin.SubmitDocsOfFaculty" %>

<%@ Register Src="~/UserControls/General/CtrlDocSubmissionByAdminForOthers.ascx" TagPrefix="uc1" TagName="CtrlDocSubmissionByAdminForOthers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlDocSubmissionByAdminForOthers runat="server" ID="CtrlDocSubmissionByAdminForOthers" />
</asp:Content>
