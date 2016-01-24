<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRGManager.ascx.cs" Inherits="FYPAutomation.UserControls.Admin.CtrlRGManager" %>


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
                                Search Here: <asp:TextBox runat="server" ID="txtSearch" ToolTip="Search by Title" />
                            </label>
                        </div>
                        <div class="ButtonNavigations">
                            <asp:Button runat="server" CssClass="mybtn_Search" OnClick="BtnSearchClicked"/>
                        </div>
                    </div>
                    <div class="clearall"></div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GvdViewSessions" runat="server" AutoGenerateColumns="False" ForeColor="#333333" Style="width: 98%; margin: 0 auto;" ShowHeaderWhenEmpty="True" CssClass="mytable" PageSize="25" AllowPaging="True" DataKeyNames="ResearchId,Title,Description" OnPageIndexChanging="GvdViewSessionsPageIndexChanging" OnSelectedIndexChanged="GvdViewSessionsSelectedIndexChanged" OnRowCommand="GvdViewSessionsRowCommand">
                        <Columns>

                            <asp:TemplateField HeaderText="S.No">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ResearchGroup Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%#  Bind("Title") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
<%--                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%#Bind("Description") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>

                            <asp:CommandField HeaderText="Edit" SelectText="Edit" ShowSelectButton="True" />
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


    <div id="AddEditRG" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
            <h5 id="myModalLabel">Add/Edit ResearchGroup</h5>
        </div>
        <div class="modal-body">
            <div class="FieldSet">
                <fieldset class="FieldSet">
                    <legend>Add/Edit Research Group:</legend>
                    <table style="width: 100%">
                        <tr>
                            <td>Name:</td>
                            <td>
                                <asp:TextBox ID="txtRGName" runat="server" Width="250px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRGName" ErrorMessage="Title required" ForeColor="Red" ValidationGroup="vgRegSession">ResearchGroup Name Required</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Description:</td>
                            <td>
                                <asp:TextBox ID="txtRGDescription" runat="server" Height="50px" TextMode="MultiLine" Width="250px"></asp:TextBox>(optional)</td>
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
