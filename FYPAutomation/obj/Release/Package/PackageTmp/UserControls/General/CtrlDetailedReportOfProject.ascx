<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlDetailedReportOfProject.ascx.cs" Inherits="FYPAutomation.UserControls.General.CtrlDetailedReportOfProject" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Reports:</legend>
        <rsweb:ReportViewer ID="rptProjectDetail" runat="server" Style="width: 100%;height: auto">
            <LocalReport ReportPath="Reports/reportProjectDetail.rdlc"></LocalReport>
        </rsweb:ReportViewer>
    </fieldset>
</div>
