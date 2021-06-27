var msgsDates = $('.msg-item span:first-child')
for (const x of msgsDates) {
    console.log($(x).text());
    console.log(moment($(x).text(), "YYYYMMDD").fromNow());
    $(x).text(moment($(x).text(), "YYYYMMDD").fromNow())
}

function addMsgToList(msg) {
    var ticks = (((new Date(msg.dateTime)).getTime() * 10000) + 621355968000000000);
    var newMsg = `<li class="msg-item">
                    <span class="dimmed-sm-label">${moment(ticks, "YYYYMMDD").fromNow()}</span>
                <div class="img-cr">
                    <img src="~/images/${msg.photoUrl}" class="rounded-circle" />
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