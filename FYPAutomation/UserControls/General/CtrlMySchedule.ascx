<%@ Control Language="C#" AutoEventWireup="true"  CodeBehind="CtrlMySchedule.ascx.cs" Inherits="FYPAutomation.UserControls.General.CtrlMySchedule" %>


<div>
    <asp:Calendar ID="CldSchedule" runat="server" SelectionMode="DayWeekMonth" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="400px" NextPrevFormat="FullMonth" Width="700px">
        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
        <TodayDayStyle BackColor="#CCCCCC" />
    </asp:Calendar>
</div>