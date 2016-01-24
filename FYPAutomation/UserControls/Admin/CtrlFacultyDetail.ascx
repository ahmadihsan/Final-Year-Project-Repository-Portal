<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlFacultyDetail.ascx.cs" Inherits="FYPAutomation.UserControls.CtrlFacultyDetail" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>

<div class="MessageDiv" >
        <asp:Label runat="server" ID="lblMessage" ClientIDMode="Static"></asp:Label>
    </div>
<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>User Info:</legend>
        <asp:FormView ID="FVFacultyDetail" runat="server"  OnModeChanging="FvFacultyDetailModeChanging" OnDataBound="FvFacultyDetailDataBound" OnItemUpdating="FvFacultyDetailItemUpdating" RenderOuterTable="False">
            <EditItemTemplate>
                <table style="width: 100%" class="mytable">
                <tr><td>Name:</td>
                <td><asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NameTextBox" ErrorMessage="Name required" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td></tr>

                <tr><td>Email:</td>
                <td><asp:TextBox ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="EmailTextBox" ErrorMessage="Email required" ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="EmailTextBox" ErrorMessage="invalid email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                </td></tr>

                <tr><td>CiitExtension:</td>
                <td><ew:numericbox id="txtExt" runat="server" MaxLength="13" Text='<%#Bind("CiitExtension") %>'/>(optional)

                </td></tr>

                <tr><td>MobileNumber:</td>
                <td><ew:numericbox id="txtMobile" runat="server" MaxLength="13" Text='<%#Bind("MobileNumber") %>'/>(optional)</td></tr>

                <tr><td>Designation:</td>
                <td><asp:DropDownList ID="ddlDesignation" runat="server" ItemType="FYPDAL.KeyValue" DataTextField="Key" DataValueField="Value" SelectMethod="GetDesignationStatuses" OnDataBound="BoundDesignation">
                </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlDesignation" ErrorMessage="Please select Designation" ForeColor="Red" InitialValue="Select Designation">Select Designation</asp:RequiredFieldValidator>
                </td></tr>

                <tr><td>Research Group:</td>
                <td>
                    <asp:DropDownList ID="ddlResearchGroup" runat="server" SelectMethod="GetResearchGroups" ItemType="FYPDAL.ResearchGroup" DataTextField="Title" DataValueField="ResearchId" OnDataBound="BoundResearchGroup" />(optional)
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlResearchGroup" ErrorMessage="Please select Research Group" ForeColor="Red" InitialValue="Select Research Group">*</asp:RequiredFieldValidator>--%>
                   </td></tr>

                <tr><td>Department :</td>
                <td><asp:DropDownList ID="ddlDep" runat="server" SelectMethod="GetDepartments" ItemType="FYPDAL.Department" DataTextField="Name" DataValueField="DId" OnDataBound="BoundDepartments">
                </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlDep" ErrorMessage="Please select role" ForeColor="Red" InitialValue="Select Department">Select Department</asp:RequiredFieldValidator>
                </td></tr>

                <tr><td>Role:</td>
                <td><asp:DropDownList ID="ddlRole" runat="server" SelectMethod="GetFacultyRoles" ItemType="FYPDAL.KeyValue" DataTextField="Key" DataValueField="Value" OnDataBound="RoleBound">
                </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlRole" ErrorMessage="Please select role" ForeColor="Red" InitialValue="Select Role">Select Role</asp:RequiredFieldValidator>
                </td></tr>

                <tr><td>Status:</td>
                <td><asp:DropDownList ID="ddlStatus" runat="server" SelectMethod="GetUserStatus" ItemType="FYPDAL.KeyValue" DataTextField="Key" DataValueField="Value" OnDataBound="BoundStatus"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlStatus" ErrorMessage="Please select Status" ForeColor="Red" InitialValue="Select Status">Select Status</asp:RequiredFieldValidator>
                </td></tr>

                <tr><td colspan="2" style="text-align: right"><asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" /></td></tr>
                    </table>
            </EditItemTemplate>

            <ItemTemplate>
                <table style="width: 100%" class="mytable">
                    <tr>
                        <td>Name:</td>
                        <td>
                            <asp:Label ID="NameLabel" runat="server" Text='<%# Bind("Name") %>' /></td>
                    </tr>
                    <tr>
                        <td>Email:</td>
                        <td>
                            <asp:Label ID="EmailLabel" runat="server" Text='<%# Bind("Email") %>' /></td>
                    </tr>
                    <caption>
                        <tr>
                            <td>Designation:</td>
                            <td>
                                <asp:Label ID="DesignationLabel" runat="server" Text='<%# Bind("Designation")  %>' />
                            </td>
                        </tr>
                        <tr>
                            <td>CiitExtension:</td>
                            <td>
                                <asp:Label ID="CiitExtensionLabel" runat="server" Text='<%# Bind("CiitExtension") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td>MobileNumber:</td>
                            <td>
                                <asp:Label ID="MobileNumberLabel" runat="server" Text='<%# Bind("MobileNumber") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td>Research Group:</td>
                            <td>
                                <asp:Label ID="ResearchIdLabel" runat="server" Text='<%#FYPDAL.FrequentAccesses.GetResearchGroupById(Convert.ToInt32(Eval("ResearchId"))) %>' />
                            </td>
                        </tr>
                            <tr>
                                <td>Department:</td>
                                <td>
                                    <asp:Label ID="DepartmentIdLabel" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetDepartmentNameById(Convert.ToInt16(Eval("DepartmentId"))) %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>Role:</td>
                                <td>
                                    <asp:Label ID="RoleIdLabel" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetRoleNameById(Convert.ToInt16(Eval("RoleId"))) %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>Status:</td>
                                <td>
                                    <asp:Label ID="StatusLabel" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetUserStatusById(Convert.ToBoolean(Eval("Status"))) %>' />
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
