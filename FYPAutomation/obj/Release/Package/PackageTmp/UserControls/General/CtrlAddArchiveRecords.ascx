<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAddArchiveRecords.ascx.cs" Inherits="FYPAutomation.UserControls.Admin.CtrlArchiveRecords" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Archive Record:</legend>
        <table style="width: 100%">

            <tr>
                <td>Select Session:</td>
                <td>
                    <asp:DropDownList ID="ddlSession" runat="server" DataTextField="Name" DataValueField="PSId" AutoPostBack="True" OnSelectedIndexChanged="DdlSessionChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlSession" ErrorMessage="Please select MileStone" ForeColor="Red" InitialValue="Select MileStone" ValidationGroup="vgRegisterFac">Please select Session</asp:RequiredFieldValidator>
                    </td>
            </tr>

            <tr>
                <td>Select Project:</td>
                <td>
                    <asp:DropDownList ID="ddlProjects" runat="server" DataTextField="Tiltle" DataValueField="PId" AutoPostBack="True" Enabled="False"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlProjects" ErrorMessage="Please select MileStone" ForeColor="Red" InitialValue="Select MileStone" ValidationGroup="vgRegisterFac">Please Select Project</asp:RequiredFieldValidator>    
                </td>
            </tr>

           
            
            <tr>
                <td>Description:</td>
                <td><asp:TextBox runat="server" ID="txtComment" TextMode="MultiLine" Width="557px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtComment" ForeColor="Red"  ValidationGroup="vgRegisterFac">Please Write Description</asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td>Upload File:</td>
                <td>
                    <ajaxToolkit:AjaxFileUpload ID="asyUploadFile" runat="server" OnUploadComplete="AsyncDocumentUpload" AllowedFileTypes="zip" />
                    (Note: only zip file allowed)
                </td>
            </tr>


            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnSumbitDoc" runat="server" Text="Submit Document" OnClick="SubmitDocument" CssClass="btn btn-primaryByMe" OnClientClick="return ConfirmMe()" ValidationGroup="vgRegisterFac" /></td>
            </tr>
        </table>


    </fieldset>

   <%-- <fieldset class="FieldSet">
        <legend>Sumbitted Archives:</legend>
        <table style="width: 100%" class="mytable">
            <tr>
                <td>
                    <asp:GridView ID="GvdViewArchiveSumbitted" runat="server" AutoGenerateColumns="False" ForeColor="#333333" Style="width: 100%; margin: 0 auto;" CssClass="mytable" PageSize="35"  GridLines="None"  DataKeyNames="UMSDId">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField="Tiltle" HeaderText="Project Name" ReadOnly="True" SortExpression="Tiltle" />
                            <asp:BoundField DataField="SubmittedDate" HeaderText="Submission Date" ReadOnly="True" SortExpression="RegistrationNo" DataFormatString="{0:D}" />
                            <%--<asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" SortExpression="Email" />--%>
                            <%--<asp:TemplateField HeaderText="Status" SortExpression="Status">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetMsDocumentStatus(Convert.ToInt32(Eval("Status"))) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                           
                            <%--<asp:TemplateField HeaderText="In Custody" SortExpression="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetCustodianOfDocument(Convert.ToInt64(Eval("UMSDId")),Convert.ToInt64(Eval("ProjectId"))) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <%--                            <asp:CommandField ShowSelectButton="True" HeaderText="Detail" SelectText="Detail" />--%>
                           <%-- <asp:BoundField DataField="RoleId" HeaderText="RoleId" ReadOnly="True" SortExpression="RoleId" Visible="False" />
                            <asp:TemplateField HeaderText="Download File">
                                <ItemTemplate>
                                    <asp:HyperLink ID="LinkButton1" runat="server" NavigateUrl='<%# string.Format("{0}{1}",ConfigurationManager.AppSettings["AllUploadsUrl"],Eval("UploadedFile"))%>' Text="Download">
                                    </asp:HyperLink>
                                   
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <%--<asp:TemplateField HeaderText="Remove File">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkRemoveFile" CommandName="DeleteRow" ForeColor="#8C4510" runat="server" CausesValidation="false" OnClientClick="return confirm('Do you want to delete this file?')">Remove</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                     <%--   </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </fieldset--%>

</div>

<script type="text/javascript">
    function ConfirmMe() {
        if (Page_ClientValidate())
            return confirm('Are you sure that you have selected the correct .zip file ?');

        return false;
    }
</script>