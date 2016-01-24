<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAssignProject.ascx.cs" Inherits="FYPAutomation.UserControls.CtrlAssignProject" %>


<div class="MessageDiv">
    <asp:Label runat="server" ID="lblMessage" ClientIDMode="Static"></asp:Label>
</div>
<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Assign/UnAssign Project:</legend>
        
        <table style="width: 100%" class="mytable">
            <tr>
                <td colspan="2"><b><asp:Label runat="server" ID="lblTitle"></asp:Label></b></td>
            </tr>
            
            <tr>
                <td colspan="2"><asp:Label runat="server" ID="lblDescription"></asp:Label></td>
            </tr>
            
            <tr>
                <td colspan="2"><asp:Label runat="server" ID="lblAssignedOrNot" Visible="False"></asp:Label></td>
            </tr>

            <tr>
                <td colspan="2" runat="server" id="sessionTD">Select Session:<asp:DropDownList ID="ddlSession" runat="server" DataValueField="PSId" DataTextField="Name" OnSelectedIndexChanged="DdlSessionSelectedIndexChanged" AutoPostBack="True"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"  ControlToValidate="ddlSession" ErrorMessage="Please Select Session" ForeColor="Red" InitialValue="Select Session" ValidationGroup="vgRegisterFac">Please Select Session</asp:RequiredFieldValidator></td>
            </tr>
            
            <%--<tr><td colspan="2">--------------------------------------------------------------------------------------------------------------------</td></tr>--%>
        </table>

        <table style="width: 100%">
            
            <asp:GridView ID="GvdViewAllStudent" runat="server" AutoGenerateColumns="False" ForeColor="#333333" GridLines="None"
                Style="width: 100%; margin: 0 auto;" ShowHeaderWhenEmpty="True"
                CssClass="mytable"
                OnSelectedIndexChanged="GvdViewAllStudentSelectedIndexChanged" DataKeyNames="RoleId,UId"
                OnPageIndexChanging="GvdViewAllStudentPageIndexChanging" PageSize="4" AllowPaging="True">
                <Columns>

                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:CheckBox ID="cboxSelection" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name" />
                    <asp:BoundField DataField="RegistrationNo" HeaderText="RegistrationNo" ReadOnly="True" SortExpression="RegistrationNo" />
                    <asp:CommandField ShowSelectButton="True" HeaderText="Detail" SelectText="Detail" />
                    <asp:BoundField DataField="RoleId" HeaderText="RoleId" ReadOnly="True" SortExpression="RoleId" Visible="False" />
                </Columns>
            </asp:GridView>
            
        </table>
        <table style="width: 100%" class="mytable">
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnAssignProject" runat="server" Text="Assign Project" OnClick="AssignProjectClick" CssClass="btn btn-primaryByMe" Visible="False"/>
                    <asp:Button ID="btnUnAssignProject" runat="server" Text="UnAssign Project" OnClick="UnAssignProjectClick" CssClass="btn btn-primaryByMe" Visible="False"/></td>
            </tr>
        </table>
    </fieldset>
</div>
