//var maps = [];
//var markers = [];
//function initMap() {
//    console.log("Hellow")
//    var $maps = $('.map');
//    $.each($maps, function (i, value) {
//        var uluru = { lat: parseFloat($(value).attr('lat')), lng: parseFloat($(value).attr('lng')) };
//        console.log(uluru);
//        var mapDivId = $(value).attr('id');
//        console.log(mapDivId);
//        const map = new google.maps.Map(document.getElementById(mapDivId), {
//            zoom: 17,
//            center: uluru
//        });
//        const marker = new google.maps.Marker({
//            position: uluru,
//            map: map,
//        });
//    })
//}
//window.initMap = initMap;

// Initialize and add the map
//function initMap() {
//    // The location of Uluru
//    const uluru = { lat: -25.344, lng: 131.031 };
//    // The map, centered at Uluru
//    const map = new google.maps.Map(document.getElementById("map"), {
//        zoom: 4,
//        center: uluru,
//    });
//    // The marker, positioned at Uluru
//    const marker = new google.maps.Marker({
//        position: uluru,
//        map: map,
//    });
//}

//window.initMap = initMap;