

function addMsgToList(msg) {
    var newMsg = `<li class="msg-item">
                    <span class="dimmed-sm-label">${new Date(msg.dateTime)}</span>
                <div class="img-cr">
                    <img src="~/images/${msg.User.photoUrl}" class="rounded-circle" />
                </div>
                <div class="msg-details">
                    <div class="row">
                        <label class="name-sm-label">${msg.User.firstName}</label>
                    </div>
                    <div class="row">
                        <p class="normal-text font-weight-bold">${msg.Text}</p>
                    </div>
                </div>
            </li>`;
    $('#chatCr').append(newMsg);

}