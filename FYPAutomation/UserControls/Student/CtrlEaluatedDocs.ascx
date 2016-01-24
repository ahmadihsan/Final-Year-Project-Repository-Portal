<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlEaluatedDocs.ascx.cs" Inherits="FYPAutomation.UserControls.Student.CtrlEaluatedDocs" %>
<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>Evaluated Documents:</legend>
       <%-- <asp:GridView ID="GridViewEvalDoc" Style="width: 100%; margin: 0 auto;" runat="server" BackColor="White" AutoGenerateColumns="false" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" DataKeyNames="PMSId,UMSId,UMSDVId" Height="167px" Width="790px"  CssClass="mytable">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="MileStone" ReadOnly="True" SortExpression="Name" />
                <asp:TemplateField HeaderText="Download File">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnkDownDoc" runat="server" NavigateUrl='<%# string.Format("{0}{1}",ConfigurationManager.AppSettings["AllUploadsUrl"],Eval("UploadedFile"))%>' Text="Download">
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>--%>
        <asp:GridView ID="GvdViewAllDocs" runat="server" AutoGenerateColumns="False" ForeColor="#333333" Style="width: 100%; margin: 0 auto;" ShowHeaderWhenEmpty="True" CssClass="mytable" EmptyDataText="No data found" GridLines="None" PageSize="7" AllowPaging="True" >
            <Columns>
                <asp:TemplateField HeaderText="S.No" ItemStyle-Width="5%">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="5%"></ItemStyle>
                </asp:TemplateField>
                <asp:BoundField DataField="Name" HeaderText="MileStone" ReadOnly="True" SortExpression="Name" />
                <asp:TemplateField HeaderText="Download File">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnkDownDoc" runat="server" NavigateUrl='<%# string.Format("{0}{1}",ConfigurationManager.AppSettings["AllUploadsUrl"],Eval("UploadedFile"))%>' Text="Download">
                        </asp:HyperLink>
                    </ItemTemplate>
                    </asp:TemplateField>
            </Columns>
            <PagerStyle CssClass="paginationClass span" HorizontalAlign="Center"></PagerStyle>
        </asp:GridView>

    </fieldset>
</div>

 