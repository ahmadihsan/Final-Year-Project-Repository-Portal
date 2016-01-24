<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrtSubmittedDocDetail.ascx.cs" Inherits="FYPAutomation.UserControls.Admin.CtrtSubmittedDocDetail" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>User Info:</legend>
        <asp:FormView ID="FVFacultyDetail" runat="server" OnModeChanging="FvFacultyDetailModeChanging" OnDataBound="FvFacultyDetailDataBound" OnItemUpdating="FvFacultyDetailItemUpdating" RenderOuterTable="False">
            <ItemTemplate>
                <table style="width: 100%" class="mytable">
                    <tr>
                        <td>Project:</td>
                        <td>
                            <asp:Label ID="lblPro" runat="server" Text='<%# Bind("Tiltle") %>' /></td>
                    </tr>
                    <tr>
                        <td>Milestone:</td>
                        <td>
                            <asp:Label ID="lblMileStone" runat="server" Text='<%# Bind("MileStoneName") %>' /></td>
                    </tr>
                    <caption>
                    <tr>
                        <td>Group Members:</td>
                        <td>
                            <%--<asp:Label ID="lblGroupmembers" runat="server" Text='<%# Bind("Designation")  %>' />--%>

                            <asp:GridView ID="gdvStudents" runat="server" AutoGenerateColumns="False" BorderStyle="None" GridLines="None" ShowHeader="False" CssClass="gridWithNoBorder">
                                <Columns>
                                    <asp:TemplateField HeaderText="StudentName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStudents" runat="server" Text='<%# string.Format("{0}",Eval("Name").ToString()) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>Submission Date:</td>
                        <td>
                            <asp:Label ID="lblSubmissionDate" runat="server" Text='<%# Bind("CiitExtension") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Status:</td>
                        <td>
                            <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("MobileNumber") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>In Custody:</td>
                        <td>
                            <asp:Label ID="lblInCustody" runat="server" Text='<%#FYPDAL.FrequentAccesses.GetResearchGroupById(Convert.ToInt32(Eval("ResearchId"))) %>' />
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2" style="text-align: right">
                            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>

        </asp:FormView>
        <%--<asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=FYPEntities" DefaultContainerName="FYPEntities" EnableFlattening="False" EntitySetName="Users" Select="it.[Name], it.[Email], it.[CiitExtension], it.[MobileNumber], it.[Designation], it.[ResearchId], it.[Status], it.[DepartmentId], it.[RoleId]" EnableUpdate="True">
        </asp:EntityDataSource>--%>
    </fieldset>
</div>
