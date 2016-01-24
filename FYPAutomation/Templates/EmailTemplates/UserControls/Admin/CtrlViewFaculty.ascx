<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlViewFaculty.ascx.cs" Inherits="FYPAutomation.UserControls.CtrlViewFaculty" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>List of Faculty</legend>
        
        <table style="width: 100%" class="mytable">
            <asp:GridView ID="GvdViewAllFaculty" runat="server" AutoGenerateColumns="False" ForeColor="#333333" GridLines="None" Style="width: 98%; margin: 0 auto;" ShowHeaderWhenEmpty="True" CssClass="mytable" DataSourceID="EDViewFaculty" OnSelectedIndexChanged="GvdViewAllFacultySelectedIndexChanged" DataKeyNames="RoleId,UId" AllowPaging="True" OnPageIndexChanging="GvdViewAllFacultyPageIndexChanging" PageSize="25">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" SortExpression="Email" />
                <asp:BoundField DataField="Designation" HeaderText="Designation" ReadOnly="True" SortExpression="Designation" />
                <asp:BoundField DataField="MobileNumber" HeaderText="MobileNumber" ReadOnly="True" SortExpression="MobileNumber" />
                <asp:BoundField DataField="CiitExtension" HeaderText="CiitExtension" ReadOnly="True" SortExpression="CiitExtension" />
                <asp:BoundField DataField="RoleId" HeaderText="RoleId" ReadOnly="True" SortExpression="RoleId" Visible="False" />
                <asp:BoundField DataField="ResearchId" HeaderText="ResearchId" ReadOnly="True" SortExpression="ResearchId" Visible="False" />
                <asp:CommandField HeaderText="Detail" SelectText="Detail" ShowSelectButton="True" />
            </Columns>
                <PagerStyle CssClass="paginationClass span" HorizontalAlign="Center"></PagerStyle>
        </asp:GridView>
            <asp:EntityDataSource ID="EDViewFaculty" runat="server" ConnectionString="name=FYPEntities" DefaultContainerName="FYPEntities" EnableFlattening="False" EntitySetName="Users" OrderBy="it.[UId]" Select="it.[UId], it.[Email], it.[MobileNumber], it.[RoleId], it.[Name], it.[CiitExtension], it.[Designation], it.[ResearchId]" Where="it.[RoleId]=1 or it.[RoleId]=2  or it.[RoleId]=3" EntityTypeFilter="User">
                <WhereParameters>
                    <asp:ControlParameter ControlID="GvdViewAllFaculty" Name="RoleId" PropertyName="SelectedValue" DbType="Int64" DefaultValue="" />
                </WhereParameters>
            </asp:EntityDataSource>
        </table>
    </fieldset>
</div>


