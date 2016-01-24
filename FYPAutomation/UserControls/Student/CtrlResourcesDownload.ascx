<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlResourcesDownload.ascx.cs" Inherits="FYPAutomation.UserControls.General.CtrlResourcesDownload" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Template Documents:</legend>

        <table style="width: 100%" class="mytable">
<%--            <tr>
                <td>
                    <div class="ButtonNavigations">
                        <label>
                            <asp:Button runat="server" ID="btnAddDeadLine" OnClick="AddDedLineClick" CssClass="mybtn_add" ToolTip="Add New" />
                            <span>Add New</span>
                        </label>
                    </div>
                    <div class="clearall"></div>
                </td>
            </tr>--%>
            <tr>
                <td>
                    <asp:GridView ID="GvdDeadline" runat="server" AutoGenerateColumns="False" Width="98%" CssClass="mytable" DataKeyNames="TDId"  AllowPaging="True"  PageSize="25" EmptyDataText="No Data found" ShowHeaderWhenEmpty="True">
                        <Columns>

                            <asp:TemplateField HeaderText="Ttile">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Download">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hlDownload" runat="server" Text="Download" NavigateUrl='<%#string.Format("{0}{1}",ConfigurationManager.AppSettings["AllUploadsUrl"],Eval("UploadedFile")) %>'></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbDelete" CommandName="DeleteRow" ForeColor="#8C4510" runat="server" CausesValidation="false">Delete</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>

    </fieldset>
</div>
