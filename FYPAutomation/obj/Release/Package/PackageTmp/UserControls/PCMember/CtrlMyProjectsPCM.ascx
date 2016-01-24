<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlMyProjectsPCM.ascx.cs" Inherits="FYPAutomation.UserControls.PCMember.CtrlMyProjectsPCM" %>

<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>My Projects : </legend>
        <table style="width: 100%">
        </table>
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
                        <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description").ToString().Length>500?Eval("Description").ToString().Substring(0, 350):Eval("Description")%>'>
                        </asp:Label>
                        <asp:HyperLink runat="server" Text="More Detail" ID="lnkMoreDetail" NavigateUrl='<%# string.Format("~/Pages/PCMember/ProjectDetail?PId={0}",Eval("PId"))%>' Visible="True"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold; color: #005580">Status :<asp:Label ID="lblStatus" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetStatusByValue(Convert.ToInt16(Eval("Status"))) %>'></asp:Label>
                        <asp:LinkButton runat="server" Text="Weekly Meeting" ID="lnkWeeklyMeeting" Visible='<%#FYPDAL.FrequentAccesses.GetStatusByValue(Convert.ToInt16(Eval("Status"))).ToLower()=="assigned"%>' OnClick="WeeklyMeetingClicked" CommandArgument='<%#Eval("PId") %>' Style="float: right"></asp:LinkButton>
                    </td>
                    
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <th style="background-color: #dae2e8">
                    <asp:Label ID="lblTitle" runat="server" Text='<%# Bind("Tiltle") %>'></asp:Label>
                </th>
                <tr>
                    <td style="background-color: #edf6fd">
                        <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description").ToString().Length>500?Eval("Description").ToString().Substring(0, 350):Eval("Description")%>'>
                        </asp:Label>
                        <asp:HyperLink runat="server" Text="More Detail" ID="lnkMoreDetail" NavigateUrl='<%# string.Format("~/Pages/PCMember/ProjectDetail?PId={0}",Eval("PId"))%>' Visible="True"></asp:HyperLink>
                    </td>
                </tr>

                <tr>
                    <td style="font-weight: bold; color: #005580; background-color: #edf6fd">Status :<asp:Label ID="lblStatus" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetStatusByValue(Convert.ToInt16(Eval("Status"))) %>'></asp:Label>
                        <asp:LinkButton runat="server" Text="Weekly Meeting" ID="lnkWeeklyMeeting" Visible='<%#FYPDAL.FrequentAccesses.GetStatusByValue(Convert.ToInt16(Eval("Status"))).ToLower()=="assigned"%>' OnClick="WeeklyMeetingClicked" CommandArgument='<%#Eval("PId") %>' Style="float: right"></asp:LinkButton>
                    </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:ListView>
    </fieldset>
</div>
