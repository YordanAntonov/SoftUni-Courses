function deleteByEmail() {
  const inputElement = document.querySelector("label input");
  const tableRows = Array.from(
    document.querySelectorAll("tr > td:nth-child(2)")
  );
  let isDeleted = false;

  tableRows.forEach((row) => {
    if (inputElement.value === row.textContent){
        let currentRow = row.parentNode;
        currentRow.parentNode.removeChild(currentRow);
        isDeleted = true;
    }
  });

  const result = document.getElementById('result');

  if (isDeleted){
    result.textContent = 'Deleted.';
  }else{
    result.textContent = 'Not found.';
  }
  
  inputElement.value = '';
}