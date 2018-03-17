<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="TreeQuiz.aspx.cs" Inherits="TreeQuiz" %>

<asp:Content ID="Map" ContentPlaceHolderID="MainContent" Runat="Server">
    <!DOCTYPE html>
<html>
<head>
    <title>RCSP Tree Quiz</title>
</head>
<body>
    <div class ="TableDiv">
        <asp:Table ID="tbl_Quiz" CssClass="tbl_Quiz" runat="server" CellPadding="5" CellSpacing="5" HorizontalAlign="Center">
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                    <asp:Table ID="tbl_Header1" runat="server">
                        <asp:TableRow>
                            <asp:TableCell Width="10%">
                               
                            </asp:TableCell>
                            <asp:TableCell Width="80%">
                                <asp:Label ID="lbl_name" runat="server" Text="Tree Name"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="10%">
                                
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                    <asp:Table ID="tbl_Header2" runat="server">
                        <asp:TableRow>
                            <asp:TableCell Width="10%">
                                <asp:Table ID="table_prev" runat="server">
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <asp:ImageButton ID="imgbtn_prev" ImageUrl="Images/small_left_arrow.png" runat="server" />
                                        </asp:TableCell>

                                        <asp:TableCell>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </asp:TableCell>
                            <asp:TableCell Width="80%">
                                <asp:Label ID="lbl_Question" runat="server" Text="Question Goes Here"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="10%">
                                <asp:Table ID="table_next" runat="server">
                                    <asp:TableRow>
                                        <asp:TableCell>

                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <asp:ImageButton ID="imgbtn_next" ImageUrl="Images/small_right_arrow.png" runat="server" />
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                    <asp:Table ID="tbl_Answers" runat="server">
                        <asp:TableRow>
                            <asp:TableCell>

                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:Button ID="btn_A1" runat="server" Text="True" Width="100%"/>
                            </asp:TableCell>
                            <asp:TableCell>

                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:Button ID="btn_A2" runat="server" Text="False" Width="100%"/>
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
                                <asp:Label ID="lbl_RightWrong" runat="server" Text="Correct/Incorrect."></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Width="75%" HorizontalAlign="Left" VerticalAlign="Top">
                                <asp:Label ID="lbl_Explanation" runat="server" Text="The sycamore tree is found mostly in..."></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:Button ID="btn_info" CssClass="info_section" runat="server" Text="More Info." OnClick="Btn_Info_Click" />
                    <asp:Label ID="lbl_info" CssClass="info_section" runat="server" Text="More info now being shown. This info may possibly be a lot of info. So much info that it may take two or three sentences to show it all." Visible="False" Width="150px"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
</body>
</html>
</asp:Content>
