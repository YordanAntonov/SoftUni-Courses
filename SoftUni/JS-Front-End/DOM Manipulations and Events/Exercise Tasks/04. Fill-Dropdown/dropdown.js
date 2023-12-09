function addItem() {
    const dropDownMenu = document.getElementById('menu');
    const itemText = document.getElementById('newItemText');
    const itemValue = document.getElementById('newItemValue');

    const newItem = document.createElement('option');

    newItem.value = itemValue.value;
    newItem.text = itemText.value;

    dropDownMenu.appendChild(newItem);

    itemText.value = '';
    itemValue.value = '';
}