<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlDocumentSubmitted.ascx.cs" Inherits="FYPAutomation.UserControls.Admin.CtrlDocumentSubmitted" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Milestone Document : </legend>
        <table style="width: 100%" class="mytable">
            <tr>
                <td>
                    <div class="ButtonNavigations">
                        <label>
                            <asp:Button runat="server" ID="Button3" OnClick="FwdStudentClick" CssClass="btn btn-primaryByMe" ToolTip="Forward to student" Text="Forward to Students" />
                        </label>
                    </div>
                    <div class="ButtonNavigations">
                        <label>
                            <asp:Button runat="server" ID="Button4" OnClick="FwdPcMemberClick" CssClass="btn btn-primaryByMe" ToolTip="Forward to PC" ValidationGroup="vgr" Text="Forward to PC Member" />
                        </label>
                    </div>
                    <div id="divv" style="float: right">
                        <div class="ButtonNavigations">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlPCMember" DataTextField="Name" DataValueField="UId" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlPCMember" ForeColor="Red" InitialValue="Select PCMember" ValidationGroup="vgr">Please Select PC Member</asp:RequiredFieldValidator>
                            </label>
                        </div>
                    </div>
                    <%--                    <div class="clearall"></div>
                    --%>
                </td>
            </tr>
            <tr>
                <td>
                    <div id="Search" style="float: right">
                        <div class="ButtonNavigations">
                            <label>
                                <asp:TextBox runat="server" ID="txtSearchByProjectName" placeholder="Search by Project Name" />
                                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSearchByProjectName" ServiceMethod="SearchProjectsByTitle" ServicePath="~/Services/AjaxBased.asmx" CompletionListCssClass="uliExtender" CompletionInterval="100" EnableCaching="False" MinimumPrefixLength="2"></ajaxToolkit:AutoCompleteExtender>
                            </label>
                        </div>
                        <div class="ButtonNavigations">
                            <asp:Button ID="Button1" runat="server" CssClass="mybtn_Search" OnClick="BtnSearchClicked" />
                        </div>
                    </div>
                    <div class="ButtonNavigations">
                        <label>
                            <asp:DropDownList runat="server" ID="ddlSession" DataTextField="Name" DataValueField="PSId" AutoPostBack="True" OnSelectedIndexChanged="DdlSessionSelectedIndexChanged" />
                        </label>
                    </div>
                    <div class="ButtonNavigations">
                        <label>
                            <asp:DropDownList runat="server" ID="ddlMileStones" DataTextField="Name" DataValueField="PMSId" AutoPostBack="True" OnSelectedIndexChanged="DdlMileStonesSelectedIndexChanged" />
                        </label>
                    </div>
                    <div class="ButtonNavigations">
                        <label>
                            <asp:DropDownList runat="server" ID="ddlEval" ClientIDMode="Static" onchange="DdlEvalSelectedIndexChanged(this)">
                                <asp:ListItem>--Select--</asp:ListItem>
                                <asp:ListItem>Evaluated</asp:ListItem>
                                <asp:ListItem>Not Evaluated</asp:ListItem>
                        </asp:DropDownList>
                        </label>
                    </div>
                </td>
            </tr>
        </table>

        <table style="width: 100%">
            <tr>
                <td>
                    <asp:GridView ID="GvdViewAllDocs" runat="server" AutoGenerateColumns="False" ForeColor="#333333" Style="width: 100%; margin: 0 auto;" ShowHeaderWhenEmpty="True" CssClass="mytable"  EmptyDataText="No data found" GridLines="None" OnRowDataBound="GvdViewDocumentSumbittedRowDataBound" DataKeyNames="ProjectId,UMSId,UMSDId,FromPC,FromStudent,ReadStatus,InCustody" OnRowCommand="GvdViewAllDocsRowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="cboxHeaderSelect" runat="server" AutoPostBack="True" OnCheckedChanged="HeaderCheckBoxChecked" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="cboxSelect" runat="server"></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="MilestoneName" HeaderText="Milestone" ReadOnly="True" SortExpression="Name" />
                            <asp:BoundField DataField="Tiltle" HeaderText="Project Name" ReadOnly="True" SortExpression="Tiltle" />

                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%#FYPDAL.FrequentAccesses.DocumentCheckedOrNot(Convert.ToInt32(Eval("EvalStatus"))) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="In Custody" SortExpression="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblGetCustodian" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetCustodianOfDocument(Convert.ToInt64(Eval("UMSDId")),Convert.ToInt64(Eval("ProjectId"))) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Download File">
                                <ItemTemplate>
                                    <%--<asp:HyperLink ID="LinkButton1" runat="server" NavigateUrl='<%# string.Format("{0}{1}",ConfigurationManager.AppSettings["AllUploadsUrl"],Eval("UploadedFile"))%>' Text="Download" Enabled='<%#FYPDAL.FrequentAccesses.IsCustodian(Convert.ToInt64(Eval("UMSDId")),FYPUtilities.FYPSession.GetLoggedUser().UserId) %>'>
                                    </asp:HyperLink>--%>
                                    <asp:HyperLink ID="LinkButton1" runat="server" NavigateUrl='<%# string.Format("{0}{1}",ConfigurationManager.AppSettings["AllUploadsUrl"],Eval("UploadedFile"))%>' Text="Download">
                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="History" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkUploadHistory" runat="server" CausesValidation="False" CommandName="Select" Text="History"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Detail" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkUploadDoc" runat="server" CausesValidation="False" CommandName="Detail" Text="Detail"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
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
</div>


