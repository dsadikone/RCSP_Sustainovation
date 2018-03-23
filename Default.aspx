<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Welcome!</h1>
        <p class="lead">Ridley Creek State Park now offers a virtual tree identification experience...</p>
        <p><a href="TreeIdentification.aspx" class="btn btn-primary btn-lg">Begin &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting Started</h2>
            <p>
                This application will display the available information and images for each tree, starting with the closest tree to you, using GPS coordinates and positioning. Simply press "begin" to start!
            </p>
            <p>
                <a class="btn btn-default" href="About.aspx">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Take the Virtual Tour!</h2>
            <p>
                Not online? Use this link to experience a virtual tour of the tree markers.
            </p>
            <p>
                <a class="btn btn-default" href="VirtualTour.aspx">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Test Your Knowledge</h2>
            <p>
                Take the Quiz!
            </p>
            <p>
                <a class="btn btn-default" href="TreeQuiz.aspx?TreeNumber=1">Start Quiz</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Help.</h2>
            <p>
                Visit the FAQ section for help or guidance.
            </p>
            <p>
                <a class="btn btn-default" href="Help.aspx">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
