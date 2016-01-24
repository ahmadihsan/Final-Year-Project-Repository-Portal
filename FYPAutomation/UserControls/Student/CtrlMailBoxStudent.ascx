<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlMailBoxStudent.ascx.cs" Inherits="FYPAutomation.UserControls.Student.CtrlMailBoxStudent" %>
<%@ Import Namespace="FYPUtilities" %>

<style type="text/css">
    .auto-style1 {
        height: 157px;
    }

    .size {
        width: 20px;
        height: 20px;
    }

    .position {
        position: relative;
    }

    .panal {
       position: absolute;
        width: 461px;
        height: 100px;
        bottom:554px;
        margin-left: 652px;
        border-width: thick;
        
    }

    .compose {
        margin: -500px 300px 0 0;
        z-index: 3;
        position: absolute;
        top: 760px;
        left: 17px;
    }

    .tblPopup {
        border-spacing: 0px;
        z-index: 256;
        position: relative;
        border: 0.5px solid #000000;
        background-color: white;
        height: 380px;
        width: 460px;
    }

    .headerPopup {
        background-color: #0066FF;
        color: #FFFFFF;
        font-family: Calibri;
        font-size: large;
        font-weight: bolder;
    }

    .cross {
        float: right;
        width: 10px;
        height: 15px;
        margin-right: 5px;
        position: relative;
    }
    .hidden {
        display:none;
    }

</style>




<div class="FieldSet">
    <fieldset class="FieldSet">
        <legend>User Emails: </legend>
        <table style="width: 100%" class="mytable">
            <tr>
                <td>

                    <div class="ButtonNavigations">
                        <label>
                            <asp:Button runat="server" ID="btnFacMail" OnClick="btnFacMail_Click" CssClass="btn btn-primaryByMe" ToolTip="Faculty" ValidationGroup="vgr" Text="Faculty" />
                        </label>
                    </div>
                    <div class="ButtonNavigations">
                        <label>
                            <asp:Button runat="server" ID="btnAdminMail" OnClick="btnAdminMail_Click" CssClass="btn btn-primaryByMe" ToolTip="Admin" ValidationGroup="vgr" Text="Admin" Width="153px" />
                        </label>
                    </div>
                    <div class="ButtonNavigations">
                        <label>
                            <asp:Button runat="server" ID="btnPCMail" OnClick="btnPCMail_Click" CssClass="btn btn-primaryByMe" ToolTip="PC Member" ValidationGroup="vgr" Text="PC Member" Width="153px" />
                        </label>
                    </div>
                </td>
            </tr>

        </table>
    </fieldset>

</div>
<table style="width: 100%; height: 182px;">
    <tr>
        <td class="auto-style1">
            <asp:GridView ID="GvdViewAllMails" runat="server"  AutoGenerateColumns="False" ForeColor="#333333" Style="width: 100%; margin: 0 auto;" ShowHeaderWhenEmpty="True" CssClass="mytable" EmptyDataText="No Email found!" GridLines="None" >
                <Columns>
                    <asp:TemplateField>

                        <HeaderTemplate>
                            <asp:CheckBox ID="chkAll"  OnClick="javascript: SelectAllCheckboxes1(this);"  runat="server" />
                            <asp:ImageButton ID="DeleteAllMail" runat="server" OnClick="DeleteAllMail_Click" ImageUrl="~/Images/deleteIcon.png" style="width:20px; height:20px" OnClientClick="return confirm('Do you want to delete this file?')" />
                        </HeaderTemplate>

                        <ItemTemplate>
                            <asp:CheckBox ID="chkview" runat="server"  AutoPostBack="true" />
                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:BoundField DataField="COMId" SortExpression="COMId"  ReadOnly="true">
                         <ItemStyle CssClass="hidden"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="EmailSubject" SortExpression="EmailSubject">
                        <ControlStyle BorderStyle="Solid" Width="20%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Message_Content" SortExpression="Message_Content">
                        <ControlStyle BorderStyle="Solid" Width="60%" />
                    </asp:BoundField>
                     <asp:TemplateField HeaderText="Download File">
                                <ItemTemplate>                                   
                                    <asp:HyperLink ID="LinkButton1" runat="server" NavigateUrl='<%# string.Format("{0}{1}",ConfigurationManager.AppSettings["AllUploadsUrl"],Eval("File_Attached"))%>' Text="Download">
                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                    <%--<asp:HyperLinkField DataNavigateUrlFields="File_Attached" DataNavigateUrlFormatString="~/AllUploads/StudentDocs/{0}" DataTextField="File_Attached" DataTextFormatString="<img src='../../Images/fileimg.png' style='width:32px; height:32px; border:0px' alt='{0}' />" />--%>

                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td></td>
    </tr>
