<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAddResearchGroup.ascx.cs" Inherits="FYPAutomation.UserControls.CtrlAddResearchGroup" %>

<div class="MessageDiv">
    <asp:Label runat="server" ID="lblMessage" ClientIDMode="Static"></asp:Label>
</div>
<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Add/Edit Research Group:</legend>
        <table style="width: 100%">
            <tr>
                <td>Research Group Title:</td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" Width="500px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle" ErrorMessage="Title required" ForeColor="Red" ValidationGroup="vgAddRG">Title Required</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Research Group Description:</td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" Height="150px" TextMode="MultiLine" Width="500px"></asp:TextBox>(optional)
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnAddResearchGroup" runat="server" Text="Add Research Group" CssClass="btn btn-primaryByMe" ValidationGroup="vgAddRG" OnClick="BtnAddResearchGroupClick"/>
                </td>
            </tr>
        </table>
    </fieldset>
</div>