<div id="DocHistory" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="width: 720px">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
        <h5 id="myModalLabel">Document Routing</h5>
    </div>
    <div class="modal-body">
        <div class="FieldSet">
            <fieldset class="FieldSet">
                <legend>DDocument History : </legend>
                <table class="mytable" style="width: 100%">
                    <tr>
                        <td>
                            <asp:GridView ID="gvdViewHistory" runat="server" AutoGenerateColumns="False" ForeColor="#333333" Style="width: 100%; margin: 0 auto;" ShowHeaderWhenEmpty="True" CssClass="mytable" EmptyDataText="No data found" DataKeyNames="ProjectId,UMSId,FromPC,FromStudent,ReadStatus,InCustody">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="MileStoneName" HeaderText="Mile Stone " />
                                    <asp:BoundField DataField="Tiltle" HeaderText="Project Name" />
                                    <asp:BoundField DataField="Name" HeaderText="Submitted By" />
                                    <asp:TemplateField HeaderText="In Custody" SortExpression="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGetCustodian" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetCustodianOfDocumentHistory(Convert.ToInt64(Eval("InCustody"))) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="CustodianDate" HeaderText="Submission Date" ReadOnly="True" SortExpression="Submission Date" DataFormatString="{0:D}" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </div>
    <div class="modal-footer">
        <button class="btn btn-primary" data-dismiss="modal" aria-hidden="true">Close</button>
    </div>
</div>

<div id="DocDetail" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="width: 720px">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
        <h5 id="H1">Document Routing</h5>
    </div>
    <div class="modal-body">
        <div class="FieldSet">
            <fieldset class="FieldSet">
                <legend>Document Detail : </legend>
                <table class="mytable" style="width: 100%">
                    <tr>
                        <td>
                            <asp:DetailsView ID="dtvDocDetail" runat="server" Height="50px" Width="100%" AutoGenerateRows="False" OnDataBound="DtvDocDetailDataBound">
                                <Fields>
                                    <asp:BoundField DataField="MileStoneName" HeaderText="Milestone" />
                                    <asp:BoundField DataField="Tiltle" HeaderText="Project" />
                                    <asp:TemplateField HeaderText="Group Members">
                                        <ItemTemplate>
                                            <asp:GridView ID="gdvStudents" runat="server" AutoGenerateColumns="False" BorderStyle="None" GridLines="None" ShowHeader="False" CssClass="gridWithNoBorder">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="StudentName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStudents" runat="server" Text='<%# string.Format("{0}",Eval("Name").ToString()) %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="SubmittedDate" HeaderText="Submission Date" DataFormatString="{0:D}" />
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%#FYPDAL.FrequentAccesses.DocumentCheckedOrNot(Convert.ToInt32(Eval("EvalStatus"))) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Comment">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtCommentStatus" runat="server" Text='<%# Bind("StatusComment") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("StatusComment") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="In Custody">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGetCusDv" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetCustodianOfDocument(Convert.ToInt64(Eval("UMSDId")),Convert.ToInt64(Eval("ProjectId"))) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Download File">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="LinkButton1" runat="server" NavigateUrl='<%# string.Format("{0}{1}",ConfigurationManager.AppSettings["AllUploadsUrl"],Eval("UploadedFile"))%>' Text="Download" Enabled='<%#FYPDAL.FrequentAccesses.IsCustodian(Convert.ToInt64(Eval("UMSDId")),FYPUtilities.FYPSession.GetLoggedUser().UserId) %>'>
                                            </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Fields>

                            </asp:DetailsView>
                        </td>
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
    function DdlEvalSelectedIndexChanged(selectedValue) {
        console.log(selectedValue);
        var val = selectedValue.options[selectedValue.selectedIndex].value;
        console.log("ddlvalue = " + val);
        if (val.toLowerCase() == "evaluated") {
            $('.evaluated').css("display", "table-row");
            $('.notevaluated').css("display","none");
        }
        else if (val.toLowerCase() == "not evaluated") {
            $('.notevaluated').css("display", "table-row");
            $('.evaluated').css("display", "none");
        } else {
            $('.evaluated').css("display", "table-row");
            $('.notevaluated').css("display", "table-row");
        }
    }
</script>