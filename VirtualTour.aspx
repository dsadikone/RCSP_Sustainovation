<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="VirtualTour.aspx.cs" Inherits="VirtualTour" %>


<asp:Content ID="VirtualTour" ContentPlaceHolderID="MainContent" Runat="Server">
 
<!DOCTYPE html>
<html>
  <head>
    <meta charset="UTF-8" />
    <title>Geolocation and Google Maps API</title>
    <script async defer src="https://maps.googleapis.com/maps/api/js?key=APIKEYHERE"
  type="text/javascript"></script>

      <script type="text/javascript">
          var markers = [
              <asp:Repeater ID="rptMarkers" runat="server">
                  <ItemTemplate>
                      {
                          "title": '<%# Eval("Number") %>',
                          "lat": '<%# Eval("Latitude") %>',
                          "lng": '<%# Eval("Longitude") %>',
                          "description": '<%# Eval("Common_Name") %>'
                      }
                  </ItemTemplate>
                  <SeparatorTemplate>
                                      ,
                  </SeparatorTemplate>
                </asp:Repeater>
        ];
     </script>
     <script type="text/javascript">
         var mapObject;
         window.onload = function () {
             
        var mapOptions = {
            center: new google.maps.LatLng(markers[0].lat, markers[0].lng),
            zoom: 14,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        var infoWindow = new google.maps.InfoWindow();
        mapObject = new google.maps.Map(document.getElementById("map"), mapOptions);
        for (i = 0; i < markers.length; i++) {
            var data = markers[i]
            var Latlng = new google.maps.LatLng(data.lat, data.lng);
            var marker = new google.maps.Marker({
                position: Latlng,
                map: mapObject,
                title: data.title
            });

            (function (marker, data) {
                google.maps.event.addListener(marker, "click", function (e) {
                    infoWindow.setContent(data.description);
                    infoWindow.open(mapObject, marker);
                });
            })(marker, data);
         }
         }
      </script>

  <style type="text/css">
    #map {
    position: relative;
    padding-bottom: 75%;
    height: 0;
    overflow: hidden;
    top: 0;
    left: 0;
    width: 100% !important;
    height: 100% !important;
    }
  </style>
  </head>
  <body>
    <h1>Virtual Tree Identification Tour</h1>
    <div id="map"></div>
    <p id="error"></p>
  </body>
</html>
</asp:Content>



