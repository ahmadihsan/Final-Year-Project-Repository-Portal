<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlLogin.ascx.cs" Inherits="FYPAutomation.UserControls.CtrlLogin"  %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Login Here : </legend>
        <table style="width: 100%">

            <tr>
                <td class="TitleTd">Email : </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email required" ForeColor="Red" Display="Dynamic" ValidationGroup="vgLogin">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="invalid email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="vgLogin">*</asp:RegularExpressionValidator>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="TitleTd">Password : </td>
                <td>
                    <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPwd" ErrorMessage="Please Enter Password" ForeColor="Red" Display="Dynamic" ValidationGroup="vgLogin">*</asp:RequiredFieldValidator>
                </td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td class="TitleTd">Role : </td>
                <td>
                    <asp:DropDownList ID="ddlRole" runat="server" DataTextField="Name" DataValueField="Rid" DataSourceID="EdRole">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlRole" ErrorMessage="Please select role" ForeColor="Red" InitialValue="Select Role" Display="Dynamic" ValidationGroup="vgLogin">*</asp:RequiredFieldValidator>
                    <asp:EntityDataSource ID="EdRole" runat="server" ConnectionString="name=FYPEntities" DefaultContainerName="FYPEntities" EnableFlattening="False" EntitySetName="Roles" Select="it.[Name], it.[Rid]">
                    </asp:EntityDataSource>
                </td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td class="TitleTd">&nbsp;</td>
                <td>
                    <asp:Button ID="btnLogin" CssClass="btn btn-primaryByMe" runat="server" Text="Login" Width="100px" OnClick="LoginClicked" ValidationGroup="vgLogin" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </fieldset>

</div>
