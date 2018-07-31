<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="MedicinalLogistics.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/style.css" rel="stylesheet" />
    <script src="style.css"></script>

    <style type="text/css">
        .style1 {
            text-decoration: underline;
            font-size: large;
            text-align: left;
            padding: 8px;
        }

        .style2 {
            width: 105px;
            padding: 8px;
        }
       
        ._TextBox {}
       
    </style>
</head>
<body>
   
    <form id="form1" runat="server">
        <div class="loginFormCls">

            <table  cellspacing:10 class ="LoginTbl">
                <caption class="style1">
                    <strong>Login</strong></caption>
                <tr>
                    <td class="style2">&nbsp;</td>
                    <%--<td>&nbsp;</td>
                    <td>&nbsp;</td>--%>
                </tr>
                <tr>
                    <td class="style2">Name</td>
                    <td>
                        <asp:TextBox CssClass="_TextBox" ID="Name" runat="server" ></asp:TextBox>
                    </td>
                   <%-- <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="TextBox1" ErrorMessage="Please Enter Your Username"
                            ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>--%>
                </tr>
                 <tr>
                    <td class="style2">Last Name</td>
                    <td>
                        <asp:TextBox CssClass="_TextBox" ID="LastName" runat="server" ></asp:TextBox>
                    </td>
                   <%-- <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="TextBox1" ErrorMessage="Please Enter Your Username"
                            ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>--%>
                </tr>
                <tr>
                    <td class="style2">Firm Name:</td>
                    <td>
                        <asp:TextBox CssClass="_TextBox" ID="FirmName" runat="server"></asp:TextBox>
                    </td>
                    <%--<td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="TextBox2" ErrorMessage="Please Enter Your Password"
                            ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>--%>
                </tr>
                <tr>
                    <td class="style2">Firm Address</td>
                   <%-- <td>&nbsp;</td>
                    <td>&nbsp;</td>--%>
                    <td>
                        <%--<asp:DropDownList ID="LoginType" runat="server">
                            <asp:ListItem>Wholesaler</asp:ListItem>
                        </asp:DropDownList>--%>
                        <asp:TextBox CssClass="_TextBox" ID="FirmAddress"  runat="server"></asp:TextBox>
                    </td>
                </tr>


               
                <tr>
                    <td class="style2">GST No</td>
                     <td>
                        <%--<asp:DropDownList ID="LoginType" runat="server">
                            <asp:ListItem>Wholesaler</asp:ListItem>
                        </asp:DropDownList>--%>
                        <asp:TextBox CssClass="_TextBox" ID="GSTNo" TextMode="number" runat="server"></asp:TextBox>
                    </td>
                     </tr>
                <tr>
                    <td class="style2">Contact No</td>
                     <td>
                        <%--<asp:DropDownList ID="LoginType" runat="server">
                            <asp:ListItem>Wholesaler</asp:ListItem>
                        </asp:DropDownList>--%>
                        <asp:TextBox CssClass="_TextBox" ID="Contact" TextMode="number" runat="server"></asp:TextBox>
                    </td>
                     </tr>
                <tr>
                    <td class="style2">Email</td>
                     <td>
                        <%--<asp:DropDownList ID="LoginType" runat="server">
                            <asp:ListItem>Wholesaler</asp:ListItem>
                        </asp:DropDownList>--%>
                        <asp:TextBox CssClass="_TextBox" ID="Email" TextMode="email" runat="server"></asp:TextBox>
                    </td>
                     </tr>
                <tr>
                    <td class="style2">Shop no.</td>
                     <td>
                        <%--<asp:DropDownList ID="LoginType" runat="server">
                            <asp:ListItem>Wholesaler</asp:ListItem>
                        </asp:DropDownList>--%>
                        <asp:TextBox CssClass="_TextBox" ID="ShopNo" TextMode="number" runat="server"></asp:TextBox>
                    </td>
                     </tr>
                <tr>
                    <td class="style2">Password</td>
                     <td>
                        <%--<asp:DropDownList ID="LoginType" runat="server">
                            <asp:ListItem>Wholesaler</asp:ListItem>
                        </asp:DropDownList>--%>
                        <asp:TextBox CssClass="_TextBox" ID="Password" TextMode="Password" runat="server"></asp:TextBox>
                    </td>
                     </tr>
                <tr>
                    <td class="style2">Confirm Password</td>
                     <td>
                        <%--<asp:DropDownList ID="LoginType" runat="server">
                            <asp:ListItem>Wholesaler</asp:ListItem>
                        </asp:DropDownList>--%>
                        <asp:TextBox CssClass="_TextBox" ID="ConfirmPassword" TextMode="Password" runat="server"></asp:TextBox>
                    </td>
                     </tr>


                <tr>
                    <td class="style2">&nbsp;</td>
                    <td>
                        <asp:Button CssClass="_Button" ID="Button1" runat="server" Text="Sign Up" OnClick="Button1_Click" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
