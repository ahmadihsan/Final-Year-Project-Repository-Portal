<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserProfile.ascx.cs" Inherits="FYPAutomation.UserControls.General.UserProfile" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>User Profile</legend>

        <asp:FormView ID="FVExternalProfile" runat="server" DataKeyNames="UId" OnItemUpdating="FVExternalProfile_ItemUpdating" OnModeChanging="FVExternalProfile_ModeChanging" OnDataBound="FVExternalProfile_DataBound" Visible="False" RenderOuterTable="False">
            <ItemTemplate>
                <table style="width: 100%" class="mytable">

                    <tr>
                        <td>Name:</td>
                        <td>
                            <asp:Label ID="NameLabel" runat="server" Text='<%# Bind("Name") %>' /></td>
                        <td rowspan="20" style="vertical-align:top">
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
                        <td>Office Contact:</td>
                        <td>
                            <asp:Label ID="CiitExtensionLabel" runat="server" Text='<%# Bind("E_Office") %>' /></td>
                    </tr>

                    <tr>
                        <td>Mobile Number:</td>
                        <td>
                            <asp:Label ID="MobileNumberLabel" runat="server" Text='<%# Bind("MobileNumber") %>' /></td>
                    </tr>
                     <tr>
                        <td>Contact Address:</td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("E_ContactAddresss") %>' /></td>
                    </tr>
                   
                     <tr>
                        <td>Specialization:</td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("E_Specialization") %>' /></td>
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

                   <%-- <tr>
                        <td colspan="2">
                            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
                        </td>
                    </tr>--%>

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
                        <td rowspan="20" style="vertical-align:top">
                            <asp:Image ID="imgFaculty" runat="server" ImageUrl='<%# Bind("UploadImage") %>' Width="150px" />
                            <ajaxToolkit:AsyncFileUpload ID="AsFImageFaculty" runat="server" ClientIDMode="Static" OnUploadedComplete="AsFImageFaculty_UploadedComplete" Width="150px" UploadingBackColor="#CCFFFF" OnClientUploadError="OnClientError" />
                            <%--<asp:Label runat="server" ID="lblErrorMessage" ClientIDMode="Static"></asp:Label>--%>
                        </td>
                    </tr>
                    

                    <tr>
                        <td>Office Contact:</td>
                        <td>
                            <ew:numericbox id="txtExt" runat="server" maxlength="13" text='<%#Bind("E_Office") %>' />
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
                            <asp:DropDownList ID="ddlDesignation" runat="server" ItemType="FYPDAL.KeyValue" DataTextField="Key" DataValueField="Value" SelectMethod="GetDesignationStatuses" OnDataBound="ddlDesignation_DataBound">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlDesignation" ErrorMessage="Please select Designation" ForeColor="Red" InitialValue="Select Designation">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>

                       <tr>
                        <td colspan="2">
                            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" /></td>
                    </tr>
                    <tr>
                        <td>Specialization:</td>
                        <td>
                            <asp:TextBox ID="txtSpec" runat="server" Text='<%# Bind("E_Specialization") %>' />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSpec" ErrorMessage="Specialization required" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
        </asp:FormView>
        </fieldset>
    </div>