</table>

    
            <asp:Panel ID="PopupPanel" CssClass="panal" runat="server">
            <table id="tblEmailPopup" class="tblPopup">
                
                <tr>
                    <td>
                        <div id="EmailComposeHeader" class="headerPopup">
                            New Message
                            <asp:Button ID="btnMailClose" runat="server" BackColor="#0066FF" BorderWidth="0px" CssClass="cross" ForeColor="White" OnClick="btnMailClose_Click" Text="X" />
                        </div>

                    </td>
                </tr>
                <tr>
                    <td>
                        From:
                        <asp:Label ID="from" runat="server" CssClass="position"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>To:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtEmailTo" runat="server" BorderStyle="None" CssClass="position" BorderWidth="0px" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Subject:&nbsp;&nbsp;
                    <asp:TextBox ID="txtEmailSubject" runat="server" BorderStyle="None" BorderWidth="0px" Width="300px" CssClass="position"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        Project Name:
                        <asp:DropDownList ID="ddlprojectname" runat="server" AutoPostBack="true" CssClass="position" DataTextField="Tiltle" DataValueField="PId" Enabled="true" OnSelectedIndexChanged="ddlprojectname_SelectedIndexChanged">
                        </asp:DropDownList>
                        <br />
                        <asp:Label ID="lblSupervisor" runat="server" CssClass="position" Visible="False" ForeColor="#33CC33"></asp:Label><br />
                        <asp:Label ID="lblStudents" runat="server" CssClass="position" Visible="False" ForeColor="#33CC33"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtEmailBody" runat="server" BackColor="#E1E1E1" BorderWidth="0px" CssClass="position" Height="175px" TextMode="MultiLine" Width="451px"></asp:TextBox>
                    </td>


                </tr>       
                <tr>
                    <td>
                        <ajaxToolkit:AjaxFileUpload ID="asyEmailUploadFile" runat="server" CssClass="position"  Height="116px" OnUploadComplete="asyEmailUploadFile_UploadComplete" Width="317px" />
                    </td>
                </tr>
                 <tr>
                    <td class="postion" style="background-color: #E1E1E1">
                        <asp:Button ID="btnEmailSend" runat="server" BackColor="#0066FF" BorderWidth="0px" CssClass="position" Font-Bold="True" ForeColor="White" Height="26px" OnClick="btnEmailSend_Click" OnClientClick="return CheckFields()" Text="Send" Width="75px" ValidationGroup="vgEmailto" />
                    </td>
                </tr>
            </table>
                </asp:Panel>
      


<asp:Button ID="btnComposeMail" runat="server" Text="Compose" Width="143px" Height="25px" CssClass="compose"  OnClick="btnComposeMail_Click" BackColor="#0066FF" BorderWidth="0px" Font-Bold="True" ForeColor="White" ToolTip="Compose Message" />
<script type="text/javascript">


    function CheckFields() {
        var emailsubject = document.getElementById('<%=txtEmailSubject.Text%>');
        var emailbody = document.getElementById('<%=txtEmailBody.Text%>');
        var emailto = document.getElementById('<%=txtEmailTo.Text%>');
        if (emailto != null) {
            if (emailbody == null || emailsubject == null) {

                return confirm("Notice! Sent this email without subject or message in the body.");
            }
        }

    }




    function SelectAllCheckboxes1(chk) {

        $('#<%=GvdViewAllMails.ClientID%>').find("input:checkbox").each(function () {
            if (this != chk) {
                this.checked = chk.checked;
            }
        });
    }
</script>



