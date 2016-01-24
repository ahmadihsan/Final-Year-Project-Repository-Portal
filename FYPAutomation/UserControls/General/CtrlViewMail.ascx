<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlViewMail.ascx.cs" Inherits="FYPAutomation.UserControls.General.CtrlViewMail" EnableViewState="true" %>

<style type="text/css">
    .Viewmail {
        background-color: white;
    }

    .header1 {
        font-size: larger;
        font-weight: bold;
    }
    .auto-style1 {
        height: 276px;
    }
    
   
</style>

<div class="Viewmail">

    <fieldset>
        <legend>User Mail</legend>
        <header>
            <asp:Label ID="lblHeaderMailView"  CssClass="header1" runat="server"></asp:Label>
            <br />
        </header>
             <div>
        <table style="height: 153px; width:100%" class="mytable" id="tblview">
            <tr>
                <td>
                    
                        <asp:Label runat="server" ID="lblMailBodyView" CssClass="Topleft" > </asp:Label>
                    
                </td>
            </tr>
            
            <tr>
                <td>
                    <%--<asp:HyperLink ID="hlFileAttach" runat="server" >Attached File</asp:HyperLink>--%>
                    <asp:LinkButton ID="lnkDownload" Text = "Download"  runat="server" OnClick ="lnkDownload_Click1"></asp:LinkButton>
                </td>
            </tr>


        </table>
        </div>



    </fieldset>


</div>
