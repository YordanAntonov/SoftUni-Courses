function encodeAndDecodeMessages() {
  
  const encodeBtn = document
    .querySelectorAll("button")[0]
    .addEventListener("click", encodeMsg);
  const decodeBtn = document
    .querySelectorAll("button")[1]
    .addEventListener("click", decodeMsg);

    function encodeMsg(e) {
        const encodeText =
          e.currentTarget.parentNode.getElementsByTagName("textarea")[0];
      
        if (encodeText.value !== "") {
          let encodedMsg = "";
      
          for (let i = 0; i < encodeText.value.length; i++) {
            let currLetter = String.fromCharCode(
              encodeText.value[i].charCodeAt(0) + 1
            );
            encodedMsg += currLetter;
          }
      
          const decodedText = document.querySelectorAll("textarea")[1];
          decodedText.value = encodedMsg;
          encodeText.value = "";
          document.querySelectorAll("button")[1].disabled = false;
        }
      }
      
      function decodeMsg(e) {
        const decodeText =
          e.currentTarget.parentNode.getElementsByTagName("textarea")[0];
      
        let decodedMessage = "";
      
        for (let i = 0; i < decodeText.value.length; i++) {
          let currLetter = String.fromCharCode(decodeText.value[i].charCodeAt(0) - 1);
          decodedMessage += currLetter;
        }
      
        decodeText.value = decodedMessage;
        e.currentTarget.disabled = true;
      }
}


