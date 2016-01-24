<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlUnassignDocsFromPc.ascx.cs" Inherits="FYPAutomation.UserControls.Admin.CtrlUnassignDocsFromPc" %>


<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Unassign Document From PC Member : </legend>
        <div id="Search" style="float: right">
                        <div class="ButtonNavigations">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlStudentSearchBySession" OnSelectedIndexChanged="SearchSelectedIndexChanged" DataTextField="Name" DataValueField="PSId" AutoPostBack="True" />
                            </label>
                        </div>
                        <div class="ButtonNavigations">
                            <label>
                                <asp:TextBox runat="server" ID="txtSearchByProjectName" placeholder="Search by Project Name" />
                            </label>
                        </div>
                        <div class="ButtonNavigations">
                            <asp:Button ID="Button1" runat="server" CssClass="mybtn_Search" OnClick="BtnSearchClicked" />
                        </div>
                    </div>
        <table style="width: 100%">
            <tr>
                <td>
                    <asp:GridView ID="GvdViewAllDocs" runat="server" AutoGenerateColumns="False" ForeColor="#333333" Style="width: 100%; margin: 0 auto;" ShowHeaderWhenEmpty="True" CssClass="mytable" PageSize="35" AllowPaging="True" EmptyDataText="No data found" GridLines="None" OnRowDataBound="GvdViewDocumentSumbittedRowDataBound" OnPageIndexChanging="GvdViewAllDocsPageIndexChanging" DataKeyNames="ProjectId,UMSId,FromPC,FromStudent,ReadStatus,InCustody">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="cboxSelect" runat="server"></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="MilestoneName" HeaderText="Milestone" ReadOnly="True" SortExpression="Name" />
                    <asp:BoundField DataField="Tiltle" HeaderText="Project Name" ReadOnly="True" SortExpression="Tiltle" />

                    <asp:TemplateField HeaderText="Group Members" SortExpression="Group Members">
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
                    <asp:BoundField DataField="SubmittedDate" HeaderText="Submission Date" ReadOnly="True" SortExpression="Submission Date" DataFormatString="{0:D}" />
                    <asp:TemplateField HeaderText="Status" SortExpression="Status">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetMsDocumentStatus(Convert.ToInt32(Eval("Status"))) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="PC Member" SortExpression="Status">
                        <ItemTemplate>
                            <asp:Label ID="lblGetCustodian" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetCustodianOfDocument(Convert.ToInt64(Eval("UMSDId")),Convert.ToInt64(Eval("ProjectId"))) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="PC Member" SortExpression="Status">
                        <ItemTemplate>
                            <asp:Label ID="lblGetCustodian" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetFacultyById(Convert.ToInt64(Eval("InCustody"))) %>'></asp:Label>
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
