function HomeControl(controlDiv, map) {
    google.maps.event.addDomListener($("#btn-map-zoomout").get()[0], 'click', function () {
        var currentZoomLevel = map.getZoom();
        if (currentZoomLevel != 0) {
            map.setZoom(currentZoomLevel - 1);
        }
    });

    google.maps.event.addDomListener($("#btn-map-zoomin").get()[0], 'click', function () {
        var currentZoomLevel = map.getZoom();
        if (currentZoomLevel != 21) {
            map.setZoom(currentZoomLevel + 1);
        }
    });

    console.log($("#btn-map-zoomin").get());
}

function initMap() {
    let initialLocation;
    
    // The current location
    const uluru = { lat: -25.344, lng: 131.036 };
    // The map, centered at Uluru
    const map = new google.maps.Map(document.getElementById("map"), {
        zoom: 7,
        disableDefaultUI: true,
    });

    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition((position) => {
            initialLocation = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
            map.setCenter(initialLocation);
            const marker = new google.maps.Marker({
                position: initialLocation,
                map: map,
            });
        });
    }

    // The marker, positioned at Uluru
    

    var homeControlDiv = document.createElement('div');
    var homeControl = new HomeControl(homeControlDiv, map);
}

$("#btn-fold-map").hide();

$(".checkbox-input").on("change", (e) => {
    let box = $(e.target);
    box.siblings(".checkbox-visual").toggleClass("checkbox-visual-checked")
    if (box.attr("checked")) {
        box.attr("checked", false);
    } else {
        box.attr("checked", true);
    }
});

$("#btn-unfold-map").click((e) => {
    $(e.currentTarget).hide();
    $("#btn-fold-map, #btn-filter-map").show();
    $("#map-wrapper").css({
        width: "100vw",
    });
    $("#main-wrapper").css({
        transform: "translateX(-59%)",
    });
});
$("#btn-fold-map").click((e) => {
    $(e.currentTarget).hide();
    $("#btn-filter-map").hide();
    $("#btn-unfold-map").show();
    $("#main-wrapper").css({
        transform: "translateX(-0%)",
    });
    $("#map-wrapper").css({
        width: "40vw",
    });
});