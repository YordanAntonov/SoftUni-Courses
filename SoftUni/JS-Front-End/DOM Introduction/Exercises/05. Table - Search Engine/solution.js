function solve() {
  document.querySelector("#searchBtn").addEventListener("click", onClick);

  let rows = document.querySelectorAll("tbody tr");
  let search = document.getElementById("searchField");

  function onClick() {
    for (const row of rows) {
      row.classList.remove('select');
       if(search.value !== "" && row.innerHTML.includes(search.value)){
         row.className = 'select';
       }
    }

     search.value = '';
  }
}
