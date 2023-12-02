function extractText() {
    let elements = [];
    let listElementsNode = Array.from(document.querySelectorAll("li")).forEach(
    (element) => {
      elements.push(element.textContent);
    }
  );
  let resultElement = document.getElementById("result");
  resultElement.textContent = elements.join("\n");
}
