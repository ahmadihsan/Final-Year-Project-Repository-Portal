<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAddExternal.ascx.cs" Inherits="FYPAutomation.UserControls.Admin.CtrlAddExternal" %>
<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>

    <style type="text/css">
        .auto-style3 {
            width: 89px;
        }
        .auto-style4 {
            width: 252px;
        }
    </style>

    <div class="MessageDiv" >
        <asp:Label runat="server" ID="lblMessage" ClientIDMode="Static"></asp:Label>
    </div>
<div class="FieldSet">
<fieldset class="FieldSet">
    <legend>User Info:</legend>
    <table style="width: 100%">
       
        <tr>
            <td class="TitleTd">Name :</td>
            <td>
                <asp:TextBox ID="txtEName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEName" ErrorMessage="Name required" ForeColor="Red">Name required</asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="TitleTd">Email : </td>
            <td>
                <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtemail" ErrorMessage="Email required" ForeColor="Red" >Email required</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtemail" ErrorMessage="Invalid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
         <tr>
            <td class="TitleTd">CNIC : </td>
            <td>
                <ew:NumericBox ID="txtECnic" runat="server" MaxLength="15" PositiveNumber="True" RealNumber="False" />
                (optional)</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        
        <tr>
            <td class="TitleTd">Mobile : </td>
            <td>
                <ew:NumericBox ID="txtEMobile" runat="server" MaxLength="13" PositiveNumber="True" RealNumber="False" />
                (optional)</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="TitleTd">Office Contact No. : </td>
            <td>
                <ew:NumericBox ID="txtEPhone" runat="server" MaxLength="13" PositiveNumber="True" RealNumber="False" />
                (optional)</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
       <tr>
            <td class="TitleTd">Contact Address : </td>
            <td>
                <asp:TextBox ID="txtEContAdrs" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEContAdrs" ErrorMessage="Please Enter Contact Address" ForeColor="Red" >Please Enter Contact Address</asp:RequiredFieldValidator>
            
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
         <tr>
            <td class="auto-style4">Specializaion : </td>
            <td>
                <asp:TextBox ID="txtESpecial" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtESpecial" ErrorMessage="Please Enter Specialization" ForeColor="Red" >Please Enter Specialization</asp:RequiredFieldValidator>
            
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</fieldset>
<fieldset class="FieldSet">
    <legend>Other</legend>
    <table style="width: 100%">
        <tr>
            <td class="auto-style4">Role : </td>
            <td>
                <asp:DropDownList ID="ddlRole" runat="server" DataTextField="Name" DataValueField="Rid" EnableViewState="true" style="margin-left: 2px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlRole" ErrorMessage="Please select role" ForeColor="Red" InitialValue="Select Role">Please select role</asp:RequiredFieldValidator>
            </td>
            <td></td>
            <td></td>
        </tr>
         <tr>
            <td class="auto-style4">Designation : </td>
            <td>
                <asp:DropDownList ID="ddlDesignation" runat="server" DataTextField="Key" DataValueField="Key" EnableViewState="true">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlDesignation" ErrorMessage="Please select Designation" ForeColor="Red" InitialValue="Select Designation" >Please select Designation</asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
         
        <tr>
            <td class="auto-style4">Department :</td>
            <td>
                <asp:DropDownList ID="ddlDep" runat="server" DataTextField="Name" DataValueField="DId"  EnableViewState="true">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlDep" ErrorMessage="Please select depratment" ForeColor="Red" InitialValue="Select Department" >Please select depratment</asp:RequiredFieldValidator>
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
            <td class="auto-style4">Status : </td>
            <td>
                <asp:RadioButtonList ID="rbStatus" runat="server" RepeatDirection="Horizontal" CssClass="RadioButtons" RepeatLayout="Flow">
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
            <td class="auto-style3"></td>
            <td class="TextAlignRight">
                <asp:Button ID="btnRegisterExternal" CssClass="btn btn-primaryByMe" runat="server" Text="Register" Width="100px" OnClick="btnRegisterExternal_Click" />
            </td>
        </tr>
       
    </table>

</div>