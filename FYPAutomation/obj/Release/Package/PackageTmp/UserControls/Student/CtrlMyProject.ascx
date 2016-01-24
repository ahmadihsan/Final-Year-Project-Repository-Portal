<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlMyProject.ascx.cs" Inherits="FYPAutomation.UserControls.Student.CtrlMyProject" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>My Project : </legend>
        <table style="width: 100%" class="mytable">
            <%--<tr>
                <td><h3>Your Project:</h3></td>
                <td><h3><asp:Label id="lblProject" runat="server" Text='<%#FYPDAL.FrequentAccesses.getproj %>'></asp:Label></h3></td>
            </tr>
            <tr>
                <td><h3>Your Supervisor:</h3></td>
                <td><h3><asp:Label ID="lblSupervisor" runat="server" Text='<%#Bind("Name") %>'></asp:Label></h3></td>
            </tr>--%>
            <tr>
                <asp:DetailsView ID="dtvProject" runat="server" Height="50px" Width="100%" CssClass="mytable" AutoGenerateRows="False">
                    <Fields>
                        <asp:TemplateField HeaderText="My Project:">
                            <ItemTemplate>
                                <asp:HyperLink ID="Label2" runat="server" Text='<%#Eval("Tiltle") %>' NavigateUrl='<%#VirtualPathUtility.ToAbsolute("~/Pages/Student/ProjectDetail.aspx?PId="+Eval("PId"))%>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="My Supervisor:">
                            <ItemTemplate>
                                <asp:HyperLink ID="Label2" runat="server" Text='<%# Eval("Name") %>' NavigateUrl='<%#VirtualPathUtility.ToAbsolute("~/Pages/Student/UserMiniProfile.aspx?uid="+Eval("UId"))%>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Fields>

                </asp:DetailsView>
            </tr>
        </table>

    </fieldset>
</div>
