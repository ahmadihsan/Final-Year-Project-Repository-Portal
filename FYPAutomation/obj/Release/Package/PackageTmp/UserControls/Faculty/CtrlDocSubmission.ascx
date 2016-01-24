<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlDocSubmission.ascx.cs" Inherits="FYPAutomation.UserControls.Faculty.CtrlDocSubmission" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Sumbit Document:</legend>
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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlProjects" ErrorMessage="Please select MileStone" ForeColor="Red" InitialValue="Select MileStone" ValidationGroup="vgRegisterFac">Please select Projects</asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td>Select MileStone:</td>
                <td>
                    <asp:DropDownList ID="ddlMileStone" runat="server" DataTextField="Name" DataValueField="PMSId" AutoPostBack="True" OnSelectedIndexChanged="DdlMileStoneSelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlMileStone" ErrorMessage="Please select MileStone" ForeColor="Red" InitialValue="Select MileStone" ValidationGroup="vgRegisterFac">Please select MileStone</asp:RequiredFieldValidator></td>
            </tr>

            <tr>
                <td>Comment :</td>
                <td>
                    <asp:TextBox runat="server" ID="txtComment" TextMode="MultiLine" Width="557px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtComment" ForeColor="Red" ValidationGroup="vgRegisterFac">Please Write Comment</asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td>Upload File:</td>
                <td>
                    <ajaxToolkit:AjaxFileUpload ID="asyUploadFile" runat="server" OnUploadComplete="AsyncDocumentUpload" AllowedFileTypes="docx,doc,pdf,xlsx,xls,ppt,pptx" />
                </td>
            </tr>


            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnSumbitDoc" runat="server" Text="Submit Document" OnClick="SubmitDocument" CssClass="btn btn-primaryByMe" OnClientClick="return ConfirmMe()" ValidationGroup="vgRegisterFac" /></td>
            </tr>
        </table>


    </fieldset>

    <fieldset class="FieldSet">
        <legend>Sumbitted Document:</legend>
        <table style="width: 100%" class="mytable">
            <tr>
                <td>
                    <div id="Search" style="float: right">
                        <div class="ButtonNavigations">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlSessionGrid"  DataTextField="Name" DataValueField="PSId" AutoPostBack="True" OnSelectedIndexChanged="SessionGridSelectedIndexChanged" />
                            </label>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GvdViewDocumentSumbitted" runat="server" AutoGenerateColumns="False" ForeColor="#333333" Style="width: 100%; margin: 0 auto;" CssClass="mytable" PageSize="35" GridLines="None" DataKeyNames="UMSDId" OnRowCommand="GvdViewDocumentSubmittedRowCommand" EmptyDataText="No data exists for selected session">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Name" HeaderText="Milestone" ReadOnly="True" SortExpression="Milestone" />
                            <asp:BoundField DataField="Tiltle" HeaderText="Project Name" ReadOnly="True" SortExpression="Tiltle" />
                            <asp:BoundField DataField="SubmittedDate" HeaderText="Submission Date" ReadOnly="True" SortExpression="RegistrationNo" DataFormatString="{0:D}" />
                            <%--<asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" SortExpression="Email" />--%>
                            <%--<asp:TemplateField HeaderText="Status" SortExpression="Status">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetMsDocumentStatus(Convert.ToInt32(Eval("Status"))) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%#FYPDAL.FrequentAccesses.DocumentCheckedOrNot(Convert.ToInt32(Eval("EvalStatus"))) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="In Custody" SortExpression="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetCustodianOfDocument(Convert.ToInt64(Eval("UMSDId")),Convert.ToInt64(Eval("ProjectId"))) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--                            <asp:CommandField ShowSelectButton="True" HeaderText="Detail" SelectText="Detail" />--%>
                            <asp:BoundField DataField="RoleId" HeaderText="RoleId" ReadOnly="True" SortExpression="RoleId" Visible="False" />
                            <asp:TemplateField HeaderText="Download File">
                                <ItemTemplate>
                                    <asp:HyperLink ID="LinkButton1" runat="server" NavigateUrl='<%# string.Format("{0}{1}",ConfigurationManager.AppSettings["AllUploadsUrl"],Eval("UploadedFile"))%>' Text="Download">
                                    </asp:HyperLink>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Remove File">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkRemoveFile" CommandName="DeleteRow" ForeColor="#8C4510" runat="server" CausesValidation="false" OnClientClick="return confirm('Do you want to delete this file?')">Remove</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </fieldset>

</div>

<script type="text/javascript">
    function ConfirmMe() {
        if (Page_ClientValidate())
            return confirm('Are you sure that you have selected the correct milestone and files ?');

        return false;
    }
</script>
