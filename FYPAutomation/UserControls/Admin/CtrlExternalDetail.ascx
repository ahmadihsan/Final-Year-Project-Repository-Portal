<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlExternalDetail.ascx.cs" Inherits="FYPAutomation.UserControls.Admin.CtrlExternalDetail" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<style type="text/css">
    .fontstyle {
       font-weight : normal;
    }
</style>
<div class="MessageDiv" >
    
        <asp:Label runat="server" ID="lblMessage" ClientIDMode="Static" ></asp:Label>
        
                                 
</div>

<div class="MessageDiv">
    <fieldset>
        <legend>Group Info:</legend>
        <table style="width: 100%" class="mytable">
            <tr>
                <td>
                    Group Members:
                </td>
                <td>
                    <asp:Label ID="OtherMembers" CssClass="fontstyle" runat="server"></asp:Label>
                </td>
            </tr>
        
         </table>
    </fieldset>
</div>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>User Info:</legend>
        <asp:FormView ID="FVExternalDetail" runat="server"  OnModeChanging="FVExternalDetail_ModeChanging1" OnDataBound="FVExternalDetail_DataBound1" OnItemUpdating="FVExternalDetail_ItemUpdating1" RenderOuterTable="False">
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

                 <tr><td>CNIC:</td>
                <td><ew:numericbox id="txtcnic" runat="server" MaxLength="13" Text='<%#Bind("E_CNIC") %>'/>(optional)</td></tr>
                
                    <tr><td>Specialization:</td>
                <td><asp:TextBox ID="txtSpecial" runat="server" Text='<%# Bind("E_Specialization") %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtSpecial" ErrorMessage="Specialization required" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td></tr>

                <tr><td>MobileNumber:</td>
                <td><ew:numericbox id="txtMobile" runat="server" MaxLength="13" Text='<%#Bind("MobileNumber") %>'/>(optional)</td></tr>
                
                <tr><td>Office Contact:</td>
                <td><ew:numericbox id="txtExt" runat="server" MaxLength="13" Text='<%#Bind("E_Office") %>'/>(optional)
                </td></tr>
               
                
                    <tr><td>Contact Address:</td>
                <td><asp:TextBox ID="txtContAddres" runat="server" Text='<%# Bind("E_ContactAddresss") %>' />
                    
                </td></tr>

                <%--<tr><td>Department :</td>
                <td><asp:DropDownList ID="ddlDep" runat="server" SelectMethod="GetDepartments" ItemType="FYPDAL.Department" DataTextField="Name" DataValueField="DId" OnDataBound="ddlDep_DataBound">
                </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlDep" ErrorMessage="Please select role" ForeColor="Red" InitialValue="Select Department">Select Department</asp:RequiredFieldValidator>
                </td></tr>

                <tr><td>Role:</td>
                <td><asp:DropDownList ID="ddlRole" runat="server" SelectMethod="GetFacultyRoles" ItemType="FYPDAL.KeyValue" DataTextField="Key" DataValueField="Value" OnDataBound="ddlRole_DataBound">
                </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlRole" ErrorMessage="Please select role" ForeColor="Red" InitialValue="Select Role">Select Role</asp:RequiredFieldValidator>
                </td></tr>--%>

                <tr><td>Status:</td>
                 <td class="TitleTd">Status : </td>
            <td>
                <asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal" CssClass="RadioButtons" RepeatLayout="Flow">
                    <asp:ListItem Text="Enable" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Disable" Value="0"></asp:ListItem>
                </asp:RadioButtonList>
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
                            <td>CNIC:</td>
                            <td>
                                <asp:Label ID="DesignationLabel" runat="server" Text='<%# Bind("E_CNIC")  %>' />
                            </td>
                        </tr>
                    <tr>
                            <td>Specialization:</td>
                            <td>
                                <asp:Label ID="ResearchIdLabel" runat="server" Text='<%# Bind("E_Specialization") %>' />
                            </td>
                        </tr>
                     <tr>
                            <td>MobileNumber:</td>
                            <td>
                                <asp:Label ID="MobileNumberLabel" runat="server" Text='<%# Bind("MobileNumber") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td>Office Contact:</td>
                            <td>
                                <asp:Label ID="CiitExtensionLabel" runat="server" Text='<%# Bind("E_Office") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td>Contact Address:</td>
                            <td>
                                <asp:Label ID="contact" runat="server" Text='<%# Bind("E_ContactAddresss") %>' />
                            </td>
                        </tr>
                       <%-- <tr>
                            <td>Group Members: </td>
                            <td>
                                 <asp:Label ID="OtherMembers" runat="server"></asp:Label>
                               <asp:GridView ID="GridView1" runat="server">
                                   <Columns>
                                         <asp:TemplateField HeaderText="Free Slot" ItemStyle-Width="25%">
                            <ItemTemplate>
                                <asp:GridView runat="server" ID="gvdGroup" CssClass="mytable" EmptyDataText="No Time match exist" DataKeyNames="UId" AutoGenerateColumns="False" ShowHeader="False" Width="240px">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="Name1" runat="server" Text='<%# FYPDAL.SP_GetNamesOfExternalGroupMember_Result(Convert.ToInt32(Eval("UId"))) %>' />
                                                
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FreeTime" />
                                    </Columns>
                                </asp:GridView>
                            </ItemTemplate>

                            <ItemStyle Width="25%"></ItemStyle>
                        </asp:TemplateField>
                                   </Columns>
                                </asp:GridView>

                            </td>
                        </tr>--%>
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
       
    </fieldset>
</div>
