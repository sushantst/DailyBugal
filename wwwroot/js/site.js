const connection = new signalR.HubConnectionBuilder()
    .withUrl("/ChatHub")
    .build();

connection.start().catch(err => console.error(err.toString()));

document.addEventListener("DOMContentLoaded", function () {
    const sendBtn = document.getElementById("sendComment");
    if (sendBtn) {
        sendBtn.addEventListener("click", function () {
            const messageInput = document.getElementById("message");
            const username = "Anonymous"; // Replace with real username if you have auth

            if (messageInput) {
                const message = messageInput.value.trim();
                if (message) {
                    connection.invoke("SendComment", username, message).catch(err => console.error(err.toString()));
                    messageInput.value = ""; // clear textarea
                }
            }
        });
    }
});

connection.on("ReceiveComment", function (username, message, time) {
    const commentsList = document.getElementById("commentsList");
    if (!commentsList) return;

    const li = document.createElement("li");
    li.className = "list-group-item";
    li.innerHTML = `<strong>${username}</strong> [${time}]: ${message}`;
    commentsList.appendChild(li);
});
