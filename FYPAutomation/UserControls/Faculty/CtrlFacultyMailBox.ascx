<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlFacultyMailBox.ascx.cs" Inherits="FYPAutomation.UserControls.Faculty.CtrlFacultyMailBox" %>
<%@ import Namespace="FYPUtilities" %>

<style type="text/css">
    .overflow {
       display: block;
   overflow:   hidden;
   width: 20px;
   height: 20px; 

    }
   
    .size {
        width: 20px;
        height: 20px;
    }

    .position {
        position: relative;
    }

    .panal {
        position: relative;
        width: 461px;
        height: 400px;
        margin-bottom:10%;
        margin-left: 57%;
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
    .widthper {
        width:5px;
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
                            <asp:Button runat="server" ID="btnFacPCMail" OnClick="btnFacPCMail_Click" CssClass="btn btn-primaryByMe" ToolTip="Prject Committee" ValidationGroup="vgr" Text="Prject Committee" />
                        </label>
                    </div>
                    <div class="ButtonNavigations">
                        <label>
                            <asp:Button runat="server" ID="btnAdminMailFac" OnClick="btnAdminMailFac_Click" CssClass="btn btn-primaryByMe" ToolTip="Faculty" ValidationGroup="vgr"  Text="Admin" Width="153px" />
                        </label>
                    </div>
                    <div class="ButtonNavigations">
                        <label>
                            <asp:Button runat="server" ID="btnStudentMailFac" OnClick="btnStudentMailFac_Click" CssClass="btn btn-primaryByMe" ToolTip="Student" ValidationGroup="vgr" Text="Student" Width="153px" />
                        </label>
                    </div>
                </td>
            </tr>

            </table>
            </fieldset>
            
            </div>
<asp:UpdatePanel runat="server" >
    <ContentTemplate>

                    <asp:GridView ID="GvdViewAllMailsFac" runat="server"  DataKeyNames="COMId"  AutoGenerateColumns="False" Style="width: 100%; margin: 0 auto;" ShowHeaderWhenEmpty="True"   EmptyDataText="No Email found!" OnRowCommand="GvdViewAllMailsFac_RowCommand" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                        <Columns>                 

                   
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox  id="chkAllfac"  onclick="javascript: SelectAllCheckboxes1(this);" runat="server" />
                                    <asp:ImageButton ID="DeleteAllMail" runat="server" OnClick="DeleteAllMail_Click" ImageUrl="~/Images/deleteIcon.png" style="width:20px; height:20px" OnClientClick="return confirm('Do you want to delete this file?')" />
                                                                      
                                </HeaderTemplate>
                               
                        <ItemTemplate>
                             <asp:CheckBox ID="chkviewFac"  Width="5px"  runat="server"    AutoPostBack="true" />
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="COMId" SortExpression="COMId"  ReadOnly="true">
                         <ItemStyle CssClass="hidden"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="EmailSubject"   HeaderStyle-Width="20px" SortExpression="EmailSubject" />
                   
                            
                   
                    <asp:BoundField DataField="Message_Content" ItemStyle-Font-Overline="false" FooterStyle-Width="50px" SortExpression="Message_Content"  >                   
                            <ControlStyle CssClass="overflow" />
                            </asp:BoundField>
                     <asp:TemplateField HeaderText="Download File">
                                <ItemTemplate>                                   
                                    <asp:HyperLink ID="LinkButton1" runat="server" NavigateUrl='<%# string.Format("{0}{1}",ConfigurationManager.AppSettings["AllUploadsUrl"],Eval("File_Attached"))%>' Text="Download">
                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                     <%--<asp:HyperLinkField DataNavigateUrlFields="File_Attached"   ItemStyle-Width="10px"  DataTextField="File_Attached"  DataTextFormatString="<img src='../../Images/fileimg.png' style='width:32px; height:32px; border:0px' alt='{0}' />" />--%>
                          
                            <asp:BoundField DataField="ReceivedDate"  ControlStyle-Width="10px" SortExpression="ReceivedDate" />                         
                    
                          
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
                            </asp:GridView>
                
        </ContentTemplate>
    </asp:UpdatePanel>


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
                    <asp:TextBox ID="txtEmailTo" ClientIDMode="Static" runat="server" BorderStyle="None" CssClass="position" BorderWidth="0px" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>Subject:&nbsp;&nbsp;
                    <asp:TextBox ID="txtEmailSubject" ClientIDMode="Static" runat="server" BorderStyle="None" BorderWidth="0px" Width="300px" CssClass="position"></asp:TextBox>
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
                        <asp:TextBox ID="txtEmailBody" ClientIDMode="Static" runat="server" BackColor="#E1E1E1" BorderWidth="0px" CssClass="position" Height="175px" TextMode="MultiLine" Width="451px"></asp:TextBox>
                    </td>


                </tr>       
                <tr>
                    <td>
                        <ajaxToolkit:AjaxFileUpload ID="asyEmailUploadFile" CssClass="position" runat="server"  Height="116px" OnUploadComplete="asyEmailUploadFile_UploadComplete" Width="454px" />
                        <br />
                        <br />
                        <br />
                        
                    </td>
                </tr>
                 <tr>
                    <td style="background-color: #E1E1E1">
                        <asp:Button ID="btnEmailSend" runat="server" BackColor="#0066FF" BorderWidth="0px" CssClass="position" Font-Bold="True" ForeColor="White" Height="26px" OnClick="btnEmailSend_Click" OnClientClick="javascript: return CheckFields()" Text="Send" Width="75px" ValidationGroup="vgEmailto" />
                    </td>
                </tr>
            </table>
                </asp:Panel>
      


<asp:Button ID="btnComposeMail" runat="server" Text="Compose" Width="143px" Height="25px" CssClass="compose"  OnClick="btnComposeMail_Click" BackColor="#0066FF" BorderWidth="0px" Font-Bold="True" ForeColor="White" ToolTip="Compose Message" />

<script type="text/javascript">

    
    function CheckFields() {
        var emailsubject = document.getElementById('<%=txtEmailSubject.ClientID%>').value;
        var emailbody = document.getElementById('<%=txtEmailBody.ClientID%>').value;
        var emailto = document.getElementById('<%=txtEmailTo.ClientID%>').value;
        if (emailto != "") {
            if (emailbody == "" || emailsubject == "") {

                return confirm("Notice! Sent this email without subject or message in the body.");
            }
        }

    }




    function SelectAllCheckboxes1(chk) {

        $('#<%= GvdViewAllMailsFac.ClientID%>').find("input:checkbox").each(function () {
             if (this != chk) {
                 this.checked = chk.checked;
             }
         });
     }
    </script>