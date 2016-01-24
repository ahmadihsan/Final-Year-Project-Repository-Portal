<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAddDeadLine.ascx.cs" Inherits="FYPAutomation.UserControls.CtrlAddDeadLine" %>


<div class="MessageDiv">
    <asp:Label runat="server" ID="lblMessage" ClientIDMode="Static"></asp:Label>
</div>
<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Add new deadline:</legend>
        <table style="width: 100%" class="mytable">
            <tr>
                <td>Select Session:</td>
                <td>
                    <asp:DropDownList ID="ddlSession" runat="server" DataTextField="Name" DataValueField="PSId"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlSession" ErrorMessage="Please select Session" ForeColor="Red" InitialValue="Select Session" ValidationGroup="vgRegisterFac">Please select Session</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Select MileStone:</td>
                <td>
                    <asp:DropDownList ID="ddlMileStone" runat="server" DataTextField="Name" DataValueField="PMSId"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlMileStone" ErrorMessage="Please select MileStone" ForeColor="Red" InitialValue="Select MileStone" ValidationGroup="vgRegisterFac">Please select MileStone</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Select Deadline:</td>
                <td>
                    <asp:TextBox runat="server" ID="cldCalender" CssClass="datepick" ClientIDMode="Static" CausesValidation="True" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cldCalender" ErrorMessage="Please select Date" ForeColor="Red" ValidationGroup="vgRegisterFac">Please select Date</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Select Time:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtTimeSpan" CssClass="timepic" ClientIDMode="Static" Width="68px" CausesValidation="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTimeSpan" ErrorMessage="Please select Time" ForeColor="Red" ValidationGroup="vgRegisterFac">Please select Time</asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td>Description:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtDescription" ClientIDMode="Static" TextMode="MultiLine" Width="400px" Height="120px" CausesValidation="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDescription" ErrorMessage="Please Enter some description" ForeColor="Red" ValidationGroup="vgRegisterFac">Please Enter some description</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAddDeadLine" runat="server" Text="Add DeadLine" OnClick="AddDeadLineClick" CssClass="btn btn-primaryByMe" ValidationGroup="vgRegisterFac" /></td>
                <td></td>
            </tr>

        </table>
    </fieldset>
</div>


