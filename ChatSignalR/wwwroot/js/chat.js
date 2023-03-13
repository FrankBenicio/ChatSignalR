"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var userName = document.getElementById("userName").value;
    var html = document.getElementById("messagesList");
    console.log(user);
    const hoje = new Date();
    var img = user === "Anne Caroline" ? '<img src="https://bootdey.com/img/Content/avatar/avatar3.png" class="rounded-circle mr-1" alt="Chris Wood" width="40" height="40">' : '<img src="https://bootdey.com/img/Content/avatar/avatar1.png" class="rounded-circle mr-1" alt="Chris Wood" width="40" height="40">';

    var classPosition = user === userName ? 'chat-message-right pb-4' : 'chat-message-left pb-4';

    html.innerHTML += ' <div class="' + classPosition + '"><div>' + img + '<div class="text-muted small text-nowrap mt-2">' + hoje.getHours() + ':' + hoje.getMinutes() + '</div></div><div class="flex-shrink-1 bg-light rounded py-2 px-3 mr-3"><div class="font-weight-bold mb-1">' + user + '</div>' + message + '</div> </div > ';

});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var userName = document.getElementById("userName").value;
    var message = document.getElementById("messageInput").value;
    console.log(userName);
    connection.invoke("SendMessage", userName, message).catch(function (err) {
        return console.error(err.toString());
    });
    var message = document.getElementById("messageInput").value = '';
    event.preventDefault();
});