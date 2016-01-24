<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPresentationSchedule.ascx.cs" Inherits="FYPAutomation.UserControls.Convener.CtrlPresentationSchedule" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" %>



<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Presentation Schedule: </legend>
        <asp:MultiView ID="mvPresentation" runat="server">
            <asp:View ID="vwTkeParams" runat="server">
                <table style="width: 100%" class="mytable">
                    <tr>
                        <td colspan="2">
                            <h4>Step 1 - Select Parameters</h4>
                        </td>
                    </tr>
                    <tr>
                        <td>Select Session:</td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddlSessionSelection" DataTextField="Name" DataValueField="PSId" />
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="ddlSessionSelection" InitialValue="Select Session" Text="Please Select Session" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Select Milestone:</td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddlMilestoneSelection" DataTextField="Name" DataValueField="PMSId" />
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="ddlMilestoneSelection" InitialValue="Select MileStone" Text="Please Select Milestone" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Select Date:</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtDateSelection" CssClass="datepick" ClientIDMode="Static" AutoPostBack="True" OnTextChanged="PresentationDateTextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="txtDateSelection" Text="Please Select Date" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>No Of Presentations:</td>
                        <td>
                            <ew:NumericBox ID="txtNoPresentation" runat="server">
                            </ew:NumericBox>
                            <asp:RequiredFieldValidator runat="server" ID="rqfitxt" ControlToValidate="txtNoPresentation" Text="Please Enter No Of Presentation" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Duration per Presentations:</td>
                        <td>
                            <ew:NumericBox ID="txtDuration" runat="server" ClientIDMode="AutoID"></ew:NumericBox>(e.g in minutes)
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator6" ControlToValidate="txtDuration" Text="Please Enter duration per Presentation" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: right">
                            <asp:Button ID="btnGoToStep2" runat="server" Text="Next >>" OnClick="BtnGoToStep2Clicked" CssClass="btn btn-primaryByMe" />
                        </td>
                    </tr>

                </table>
            </asp:View>
            <asp:View ID="vwPresent" runat="server">
                <table style="width: 100%" class="mytable">
                    <tr>
                        <td>
                            <h4>Step 2 - Assign Presentation Slots</h4>
                        </td>
                    </tr>
                    
                    <asp:HiddenField ID="hfTime" runat="server" />
                </table>
                <asp:GridView ID="GvdPresentationSchedule" runat="server" AutoGenerateColumns="False" ForeColor="#333333" Style="width: 100%; margin: 0 auto;" ShowHeaderWhenEmpty="True" CssClass="mytable" EmptyDataText="No data found" DataKeyNames="PId" OnRowDataBound="GvdPresentationDataBound" ClientIDMode="AutoID">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="10%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Tiltle" HeaderText="Project" ItemStyle-Width="25%">
                            <ItemStyle Width="25%"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Free Slot" ItemStyle-Width="25%">
                            <ItemTemplate>
                                <asp:GridView runat="server" ID="gvdSuggestedTimes" CssClass="mytable" EmptyDataText="No Time match exist" AutoGenerateColumns="False" ShowHeader="False" Width="240px">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%#FYPDAL.FrequentAccesses.GetStringDayFrom(Convert.ToInt32(Eval("Day"))) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FreeTime" />
                                    </Columns>
                                </asp:GridView>
                            </ItemTemplate>

                            <ItemStyle Width="25%"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Assign Time" ItemStyle-Width="25%">
                            <ItemTemplate>
                                <asp:TextBox ID="txtStartTime" runat="server" CssClass="timepic fromTimetxt" onblur='setTimeTo(this)' Width="68px" ClientIDMode="AutoID"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtStartTime" ID="rfvrom" Text="*" ForeColor="Red" ValidationGroup="vgSubmit"></asp:RequiredFieldValidator>
                                <b>TO</b>
                                &nbsp;
                        <asp:TextBox ID="txtEndTime" runat="server" CssClass="timepic toTimetxt" Width="68px" ClientIDMode="AutoID"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEndTime" ID="RequiredFieldValidator1" Text="*" ForeColor="Red" ValidationGroup="vgSubmit"></asp:RequiredFieldValidator>
                            </ItemTemplate>
                            <ItemStyle Width="25%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Room #" ItemStyle-Width="25%">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlRoom" runat="server" Width="121px"  DataTextField="Title" DataValueField="RoomId"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlRoom" ID="rfvrom11" Text="*" ForeColor="Red" ValidationGroup="vgSubmit"  InitialValue="Select Room"></asp:RequiredFieldValidator>
                            </ItemTemplate>
                            <ItemStyle Width="16%" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:View>
        </asp:MultiView>
        <table class="mytable" style="width: 100%" id="myTableToShow" runat="server">
            <tr>
                <td>
                    <div id="Div1" style="float: right">
                        <div class="ButtonNavigations">
                            <label>
                                <asp:Button ID="btnCheckConflict" runat="server" Text="Check Conflict" CssClass="btn btn-primaryByMe" OnClick="BtnCheckConflictClicked"/>
                            </label>
                        </div>
                        <div class="ButtonNavigations">
                            <label>
                                <asp:Button ID="btnSubmitPres" runat="server" Text="Submit" CssClass="btn btn-primaryByMe" OnClick="BtnSubmitClicked"  ValidationGroup="vgSubmit"/>
                            </label>
                        </div>
                        <div class="ButtonNavigations">
                            <label>
                                <asp:Button ID="Button1" runat="server" Text="Cancel" CssClass="btn btn-primaryByMe" OnClick="BtnCancelClicked" OnClientClick="return  confirm('Are you sure you want to cancel?')" />
                            </label>
                        </div>
                        <asp:ValidationSummary runat="server" ID="vSummery" ShowMessageBox="True" ValidationGroup="vgSubmit"/>
                    </div>
                </td>
            </tr>
        </table>
    </fieldset>
</div>

<script type="text/javascript">

    function setTimeTo(fromElem) {

        var firstElm = "#" + $(fromElem).attr("id");
        var timestr = $(fromElem).val().toString();

        var toadd = parseInt(document.getElementById("<%=hfTime.ClientID%>").value);

        var nex = $(firstElm).parent().children(".toTimetxt");

        if (timestr != '') {
            var valto = ReturnTime(timestr, toadd);
            nex.val(valto);
        }
    }
   


</script>
<style type="text/css">
    .mytable td {
        background: none !important;
    }
</style>

