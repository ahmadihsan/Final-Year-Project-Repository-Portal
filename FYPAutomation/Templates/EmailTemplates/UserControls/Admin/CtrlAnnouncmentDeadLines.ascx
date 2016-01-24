<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAnnouncmentDeadLines.ascx.cs" Inherits="FYPAutomation.UserControls.Admin.CtrlAnnouncmentDeadLines" %>
<%@ Register Src="~/UserControls/Admin/CtrlAddDeadLine.ascx" TagPrefix="uc1" TagName="CtrlAddDeadLine" %>

<div class="MessageDiv">
    <asp:Label runat="server" ID="lblMessage" ClientIDMode="Static"></asp:Label>
</div>
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
                                <asp:DropDownList runat="server" ID="ddlDropDown" />
                            </label>
                        </div>
                        <div class="ButtonNavigations">
                            <label>
                                <asp:TextBox runat="server" ID="txtSearch" ToolTip="Search DeadLines"></asp:TextBox>
                                <asp:Button runat="server" ID="BtnSearch" OnClick="BtnSearchClicked" CssClass="mybtn_Search" />
                            </label>
                        </div>
                    </div>
                    <div class="clearall"></div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GvdDeadline" runat="server" AutoGenerateColumns="False" Width="98%" CssClass="mytable" DataKeyNames="PMSDId,PMSId,PSId" OnRowCommand="GvdDeadlineRowCommand">
                        <Columns>

                            <asp:TemplateField HeaderText="Ttile">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlMileStoneGrid" runat="server" DataTextField="Name" DataValueField="PMSId" ItemType="FYPDAL.ProjectMileStone">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlMileStoneGrid" ErrorMessage="Please select depratment" ForeColor="Red" InitialValue="Select MileStone" ValidationGroup="vgRegisterFac">*</asp:RequiredFieldValidator>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("mileStoneName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DeadLine">
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" ID="cldCalender" CssClass="datepick" ClientIDMode="Static" Text='<%# Bind("DeadLine", "{0:F}") %>'>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cldCalender" ErrorMessage="Please select Date" ForeColor="Red" InitialValue="Select DeadLine" ValidationGroup="vgRegisterFac">*</asp:RequiredFieldValidator>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblDeadLine" runat="server" Text='<%# Bind("DeadLine", "{0:F}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Session">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlSessionGrid" runat="server" DataTextField="Name" DataValueField="PSId" ItemType="FYPDAL.ProjectSession">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlSessionGrid" ErrorMessage="Please select depratment" ForeColor="Red" InitialValue="Select MileStone" ValidationGroup="vgRegisterFac">*</asp:RequiredFieldValidator>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("sessName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbEdit" CommandName="EditRow" ForeColor="#8C4510" runat="server">Edit</asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="lbUpdate" CommandName="UpdateRow" ForeColor="#8C4510" runat="server">Update</asp:LinkButton>
                                    <asp:LinkButton ID="lbCancel" CommandName="CancelUpdate" ForeColor="#8C4510" runat="server" CausesValidation="false">Cancel</asp:LinkButton>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbDelete" CommandName="DeleteRow" ForeColor="#8C4510" runat="server" CausesValidation="false">Delete</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>

    </fieldset>


    <div id="AddDeadLine" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
            <h5 id="myModalLabel">Add New Deadline</h5>
        </div>
        <div class="modal-body">
            <uc1:CtrlAddDeadLine runat="server" ID="CtrlAddDeadLine" />
        </div>
        <div class="modal-footer">
            <button class="btn btn-primary" data-dismiss="modal" aria-hidden="true">Close</button>
        </div>
    </div>



</div>
