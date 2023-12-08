function search() {
   let search = document.getElementById("searchText").value;
   let listElements = document.querySelectorAll('li');
   let result = document.getElementById("result");
   let numOfMatches = 0;

   for (const li of listElements) {
      li.style.fontWeight = "";
      li.style.textDecoration = "";

      if (li.textContent.includes(search)){
         numOfMatches++;
         li.style.fontWeight = "bold";
         li.style.textDecoration = "underline";
      }
   }

   result.textContent = `${numOfMatches} matches found`;
}
