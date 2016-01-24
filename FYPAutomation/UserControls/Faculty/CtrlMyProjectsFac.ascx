<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlMyProjectsFac.ascx.cs" Inherits="FYPAutomation.UserControls.Faculty.CtrlMyProjectsFac" %>

<%--<style type="text/css">
    .btnReserve {
        margin-left: 65%;
        border-style: outset;
        border-radius: 10px;
        background-color: darkred;
        border-color: darkred;
        width: 80px;
        height: 30px;
        color: white;
    }
    .pad
    {
        padding:10px;
    }
</style>

--%>


<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>My Projects : </legend>
        <table style="width: 100%">
        </table>
        <asp:ListView ID="lstProjects" runat="server" ItemPlaceholderID="plItems"  OnItemCommand="lstProjects_ItemCommand">
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
                        <asp:HyperLink runat="server" Text="More Detail" ID="lnkMoreDetail" NavigateUrl='<%# string.Format("~/Pages/Faculty/ProjectDetail?PId={0}",Eval("PId"))%>' Visible="True"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold; color: #005580">Status :<asp:Label ID="lblStatus" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetStatusByValue(Convert.ToInt16(Eval("Status"))) %>'></asp:Label>
                        <%--<asp:Button runat="server" ID="tnReserveProc" Text="Reserve" CssClass="btnReserve"  />--%>
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
                        <asp:HyperLink runat="server" Text="More Detail" ID="lnkMoreDetail" NavigateUrl='<%# string.Format("~/Pages/Faculty/ProjectDetail?PId={0}",Eval("PId"))%>' Visible="True"></asp:HyperLink>
                    </td>
                </tr>

                <tr>
                    <td style="font-weight: bold; color: #005580; background-color: #edf6fd">Status :<asp:Label ID="lblStatus" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetStatusByValue(Convert.ToInt16(Eval("Status"))) %>'></asp:Label>
                        <%--<asp:Button runat="server" ID="tnReserveProc" Text="Reserve" CssClass="btnReserve" />--%>
                        <asp:LinkButton runat="server" Text="Weekly Meeting" ID="lnkWeeklyMeeting" Visible='<%#FYPDAL.FrequentAccesses.GetStatusByValue(Convert.ToInt16(Eval("Status"))).ToLower()=="assigned"%>' OnClick="WeeklyMeetingClicked" CommandArgument='<%#Eval("PId") %>' Style="float: right"></asp:LinkButton>
                    </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:ListView>
    </fieldset>
</div>

<%--<div class="FieldSet">
    <fieldset class="FieldSet">--%>

        <%--<asp:GridView ID="GvdProclist" runat="server" CellPadding="3" DataKeyNames="PId" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CssClass="pad">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <label style="color:white">My Projects:</label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table>
                            <th style="float:left">
                                <asp:Label ID="lblTitle" runat="server" Text='<%# Bind("Tiltle") %>'></asp:Label>
                            </th>
                           
                            <tr>
                                <td>
                                    
                                    <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description").ToString().Length>500?Eval("Description").ToString().Substring(0, 350):Eval("Description")%>'>
                                    </asp:Label>
                                    <asp:HyperLink runat="server" Text="More Detail" ID="lnkMoreDetail" NavigateUrl='<%# string.Format("~/Pages/Faculty/ProjectDetail?PId={0}",Eval("PId"))%>' Visible="True"></asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; color: #005580">Status :<asp:Label ID="lblStatus" runat="server" Text='<%# FYPDAL.FrequentAccesses.GetStatusByValue(Convert.ToInt16(Eval("Status"))) %>'></asp:Label>
                                    <asp:Button runat="server" ID="btnReserveProc" ClientIDMode="Static" Text="Reserve" CssClass="btnReserve" OnClientClick="UpdateTime()" />
                                    <asp:LinkButton runat="server" Text="Weekly Meeting" ID="lnkWeeklyMeeting" Visible='<%#FYPDAL.FrequentAccesses.GetStatusByValue(Convert.ToInt16(Eval("Status"))).ToLower()=="assigned"%>' OnClick="WeeklyMeetingClicked" CommandArgument='<%#Eval("PId") %>' Style="float: right"></asp:LinkButton>
                                </td>

                            </tr>
                                
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>--%>

   <%-- </fieldset>
</div>--%>


<%--<script type="text/javascript">
    function UpdateTime() {
        
        var timeRemaining =(<%= (DateTime.Now - TestStarted.Value).TotalMinutes - MinutesAllowed %> * 60);
        // Start an interval that repeats each second and decrements the timer
        setInterval(UpdateTimer, 1000);

        function UpdateTimer() {
            // Decrement the timer
            timeRemaining--;
            // Display your time
            var btnR = document.getElementById('btnReserveProc');
            btnR.attributes["style"] = "margin-left: 65%; border-style: outset; border-radius: 10px;background-color:#006600;border-color: darkred;width: 80px;height: 30px;color: white;";
            btnR.innerHTML = timeRemaining.toString().toHHMMSS();
            // Check if the timer has completed
            if (timeRemaining <= 0) {
                // Do something here
                btnR.attributes["style"] = " margin-left: 65%; border-style: outset; border-radius: 10px; background-color: darkred;border-color: darkred;width: 80px;height: 30px;color: white;";
                timeRemaining = (<%= (DateTime.Now - TestStarted.Value).TotalMinutes - MinutesAllowed %> * 60);

                return btnR.innerHTML = "Reserve";

            }

            String.prototype.toHHMMSS = function () {
                var sec_num = parseInt(this, 10); // don't forget the second param
                var hours = Math.floor(sec_num / 3600);
                var minutes = Math.floor((sec_num - (hours * 3600)) / 60);
                var seconds = sec_num - (hours * 3600) - (minutes * 60);

                if (hours < 10) { hours = "0" + hours; }
                if (minutes < 10) { minutes = "0" + minutes; }
                if (seconds < 10) { seconds = "0" + seconds; }
                var time = hours + ':' + minutes + ':' + seconds;
                return time;
            }
        }
    }
     
</script>--%>
