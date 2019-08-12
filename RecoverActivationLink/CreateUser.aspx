<%@ page language="C#" autoeventwireup="true" codebehind="CreateUser.aspx.cs" inherits="RecoverActivationLink.CreateUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>UserName : </td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Password : </td>
                    <td>
                        <asp:TextBox ID="txtPasword" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Email Id : </td>
                    <td>
                        <asp:TextBox ID="txtEmailId" runat="server"></asp:TextBox><br />
                        <asp:RegularExpressionValidator ID="revEmailId" runat="server"
                            ErrorMessage="Please enter valid email address"
                            ControlToValidate="txtEmailId" Display="Dynamic"
                            ForeColor="Red" SetFocusOnError="True"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit"
                            OnClick="btnSubmit_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>

    </form>
</body>
</html>
