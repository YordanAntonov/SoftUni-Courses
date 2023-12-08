function addItem() {
    const inputItem = document.getElementById('newItemText');
    let newElement = document.createElement('li');
    newElement.textContent = inputItem.value;
    const ulElement = document.getElementById('items');
    ulElement.appendChild(newElement);

    inputItem.value = '';
}