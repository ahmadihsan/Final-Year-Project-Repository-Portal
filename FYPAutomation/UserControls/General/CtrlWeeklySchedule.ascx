<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlWeeklySchedule.ascx.cs" Inherits="FYPAutomation.UserControls.General.CtrlWeeklySchedule" %>

<style type="text/css">
    .auto-style1 {
        width: 111px;
    }
    .auto-style2 {
        width: 281px;
    }
    .auto-style3 {
        width: 51px;
    }
    .auto-style4 {
        width: 145px;
    }
</style>

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
                <td class="auto-style1">
                    <asp:DropDownList ID="ddlDays" runat="server">
                        <asp:ListItem Value="Select Day">Select Day</asp:ListItem>
                        <asp:ListItem Value="1">Monday</asp:ListItem>
                        <asp:ListItem Value="2">Tuesday</asp:ListItem>
                        <asp:ListItem Value="3">Wednsday</asp:ListItem>
                        <asp:ListItem Value="4">Thursday</asp:ListItem>
                        <asp:ListItem Value="5">Friday</asp:ListItem>
                        <asp:ListItem Value="6">Saturday</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:RequiredFieldValidator runat="server" ID="rfdays" ControlToValidate="ddlDays" Text="Please Select Day" ForeColor="Red" InitialValue="Select Day" ValidationGroup="vgsubmit"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style2">
                    
                </td>
            </tr>
            <tr>
                <td class="auto-style1"></td>
                <td class="auto-style2">
                    <asp:Button ID="btnAddSchedule" runat="server" Text="Submit" OnClick="AddScheduleClicked" CssClass="btn btn-primaryByMe" ValidationGroup="vgsubmit"  ClientIDMode="Static" /></td>
                <td></td>
            </tr>
            <tr style="color: grey">
                <td colspan="7" style="background-color: #808080;height: 20px"><h4>Note:</h4><p>Please select your free slots of the week</p></td>
            </tr>
            <tr>
                <td class="auto-style1">
                     <asp:CheckBox ID="selectSlot1" runat="server" width="15px" Height="17px"/>
                </td>
                <td class="auto-style2">
                    <h5>slot 1 :   </h5>
                    <asp:TextBox ID="txtslot1" runat="server"></asp:TextBox>
                </td>
                <td colspan="2" class="auto-style4">8:30AM   <b>to</b>   10:00AM</td>
                <td class="auto-style3">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlDocType" runat="server" DataTextField="Name" DataValueField="PMSId"></asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    <asp:DropDownList ID="ddlEvaluators" runat="server"></asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlProjects" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                     <asp:CheckBox ID="selectSlot2" runat="server" width="15px" Height="17px"/>
                </td>
                <td class="auto-style2"><h5>slot 2 :</h5>
                    <asp:TextBox ID="txtslot2" runat="server"></asp:TextBox>
                </td>
                <td colspan="2" class="auto-style4">10:00AM   <b>to</b>   11:30AM</td>
                <td class="auto-style3">
                    <h4 style="font-family:Calibri; margin-top: 4px; width: 118px; height: 17px; position: absolute; top: 128px; left: 675px; right: 311px;" >Document </h4>
                    <h4 style="font-family:Calibri; margin-top: 4px; width: 118px; height: 17px; position: absolute; top: 128px; left: 675px; right: 311px;" >Document Tpe</h4>
                    <h4 style="font-family:Calibri; margin-top: 4px; width: 118px; height: 17px; position: absolute; top: 129px; left: 808px; right: 178px;" >Evaluators</h4>
                    <h4 style="font-family:Calibri; margin-top: 4px; width: 118px; height: 17px; position: absolute; top: 128px; left: 435px; " >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Time</h4>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlDocType2" runat="server" DataTextField="Name" DataValueField="PMSId"></asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    <asp:DropDownList ID="ddlEvaluators2" runat="server"></asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlProjects2" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                 <td class="auto-style1">
                     <asp:CheckBox ID="selectSlot3" runat="server" width="15px" Height="17px"/>
                </td>
                <td class="auto-style2"><h5>slot 3 :</h5>
                    <asp:TextBox ID="txtslot3" runat="server"></asp:TextBox>
                </td>
                <td colspan="2" class="auto-style4">11:30AM   <b>to</b>   1:00PM</td>
                <td class="auto-style3">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlDcoType3" runat="server" DataTextField="Name" DataValueField="PMSId" OnSelectedIndexChanged="ddlDcoType3_SelectedIndexChanged"></asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                 <td>
                    <asp:DropDownList ID="ddlEvaluators3" runat="server"></asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlProjects3" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                 <td class="auto-style1">
                     <asp:CheckBox ID="selectSlot4" runat="server" width="15px" Height="17px"/>
                </td>
                <td class="auto-style2"><h5>slot 4 :</h5>
                    <asp:TextBox ID="txtslot4" runat="server"></asp:TextBox>
                </td>
                <td colspan="2" class="auto-style4">1:00PM   <b>to</b>   2:30PM</td>
                <td class="auto-style3">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlDocType4" runat="server" DataTextField="Name" DataValueField="PMSId"></asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                 <td>
                    <asp:DropDownList ID="ddlEvaluators4" runat="server"></asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlProjects4" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                     <asp:CheckBox ID="selectSlot5" runat="server" width="15px" Height="17px"/>
                </td>
                <td class="auto-style2"><h5>slot 5 :</h5>
                    <asp:TextBox ID="txtslot5" runat="server"></asp:TextBox>
                </td>
                <td colspan="2" class="auto-style4">2:30PM   <b>to</b>   4:00PM</td>
                <td class="auto-style3">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlDocType5" runat="server" DataTextField="Name" DataValueField="PMSId"></asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                 <td>
                    <asp:DropDownList ID="ddlEvaluators5" runat="server"></asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlProjects5" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                     <asp:CheckBox ID="selectSlot6" runat="server" width="15px" Height="17px"/>
                </td>
                <td class="auto-style2"><h5>slot 6 :</h5>
                    <asp:TextBox ID="txtslot6" runat="server"></asp:TextBox>
                </td>
                <td colspan="2" class="auto-style4">4:00PM   <b>to</b>   5:30PM</td>
                <td class="auto-style3">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlDocType6" runat="server" DataTextField="Name" DataValueField="PMSId"></asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<h4 style="font-family:Calibri; margin-top: 4px; width: 118px; height: 17px; position: absolute; top: 128px; left: 952px; right: 34px;" >Projects</h4>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                 <td>
                    <asp:DropDownList ID="ddlEvaluators6" runat="server" DataTextField="UId" DataValueField="PMSId"></asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlProjects6" runat="server"></asp:DropDownList>
                </td>
            </tr>
        </table>
    </fieldset>
</div>


<script type="text/javascript">
    <!--http://forums.asp.net/t/1846958.aspx?Required+field+validator+checkboxlist-->
        
    <%--function ValidateModuleList(source, args) {
        var chkListModules = document.getElementById('<%= cblTimeSlot.ClientID %>');
        var chkListinputs = chkListModules.getElementsByTagName("input");
        for (var i = 0; i < chkListinputs.length; i++) {
            if (chkListinputs[i].checked) {
                args.IsValid = true;
                return;
            }
        }
        args.IsValid = false;
    }--%>
</script>
