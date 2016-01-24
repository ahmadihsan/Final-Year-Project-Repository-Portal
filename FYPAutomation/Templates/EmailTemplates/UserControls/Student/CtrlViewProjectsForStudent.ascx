<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlViewProjectsForStudent.ascx.cs" Inherits="FYPAutomation.UserControls.CtrlViewProjectsForStudent" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>List of Projects</legend>
       <asp:ListView ID="lstProjects" runat="server" ItemPlaceholderID="plItems">
                    <LayoutTemplate>
                        <table style="width: 100%" class="mytable">
                            <tbody>
                                <asp:PlaceHolder runat="server" ID="plItems"></asp:PlaceHolder>
                            </tbody>
                            </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <th>
                                <asp:Label ID="lblTitle" runat="server" Text='<%# Bind("Tiltle") %>'></asp:Label>
                        </th>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description").ToString().Substring(0, 500)%>'>
                                </asp:Label>
                                <asp:HyperLink runat="server" Text="More Detail" ID="lnkMoreDetail" NavigateUrl='<%# string.Format("~/Pages/Student/ProjectDetail?PId={0}",Eval("PId"))%>' Visible='<%# Eval("Description").ToString().Length>500 ? true: false %>'></asp:HyperLink>       
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold;color: #005580">Status :<asp:Label ID="lblStatus" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetStatusByValue(Convert.ToInt16(Eval("Status"))) %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Proposed By :
                                 <asp:HyperLink runat="server" Text='<%# Bind("Name") %>' ID="lnkProposedBy" NavigateUrl='<%# string.Format("~/Pages/Student/UserProfile.aspx?UId={0}",Eval("ProposedBy"))%>'></asp:HyperLink>     
                              </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <th style="background-color: #dae2e8">
                                <asp:Label ID="lblTitle" runat="server" Text='<%# Bind("Tiltle") %>'></asp:Label>
                        </th>
                        <tr>
                            <td style="background-color: #edf6fd">
                                <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description").ToString().Substring(0, 400)%>'>
                                </asp:Label>
                                 <asp:HyperLink runat="server" Text="More Detail" ID="lnkMoreDetail" NavigateUrl='<%# string.Format("~/Pages/Student/ProjectDetail?PId={0}",Eval("PId"))%>' Visible='<%# Eval("Description").ToString().Length>400 ? true: false %>'></asp:HyperLink>       
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold;color: #005580">Status :<asp:Label ID="lblStatus" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetStatusByValue(Convert.ToInt16(Eval("Status"))) %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="background-color:  #edf6fd">Proposed By :
                                 <asp:HyperLink runat="server" Text='<%# Bind("Name") %>' ID="lnkProposedBy" NavigateUrl='<%# string.Format("~/Pages/Student/UserProfile.aspx?UId={0}",Eval("ProposedBy"))%>'></asp:HyperLink>     
                               
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                </asp:ListView>
         
    </fieldset>

</div>
