<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlChangePassword.ascx.cs" Inherits="FYPAutomation.UserControls.General.CtrlChangePassword" %>

<style type="text/css">
    .auto-style1 {
        height: 30px;
    }
</style>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Change Passwor: </legend>
        <table style="width: 100%" class="mytable">
            <tr>
                <td>Current Password</td>
                <td><asp:TextBox runat="server" ID="txtCurrentPwd" TextMode="Password" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCurrentPwd" ErrorMessage="Current Password required" ForeColor="Red" ValidationGroup="vgPwd">Enter Your current Password</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>New Password</td>
                <td><asp:TextBox runat="server" ID="txtNewPwd" ValidationGroup="vgPwd" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPwd" ErrorMessage="Current Password required" ForeColor="Red" ValidationGroup="vgPwd">New Password</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Confirm Password</td>
                <td class="auto-style1"><asp:TextBox runat="server" ID="txtConfirmPwd" ValidationGroup="vgPwd" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfirmPwd" ErrorMessage="Current Password required" ForeColor="Red" ValidationGroup="vgPwd">Confirm Password</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPwd" ControlToValidate="txtConfirmPwd" ErrorMessage="Password does't match" ForeColor="Red" ValidationGroup="vgPwd">Password does&#39;t match</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button runat="server" ID="btnSubmit" ValidationGroup="vgPwd" Text="Submit" OnClick="SubmitChangePwd" CssClass="btn btn-primaryByMe"></asp:Button>
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </fieldset>
</div>
