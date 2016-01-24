<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAssignProject.ascx.cs" Inherits="FYPAutomation.UserControls.CtrlAssignProject" %>


<div class="MessageDiv">
    <asp:Label runat="server" ID="lblMessage" ClientIDMode="Static"></asp:Label>
</div>
<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Assign/UnAssign Project:</legend>

        <table style="width: 100%" class="mytable">
            <tr>
                <td colspan="2"><b>
                    <asp:Label runat="server" ID="lblTitle"></asp:Label></b></td>
            </tr>

            <tr>
                <td colspan="2">
                    <asp:Label runat="server" ID="lblDescription"></asp:Label></td>
            </tr>

            <tr>
                <td colspan="2">
                    <asp:Label runat="server" ID="lblAssignedOrNot" Visible="False"></asp:Label></td>
            </tr>

            <tr runat="server" id="showrowOfNames">
                <td colspan="2">
                    <asp:Label runat="server" ID="lblShowNames" Visible="False"></asp:Label></td>
            </tr>

            <tr>
                <td runat="server" id="sessionTD">Select Session:<asp:DropDownList ID="ddlSession" runat="server" DataValueField="PSId" DataTextField="Name" OnSelectedIndexChanged="DdlSessionSelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlSession" ErrorMessage="Please Select Session" ForeColor="Red" InitialValue="Select Session" ValidationGroup="vgRegisterFac">Please Select Session</asp:RequiredFieldValidator></td>
                <td>
                    <asp:Button ID="btnAssignProject" runat="server" Text="Assign Project" OnClick="AssignProjectClick" CssClass="btn btn-primaryByMe" Visible="False" /></td>
            </tr>
        </table>
        <%--<table style="width: 100%" class="mytable" runat="server" ID="tblSearchByName">
            <tr>
                <td>
                    <div id="Search" style="float: right">
                       <asp:Panel runat="server" ID="Panel1" DefaultButton="Button1" CssClass="ButtonNavigations">
                            <div class="ButtonNavigations">
                                <label>
                                    <asp:TextBox runat="server" ID="txtSearchByName" placeholder="Search by Name" />
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSearchByName" ServiceMethod="SearchStudentByName" ServicePath="~/Services/AjaxBased.asmx" CompletionListCssClass="uliExtender" CompletionInterval="100" EnableCaching="False" MinimumPrefixLength="2"></ajaxToolkit:AutoCompleteExtender>
                                </label>
                            </div>
                            <div class="ButtonNavigations">
                                <asp:Button ID="Button1" runat="server" CssClass="mybtn_Search" OnClick="BtnSearchClicked" />
                            </div>
                        </asp:Panel>
                    </div>
                </td>
            </tr>
        </table>--%>
        <table style="width: 100%">

            <asp:GridView ID="GvdViewAllStudent" runat="server" AutoGenerateColumns="False" ForeColor="#333333" GridLines="None"
                Style="width: 100%; margin: 0 auto;"
                CssClass="mytable"
                OnSelectedIndexChanged="GvdViewAllStudentSelectedIndexChanged" DataKeyNames="RoleId,UId,Name"
                OnPageIndexChanging="GvdViewAllStudentPageIndexChanging" PageSize="30" AllowPaging="True">
                <Columns>

                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:CheckBox ID="cboxSelection" runat="server" AutoPostBack="True" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name" />
                    <asp:BoundField DataField="RegistrationNo" HeaderText="RegistrationNo" ReadOnly="True" SortExpression="RegistrationNo" />
                    <asp:CommandField ShowSelectButton="True" HeaderText="Detail" SelectText="Detail" />
                    <asp:BoundField DataField="RoleId" HeaderText="RoleId" ReadOnly="True" SortExpression="RoleId" Visible="False" />
                </Columns>
                <PagerStyle CssClass="paginationClass span" HorizontalAlign="Center"></PagerStyle>
            </asp:GridView>

        </table>
        <table style="width: 100%" class="mytable">
            <tr>
                <td colspan="2">
                    <%--<asp:Button ID="btnAssignProject" runat="server" Text="Assign Project" OnClick="AssignProjectClick" CssClass="btn btn-primaryByMe" Visible="False" />--%>
                    <asp:Button ID="btnUnAssignProject" runat="server" Text="UnAssign Project" OnClick="UnAssignProjectClick" CssClass="btn btn-primaryByMe" Visible="False" OnClientClick="return confirm('Do you want to Unassign this project?')"/></td>
            </tr>
        </table>
    </fieldset>
</div>
