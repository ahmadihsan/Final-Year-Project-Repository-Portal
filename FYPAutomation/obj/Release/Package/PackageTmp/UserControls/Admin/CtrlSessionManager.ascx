<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlSessionManager.ascx.cs" Inherits="FYPAutomation.UserControls.Admin.CtrlSessionManager" %>


<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Session Manager : </legend>
        <table style="width: 100%" class="mytable">
            <tr>
                <td>
                    <div class="ButtonNavigations">
                        <label>
                            <asp:Button runat="server" ID="btnAddSession" OnClick="AddSessionClick" CssClass="mybtn_add" ToolTip="Add New" />
                            <span>Add New</span>
                        </label>
                    </div>
                    <div id="Search" style="float: right">
                        <div class="ButtonNavigations">
                            <label>
                                Search Here: <asp:DropDownList runat="server" ID="ddlSearchSession" DataTextField="Name" DataValueField="PSId" OnSelectedIndexChanged="SearchSessionSelectedIndexChanged" ToolTip="Search by Session" AutoPostBack="True" />
                            </label>
                        </div>
                        <div class="ButtonNavigations">
                        </div>
                    </div>
                    <div class="clearall"></div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GvdViewSessions" runat="server" AutoGenerateColumns="False" ForeColor="#333333" Style="width: 98%; margin: 0 auto;" ShowHeaderWhenEmpty="True" CssClass="mytable" PageSize="25" AllowPaging="True" DataKeyNames="PSId,Name,Description" OnPageIndexChanging="GvdViewSessionsPageIndexChanging" OnSelectedIndexChanged="GvdViewSessionsSelectedIndexChanged">
                        <Columns>

                            <asp:TemplateField HeaderText="S.No">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Session Title">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlSessionTitleGrid" runat="server" DataTextField="Name" DataValueField="PSId" ItemType="FYPDAL.ProjectSession">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%#  Bind("Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <EditItemTemplate>
                                    <asp:RadioButtonList ID="rbSessionStatus" runat="server" SelectedValue='<%# Bind("Status") %>'>
                                    </asp:RadioButtonList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetProjectSessionStatus(Convert.ToBoolean(Eval("Status"))) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Edit" Visible="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbEdit" CommandName="EditRow" ForeColor="#8C4510" runat="server">Edit</asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="lbUpdate" CommandName="UpdateRow" ForeColor="#8C4510" runat="server">Update</asp:LinkButton>
                                    <asp:LinkButton ID="lbCancel" CommandName="CancelUpdate" ForeColor="#8C4510" runat="server" CausesValidation="false">Cancel</asp:LinkButton>
                                </EditItemTemplate>
                            </asp:TemplateField>--%>

                            <asp:CommandField HeaderText="Edit" SelectText="Edit" ShowSelectButton="True" />

                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </fieldset>


    <div id="AddEditSession" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
            <h5 id="myModalLabel">Add/Edit Session</h5>
        </div>
        <div class="modal-body">
            <div class="FieldSet">
                <fieldset class="FieldSet">
                    <legend>Add/Edit FYP Session:</legend>
                    <table style="width: 100%">
                        <tr>
                            <td>Name:</td>
                            <td>
                                <asp:TextBox ID="txtSessionName" runat="server" Width="250px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSessionName" ErrorMessage="Title required" ForeColor="Red" ValidationGroup="vgRegSession">Session Name Required</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Description:</td>
                            <td>
                                <asp:TextBox ID="txtDescription" runat="server" Height="50px" TextMode="MultiLine" Width="250px"></asp:TextBox>(optional)</td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="btnAddEditSession" runat="server" Text="Add Session" CssClass="btn btn-primaryByMe" ValidationGroup="vgRegSession" OnClick="BtnAddEditSession" /></td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </div>
        <div class="modal-footer">
            <button class="btn btn-primary" data-dismiss="modal" aria-hidden="true">Close</button>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hdnPsid"/>
</div>
