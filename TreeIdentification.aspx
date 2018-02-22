<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="TreeIdentification.aspx.cs" Inherits="TreeIdentification" %>

<asp:Content ID="Map" ContentPlaceHolderID="MainContent" Runat="Server">
<!DOCTYPE html>
<html>
  <head>
    <meta charset="UTF-8" />
    <title>Geolocation and Google Maps API</title>
    <script async defer src="https://maps.googleapis.com/maps/api/js?key=APIKEYHERE"
  type="text/javascript"></script>
    <script>
      function writeAddressName(latLng) {
        var geocoder = new google.maps.Geocoder();
        geocoder.geocode({
          "location": latLng
        },
        function(results, status) {
          if (status == google.maps.GeocoderStatus.OK)
            document.getElementById("address").innerHTML = results[0].formatted_address;
          else
            document.getElementById("error").innerHTML += "Unable to retrieve your address" + "<br />";
        });
      }

      function geolocationSuccess(position) {
        var userLatLng = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
        // Writing the address
        writeAddressName(userLatLng);

        var myOptions = {
          zoom : 12,
          center : userLatLng,
          mapTypeId : google.maps.MapTypeId.ROADMAP
        };
        // Drawing the map
        var mapObject = new google.maps.Map(document.getElementById("map"), myOptions);
        // Placing the marker
        new google.maps.Marker({
          map: mapObject,
          position: userLatLng
        });
        // Drawing a circle for the user's current position
        var circle = new google.maps.Circle({
          center: userLatLng,
          radius: position.coords.accuracy,
          map: mapObject,
          fillColor: '#42b3f4',
          fillOpacity: 0.5,
          strokeColor: '#42b3f4',
          strokeOpacity: 1.0
        });
        mapObject.fitBounds(circle.getBounds());
      }

      function geolocationError(positionError) {
        document.getElementById("error").innerHTML += "Error: " + positionError.message + "<br />";
      }

      function geolocateUser() {
        // If the Geolocation API is supported
        if (navigator.geolocation)
        {
          var positionOptions = {
            enableHighAccuracy: true,
            timeout: 10 * 1000 
          };
          navigator.geolocation.getCurrentPosition(geolocationSuccess, geolocationError, positionOptions);
        }
        else
          document.getElementById("error").innerHTML += "Your current browser does not support the Geolocation API!";
      }
      window.onload = geolocateUser;
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
    <h1>Geolocation-Based Tree Identification</h1>
    <div id="map"></div>
    <p><b>Current Address</b>: <span id="address"></span></p>
    <p id="error"></p>
  </body>
</html>
</asp:Content>

