<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlMStoneManager.ascx.cs" Inherits="FYPAutomation.UserControls.Admin.CtrlMStoneManager" %>


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
                                Search Here: <asp:DropDownList runat="server" ID="ddlSearchMS" DataTextField="Name" DataValueField="PMSId" OnSelectedIndexChanged="SearchSessionSelectedIndexChanged" ToolTip="Search by MileStone" AutoPostBack="True" />
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
                    <asp:GridView ID="GvdViewSessions" runat="server" AutoGenerateColumns="False" ForeColor="#333333" Style="width: 98%; margin: 0 auto;" ShowHeaderWhenEmpty="True" CssClass="mytable" PageSize="25" AllowPaging="True" DataKeyNames="PMSId,Name,Description" OnPageIndexChanging="GvdViewSessionsPageIndexChanging" OnSelectedIndexChanged="GvdViewSessionsSelectedIndexChanged" OnRowCommand="GvdViewSessionsRowCommand">
                        <Columns>

                            <asp:TemplateField HeaderText="S.No">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MileStone Title">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlSessionTitleGrid" runat="server" DataTextField="Name" DataValueField="PSId" ItemType="FYPDAL.ProjectSession">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%#  Bind("Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                          
                            <asp:CommandField HeaderText="Edit" SelectText="Edit" ShowSelectButton="True" />
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbDelete" CommandName="DeleteRow" ForeColor="#8C4510" runat="server" CausesValidation="false" OnClientClick="return confirm('Do you want to delete Milestone?')">Delete</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </fieldset>


    <div id="AddEditMS" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
            <h5 id="myModalLabel">Add/Edit MileStone</h5>
        </div>
        <div class="modal-body">
            <div class="FieldSet">
                <fieldset class="FieldSet">
                    <legend>Add/Edit MileStone:</legend>
                    <table style="width: 100%">
                        <tr>
                            <td>Name:</td>
                            <td>
                                <asp:TextBox ID="txtSessionName" runat="server" Width="250px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSessionName" ErrorMessage="Title required" ForeColor="Red" ValidationGroup="vgRegSession">Milestone Name Required</asp:RequiredFieldValidator>
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
