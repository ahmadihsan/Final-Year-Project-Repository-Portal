<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAddEditStudent.ascx.cs" Inherits="FYPAutomation.UserControls.CtrlAddEditStudent" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>

<div class="MessageDiv">
    <asp:Label runat="server" ID="lblMessage" ClientIDMode="Static"></asp:Label>
</div>
<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>User Info:</legend>
        <table style="width: 100%">

            <tr>
                <td class="TitleTd">Student Name :</td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName" ErrorMessage="First Name required" ForeColor="Red" ValidationGroup="vgRegStudent">First Name required</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="TitleTd">Registration No : </td>
                <td>
                    <asp:TextBox ID="txtRegNo" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtRegNo" ErrorMessage="Registration No required" ForeColor="Red" ValidationGroup="vgRegStudent">Registration No required</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="TitleTd">Email : </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email required" ForeColor="Red" ValidationGroup="vgRegStudent">Email required</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="invalid email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="TitleTd">Cell No : </td>
                <td>
                    <ew:NumericBox ID="txtMobile" runat="server" MaxLength="13" PositiveNumber="True" RealNumber="False" />
                    (optional)</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="TitleTd">CGPA :</td>
                <td>
                    <ew:NumericBox ID="txtCgpa" runat="server" MaxLength="4" PositiveNumber="True" TruncateLeadingZeros="True" />
                    (optional)</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </fieldset>
    <fieldset class="FieldSet">
        <legend>Other</legend>
        <table style="width: 100%">
            <%--<tr>
            <td class="TitleTd">Role : </td>
            <td>
                <asp:DropDownList ID="ddlRole" runat="server" DataTextField="Name" DataValueField="Rid" EnableViewState="true">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlRole" ErrorMessage="Please select role" ForeColor="Red" InitialValue="Select Role">*</asp:RequiredFieldValidator>
            </td>
            <td></td>
            <td></td>
        </tr>--%>
            <tr>
                <td class="TitleTd">Department :</td>
                <td>
                    <asp:DropDownList ID="ddlDepartment" runat="server" DataTextField="Name" DataValueField="DId" EnableViewState="true">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlDepartment" ErrorMessage="Please select Department" ForeColor="Red" InitialValue="Select Department" ValidationGroup="vgRegStudent">Please select Department</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="TitleTd">Semester : </td>
                <td>
                    <asp:DropDownList ID="ddlSemester" runat="server" EnableViewState="true">
                        <asp:ListItem>Select Semester</asp:ListItem>
                        <asp:ListItem Value="7">7th</asp:ListItem>
                        <asp:ListItem Value="8">8th</asp:ListItem>
                        <asp:ListItem Value="7">9th</asp:ListItem>
                        <asp:ListItem Value="8">10th</asp:ListItem>
                        <asp:ListItem Value="7">11th</asp:ListItem>
                        <asp:ListItem Value="8">12th</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlSemester" ErrorMessage="Please select semester" ForeColor="Red" InitialValue="Select Semester" ValidationGroup="vgRegStudent">Please select semester</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            
            <tr>
                <td class="TitleTd">Session :</td>
                <td>
                    <asp:DropDownList ID="ddlSession" runat="server" DataTextField="Name" DataValueField="PSId" EnableViewState="true">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlSession" ErrorMessage="Please select Session" ForeColor="Red" InitialValue="Select Session" ValidationGroup="vgRegStudent">Please select Session</asp:RequiredFieldValidator>
                </td>
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
                <asp:Button ID="btnRegisterFaculty" CssClass="btn btn-primaryByMe" runat="server" Text="Register" Width="100px" OnClick="AddStudent" ValidationGroup="vgRegStudent" />
            </td>
        </tr>
        <tr>
            <td class="TitleTd"></td>
            <td></td>
            <td></td>
            <td class="TextAlignRight">&nbsp;</td>
        </tr>
    </table>

</div>
