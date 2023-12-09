function create(words) {

  const contentElement = document.getElementById("content");

  words.forEach((element) => {

    const newDiv = document.createElement("div");

    const newParagraph = document.createElement("p");

    newParagraph.textContent = element;

    newParagraph.style.display = "none";

    newDiv.appendChild(newParagraph);

    newDiv.addEventListener("click", onClick);

    contentElement.appendChild(newDiv);
    
    function onClick(e) {
      if (newParagraph.style.display === ''){
         newParagraph.style.display = 'none'
      }else{
         newParagraph.style.display = ''
      }
    }
  });
}  
