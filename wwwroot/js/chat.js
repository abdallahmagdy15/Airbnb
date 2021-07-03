function addMsgToList(msg) {
    console.log(msg.text + " , isMine? " , msg.UserId == currUserId);
    var new_msg = `<li class="clearfix">
                    <div class="message-data ${msg.userId == currUserId ? 'align-right' : ''}">
                 <span class="dimmed-sm-label datetime">${moment(new Date(msg.dateTime), "YYYYMMDD").fromNow()}</span>
                        &nbsp; &nbsp;
                    <span class="message-data-name">${msg.firstName}</span> <i class="fa fa-circle me"></i>
                    </div>
                    <div class="message ${msg.userId == currUserId ?'my-message float-right':'other-message'}">
                        ${msg.text}
                    </div>
                </li>`;
    $('#chatCr').append(new_msg);
    $('#chat-history').animate({ scrollTop: $('#chatCr').height() }, 300);
}