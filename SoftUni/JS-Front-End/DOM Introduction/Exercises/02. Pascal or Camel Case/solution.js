function solve() {
  let text = document.getElementById("text").value.toLowerCase();
  let namingCase = document.getElementById("naming-convention").value;
  let result = document.getElementById("result");

  let sentance = text.split(" ");
  let resultSentance = [];
  if (namingCase === "Camel Case") {
    resultSentance.push(sentance[0]);

    for (let index = 1; index < sentance.length; index++) {
      resultSentance.push(
        sentance[index].charAt(0).toUpperCase() + sentance[index].slice(1)
      );
    }

    result.textContent = resultSentance.join("");
  } else if (namingCase === "Pascal Case") {
    for (let index = 0; index < sentance.length; index++) {
      resultSentance.push(
        sentance[index].charAt(0).toUpperCase() + sentance[index].slice(1)
      );
    }

    result.textContent = resultSentance.join("");
  }else{
    result.textContent = "Error!"
  }
}
