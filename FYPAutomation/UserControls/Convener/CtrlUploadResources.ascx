<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlUploadResources.ascx.cs" Inherits="FYPAutomation.UserControls.CtrlUploadResources" %>
<%@ Register Src="~/UserControls/Convener/CtrlUploadResourceDoc.ascx" TagPrefix="uc1" TagName="CtrlUploadResourceDoc" %>


<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Template Documents:</legend>

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
                            <label>Filter:
                                <asp:DropDownList runat="server" ID="ddlSessionSearch" OnSelectedIndexChanged="SessionSearchSelectedIndexChanged" DataTextField="Name" DataValueField="PSId" AutoPostBack="True"/>
                            </label>
                        </div>
                    </div>
                    <div class="clearall"></div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GvdDeadline" runat="server" AutoGenerateColumns="False" Width="98%" CssClass="mytable" DataKeyNames="TDId" OnRowCommand="GvdDeadlineRowCommand" EmptyDataText="No Data found" ShowHeaderWhenEmpty="True">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
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
                            <asp:TemplateField HeaderText="Session">
                                <ItemTemplate>
                                    <asp:Label ID="lblSession" runat="server" Text='<%#FYPDAL.FrequentAccesses.GetProjectSessionNameById(Convert.ToInt64(Eval("PSId"))) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbDelete" CommandName="DeleteRow" ForeColor="#8C4510" runat="server" CausesValidation="false" OnClientClick="return confirm('Do you want to delete the document?')">Delete</asp:LinkButton>
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
            <h5 id="myModalLabel">Add New Resource</h5>
        </div>
        <div class="modal-body">
            <uc1:CtrlUploadResourceDoc runat="server" id="CtrlUploadResourceDoc" />
        </div>
        <div class="modal-footer">
            <button class="btn btn-primary" data-dismiss="modal" aria-hidden="true">Close</button>
        </div>
    </div>



</div>
