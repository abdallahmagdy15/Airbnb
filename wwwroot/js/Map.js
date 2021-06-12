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
        width: "99vw",
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