//Task 1

function sumArray(arr) {
  let first = arr[0];
  let last = arr[arr.length - 1];

  console.log(first + last);
}

// sumArray([20, 30, 40]);

//Task 2

function reverseArray(n, arr) {
  let newArr = [];
  for (let i = 0; i < n; i++) {
    newArr[i] = arr[i];
  }
  newArr.reverse();
  console.log(newArr.join(" "));
}

// reverseArray(3, [10, 20, 30, 40, 50]);

//Task 3

function evenOddSum(arr) {
  let oddSum = 0;
  let evenSum = 0;

  for (let i = 0; i < arr.length; i++) {
    if (arr[i] % 2 === 0) {
      evenSum += arr[i];
    } else {
      oddSum += arr[i];
    }
  }

  let result = evenSum - oddSum;

  console.log(result);
}

// evenOddSum([3,5,7,9]);

//Task 4

function substring(string, ...args) {
  let sub = string.substring(args[0], args[0] + args[1]);

  console.log(sub);
}

// substring('SkipWord', 4, 7);

//Task 5

function censoringWord(sentance, word) {
  const regex = new RegExp(word, "g");
  const replacement = "*".repeat(word.length);
  console.log(sentance.replace(regex, replacement));
}

// censoringWord('Find the hidden word', 'hidden')

//Task 6

function solve(text, search) {
  let splitted = text.split(" ");
  let count = 0;

  for (let i = 0; i < splitted.length; i++) {
    if (splitted[i] === search) {
      count++;
    }
  }

  console.log(count);
}

solve('This is a word and it also is a sentence','is');
