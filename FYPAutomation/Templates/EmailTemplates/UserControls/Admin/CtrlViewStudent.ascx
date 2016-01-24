<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlViewStudent.ascx.cs" Inherits="FYPAutomation.UserControls.CtrlViewStudent" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>List of Students</legend>
        
        <table style="width: 100%" class="mytable">
            <asp:GridView ID="GvdViewAllStudent" runat="server" AutoGenerateColumns="False" ForeColor="#333333" GridLines="None" Style="width: 98%; margin: 0 auto;" ShowHeaderWhenEmpty="True" CssClass="mytable" DataSourceID="EDViewStudent" OnSelectedIndexChanged="GvdViewAllStudentSelectedIndexChanged" DataKeyNames="RoleId,UId" OnPageIndexChanging="GvdViewAllStudentPageIndexChanging" PageSize="25" >
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
                    <asp:CommandField ShowSelectButton="True" HeaderText="Detail" SelectText="Detail" />
                    <asp:BoundField DataField="RoleId" HeaderText="RoleId" ReadOnly="True" SortExpression="RoleId" Visible="False" />
                </Columns>
            </asp:GridView>
            <asp:EntityDataSource ID="EDViewStudent" runat="server" ConnectionString="name=FYPEntities" DefaultContainerName="FYPEntities" EnableFlattening="False" AutoGenerateOrderByClause="True" EntitySetName="Users" Select="it.[UId], it.[Email], it.[MobileNumber], it.[Name], it.[RegistrationNo], it.[Semester], it.[RoleId]" Where="it.[RoleId]=4" EntityTypeFilter="User">
                <WhereParameters>
                    <asp:ControlParameter ControlID="GvdViewAllStudent" Name="RoleId" PropertyName="SelectedValue" DbType="Int64" DefaultValue="" />
                </WhereParameters>
            </asp:EntityDataSource>
        </table>
    </fieldset>
</div>


