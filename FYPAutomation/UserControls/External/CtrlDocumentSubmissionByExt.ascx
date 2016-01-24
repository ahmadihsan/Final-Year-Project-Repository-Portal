<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlDocumentSubmissionByExt.ascx.cs" Inherits="FYPAutomation.UserControls.General.CtrlDocumentSubmissionByExt" %>
<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Assign Document From Admin : </legend>
        <div id="Search" style="float: right">
           
            <div class="ButtonNavigations">
                <label>
                    <asp:TextBox runat="server" ID="txtSearchByProjectName" placeholder="Search by Project Name" />
                </label>
            </div>
            <div class="ButtonNavigations">
                <asp:Button ID="Button1" runat="server" CssClass="mybtn_Search" OnClick="Button1_Click" />
            </div>
        </div>
        <table style="width: 100%">
            <tr>
                <td>
                    <asp:GridView ID="GvdViewAllDocs" runat="server" AutoGenerateColumns="False" ForeColor="#333333" Style="width: 100%; margin: 0 auto;" ShowHeaderWhenEmpty="True" CssClass="mytable" PageSize="35" AllowPaging="True" EmptyDataText="No data found" GridLines="None" DataKeyNames="ProjectId,UMSId,FromPC,FromStudent,ReadStatus,InCustody,UMSDId,PMSId,Tiltle,MileStoneName" OnSelectedIndexChanged="GvdViewAllDocs_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="MilestoneName" HeaderText="Milestone" ReadOnly="True" SortExpression="Name" />
                            <asp:BoundField DataField="Tiltle" HeaderText="Project Name" ReadOnly="True" SortExpression="Tiltle" />
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%#FYPDAL.FrequentAccesses.DocumentCheckedOrNot(Convert.ToInt32(Eval("ReadStatus"))) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Download File">
                                <ItemTemplate>
                                    <asp:HyperLink ID="LinkButton1" runat="server" NavigateUrl='<%# string.Format("{0}{1}",ConfigurationManager.AppSettings["AllUploadsUrl"],Eval("UploadedFile"))%>' Text="Download" Enabled='<%#!FYPDAL.FrequentAccesses.GetBooleanFrom10(Convert.ToInt32(Eval("EvalStatus")))%>'>
                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                        <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                     <asp:HyperLink ID="lnkView" runat="server" NavigateUrl='<%# string.Format("{0}{1}",ConfigurationManager.AppSettings["AllUploadsUrl"],Eval("UploadedFile"))%>' Text="View" Enabled='<%#!FYPDAL.FrequentAccesses.GetBooleanFrom10(Convert.ToInt32(Eval("EvalStatus")))%>'>
                                    </asp:HyperLink>
                                   </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Upload Document" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkUploadDoc" runat="server" CausesValidation="False" CommandName="Select" Text="Upload File" Enabled='<%#!FYPDAL.FrequentAccesses.GetBooleanFrom10(Convert.ToInt32(Eval("ReadStatus")))%>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <PagerStyle CssClass="paginationClass span" HorizontalAlign="Center"></PagerStyle>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </fieldset>
</div>

<div id="UploadDoc" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="width: 690px">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
        <h5 id="myModalLabel">Upload Document</h5>
    </div>
    <div class="modal-body">
        <div class="FieldSet">
            <fieldset class="FieldSet">
                <legend>Upload Checked Documets : </legend>
                <table class="mytable" style="width: 100%">
                    <tr>
                        <td>MileStone Name:</td>
                        <td>
                            <asp:Label runat="server" ID="lblMilestoneName"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 125px">Project Name:</td>
                        <td>
                            <asp:Label runat="server" ID="lblProjectName"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td>Document Status:</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtStatusComment" TextMode="MultiLine" Width="350px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtStatusComment" ErrorMessage="Please select Status" ForeColor="Red"  ValidationGroup="vgRegisterFac">Comment required</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>Upload File:</td>
                        <td>
                            <ajaxToolkit:AjaxFileUpload ID="asyUploadFile" runat="server" OnUploadComplete="asyUploadFile_UploadComplete" AllowedFileTypes="docx,doc,pdf,xlsx,xls,ppt,pptx" />
                        </td>
                    </tr>


                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnSumbitDocByExt" runat="server" Text="Submit Document" OnClientClick="return ConfirmMe()" OnClick="btnSumbitDocByExt_Click" CssClass="btn btn-primaryByMe" ValidationGroup="vgRegisterFac" /></td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </div>
    <div class="modal-footer">
        <button class="btn btn-primary" data-dismiss="modal" aria-hidden="true">Close</button>
    </div>
</div>

<script type="text/javascript">
    function ConfirmMe() {
        if (Page_ClientValidate())
            return confirm('Are you sure that you have selected the correct milestone and files ?');

        return false;
    }
</script>