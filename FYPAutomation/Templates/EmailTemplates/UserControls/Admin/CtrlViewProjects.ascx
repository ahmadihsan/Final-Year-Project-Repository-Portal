<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlViewProjects.ascx.cs" Inherits="FYPAutomation.UserControls.CtrlViewProjects" %>

<div class="MessageDiv">
    <asp:Label runat="server" ID="lblMessage" ClientIDMode="Static"></asp:Label>
</div>
<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>List of Projects</legend>
       <asp:ListView ID="lstProjects" runat="server" ItemPlaceholderID="plItems" OnPagePropertiesChanging="LstProjectsPagePropertiesChanging" >
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
                                <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description").ToString().Length>500?Eval("Description").ToString().Substring(0, 350):Eval("Description")%>'>
                                </asp:Label>
                                <asp:HyperLink runat="server" Text="More Detail" ID="lnkMoreDetail" NavigateUrl='<%# string.Format("~/Pages/Admin/ProjectDetail?PId={0}",Eval("PId"))%>' Visible='<%# Eval("Description").ToString().Length>500 ? true: false %>'></asp:HyperLink>       
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold;color: #005580">Status :<asp:Label ID="lblStatus" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetStatusByValue(Convert.ToInt16(Eval("Status"))) %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Proposed By :
                                 <asp:HyperLink runat="server" Text='<%# Bind("Name") %>' ID="lnkProposedBy" NavigateUrl='<%# string.Format("~/Pages/Admin/UserProfile.aspx?UId={0}",Eval("ProposedBy"))%>'></asp:HyperLink>
                                <asp:LinkButton runat="server" Text="Cancel" ID="lnkCancel" Visible='<%#FYPUtilities.FYPSession.GetLoggedUser().RoleName.ToLower()=="admin"?true:false%>' OnClick="CancelClick" CommandArgument='<%#Eval("PId") %>' Style="float:right"></asp:LinkButton>
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
                                 <asp:HyperLink runat="server" Text="More Detail" ID="lnkMoreDetail" NavigateUrl='<%# string.Format("~/Pages/Admin/ProjectDetail?PId={0}",Eval("PId"))%>' Visible='<%# Eval("Description").ToString().Length>400 ? true: false %>'></asp:HyperLink>       
                            </td>
                        </tr>
                        
                        <tr>
                                <td style="font-weight: bold;color: #005580;background-color:  #edf6fd">Status :<asp:Label ID="lblStatus" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetStatusByValue(Convert.ToInt16(Eval("Status"))) %>'></asp:Label></td>
                            </tr>
                        <tr>
                            <td style="background-color:  #edf6fd">Proposed By :
                                 <asp:HyperLink runat="server" Text='<%# Bind("Name") %>' ID="lnkProposedBy" NavigateUrl='<%# string.Format("~/Pages/Admin/UserProfile.aspx?UId={0}",Eval("ProposedBy"))%>'></asp:HyperLink>     
                               <asp:LinkButton runat="server" Text="Cancel" ID="lnkCancel" Visible='<%#FYPUtilities.FYPSession.GetLoggedUser().RoleName.ToLower()=="admin"?true:false%>' OnClick="CancelClick" CommandArgument='<%#Eval("PId") %>' Style="float:right"></asp:LinkButton>
                            </td>
                            
                        </tr>
                    </AlternatingItemTemplate>
                </asp:ListView>
         <asp:DataPager ID="dPagerProjects" runat="server" PagedControlID="lstProjects" PageSize="10">
    <Fields>
        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
        <asp:NumericPagerField />
        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
    </Fields>
</asp:DataPager>
    </fieldset>

</div>


