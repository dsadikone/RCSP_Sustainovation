<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeFile="TreeQuiz.aspx.vb" Inherits="TreeQuiz" %>

<asp:Content ID="Map" ContentPlaceHolderID="MainContent" Runat="Server">
<!DOCTYPE html>
<html>
<head>
    <title>RCSP Tree Quiz</title>
    <link type="text/css" rel="stylesheet" href="StyleSheet.css" />
</head>
<body>
    <div>
        <asp:Table ID="tbl_Quiz" runat="server" CellPadding="10" CellSpacing="5" GridLines="Both" HorizontalAlign="Center" Height="239px">
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                    <asp:Label ID="lbl_Question" runat="server" Text="Question Goes Here"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                    <asp:Table ID="tbl_Answers" runat="server">
                        <asp:TableRow>
                            <asp:TableCell>

                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:Button ID="btn_A1" runat="server" Text="First Answer Goes Here" Width="100%"/>
                            </asp:TableCell>
                            <asp:TableCell>

                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:ImageButton ID="imgbtn_prev" ImageUrl="Images/small_left_arrow.png" runat="server" />
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:Button ID="btn_A2" runat="server" Text="Second Answer Goes Here" Width="100%"/>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:ImageButton ID="imgbtn_next" ImageUrl="Images/small_right_arrow.png" runat="server" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>

                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:Button ID="btn_A3" runat="server" Text="Third Answer Goes Here" Width="100%"/>
                            </asp:TableCell>
                            <asp:TableCell>

                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                    <asp:Table ID="tbl_Feedback" runat="server">
                        <asp:TableRow>
                            <asp:TableCell Width="25%" HorizontalAlign="Center" VerticalAlign="Top">
                                <asp:Label ID="lbl_RightWrong" runat="server" Text="R/W"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="75%" HorizontalAlign="Left" VerticalAlign="Top">
                                <asp:Label ID="lbl_Explanation" runat="server" Text="Explanation for Answer Goes Here"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
</body>
</html>
</asp:Content>
