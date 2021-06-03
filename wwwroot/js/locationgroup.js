$('.carousel > a').hide();
$('.small-card, .big-card').mouseenter((e) => {
    $(e.currentTarget).find('.carousel > a').show();
});
$('.small-card, .big-card').mouseleave((e) => {
    $(e.currentTarget).find('.carousel > a').hide();
});

$('.carousel').carousel({
    interval: false,
});
$(".group-actions .btn-circle-direction, #popular-locations .btn-circle-direction").on("click", (e) => {
    var itemsId = $(e.currentTarget).attr('data-target');
    var direction = $(e.currentTarget).attr('aria-label');

    var items = document.getElementById(itemsId);

    var media = window.matchMedia('(min-width: 1200px)');

    var max;

    if (media.matches) {
        max = 100;
    }
    else {
        max = 200;
    }

    if (items.style.transform == `translate(-${max}%)`) {
        if (direction == 'next') {
            items.style.transform = `translate(0%)`;
        } else {
            if (items.style.transform == `translate(-100%)`) {
                items.style.transform = `translate(0%)`;
            } else {
                items.style.transform = `translate(-100%)`;
            }
        }
    }
    else {
        if (items.style.transform == `translate(-100%)`) {
            if (direction == 'next') {
                items.style.transform = `translate(-200%)`;
            } else {
                items.style.transform = `translate(0%)`;
            }
        } else {
            if (direction == 'next') {
                items.style.transform = `translate(-100%)`;
            } else {
                items.style.transform = `translate(-${max}%)`;
            }
        }
    }
});