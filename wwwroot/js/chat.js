var msgsDates = $('.msg-item span:first-child')
for (const x of msgsDates) {
    console.log($(x).text());
    console.log(moment($(x).text(), "YYYYMMDD").fromNow());
    $(x).text(moment($(x).text(), "YYYYMMDD").fromNow())
}

function addMsgToList(msg) {
    var newMsg = `<li class="msg-item">
                    <span class="dimmed-sm-label">${moment(new Date(msg.dateTime), "YYYYMMDD").fromNow()}</span>
                <div class="img-cr">
                    <img src="~/images/${msg.photoUrl ? msg.photoUrl :'default_dp.jpg'}" class="rounded-circle" />
                </div>
                <div class="msg-details">
                    <div class="row">
                        <label class="name-sm-label">${msg.firstName}</label>
                    </div>
                    <div class="row">
                        <p class="normal-text font-weight-bold">${msg.text}</p>
                    </div>
                </div>
            </li>`;
    $('#chatCr').append(newMsg);

}