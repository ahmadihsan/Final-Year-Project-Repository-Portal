<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewProjects.ascx.cs" Inherits="FYPAutomation.UserControls.General.ViewProjects" %>
<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>List of Projects</legend>
        <table style="width: 100%" class="mytable">
            <tr>
                <td>
                    <div id="Search" style="float: right">
                        <div class="ButtonNavigations">
                            <label>
                                <asp:DropDownList runat="server" ID="ddlSession" OnSelectedIndexChanged="ddlSession_SelectedIndexChanged" DataTextField="Name" DataValueField="PSId" AutoPostBack="True"/>
                            </label>
                        </div>
                        <asp:Panel runat="server" ID="Panel1" DefaultButton="Button1" CssClass="ButtonNavigations">
                            <div class="ButtonNavigations">
                                <label>
                                    <asp:TextBox runat="server" ID="txtByProjectName" PlaceHolder="Search by Project Name" />
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtByProjectName" ServiceMethod="SearchProjectsByTitle" ServicePath="~/Services/AjaxBased.asmx" CompletionListCssClass="uliExtender" CompletionInterval="100" EnableCaching="False" MinimumPrefixLength="2"></ajaxToolkit:AutoCompleteExtender>
                                </label>
                            </div>
                            <div class="ButtonNavigations">
                                <asp:Button ID="Button1" runat="server" CssClass="mybtn_Search" OnClick="Button1_Click" />
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="clearall"></div>
                </td>
            </tr>
        </table>
       <asp:ListView ID="lstProjects" runat="server" ItemPlaceholderID="plItems" OnPagePropertiesChanging="lstProjects_PagePropertiesChanging" >
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
                              <%--  <asp:HyperLink runat="server" Text="More Detail" ID="lnkMoreDetail" NavigateUrl='<%# string.Format("~/Pages/Faculty/ProjectDetail?PId={0}",Eval("PId"))%>' Visible="True"></asp:HyperLink>--%> 

                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold;color: #005580">Status :<asp:Label ID="lblStatus" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetStatusByValue(Convert.ToInt16(Eval("Status"))) %>'></asp:Label></td>
                        </tr>
                       <%-- <tr>
                            <td>Proposed By :
                                 <asp:HyperLink runat="server" Text='<%# Bind("Name") %>' ID="lnkProposedBy" NavigateUrl='<%# string.Format("~/Pages/Faculty/UserMiniProfile.aspx?UId={0}",Eval("ProposedBy"))%>'></asp:HyperLink>   
                                <asp:LinkButton runat="server" Text="Delete" ID="lnkCancel" Visible='<%#FYPUtilities.FYPSession.GetLoggedUser().RoleName.ToLower()=="admin"?true:false%>' OnClick="CancelClick" CommandArgument='<%#Eval("PId") %>' Style="float:right"></asp:LinkButton>
                            </td>

                        </tr>--%>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <th style="background-color: #dae2e8">
                                <asp:Label ID="lblTitle" runat="server" Text='<%# Bind("Tiltle") %>'></asp:Label>
                        </th>
                        <tr>
                            <td style="background-color: #edf6fd">
                                <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description").ToString().Length>500?Eval("Description").ToString().Substring(0, 350):Eval("Description")%>'>
                                </asp:Label>
                                
                                <%--<asp:HyperLink runat="server" Text="More Detail" ID="lnkMoreDetail" NavigateUrl='<%# string.Format("~/Pages/Faculty/ProjectDetail?PId={0}",Eval("PId"))%>' Visible="True"></asp:HyperLink>--%>
                            </td>
                        </tr>
                        
                        <tr>
                                <td style="font-weight: bold;color: #005580;background-color:  #edf6fd">Status :<asp:Label ID="lblStatus" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetStatusByValue(Convert.ToInt16(Eval("Status"))) %>'></asp:Label></td>
                            </tr>
                       <%-- <tr>
                            <td style="background-color:  #edf6fd">Proposed By :
                                 <asp:HyperLink runat="server" Text='<%# Bind("Name") %>' ID="lnkProposedBy" NavigateUrl='<%# string.Format("~/Pages/Faculty/UserMiniProfile.aspx?UId={0}",Eval("ProposedBy"))%>'></asp:HyperLink>   
                               <asp:LinkButton runat="server" Text="Delete" ID="lnkCancel" Visible='<%#FYPUtilities.FYPSession.GetLoggedUser().RoleName.ToLower()=="admin"?true:false%>' OnClick="CancelClick" CommandArgument='<%#Eval("PId") %>' Style="float:right"></asp:LinkButton>
                            </td>
                            
                        </tr>--%>
                    </AlternatingItemTemplate>
                </asp:ListView>
         <asp:DataPager ID="dPagerProjects" runat="server" PagedControlID="lstProjects" PageSize="25">
    <Fields>
        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
        <asp:NumericPagerField />
        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
    </Fields>
</asp:DataPager>
    </fieldset>

</div>
