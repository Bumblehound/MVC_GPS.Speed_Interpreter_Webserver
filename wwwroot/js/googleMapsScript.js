function initMap() {
    var $maps = $(".map");
    $.each($maps, function (i, value) {
        var directionsService = new google.maps.DirectionsService();
        var directionsDisplay = new google.maps.DirectionsRenderer();
        //  ourOrigin = new google.maps.LatLng(pos.lat, pos.lng);
        var mapDivId = $(value).attr("id");
        console.log(mapDivId);
        var map = new google.maps.Map(document.getElementById(mapDivId), {
            zoom: 1,
            styles: [
                { elementType: "geometry", stylers: [{ color: "#242f3e" }] },
                {
                    elementType: "labels.text.stroke",
                    stylers: [{ color: "#242f3e" }],
                },
                {
                    elementType: "labels.text.fill",
                    stylers: [{ color: "#746855" }],
                },
                {
                    featureType: "administrative.locality",
                    elementType: "labels.text.fill",
                    stylers: [{ color: "#d59563" }],
                },
                {
                    featureType: "poi",
                    elementType: "labels.text.fill",
                    stylers: [{ color: "#d59563" }],
                },
                {
                    featureType: "poi.park",
                    elementType: "geometry",
                    stylers: [{ color: "#263c3f" }],
                },
                {
                    featureType: "poi.park",
                    elementType: "labels.text.fill",
                    stylers: [{ color: "#6b9a76" }],
                },
                {
                    featureType: "road",
                    elementType: "geometry",
                    stylers: [{ color: "#38414e" }],
                },
                {
                    featureType: "road",
                    elementType: "geometry.stroke",
                    stylers: [{ color: "#212a37" }],
                },
                {
                    featureType: "road",
                    elementType: "labels.text.fill",
                    stylers: [{ color: "#9ca5b3" }],
                },
                {
                    featureType: "road.highway",
                    elementType: "geometry",
                    stylers: [{ color: "#746855" }],
                },
                {
                    featureType: "road.highway",
                    elementType: "geometry.stroke",
                    stylers: [{ color: "#1f2835" }],
                },
                {
                    featureType: "road.highway",
                    elementType: "labels.text.fill",
                    stylers: [{ color: "#f3d19c" }],
                },
                {
                    featureType: "transit",
                    elementType: "geometry",
                    stylers: [{ color: "#2f3948" }],
                },
                {
                    featureType: "transit.station",
                    elementType: "labels.text.fill",
                    stylers: [{ color: "#d59563" }],
                },
                {
                    featureType: "water",
                    elementType: "geometry",
                    stylers: [{ color: "#17263c" }],
                },
                {
                    featureType: "water",
                    elementType: "labels.text.fill",
                    stylers: [{ color: "#515c6d" }],
                },
                {
                    featureType: "water",
                    elementType: "labels.text.stroke",
                    stylers: [{ color: "#17263c" }],
                },
            ],
        });
        directionsDisplay.setMap(map);
        var origin = [
            parseFloat($(value).attr("OriginLat")).toString(),
            parseFloat($(value).attr("OriginLng")).toString(),
        ];
        console.log(origin);
        var destination = [
            parseFloat($(value).attr("DestinationLat")).toString(),
            parseFloat($(value).attr("DestinationLng")).toString(),
        ];
        calculateAndDisplayRoute(
            directionsService,
            directionsDisplay,
            origin,
            destination
        );
    });
}

function calculateAndDisplayRoute(
    directionsService,
    directionsDisplay,
    origin,
    destination
) {
    console.log(origin);
    directionsService.route(
        {
            origin: new google.maps.LatLng(origin[0], origin[1]),
            destination: new google.maps.LatLng(destination[0], destination[1]),
            travelMode: "DRIVING",
        },
        function (response, status) {
            if (status === "OK") {
                directionsDisplay.setDirections(response);
            } else {
                window.alert("Directions request failed due to " + status);
            }
        }
    );
}