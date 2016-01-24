<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlStudentDetail.ascx.cs" Inherits="FYPAutomation.UserControls.CtrlStudentDetail" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>


<div class="MessageDiv">
    <asp:Label runat="server" ID="lblMessage" ClientIDMode="Static"></asp:Label>
</div>
<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>User Info:</legend>
        <asp:FormView ID="FVStudentDetail" runat="server" OnModeChanging="FvStudentDetailModeChanging" OnDataBound="FvStudentDetailDataBound" OnItemUpdating="FvStudentDetailItemUpdating" RenderOuterTable="False">
            <EditItemTemplate>
                <table style="width: 100%" class="mytable">
                    <tr>
                        <td>Name:</td>
                        <td>
                            <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NameTextBox" ErrorMessage="Name required" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>Registration Number:</td>
                        <td>
                            <asp:TextBox ID="RegistrationNoTextBox" runat="server" Text='<%# Bind("RegistrationNo") %>' />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="RegistrationNoTextBox" ErrorMessage="RegistrationNo required" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>Email:</td>
                        <td>
                            <asp:TextBox ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="EmailTextBox" ErrorMessage="Email required" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="EmailTextBox" ErrorMessage="invalid email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>


                    <tr>
                        <td>MobileNumber:</td>
                        <td>
                            <ew:NumericBox ID="txtMobile" runat="server" MaxLength="13" Text='<%#Bind("MobileNumber") %>' />(optional)</td>
                    </tr>

                    <tr>
                        <td>Semester:</td>
                        <td>
                            <asp:DropDownList ID="ddlSemester" runat="server" DataTextField="Value" DataValueField="Key" ItemType="FYPDAL.KeyValue" OnDataBound="BoundSemester" SelectMethod="GetSemesterList">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlSemester" ErrorMessage="Please select Semester" ForeColor="Red" InitialValue="Select Semester">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>Project Session:</td>
                        <td>
                            <asp:DropDownList ID="ddlPSession" runat="server" DataTextField="Name" DataValueField="PSId" ItemType="FYPDAL.ProjectSession" SelectMethod="GetProjectSessions" OnDataBound="BoundSession">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlPSession" ErrorMessage="Please select Session" ForeColor="Red" InitialValue="Select Session">*</asp:RequiredFieldValidator></td>
                    </tr>


                    <tr>
                        <td>Department:</td>
                        <td>
                            <asp:DropDownList ID="ddlDep" runat="server" SelectMethod="GetDepartments" ItemType="FYPDAL.Department" DataTextField="Name" DataValueField="DId" OnDataBound="BoundDepartments">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlDep" ErrorMessage="Please select role" ForeColor="Red" InitialValue="Select Department">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>Status:</td>
                        <td>
                            <asp:DropDownList ID="ddlStatus" runat="server" SelectMethod="GetUserStatus" ItemType="FYPDAL.KeyValue" DataTextField="Key" DataValueField="Value" OnDataBound="BoundStatus" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlStatus" ErrorMessage="Please select Status" ForeColor="Red" InitialValue="Select Status">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2" style="text-align: right">
                            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" /></td>
                    </tr>
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
                        <td>Registration Number:</td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("RegistrationNo") %>' /></td>
                    </tr>
                    <tr>
                        <td>Email:</td>
                        <td>
                            <asp:Label ID="EmailLabel" runat="server" Text='<%# Bind("Email") %>' /></td>
                    </tr>

                    <tr>
                        <td>MobileNumber:</td>
                        <td>
                            <asp:Label ID="MobileNumberLabel" runat="server" Text='<%# Bind("MobileNumber") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>Semester:</td>
                        <td>
                            <asp:Label ID="SemesterLabel" runat="server" Text='<%# FYPDAL.FrequentAccesses.GethSemesterString(Convert.ToInt32(Eval("Semester"))) %>' />
                        </td>
                    </tr>

                    <tr>
                        <td>Project Session:</td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text='<%#FYPDAL.FrequentAccesses.GetProjectSessionNameById(Convert.ToInt64(Eval("ProjectSessionId")))  %>' /></td>
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
                        <td>CGPA:</td>
                        <td>
                            <asp:Label ID="CgpaLabel" runat="server" Text='<%# Eval("Cgpa") %>' />
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
