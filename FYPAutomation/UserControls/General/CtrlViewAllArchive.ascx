<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlViewAllArchive.ascx.cs" Inherits="FYPAutomation.UserControls.Admin.CtrlViewAllArchive" %>


<fieldset class="FieldSet">
<%--    <td>
        <div class="ButtonNavigations">
                        <label>
                            <asp:Button runat="server" ID="btnAddArchive" OnClick="AddArchiveClick" CssClass="mybtn_add" ToolTip="Add New" />
                            <span>Add New</span>
                        </label>
                    </div>
    </td>--%>
        <legend>Sumbitted Archives:</legend>
        <table style="width: 100%" class="mytable">
            <tr>
                <td>
                    <div id="Search" style="float: right">
                        <div class="ButtonNavigations">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlSession" OnSelectedIndexChanged="ArchiveSearchSelectedIndexChanged" DataTextField="Name" DataValueField="PSId" AutoPostBack="True" />
                            </label>
                        </div>
                        <asp:Panel runat="server" ID="Panel1" DefaultButton="Button1" CssClass="ButtonNavigations">
                            <div class="ButtonNavigations">
                                <label>
                                    <asp:TextBox runat="server" ID="txtByProjectName" PlaceHolder="Search by Project Name" />
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtByProjectName" ServiceMethod="SearchProjectsByTitle" ServicePath="~/Services/AjaxBased.asmx" CompletionListCssClass="uliExtender" CompletionInterval="100" EnableCaching="False" MinimumPrefixLength="2"></ajaxToolkit:AutoCompleteExtender>
                                </label>
                            </div>
                            <div class="ButtonNavigations">
                                <asp:Button ID="Button1" runat="server" CssClass="mybtn_Search" OnClick="BtnProjectSearchClicked" />
                            </div>
                        </asp:Panel>
                        </td>
                </tr>
            <tr>
                <td>
                    <asp:GridView ID="GvdViewProjectArchive" runat="server" AutoGenerateColumns="False" Style="width: 100%; margin: 0 auto;" CssClass="mytable" PageSize="45"  DataKeyNames="pId,PDId" OnRowCommand="GvdViewProjectArchiveRowCommand" >
                        <Columns>
                            <asp:TemplateField HeaderText="S.No">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="Name" HeaderText="Milestone" ReadOnly="True" SortExpression="Milestone" />--%>
                            <asp:BoundField DataField="Tiltle" HeaderText="Project Name" ReadOnly="True" SortExpression="Tiltle" />
                            <asp:BoundField DataField="Name" HeaderText="Project Session" ReadOnly="True" SortExpression="Tiltle" />
                            <asp:BoundField DataField="Description" HeaderText="Description" ReadOnly="True" SortExpression="RegistrationNo" DataFormatString="{0:D}" />
                            <%--<asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" SortExpression="Email" />--%>
                            <%--<asp:TemplateField HeaderText="Status" SortExpression="Status">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetMsDocumentStatus(Convert.ToInt32(Eval("Status"))) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <%--<asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%#FYPDAL.FrequentAccesses.DocumentCheckedOrNot(Convert.ToInt32(Eval("EvalStatus"))) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <%--<asp:TemplateField HeaderText="In Custody" SortExpression="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetCustodianOfDocument(Convert.ToInt64(Eval("UMSDId")),Convert.ToInt64(Eval("ProjectId"))) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <%--                            <asp:CommandField ShowSelectButton="True" HeaderText="Detail" SelectText="Detail" />--%>
                            <asp:BoundField DataField="RoleId" HeaderText="RoleId" ReadOnly="True" SortExpression="RoleId" Visible="False" />
                            <asp:BoundField DataField="PDId" HeaderText="PDId" ReadOnly="True" SortExpression="PDId" Visible="False" />
                            <asp:TemplateField HeaderText="Download File">
                                <ItemTemplate>
                                    <asp:HyperLink ID="LinkButton1" runat="server" NavigateUrl='<%# string.Format("{0}{1}",ConfigurationManager.AppSettings["AllUploadsUrl"],Eval("UploadedFile"))%>' Text="Download">
                                    </asp:HyperLink>
                                   
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PDId" HeaderText="PDId" ReadOnly="True" SortExpression="PDId" Visible="False" />
                            <asp:TemplateField HeaderText="Remove File">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkRemoveFile" CommandName="DeleteRow" ForeColor="#8C4510" runat="server" CausesValidation="false" OnClientClick="return confirm('Do you want to delete this file?')">Remove</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </fieldset>
