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
                                <asp:Label ID="lbl_name" CssClass="treename" runat="server" Text="Tree Name"></asp:Label>
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
                                            <asp:ImageButton ID="imgbtn_prev" ImageUrl="Images/small_left_arrow.png" runat="server" OnClick="ImgBtn_Prev_Click" />
                                        </asp:TableCell>

                                        <asp:TableCell>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </asp:TableCell>
                            <asp:TableCell Width="80%">
                                <asp:Label ID="lbl_Question" CssClass="treeInfo" runat="server" Text="Question Goes Here"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="10%">
                                <asp:Table ID="table_next" runat="server">
                                    <asp:TableRow>
                                        <asp:TableCell>

                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <asp:ImageButton ID="imgbtn_next" ImageUrl="Images/small_right_arrow.png" runat="server" OnClick="ImgBtn_Next_Click"/>
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
                                <asp:Button ID="btn_True" CssClass="btn_TF" runat="server" Text="True" Width="100%" OnClick="btn_True_Click" BackColor="White" />
                            </asp:TableCell>
                            <asp:TableCell>

                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                                <asp:Button ID="btn_False" CssClass="btn_TF" runat="server" Text="False" Width="100%" OnClick="btn_False_Click" BackColor="White" />
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
                                <asp:Label ID="lbl_Score" runat="server" Text="Score: 0%" Visible="False"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Width="75%" HorizontalAlign="Left" VerticalAlign="Top">
                                
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" Width ="80%">
                    <asp:Button ID="btn_info" CssClass="btn_TF" runat="server" Text="More Info" OnClick="Btn_Info_Click" />
                    <asp:Label ID="lbl_info" CssClass="treeInfo" runat="server" Text="" Visible="False"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
</body>
</html>
</asp:Content>
