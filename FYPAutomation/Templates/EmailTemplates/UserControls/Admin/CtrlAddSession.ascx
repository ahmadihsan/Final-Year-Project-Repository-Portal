<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAddSession.ascx.cs" Inherits="FYPAutomation.UserControls.CtrlAddSession" %>

<div class="MessageDiv">
    <asp:Label runat="server" ID="lblMessage" ClientIDMode="Static"></asp:Label>
</div>
<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Add FYP Session:</legend>
        <table style="width: 100%">
            <tr>
                <td>Department:</td>
                <td>
                    <asp:DropDownList ID="ddlDep" runat="server" DataTextField="Name" DataValueField="DId">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                        ControlToValidate="ddlDep" ErrorMessage="Please select depratment" ForeColor="Red"
                        InitialValue="Select Department"
                        ValidationGroup="vgRegSession">Please select depratment</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Name:</td>
                <td>
                    <asp:TextBox ID="txtSessionName" runat="server" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSessionName" ErrorMessage="Title required" ForeColor="Red" ValidationGroup="vgRegSession">Session Name Required</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Description:</td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" Height="70px" TextMode="MultiLine" Width="300px"></asp:TextBox>(optional)</td>
            </tr>
            <tr>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnAddSession" runat="server" Text="Add Session" CssClass="btn btn-primaryByMe" ValidationGroup="vgRegSession" OnClick="BtnAddSessionClick" /></td>
            </tr>
        </table>
    </fieldset>
</div>
