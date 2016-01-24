<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AaaaaaaMarquee.ascx.cs" Inherits="FYPAutomation.UserControls.Admin.AaaaaaaMarquee" %>
<style type="text/css">
    #tblTechNewsScrolling {
        width: 315px;
    }
</style>
<div class="FieldSet">
    <fieldset class="FieldSet">
        
        <table class="mytable" border="0" cellpadding="0" id="tblTechNewsScrolling" runat="server" cellspacing="0">
             <tr>
                <td style="width:7px; height:35px" ></td>
                <td style="align-self:center" class="auto-style1" ><asp:Label ID="lblNewsHeading" runat="server"></asp:Label></td>
                <td style="width:11px; height:35px"></td>
              </tr>
              <tr>
              <td class="midleft"></td>
              <td >
               <div id="divNews" style="width:313px; height:344px" runat="server">
                  
                   <asp:Literal ID="Literal1" runat="server"></asp:Literal>
               </div></td>
                <td class="midright"></td>
              </tr>
                <tr>
                <td style="width:7px; height:11px"></td>
                <td>&nbsp;</td>
                <td ></td>
              </tr>
            </table>
        </fieldset>
            </div>