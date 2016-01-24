<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlWeeklySchedule.ascx.cs" Inherits="FYPAutomation.UserControls.General.CtrlWeeklySchedule" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Weekly Schedule : </legend>
        <table style="width: 100%" class="mytable">
            <%--<tr>
                <td>Select Announcment :</td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlAnnouncment" DataTextField="Title" DataValueField="AnnId" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlAnnouncment" ErrorMessage="Please select Announcment" ForeColor="Red" InitialValue="Select Announcment" ValidationGroup="vgRegisterFac">Please Select Announcment</asp:RequiredFieldValidator>
                </td>
            </tr>--%>            <%--<tr>
                <td>Select Day :</td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlDay">
                        <asp:ListItem>Select Day</asp:ListItem>
                        <asp:ListItem>Monday</asp:ListItem>
                        <asp:ListItem>Tuesday</asp:ListItem>
                        <asp:ListItem>Wednesday</asp:ListItem>
                        <asp:ListItem>Thursday</asp:ListItem>
                        <asp:ListItem>Friday</asp:ListItem>
                        <asp:ListItem>Saturday</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlDay" ErrorMessage="Please select Day" ForeColor="Red" InitialValue="Select Announcment" ValidationGroup="vgRegisterFac">Please select Day</asp:RequiredFieldValidator>
                </td>
            </tr>--%>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlDays" runat="server">
                        <asp:ListItem Value="Select Day">Select Day</asp:ListItem>
                        <asp:ListItem Value="1">Monday</asp:ListItem>
                        <asp:ListItem Value="2">Tuesday</asp:ListItem>
                        <asp:ListItem Value="3">Wednsday</asp:ListItem>
                        <asp:ListItem Value="4">Thursday</asp:ListItem>
                        <asp:ListItem Value="5">Friday</asp:ListItem>
                        <asp:ListItem Value="6">Saturday</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ID="rfdays" ControlToValidate="ddlDays" Text="Please Select Day" ForeColor="Red" InitialValue="Select Day" ValidationGroup="vgsubmit"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:CheckBoxList ID="cblTimeSlot" runat="server" RepeatDirection="Horizontal" DataTextField="time" DataValueField="TSId" Font-Bold="True" Font-Size="Large">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnAddSchedule" runat="server" Text="Submit" OnClick="AddScheduleClicked" CssClass="btn btn-primaryByMe" ValidationGroup="vgsubmit"  ClientIDMode="Static" /></td>
            </tr>
            <tr style="color: grey">
                <td colspan="2" style="background-color: #808080;height: 20px"><h4>Note:</h4><p>Please select your free slots of the week</p></td>
            </tr>
            <tr>
                <td><h5>slot 1 :</h5></td>
                <td colspan="2">8:30AM   <b>to</b>   10:00AM</td>
            </tr>
            <tr>
                <td><h5>slot 2 :</h5></td>
                <td colspan="2">10:00AM   <b>to</b>   11:30AM</td>
            </tr>
            <tr>
                <td><h5>slot 3 :</h5></td>
                <td colspan="2">11:30AM   <b>to</b>   1:00PM</td>
            </tr>
            <tr>
                <td><h5>slot 4 :</h5></td>
                <td colspan="2">1:00PM   <b>to</b>   2:30PM</td>
            </tr>
            <tr>
                <td><h5>slot 5 :</h5></td>
                <td colspan="2">2:30PM   <b>to</b>   4:00PM</td>
            </tr>
            <tr>
                <td><h5>slot 6 :</h5></td>
                <td colspan="2">4:00PM   <b>to</b>   5:30PM</td>
            </tr>
        </table>
    </fieldset>
</div>


<script type="text/javascript">
    <!--http://forums.asp.net/t/1846958.aspx?Required+field+validator+checkboxlist-->
        
    function ValidateModuleList(source, args) {
        var chkListModules = document.getElementById('<%= cblTimeSlot.ClientID %>');
        var chkListinputs = chkListModules.getElementsByTagName("input");
        for (var i = 0; i < chkListinputs.length; i++) {
            if (chkListinputs[i].checked) {
                args.IsValid = true;
                return;
            }
        }
        args.IsValid = false;
    }
</script>
