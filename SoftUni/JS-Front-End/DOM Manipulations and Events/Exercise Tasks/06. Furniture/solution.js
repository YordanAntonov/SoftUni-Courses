function solve() {
  const generateBtn = document
    .getElementById("exercise")
    .getElementsByTagName("button")[0];
  generateBtn.addEventListener("click", generateFurniture);

  const buyBtn = document
    .getElementById("exercise")
    .getElementsByTagName("button")[1];
  buyBtn.addEventListener("click", buyFurniture);

  let totalSum = 0;
  let boughtFurniture = [];
  let avgDeco = 0;

  function generateFurniture(e) {
    let currentFurnitures = [];
    let getInfo = e.currentTarget.parentNode;
    let furnitureInfo = getInfo.getElementsByTagName("textarea")[0];

    if (!furnitureInfo.value) {
      return;
    }

    currentFurnitures = JSON.parse(furnitureInfo.value);

    for (const furniture of currentFurnitures) {
      let newTr = document.createElement("tr");
      let imageTd = document.createElement("td");
      let imageElement = document.createElement("img");
      imageElement.src = furniture["img"];
      imageTd.appendChild(imageElement);
      newTr.appendChild(imageTd);

      let nameP = document.createElement("p");
      nameP.textContent = furniture["name"];
      let priceP = document.createElement("p");
      priceP.textContent = furniture["price"];
      let decoFactorP = document.createElement("p");
      decoFactorP.textContent = furniture["decFactor"];

      let nameTd = document.createElement("td");
      nameTd.appendChild(nameP);
      let priceTd = document.createElement("td");
      priceTd.appendChild(priceP);
      let decoFactorTd = document.createElement("td");
      decoFactorTd.appendChild(decoFactorP);

      let markTd = document.createElement("td");
      let markElement = document.createElement("input");
      markElement.type = "checkbox";
      markElement.disabled = false;
      markTd.appendChild(markElement);

      newTr.appendChild(nameTd);
      newTr.appendChild(priceTd);
      newTr.appendChild(decoFactorTd);
      newTr.appendChild(markTd);

      getInfo.querySelector("tbody").appendChild(newTr);
    }
  }

  function buyFurniture(e) {
    let table = Array.from(
      document.querySelectorAll("tbody tr > td:nth-child(5) input")
    );
    let getInfo = e.currentTarget.parentNode;

    table.forEach((t) => {
      if (t.checked) {
        let currProductName =
          t.parentNode.parentNode.querySelector(
            "td:nth-child(2) p"
          ).textContent;
        let currProductPrice =
          t.parentNode.parentNode.querySelector(
            "td:nth-child(3) p"
          ).textContent;
        let currProductDeco =
          t.parentNode.parentNode.querySelector(
            "td:nth-child(4) p"
          ).textContent;

        boughtFurniture.push(currProductName);
        totalSum += Number(currProductPrice);
        avgDeco += Number(currProductDeco);
      }
    });

    let finalCheckout = getInfo.getElementsByTagName("textarea")[1];
    let finalSentance = `Bought furniture: ${boughtFurniture.join(
      ", "
    )}\nTotal price: ${totalSum.toFixed(2)}\nAverage decoration factor: ${
      avgDeco / (table.length - 1)
    }`;

    finalCheckout.value = finalSentance;
  }
}
