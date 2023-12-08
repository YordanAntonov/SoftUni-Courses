function addItem() {
  const addItem = document.getElementById("newItemText");
  const newElement = document.createElement("li");
  newElement.textContent = addItem.value;

  const deleteLink = document.createElement("a");
  deleteLink.href = '#';
  deleteLink.textContent = "[Delete]";
  deleteLink.addEventListener("click", deleteItem);

  newElement.appendChild(deleteLink);

  const list = document.getElementById("items");
  list.appendChild(newElement);

  addItem.value = "";
}

function deleteItem(e) {
    let currRow = e.currentTarget.parentNode;
    currRow.remove(); 
  }
