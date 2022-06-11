 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplication4.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <form id="form1" runat="server">
        <div >
            <h2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Generate a one-time password</h2>
            
             

            <h4>User ID&nbsp  <asp:TextBox ID="TextBox1" runat="server" Height="33px" Width="306px" ></asp:TextBox></h4>
            <h4 > DateTime&nbsp;<asp:Label ID="labeldt" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label></h4> 
            <h3>
            <asp:Button ID="Button1" runat="server" Text="Generate" OnClick="Button_Click" Height="39px" Width="103px" BorderStyle="Solid" ForeColor="#0066FF"  /></h3>
            <h3>Password generate is :<asp:Label ID="l1" runat="server" Font-Bold="True" ForeColor="#00CC00" />   </h3>
            <p>
            <asp:Label ID="LTimer" runat="server" Font-Bold="True" ForeColor="#CC0066"></asp:Label>
            &nbsp;
             </p> 
            <asp:ScriptManager ID="ScriptManager" runat="server"> </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Always">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Timer" EventName="Tick" />
                </Triggers>
                <ContentTemplate>
                    <h3>Valid for&nbsp; 
                    <asp:Label ID="DisplayTextMinutes" runat="server" Text="00" Font-Size="X-Large"></asp:Label>
                    <span>:</span>
                    <asp:Label ID="DisplayTextSeconds" runat="server" Text="00" Font-Size="X-Large"></asp:Label>
                        &nbsp;seconds </h3>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Timer ID="Timer" runat="server" Interval="1000" OnTick="Timer_Tick" Enabled="False" >
            </asp:Timer>
           
        </div>
    </form> 
</body>
</html>
