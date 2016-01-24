<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAddMileStone.ascx.cs" Inherits="FYPAutomation.UserControls.CtrlAddMileStone" %>
<div class="MessageDiv">
    <asp:Label runat="server" ID="lblMessage" ClientIDMode="Static"></asp:Label>
</div>
<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Add MileStones:</legend>
        <table style="width: 100%">
            <tr>
                <td>Name:</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="500px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="Title required" ForeColor="Red" ValidationGroup="vgAddRG">Title Required</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Description:</td>
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
                    <asp:Button ID="btnAddMileStone" runat="server" Text="Add MileStone" CssClass="btn btn-primaryByMe" ValidationGroup="vgAddRG" OnClick="BtnAddMileStoneGroupClick"/>
                </td>
            </tr>
        </table>
    </fieldset>
</div>
