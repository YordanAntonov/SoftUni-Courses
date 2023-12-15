function attachEvents() {
  const mainUrl = "http://localhost:3030/jsonstore/messenger";

  const sendBtn = document.getElementById("submit");
  const refreshBtn = document.getElementById("refresh");

  sendBtn.addEventListener("click", sendMsg);

  async function sendMsg() {
    let authorForObj = document.querySelector("input[name = author]");
    let contentForObj = document.querySelector("input[name = content]");

    const msgObj = {
      author: authorForObj.value,
      content: contentForObj.value,
    };

    let messageNotEmpty =
      authorForObj.value !== "" && contentForObj.value !== "";
    if (messageNotEmpty) {
      await fetch(mainUrl, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(msgObj),
      });

      authorForObj.value = "";
      contentForObj.value = "";
    }
  }

  refreshBtn.addEventListener("click", refreshMsg);

  async function refreshMsg() {
    let textarea = document.getElementById("messages");

    textarea.textContent = "";

    const requestMsg = await fetch(mainUrl);
    const msgCollection = await requestMsg.json();

    let allMessages = [];

    for (const msgObj of Object.values(msgCollection)) {
      let curntMsg = `${msgObj.author}: ${msgObj.content}`;
      allMessages.push(curntMsg);
    }

    textarea.textContent = allMessages.join("\n");
  }
}

attachEvents();
