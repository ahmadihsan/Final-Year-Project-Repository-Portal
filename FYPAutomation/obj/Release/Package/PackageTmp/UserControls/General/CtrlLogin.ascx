<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlLogin.ascx.cs" Inherits="FYPAutomation.UserControls.CtrlLogin" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Login Here : </legend>
        <table style="width: 100%">

            <tr>
                <td class="TitleTd">Email/Reg No : </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email required" ForeColor="Red" Display="Dynamic" ValidationGroup="vgLogin">*</asp:RequiredFieldValidator>
                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="invalid email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="vgLogin">*</asp:RegularExpressionValidator>--%>
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
            <%--<tr>
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
            </tr>--%>
            <tr>
                <td class="TitleTd">&nbsp;</td>
                <td>
                    <asp:Button ID="btnLogin" CssClass="btn btn-primaryByMe" runat="server" Text="Login" Width="100px" OnClick="LoginClicked" ValidationGroup="vgLogin" />
                    <asp:Label runat="server" ID="lblMessage" ForeColor="Red"></asp:Label>
                    <br />
                    
                </td>
                <td></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="TitleTd">&nbsp;</td>
                <td>
                    <asp:LinkButton ID="lnk" runat="server" OnClick="LnkForgotPasswordClicked">Forgot Password</asp:LinkButton>
                </td>
                <td></td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </fieldset>

</div>


<div id="forgotPwd" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
            <h5 id="myModalLabel">Forgot Password</h5>
        </div>
        <div class="modal-body">
        <table class="mytable" style="width: 500px">
            <tr id="firstRow" runat="server">
                <td>Enter Email:</td>
                <td><asp:TextBox runat="server" ID="txtResetEmail" ></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button runat="server" ID="btnSubmitEmail" OnClick="BtnSubmitRestPwdClicked" CssClass="btn btn-primaryByMe" Text="Submit"/>
                    
                </td>
            </tr>
        </table>    
        </div>
        <div class="modal-footer">
            <button class="btn btn-primary" data-dismiss="modal" aria-hidden="true">Close</button>
        </div>
    </div>