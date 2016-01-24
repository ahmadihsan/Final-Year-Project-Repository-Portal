<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlEvaluatePresentationPC.ascx.cs" Inherits="FYPAutomation.UserControls.PCMember.CtrlEvaluatePresentationPC" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Selection Criteria for Evaluation : </legend>
        <table class="mytable" style="width: 100%">
            <tr>
                <td>
                    <asp:DropDownList ID="ddlEvalType" runat="server"></asp:DropDownList>
                    <div id="Search" style="float: right">
                        <asp:Panel runat="server" ID="Panel1" DefaultButton="btnSearch" CssClass="ButtonNavigations">
                            <div class="ButtonNavigations">
                                <label>
                                    <label>
                                        <asp:TextBox runat="server" ID="txtByProjectName" PlaceHolder="Search by Project Name" />
                                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtByProjectName" ServiceMethod="SearchProjectsByTitle" ServicePath="~/Services/AjaxBased.asmx" CompletionListCssClass="uliExtender" CompletionInterval="100" EnableCaching="False" MinimumPrefixLength="2"></ajaxToolkit:AutoCompleteExtender>
                                    </label>
                                </label>
                            </div>
                            <div class="ButtonNavigations">
                                <asp:Button ID="btnSearch" runat="server" CssClass="mybtn_Search" OnClick="btnSearch_Click" />
                            </div>
                        </asp:Panel>
                    </div>
            </tr>
            <asp:HiddenField ID="hfEvaludateClicked" runat="server" Visible="False" />
        </table>



        <asp:GridView ID="GvdViewAllDocs" runat="server" AutoGenerateColumns="False" ForeColor="#333333" Style="width: 100%; margin: 0 auto;" ShowHeaderWhenEmpty="True" CssClass="mytable" EmptyDataText="No data found" GridLines="None" PageSize="35" AllowPaging="True" DataKeyNames="ProjectId,UMSId,FromPC,FromStudent,ReadStatus,InCustody,UMSDId,PMSId,Tiltle,MileStoneName" OnRowDataBound="GvdViewAllDocs_RowDataBound" OnSelectedIndexChanged="GvdViewAllDocs_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField HeaderText="S.No" ItemStyle-Width="5%">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="5%"></ItemStyle>
                </asp:TemplateField>
                <asp:BoundField DataField="Tiltle" HeaderText="Project Name" ReadOnly="True" SortExpression="Tiltle" />
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

                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%#FYPDAL.FrequentAccesses.DocumentCheckedOrNot(Convert.ToInt32(Eval("ReadStatus"))) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="Select" ShowSelectButton="True" />
                <asp:TemplateField HeaderText="Download File">
                    <ItemTemplate>
                        <asp:HyperLink ID="LinkButton1" runat="server" NavigateUrl='<%# string.Format("{0}{1}",ConfigurationManager.AppSettings["AllUploadsUrl"],Eval("UploadedFile"))%>' Text="Download" Enabled='<%#!FYPDAL.FrequentAccesses.GetBooleanFrom10(Convert.ToInt32(Eval("EvalStatus")))%>'>
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerStyle CssClass="paginationClass span" HorizontalAlign="Center"></PagerStyle>
        </asp:GridView>

    </fieldset>
</div>


<div id="PreComments" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="width: 1023px; margin-left: -505px">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
        <h5 id="H1">Evaluate Presentation</h5>
    </div>
    <div class="modal-body">
        <div class="FieldSet">
            <fieldset class="FieldSet">
                <legend>Evaluation : </legend>
                <table class="mytable" style="width: 100%">
                    <tr style="border-top: 1px solid #C1DAD7">
                        <td style="width: 97px">Milestone</td>
                        <td>
                            <asp:DropDownList ID="ddlMileStone" runat="server" DataTextField="Name" DataValueField="PMSId">
                            </asp:DropDownList></td>
                    </tr>
                </table>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlMileStone" ErrorMessage="Please select Milestone" ForeColor="Red" InitialValue="Select MileStone" ValidationGroup="vgRegisterFac">Please select Milestone</asp:RequiredFieldValidator>
                <asp:Table ID="tblStudents" runat="server" CssClass="mytable" Width="100%"></asp:Table>
                <table>
                    <tr>
                        <td>
                            <asp:Button runat="server" ID="SubmitComments" Style="margin: 10px 40px;" OnClick="SubmitComments_Click" Text="Submit" CssClass="btn btn-primaryByMe" ValidationGroup="vgRegisterFac" />
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
