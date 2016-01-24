﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlUserProfileStudent.ascx.cs" Inherits="FYPAutomation.UserControls.Student.CtrlUserProfileStudent" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>User Profile</legend>

        <asp:FormView ID="FVFacProfile" runat="server" DataKeyNames="UId" OnItemUpdating="FvFacProfileItemUpdating" OnModeChanging="FvFacProfileModeChanging" OnDataBound="FvFacProfileDataBound" Visible="False" RenderOuterTable="False">
            <ItemTemplate>
                <table style="width: 100%" class="mytable">

                    <tr>
                        <td>Name:</td>
                        <td>
                            <asp:Label ID="NameLabel" runat="server" Text='<%# Bind("Name") %>' /></td>
                        <td rowspan="20" valign="top">
                            <asp:Image ID="imgFaculty" runat="server" ImageUrl='<%# string.Format("{0}/{1}",UploadImageUrl,Eval("UploadImage")) %>' Width="150px" Height="150px" />
                        </td>

                    </tr>

                    <tr>
                        <td>Email:</td>
                        <td>
                            <asp:Label ID="EmailLabel" runat="server" Text='<%# Bind("Email") %>' /></td>

                    </tr>


                    <tr>
                        <td>Designation:</td>
                        <td>
                            <asp:Label ID="DesignationLabel" runat="server" Text='<%# Bind("Designation") %>' /></td>
                    </tr>


                    <tr>
                        <td>CiitExtension:</td>
                        <td>
                            <asp:Label ID="CiitExtensionLabel" runat="server" Text='<%# Bind("CiitExtension") %>' /></td>
                    </tr>

                    <tr>
                        <td>MobileNumber:</td>
                        <td>
                            <asp:Label ID="MobileNumberLabel" runat="server" Text='<%# Bind("MobileNumber") %>' /></td>
                    </tr>

                    <tr>
                        <td>Research Group:</td>
                        <td>
                            <asp:Label ID="ResearchIdLabel" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetResearchGroupById(Convert.ToInt32(Eval("ResearchId"))) %>' /></td>
                    </tr>

                    <tr>
                        <td>Department:</td>
                        <td>
                            <asp:Label ID="DepartmentIdLabel" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetDepartmentNameById(Convert.ToInt32(Eval("DepartmentId"))) %>' /></td>
                    </tr>

                    <tr>
                        <td>Role:</td>
                        <td>
                            <asp:Label ID="RoleIdLabel" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetRoleNameById(Convert.ToInt32(Eval("RoleId"))) %>' /></td>
                    </tr>



                    <tr>
                        <td>Status:</td>
                        <td>
                            <asp:Label ID="StatusLabel" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetUserStatusById(Convert.ToBoolean(Eval("Status"))) %>' /></td>
                    </tr>

                    <tr>
                        <td colspan="2">
                            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
                        </td>
                    </tr>

                </table>
            </ItemTemplate>
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
                        <td>Email:</td>
                        <td>
                            <asp:TextBox ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="EmailTextBox" ErrorMessage="Email required" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="EmailTextBox" ErrorMessage="invalid email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                        </td>
                        <td rowspan="20" valign="top">
                            <asp:Image ID="imgFaculty" runat="server" ImageUrl='<%# Bind("UploadImage") %>' Width="150px" />
                            <ajaxToolkit:AsyncFileUpload ID="AsFImageFaculty" runat="server" OnUploadedComplete="AsFImageFacultyUploadedComplete" Width="150px" UploadingBackColor="#CCFFFF" />
                        </td>
                    </tr>


                    <tr>
                        <td>CiitExtension:</td>
                        <td>
                            <ew:numericbox id="txtExt" runat="server" maxlength="13" text='<%#Bind("CiitExtension") %>' />
                            (optional)

                        </td>
                    </tr>

                    <tr>
                        <td>MobileNumber:</td>
                        <td>
                            <ew:numericbox id="txtMobile" runat="server" maxlength="13" text='<%#Bind("MobileNumber") %>' />
                            (optional)</td>
                    </tr>

                    <tr>
                        <td>Designation:</td>
                        <td>
                            <asp:DropDownList ID="ddlDesignation" runat="server" ItemType="FYPDAL.KeyValue" DataTextField="Key" DataValueField="Value" SelectMethod="GetDesignationStatuses" OnDataBound="BoundDesignation">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlDesignation" ErrorMessage="Please select Designation" ForeColor="Red" InitialValue="Select Designation">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>Research Group:</td>
                        <td>
                            <asp:DropDownList ID="ddlResearchGroup" runat="server" SelectMethod="GetResearchGroups" ItemType="FYPDAL.ResearchGroup" DataTextField="Title" DataValueField="ResearchId" OnDataBound="BoundResearchGroup" />
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlResearchGroup" ErrorMessage="Please select Research Group" ForeColor="Red" InitialValue="Select Research Group">*</asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2">
                            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" /></td>
                    </tr>
                </table>
            </EditItemTemplate>
        </asp:FormView>

        <%-- ===========================Student========================= porfile--%>
        <asp:FormView ID="FVStudent" runat="server" DataKeyNames="UId" OnItemUpdating="FvStudentProfileItemUpdating" OnModeChanging="FvStudentProfileModeChanging" OnDataBound="FvStudentProfileDataBound" Visible="False" RenderOuterTable="False">
            <ItemTemplate>
                <table style="width: 100%" class="mytable">

                    <tr>
                        <td>Name:</td>
                        <td>
                            <asp:Label ID="NameLabel" runat="server" Text='<%# Bind("Name") %>' /></td>
                        <td rowspan="20" valign="top">
                            <asp:Image ID="imgFaculty" runat="server" ImageUrl='<%# string.Format("{0}/{1}",UploadImageUrl,Eval("UploadImage")) %>' />
                        </td>

                    </tr>

                    <tr>
                        <td>Email:</td>
                        <td>
                            <asp:Label ID="EmailLabel" runat="server" Text='<%# Bind("Email") %>' /></td>
                    </tr>


                    <tr>
                        <td>Registration Number:</td>
                        <td>
                            <asp:Label ID="RegNoLabel" runat="server" Text='<%# Bind("RegistrationNo") %>' /></td>
                    </tr>


                    <tr>
                        <td>MobileNumber:</td>
                        <td>
                            <asp:Label ID="MobileNumberLabel" runat="server" Text='<%# Bind("MobileNumber") %>' /></td>
                    </tr>



                    <tr>
                        <td>Semester:</td>
                        <td>
                            <asp:Label ID="SemesterLabel" runat="server" Text='<%# FYPDAL.FrequentAccesses.GethSemesterString(Convert.ToInt32(Eval("Semester"))) %>' /></td>
                    </tr>

                    <tr>
                        <td>Department:</td>
                        <td>
                            <asp:Label ID="DepartmentIdLabel" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetDepartmentNameById(Convert.ToInt32(Eval("DepartmentId"))) %>' /></td>
                    </tr>

                    <tr>
                        <td>CGPA:</td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Cgpa") %>' /></td>
                    </tr>


                    <tr>
                        <td>Role:</td>
                        <td>
                            <asp:Label ID="RoleIdLabel" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetRoleNameById(Convert.ToInt32(Eval("RoleId"))) %>' /></td>
                    </tr>



                    <tr>
                        <td>Status:</td>
                        <td>
                            <asp:Label ID="StatusLabel" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetUserStatusById(Convert.ToBoolean(Eval("Status"))) %>' /></td>
                    </tr>

                    <tr>
                        <td colspan="2">
                            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
                        </td>
                    </tr>

                </table>
            </ItemTemplate>
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
                            <asp:TextBox ID="RegistrationNoTextBox" runat="server" Text='<%# Bind("RegistrationNo") %>' /><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="RegistrationNoTextBox" ErrorMessage="Registration Number required" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td rowspan="20" valign="top">
                            <asp:Image ID="imgFaculty" runat="server" ImageUrl='<%# string.Format("{0}/{1}",UploadImageUrl,Eval("UploadImage")) %>' />
                            <ajaxToolkit:AsyncFileUpload ID="AsFImageFaculty" runat="server" OnUploadedComplete="AsFImageFacultyUploadedComplete" Width="150px" UploadingBackColor="#CCFFFF" />
                        </td>
                    </tr>

                    <tr>
                        <td>Email:</td>
                        <td>
                            <asp:TextBox ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="EmailTextBox" ErrorMessage="Email required" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="EmailTextBox" ErrorMessage="invalid email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                        </td>

                    </tr>

                    <tr>
                        <td>CGPA:</td>
                        <td>
                            <ew:numericbox id="txtCgpa" runat="server" maxlength="4" text='<%#Bind("Cgpa") %>' />
                        </td>
                    </tr>


                    <tr>
                        <td>MobileNumber:</td>
                        <td>
                            <ew:numericbox id="txtMobile" runat="server" maxlength="13" text='<%#Bind("MobileNumber") %>' />
                            (optional)</td>
                    </tr>


                    <tr>
                        <td colspan="2">
                            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" /></td>
                    </tr>
                </table>
            </EditItemTemplate>
        </asp:FormView>

    </fieldset>
</div>
