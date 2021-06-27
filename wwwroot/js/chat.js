var msgsDates = $('.datetime')
for (const x of msgsDates) {
    console.log($(x).text());
    console.log(moment(new Date($(x).text()), "YYYYMMDD").fromNow());
    $(x).text(moment(new Date($(x).text()), "YYYYMMDD").fromNow())
}

function addMsgToList(msg) {
    console.log(msg.dateTime);
    var new_msg = `<li class="clearfix">
                    <div class="message-data align-right">
                 <span class="dimmed-sm-label datetime">${moment(new Date(msg.dateTime), "YYYYMMDD").fromNow()}</span>
                        &nbsp; &nbsp;
                    <span class="message-data-name">${msg.firstName}</span> <i class="fa fa-circle me"></i>
                    </div>
                    <div class="message other-message float-right">
                        ${msg.text}
                    </div>
                </li>`;
    $('#chatCr').append(new_msg);
}