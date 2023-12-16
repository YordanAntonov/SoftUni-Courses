window.addEventListener("load", solve);

function solve() {
  let expenseInput = document.getElementById("expense");
  let amountInput = document.getElementById("amount");
  let dateInput = document.getElementById("date");

  const addBtn = document.getElementById("add-btn");

  //UL ITEM
  let previewList = document.getElementById("preview-list");
  let expensesList = document.getElementById("expenses-list");

  addBtn.addEventListener("click", addExpense);

  function addExpense(e) {
    e.preventDefault();

    if (expenseInput.value === "" ||
        amountInput.value === ""      ||
        dateInput.value === ""){
        return;
    }


    let liItem = creatingLiItem(expenseInput.value, amountInput.value, dateInput.value);

    let btnDiv = document.createElement("div");
    btnDiv.classList.add("buttons");

    //edit btn
    let editBtn = document.createElement('button');
    editBtn.classList.add("btn");
    editBtn.classList.add("edit");
    editBtn.textContent = "Edit";

    btnDiv.appendChild(editBtn);

    editBtn.addEventListener("click", () => {

      let paragraphs = document.querySelectorAll('article p');

      let expense = paragraphs[0].textContent.split(": ")[1];
      expenseInput.value = expense;

      let amount = paragraphs[1].textContent.split(": ")[1];
      const extract = amount.match(/\d+/);
      const extractedNumber = extract ? extract[0] : null;
      amountInput.value = extractedNumber;

      let date = paragraphs[2].textContent.split(": ")[1];
      dateInput.value = date;

      previewList.removeChild(liItem);
      addBtn.disabled = false;
    })

    //ok btn
    let okbtn = document.createElement('button');
    okbtn.classList.add("btn");
    okbtn.classList.add("ok");
    okbtn.textContent = "ok";

    btnDiv.appendChild(okbtn);

    okbtn.addEventListener("click", () =>{

      let paragraphs = document.querySelectorAll('article p');

      let expense = paragraphs[0].textContent.split(": ")[1];

      let amount = paragraphs[1].textContent.split(": ")[1];
      const extract = amount.match(/\d+/);
      const extractedNumber = extract ? extract[0] : null;

      let date = paragraphs[2].textContent.split(": ")[1];

      let listItem = creatingLiItem(expense, extractedNumber, date);

      expensesList.appendChild(listItem);
      previewList.removeChild(liItem);

      addBtn.disabled = false;
    })


    //adding to main li
    liItem.appendChild(btnDiv);

    //appending to ul
    previewList.appendChild(liItem);

    addBtn.disabled = true;

    expenseInput.value = "";
    amountInput.value = "";
    dateInput.value = "";

  }

  let deleteBtn = document.querySelector('.delete');
  deleteBtn.addEventListener("click", () => {
    location.reload();
  });


  function creatingLiItem(expense, amount, date){

    let mainLiItem = document.createElement("li");
    mainLiItem.classList.add("expense-item");

    let article = document.createElement("article");

    let expenseP = document.createElement("p");
    expenseP.textContent = `Type: ${expense}`
    let amountP = document.createElement("p");
    amountP.textContent = `Amount: ${amount}$`
    let dateP = document.createElement("p");
    dateP.textContent = `Date: ${date}`;

    article.appendChild(expenseP);
    article.appendChild(amountP);
    article.appendChild(dateP);

    mainLiItem.appendChild(article);


    return mainLiItem;

  }
}
