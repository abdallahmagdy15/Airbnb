$(document).ready(function () {

    var guestvalue = $('#guestvalue').html();


    $('#add-btn-Adult').click(function (event) {
        // alert('aaaaa');
        var AdultValue = $('#Adult-value').html();

        AdultValue++;
        guestvalue++;
        $('#Adult-value').html(AdultValue);
        $('#guestvalue').html(guestvalue);
        event.stopPropagation();

    })

    $('#add-btn-Children').click(function (event) {
        var ChildrenValue = $('#Children-value').html();
        ChildrenValue++;
        guestvalue++;
        $('#Children-value').html(ChildrenValue);
        $('#guestvalue').html(guestvalue);
        event.stopPropagation();

    })

    $('#add-btn-Infants').click(function (event) {
        var InfantsValue = $('#Infants-value').html();
        InfantsValue++;
        $('#Infants-value').html(InfantsValue);
        $('#Infantsvalue').html(InfantsValue);
        event.stopPropagation();

    })


    $('#sub-btn-Adult').click(function (event) {
        var AdultValue = $('#Adult-value').html();
        if (AdultValue > 1) {
            guestvalue--;
            AdultValue--;
            $('#Adult-value').html(AdultValue);
            $('#guestvalue').html(guestvalue);
        }
        event.stopPropagation();
    })

    $('#sub-btn-Children').click(function (event) {
        var ChildrenValue = $('#Children-value').html();
        if (ChildrenValue > 0) {
            guestvalue--;
            ChildrenValue--;
            $('#Children-value').html(ChildrenValue);
            $('#guestvalue').html(guestvalue);
        }
        event.stopPropagation();
    })

    $('#sub-btn-Infants').click(function (event) {
        var InfantsValue = $('#Infants-value').html();
        if (InfantsValue > 0) {
            InfantsValue--;
            $('#Infants-value').html(InfantsValue);
        $('#Infantsvalue').html(InfantsValue);

        }
        event.stopPropagation();
    })



})

