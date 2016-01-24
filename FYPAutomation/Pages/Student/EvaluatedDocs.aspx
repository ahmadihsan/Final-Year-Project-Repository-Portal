<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/comsats/student.Master" CodeBehind="EvaluatedDocs.aspx.cs" Inherits="FYPAutomation.Pages.Student.EvaluatedDocs" %>

<%@ Register Src="~/UserControls/Student/CtrlEaluatedDocs.ascx" TagPrefix="uc1" TagName="CtrlEaluatedDocs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlEaluatedDocs ID="CtrlEaluatedDocs" runat="server" />
</asp:Content>
