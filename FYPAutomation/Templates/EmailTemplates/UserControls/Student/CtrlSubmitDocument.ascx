<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlSubmitDocument.ascx.cs" Inherits="FYPAutomation.UserControls.Student.CtrlSubmitDocument" %>


<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Sumbit Dcument:</legend>
        <table style="width: 100%">
            <tr>
                <td>Select MileStone:</td>
                <td>
                    <asp:DropDownList ID="ddlMileStone" runat="server" DataTextField="Name" DataValueField="PMSId"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlMileStone" ErrorMessage="Please select MileStone" ForeColor="Red" InitialValue="Select MileStone" ValidationGroup="vgRegisterFac">Please select MileStone</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Attach File:</td>
                <td><ajaxToolkit:AsyncFileUpload ID="asyUploadDoc" runat="server" OnUploadedComplete="AsyUploadDocUploadedComplete" /></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnAddDeadLine" runat="server" Text="Submit Document" OnClick="SumbitDocClick" CssClass="btn btn-primaryByMe" ValidationGroup="vgRegisterFac" OnClientClick="alert('Are you sure! Once submitted, this document cant be changed again')"/></td>
            </tr>
        </table>
    </fieldset>
</div>
