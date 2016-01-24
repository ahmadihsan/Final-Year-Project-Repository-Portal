<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAnnouncmentDeadLines.ascx.cs" Inherits="FYPAutomation.UserControls.Admin.CtrlAnnouncmentDeadLines" %>
<%@ Register Src="~/UserControls/Admin/CtrlAddDeadLine.ascx" TagPrefix="uc1" TagName="CtrlAddDeadLine" %>


<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Announcments:</legend>

        <table style="width: 100%" class="mytable">
            <tr>
                <td>
                    <div class="ButtonNavigations">
                        <label>
                            <asp:Button runat="server" ID="btnAddDeadLine" OnClick="AddDedLineClick" CssClass="mybtn_add" ToolTip="Add New" />
                            <span>Add New</span>
                        </label>
                    </div>
                    <div id="Search" style="float: right">
                        <div class="ButtonNavigations">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlMileStoneSearch" OnSelectedIndexChanged="MileStoneSearchSelectedIndexChanged" DataTextField="Name" DataValueField="PMSId" AutoPostBack="True" />
                            </label>
                        </div>
                        <div class="ButtonNavigations">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlSessionSearch" OnSelectedIndexChanged="SessionSearchSelectedIndexChanged" DataTextField="Name" DataValueField="PSId" AutoPostBack="True" />
                            </label>
                        </div>
                    </div>
                    <div class="clearall"></div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GvdDeadline" runat="server" AutoGenerateColumns="False" Width="98%" CssClass="mytable" DataKeyNames="PMSDId,PMSId,PSId" OnRowCommand="GvdDeadlineRowCommand" AllowPaging="True" OnPageIndexChanging="GvdDeadlinePageIndexChanging" PageSize="25">
                        <Columns>

                            <asp:TemplateField HeaderText="Ttile">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("mileStoneName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DeadLine">
                                <ItemTemplate>
                                    <asp:Label ID="lblDeadLine" runat="server" Text='<%# Bind("DeadLine", "{0:dddd, MMMM d, yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Session">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("sessName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbEdit" CommandName="EditRow" ForeColor="#8C4510" runat="server">Edit</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbDelete" CommandName="DeleteRow" ForeColor="#8C4510" runat="server" CausesValidation="false" OnClientClick="return confirm('Do you want to delete deadline?')">Delete</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Detail">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbDetail" CommandName="DetailRow" ForeColor="#8C4510" runat="server" CausesValidation="false">Detail</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>

    </fieldset>


    <div id="AddDeadLine" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="width: 590px">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
            <h5 id="myModalLabel">Add New Deadline</h5>
        </div>
        <div class="modal-body" style="height: 580px">
            <uc1:CtrlAddDeadLine runat="server" ID="CtrlAddDeadLine" />
        </div>
        <div class="modal-footer">
            <button class="btn btn-primary" data-dismiss="modal" aria-hidden="true">Close</button>
        </div>
    </div>

    <div id="EditDeadLine" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="width: 590px">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
            <h5 id="H1">Edit Deadline Detail</h5>
        </div>
        <div class="modal-body" style="height: 580px">
            <table style="width: 100%">
                <tr>
                    <td>Select Session:</td>
                    <td>
                        <asp:DropDownList ID="ddlSession11" runat="server" DataTextField="Name" DataValueField="PSId"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlSession11" ErrorMessage="Please select Session" ForeColor="Red" InitialValue="Select Session" ValidationGroup="updateDeadLine">Please select Session</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Select MileStone:</td>
                    <td>
                        <asp:DropDownList ID="ddlMileStone11" runat="server" DataTextField="Name" DataValueField="PMSId"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlMileStone11" ErrorMessage="Please select MileStone" ForeColor="Red" InitialValue="Select MileStone" ValidationGroup="updateDeadLine">Please select MileStone</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td>Select Deadline:</td>
                    <td>
                        <asp:TextBox runat="server" ID="cldCalender11" CssClass="datepick" ClientIDMode="Static"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cldCalender11" ErrorMessage="Please select Date" ForeColor="Red" ValidationGroup="updateDeadLine">Please select Date</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Select Time:</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtTimeSpan11" CssClass="timepic" ClientIDMode="Static" Width="68px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTimeSpan11" ErrorMessage="Please select Time" ForeColor="Red" ValidationGroup="updateDeadLine">Please select Time</asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>Description:</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtDescription11" ClientIDMode="Static" TextMode="MultiLine" Width="400px" Height="120px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDescription11" ErrorMessage="Please Enter some description" ForeColor="Red" ValidationGroup="updateDeadLine">Please Enter some description</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Update" OnClick="UpdateDeadLineClick" CssClass="btn btn-primaryByMe" ValidationGroup="updateDeadLine" /></td>
                    <td>
                        <asp:Button ID="Button2" runat="server" Text="Cancel" OnClick="CancelDeadLineClick" CssClass="btn btn-primaryByMe" /></td>
                </tr>

            </table>
        </div>
        <div class="modal-footer">
            <button class="btn btn-primary" data-dismiss="modal" aria-hidden="true">Close</button>
        </div>
    </div>


    <div id="DetailDeadLine" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="width: 590px">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
            <h5 id="H2">Deadline Detail</h5>
        </div>
        <div class="modal-body">
            <table style="width: 100%" class="mytable">
                <tr runat="server" id="lbll">
                    <td>Session:</td>
                    <td>
                        <asp:Label runat="server" ID="lblSession"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>MileStone:</td>
                    <td>
                        <asp:Label runat="server" ID="lblMilestone"></asp:Label></td>
                </tr>
                <tr>
                    <td>Deadline:</td>
                    <td>
                        <asp:Label runat="server" ID="lblDeadline"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>Description:</td>
                    <td>
                        <asp:Label runat="server" ID="lblDescr"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="modal-footer">
            <button class="btn btn-primary" data-dismiss="modal" aria-hidden="true">Close</button>
        </div>
    </div>

</div>




