window.addEventListener("load", solve);

function solve() {
  const playerNameInput = document.getElementById("player");
  const scoreInput = document.getElementById("score");
  const roundInput = document.getElementById("round");

  const addBtn = document.getElementById('add-btn');
  addBtn.addEventListener('click', addToList);

  const ulElement = document.getElementById('sure-list');
  const scoreBoardUl = document.getElementById('scoreboard-list');

  function addToList(e){
    e.preventDefault();

    if (
      playerNameInput.value === "" ||
      scoreInput.value === "" ||
      roundInput.value === ""
    ) {
      return;
    }

    let liItem = createLiItem(playerNameInput.value, scoreInput.value, roundInput.value);

    let editBtn = document.createElement('button');
    editBtn.classList.add('btn');
    editBtn.classList.add('edit');
    editBtn.textContent = 'Edit';

    editBtn.addEventListener('click', editEntry);

    function editEntry(){
      let paragraphs = document.querySelectorAll('article p');
      playerNameInput.value = paragraphs[0].textContent;
      let score = paragraphs[1].textContent.split(": ")[1];
      scoreInput.value = score;
      let rounds = paragraphs[2].textContent.split(": ")[1];
      roundInput.value = rounds;

      ulElement.removeChild(liItem);
      addBtn.disabled = false;
    }

    let okBtn = document.createElement('button');
    okBtn.classList.add('btn');
    okBtn.classList.add('ok');
    okBtn.textContent = 'Ok';

    okBtn.addEventListener('click', addToScoreboard);

    function addToScoreboard(){
      let paragraphs = document.querySelectorAll('article p');
      let name = paragraphs[0].textContent;
      let score = paragraphs[1].textContent.split(": ")[1];
      let rounds = paragraphs[2].textContent.split(": ")[1];

      let list = createLiItem(name, score, rounds);
      scoreBoardUl.appendChild(list);
      ulElement.removeChild(liItem);

      addBtn.disabled = false;
    }

    liItem.appendChild(editBtn);
    liItem.appendChild(okBtn);

    ulElement.appendChild(liItem);

    playerNameInput.value = "";
    scoreInput.value = "";
    roundInput.value = "";

    addBtn.disabled = true;
  }

  function createLiItem(nameValue, scoreValue, roundValue){
    let liDartItem = document.createElement('li');
    liDartItem.classList.add('dart-item');
    
    let articleElement = document.createElement('article');

    let namePara = document.createElement('p');
    namePara.textContent = nameValue;

    let scorePara = document.createElement('p');
    scorePara.textContent = `Score: ${scoreValue}`;

    let roundPara = document.createElement('p');
    roundPara.textContent = `Round: ${roundValue}`;

    articleElement.appendChild(namePara);
    articleElement.appendChild(scorePara);
    articleElement.appendChild(roundPara);

    liDartItem.appendChild(articleElement);

    return liDartItem;
  }

  let clearBtn = document.querySelector('.clear');
  clearBtn.addEventListener('click', () =>{
    location.reload();
  });

}
