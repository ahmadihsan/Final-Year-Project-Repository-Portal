<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAdminNotificationSideBar.ascx.cs" Inherits="FYPAutomation.UserControls.Admin.CtrlAdminNotificationSideBar" %>
<style type="text/css">
    .ui-accordion .ui-accordion-header {
        padding: 6px 20px !important;
    }
</style>

<div class="FieldSet">
    <div id="dvAccordian" style="width: 400px">
        <asp:Repeater ID="rptAccordian" runat="server">
            <ItemTemplate>
                <h3><b style="color: rgb(10, 17, 220)"><%#Eval("Name") + " Submission Deadline" %></b></h3>
                <div>
                    <%#Eval("Description") %>
                    <p>
                        Deadline : <h5><%# Convert.ToDateTime(Eval("DeadLine")).ToString("dddd, dd MMMM yyyy ") %></h5> till Time <h3><%#Eval("TimeSpan") %></h3>
                    </p>
                    <p style="color: red">
                        Click bellow link to Submit your document
                        <br />
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#FYPDAL.FrequentAccesses.GetUrlForSubmissionDocument(FYPUtilities.FYPSession.GetLoggedUser().RoleName,Eval("PMSDId").ToString()) %>' Text="Click Here" Visible='<%#FYPUtilities.FYPSession.GetLoggedUser().RoleName.ToLower()!="student" %>' Style="text-decoration: underline"></asp:HyperLink><b></b>
                            <asp:HiddenField runat="server" ID="hdnDeadlineId" Value='<%#Eval("PMSDId") %>'/>
                    </p>
                    <p style="color: red">
                        <b>Note : </b>Please get the templates from download portion.
                    </p>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        
        <asp:Repeater ID="rptGeneralAnnouncement" runat="server">
            <ItemTemplate>
                <h3><b style="color: rgb(10, 17, 220)"><%#Eval("Title") %></b></h3>
                <div>
                    <p>
                        <%#Eval("Description") %>
                    </p>
                    <p style="color: red">
                        <asp:Label runat="server" ID="lblToDownlaod" Text='<%#Eval("Upload")!=null?"Click bellow link to download attached file":string.Empty %>' Visible='<%#Eval("Upload")!=null%>'></asp:Label>
                        <br />
                        <asp:HyperLink ID="lnkFileExistOrNot" runat="server" NavigateUrl='<%#Eval("Upload")!=null?string.Format("{0}{1}",ConfigurationManager.AppSettings["AllUploadsUrl"],Eval("Upload")):"#" %>' Text='<%#Eval("Upload")==null?"No file exist":"Click Here to download file" %>' Visible='<%#Eval("Upload") != null %>' Style="text-decoration: underline"></asp:HyperLink><b></b>
                    </p>
                </div>
            </ItemTemplate>
        </asp:Repeater>

<%--        <asp:Repeater ID="rptAnnouncment" runat="server">
            <ItemTemplate>
                <h3><b class="blink" style="color: red"><%#Eval("Title") %></b></h3>
                <div>
                    <p>
                        <%#Eval("Description") %>
                    </p>
                    <p style="color: red">
                        Follow bellow link to fill your weekly schedule
                        <br />
                        <asp:HyperLink runat="server" NavigateUrl='<%#FYPDAL.FrequentAccesses.GetUrlForSchedule(FYPUtilities.FYPSession.GetLoggedUser().RoleName)+"?AnnId="+Eval("AnnId") %>' Text="Click Here" Style="text-decoration: underline"></asp:HyperLink><b></b>
                    </p>
                   
                    <asp:Label ID="Label1" runat="server" Text='<%#Convert.ToBoolean(Eval("isScheduleBase"))?"<b>Note:</b> Schedule asked to submit is <b>FROM</b>    "+Convert.ToDateTime(Eval("StartDate")).ToString("dddd, dd MMMM yyyy")+" <b>TO</b> "+Convert.ToDateTime(Eval("CloseDate")).ToString("dddd, dd MMMM yyyy"):string.Empty %>'></asp:Label>
                </div>
            </ItemTemplate>
        </asp:Repeater>--%>
    </div>
</div>
