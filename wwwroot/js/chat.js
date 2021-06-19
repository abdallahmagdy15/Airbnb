import TimeAgo from 'javascript-time-ago'
// English.
import en from 'javascript-time-ago/locale/en'

TimeAgo.addDefaultLocale(en)

// Create formatter (English).
const timeAgo = new TimeAgo('en-US')


console.log("ssss")
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

async function start() {
    try {
        await connection.start();
        console.log("chat hub Connected.");
        try {
            await connection.invoke("join_chat", "@Model.Chat.ChatId");
        } catch (err) {
            console.error(err);
        }
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

connection.onclose(start);

// Start the connection.
start();

connection.on("new_message", function (msg) {
    console.log("New Message : ", msg);
    addMsgToList(msg);
});
connection.on("removed_message", function (_messageId) {
    console.log(_messageId);
});

$('#send-btn').click(function () {
    console.log("clicked");
    connection.invoke("send_message", '@Model.Chat.ChatId', $('#text').val());
});


function addMsgToList(msg) {
    var newMsg = `<li class="msg-item">
                    <span class="dimmed-sm-label">${timeAgo.format(new Date(msg.dateTime))}</span>
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