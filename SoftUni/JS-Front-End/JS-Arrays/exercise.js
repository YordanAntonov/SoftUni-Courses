//Task 1
function arrayRotation(arr, n) {
  for (let i = 0; i < n; i++) {
    let currNum = arr.shift();
    arr.push(currNum);
  }

  console.log(arr.join(" "));
}

// arrayRotation([51, 47, 32, 61, 21], 2);

//Task 2
function returnNumberOfElements(arr, n) {
  let arrLenght = arr.length;
  let newArr = [];
  for (let i = 0; i < arrLenght; i += n) {
    newArr.push(arr[i]);
  }

  return newArr;
}

// console.log(returnNumberOfElements(['5','20','31','4','20'],2))

//Task 3
function arrOfNames(arr) {
  let sortedArray = arr.sort((a, b) => {
    return a.localeCompare(b);
  });
  let i = 1;
  for (const name of sortedArray) {
    console.log(`${i}.${name}`);
    i++;
  }
}

// arrOfNames(["John", "Bob", "Christina", "Ema"]);

//Task 4
function sortingBigToSmall(arr) {
  let sortedArr = arr.sort((a, b) => a - b);

  let newArr = [];

  while (sortedArr.length > 0) {
    newArr.push(sortedArr.shift());
    if (sortedArr.length > 1) {
      newArr.push(sortedArr.pop());
    }
  }

  return newArr;
}

// console.log(sortingBigToSmall([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));

//Task 5
function revealWords(word, sentance) {
  let wordsArr = sentance.split(" ");
  let replacingWords = word.split(", ");

  for (let i = 0; i < replacingWords.length; i++) {
    for (let j = 0; j < wordsArr.length; j++) {
      let isValid =
        replacingWords[i].length === wordsArr[j].length &&
        wordsArr[j].includes("*");

      if (isValid) {
        wordsArr[j] = replacingWords[i];
      }
    }
  }

  console.log(wordsArr.join(" "));
}

// revealWords('great, learning','softuni is ***** place for ******** new programming languages');

//Task 6
function regex1(sentance) {
  let regex = /#[A-Za-z]+/gm;

  let matches = sentance.match(regex);

  for (let word of matches) {
    word = word.replace("#", "");
    console.log(word);
  }
}

// regex1("Nowadays everyone uses # to tag a #special word in #socialMedia");

//Task 7
function wordExist(word, sentance) {
  let wordsArray = sentance.toLowerCase().split(" ");
  let output = `${word} not found!`;

  for (let index = 0; index < wordsArray.length; index++) {
    let currentWord = wordsArray[index];

    if (currentWord === word) {
      output = currentWord;
    }
  }

  console.log(output);
}

// wordExist("aaa", "you live in the world of Javascript");

//Task 8
function pascalCase(sentance){
    let regex = /[A-Z][a-z]*/gm;

    let matches = sentance.match(regex);

    console.log(matches.join(", "));
}

pascalCase("SplitMeIfYouCanHaHaYouCantOrYouCan");
