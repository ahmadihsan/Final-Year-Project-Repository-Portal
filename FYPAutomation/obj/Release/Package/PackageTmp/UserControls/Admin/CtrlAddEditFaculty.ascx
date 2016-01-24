<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAddEditFaculty.ascx.cs" Inherits="FYPAutomation.UserControls.CtrlAddEditFaculty" %>

<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>

    <div class="MessageDiv" >
        <asp:Label runat="server" ID="lblMessage" ClientIDMode="Static"></asp:Label>
    </div>
<div class="FieldSet">
<fieldset class="FieldSet">
    <legend>User Info:</legend>
    <table style="width: 100%">
       
        <tr>
            <td class="TitleTd">Faculty Name :</td>
            <td>
                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Name required" ForeColor="Red" ValidationGroup="vgRegisterFac">Name required</asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="TitleTd">Email : </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email required" ForeColor="Red" ValidationGroup="vgRegisterFac">Email required</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="invalid email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="TitleTd">Extension Number : </td>
            <td>
                <ew:NumericBox ID="txtPhone" runat="server" MaxLength="13" PositiveNumber="True" RealNumber="False" />
                (optional)</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="TitleTd">Mobile : </td>
            <td>
                <ew:NumericBox ID="txtMobile" runat="server" MaxLength="13" PositiveNumber="True" RealNumber="False" />
                (optional)</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="TitleTd">Designation : </td>
            <td>
                <asp:DropDownList ID="ddlDesignation" runat="server" DataTextField="Key" DataValueField="Key" EnableViewState="true">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlDesignation" ErrorMessage="Please select Designation" ForeColor="Red" InitialValue="Select Designation" ValidationGroup="vgRegisterFac">Please select Designation</asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</fieldset>
<fieldset class="FieldSet">
    <legend>Other</legend>
    <table style="width: 100%">
        <tr>
            <td class="TitleTd">Role : </td>
            <td>
                <asp:DropDownList ID="ddlRole" runat="server" DataTextField="Name" DataValueField="Rid" EnableViewState="true">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlRole" ErrorMessage="Please select role" ForeColor="Red" InitialValue="Select Role" ValidationGroup="vgRegisterFac">Please select role</asp:RequiredFieldValidator>
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td class="TitleTd">Department :</td>
            <td>
                <asp:DropDownList ID="ddlDepartment" runat="server" DataTextField="Name" DataValueField="DId"  EnableViewState="true">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlDepartment" ErrorMessage="Please select depratment" ForeColor="Red" InitialValue="Select Department" ValidationGroup="vgRegisterFac">Please select depratment</asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="TitleTd">Research Group :</td>
            <td>
                <asp:DropDownList ID="ddlResearchGroup" runat="server" DataTextField="Title" DataValueField="ResearchId"  EnableViewState="true">
                </asp:DropDownList>
                (optional)</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</fieldset>
<fieldset class="FieldSet">
    <legend>Status</legend>
    <table style="width: 100%">
        <tr>
            <td class="TitleTd">Status : </td>
            <td>
                <asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal" CssClass="RadioButtons" RepeatLayout="Flow">
                    <asp:ListItem Text="Enable" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Disable" Value="0"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td></td>
            <td></td>
        </tr>
    </table>
</fieldset>

    <table style="width: 99%">
        <tr>
            <td class="TitleTd"></td>
            <td></td>
            <td></td>
            <td class="TextAlignRight">
                <asp:Button ID="btnRegisterFaculty" CssClass="btn btn-primaryByMe" runat="server" Text="Register" Width="100px" OnClick="AddFaculty" ValidationGroup="vgRegisterFac"/>
            </td>
        </tr>
        <tr>
            <td class="TitleTd"></td>
            <td></td>
            <td></td>
            <td class="TextAlignRight">
               
                &nbsp;</td>
        </tr>
    </table>

</div>