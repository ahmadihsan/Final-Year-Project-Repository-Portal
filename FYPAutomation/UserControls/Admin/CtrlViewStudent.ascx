<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlViewStudent.ascx.cs" Inherits="FYPAutomation.UserControls.CtrlViewStudent" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>List of Students</legend>

        <table style="width: 100%" class="mytable">
            <tr>
                <td>
                    <div id="Search" style="float: right">
                        <div class="ButtonNavigations">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlSearchBySemester" OnSelectedIndexChanged="StudentSearchBySemesterSelectedIndexChanged" DataTextField="Name" DataValueField="PSId" AutoPostBack="True">
                                    <asp:ListItem>Search By Semester</asp:ListItem>
                                    <asp:ListItem Value="7">7th</asp:ListItem>
                                    <asp:ListItem Value="8">8th</asp:ListItem>
                                    <asp:ListItem Value="9">9th</asp:ListItem>
                                    <asp:ListItem Value="10">10th</asp:ListItem>
                                    <asp:ListItem Value="11">11th</asp:ListItem>
                                    <asp:ListItem Value="12">12th</asp:ListItem>
                                </asp:DropDownList>
                            </label>
                        </div>
                        <div class="ButtonNavigations">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlStudentSearchBySession" OnSelectedIndexChanged="StudentSearchBySessionSelectedIndexChanged" DataTextField="Name" DataValueField="PSId" AutoPostBack="True" />
                            </label>
                        </div>
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
                    <div class="clearall"></div>
                </td>
            </tr>
        </table>
        <%--<table style="width: 100%" class="mytable">--%>
            <tr>
                <td>
                    <asp:GridView ID="GvdViewAllStudent" runat="server" AutoGenerateColumns="False" ForeColor="#333333" Style="width: 100%; margin: 0 auto;" ShowHeaderWhenEmpty="True" CssClass="mytable"  DataKeyNames="RoleId,UId" OnPageIndexChanging="GvdViewAllStudentPageIndexChanging" PageSize="70" AllowPaging="True" EmptyDataText="No data found" GridLines="None" OnRowCommand="GvdViewAllStudentRowCommand">
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name" />
                            <asp:BoundField DataField="RegistrationNo" HeaderText="RegistrationNo" ReadOnly="True" SortExpression="RegistrationNo" />
                            <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" SortExpression="Email" />
                            <asp:BoundField DataField="MobileNumber" HeaderText="MobileNumber" ReadOnly="True" SortExpression="MobileNumber" />
                            <asp:TemplateField HeaderText="Semester" SortExpression="Semester">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# FYPDAL.FrequentAccesses.GethSemesterString(Convert.ToInt32(Eval("Semester"))) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Detail" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Detail" Text="Detail" ForeColor="#8C4510" ></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="RoleId" HeaderText="RoleId" ReadOnly="True" SortExpression="RoleId" Visible="False" />
                            <asp:TemplateField HeaderText="Remove File">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkRemoveFile" CommandName="DeleteRow" ForeColor="#8C4510" runat="server" CausesValidation="false" OnClientClick="return confirm('Do you want to delete this file?')">Remove</asp:LinkButton>
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


