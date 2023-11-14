//Task 1
function smallestNumber(a, b, c) {
  let array = [a, b, c];

  let result = Math.min(...array);

  console.log(result);
}

// smallestNumber(1, 5, 10)

//Task 2
function addSubtract(n1, n2, n3) {
  console.log(subtract(n3, add(n1, n2)));

  function add(n1, n2) {
    return n1 + n2;
  }

  function subtract(n3, n4) {
    return n4 - n3;
  }
}

// addSubtract(1, 17, 30);

//Task 3
function charInRange(char1, char2) {
  let ch1 = char1.charCodeAt();
  let ch2 = char2.charCodeAt();
  let arr = [];

  let index = Math.min(ch1, ch2) + 1;
  let length = Math.max(ch1, ch2);

  for (let i = index; i < length; i++) {
    arr.push(String.fromCharCode(i));
  }

  console.log(arr.join(" "));
}

// charInRange('a', 'g');

//Task 4
function oddEvenSum(number) {
  let str = String(number).split("");
  let oddSum = 0;
  let evenSum = 0;

  for (let i = 0; i < str.length; i++) {
    let currNum = Number(str[i]);
    if (currNum % 2 === 0) {
      evenSum += currNum;
    } else {
      oddSum += currNum;
    }
  }

  console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}

// oddEvenSum(100435)

//Task 5

function palindrome(arr) {
  function isPalidrome(num) {
    let numAsString = num.toString();
    let reversedNum = numAsString.split("").reverse().join("");

    return numAsString === reversedNum;
  }

  for (let i = 0; i < arr.length; i++) {
    console.log(isPalidrome(arr[i]));
  }
}

// palindrome([123, 323, 421, 121]);

//Task 6
function passwordValidator(pass) {
  if (!validateLength(pass)) {
    console.log("Password must be between 6 and 10 characters");
  }
  if (!validateLettersAndDigits(pass)) {
    console.log("Password must consist only of letters and digits");
  }
  if (!validateDigits(pass)) {
    console.log("Password must have at least 2 digits");
  }

  if (
    validateDigits(pass) &&
    validateLettersAndDigits(pass) &&
    validateLength(pass)
  ) {
    console.log("Password is valid");
  }

  function validateLettersAndDigits(pass) {
    let regex = /^[a-zA-Z0-9]+$/gm;
    let isCorrect = regex.test(pass);

    return isCorrect;
  }

  function validateLength(pass) {
    return pass.length >= 6 && pass.length <= 10;
  }

  function validateDigits(pass) {
    let count = 0;

    for (const digit of pass) {
      if (!isNaN(digit)) {
        count++;
      }
    }

    return count >= 2;
  }
}

// passwordValidator("Pa$s$s");

//Task 7
function matrix(n) {
  function printRow(num) {
    return (num.toString() + ` `).repeat(num);
  }

  for (let i = 1; i <= n; i++) {
    console.log(printRow(n));
  }
}

// matrix(3);

//Task 8
function perfNum(number) {
  let sum = 0;

  for (let i = 1; i < number; i++) {
    if (number % i === 0) {
      sum += i;
    }
  }

  if (sum === number) {
    console.log(`We have a perfect number!`);
  } else {
    console.log("It's not so perfect.");
  }
}

// perfNum(6)

//Task 9
function loadingBar(prc) {
  if (prc === 100) {
    console.log("100% Complete!");
  } else {
    let realNum = prc / 10;

    let percentages = "%".repeat(realNum);
    let dots = ".".repeat(10 - realNum);

    let finalResult = `${prc}% [${percentages}${dots}] \nStill loading...`;

    console.log(finalResult);
  }
}

// loadingBar(100);

//Task 10
function factorial(n1, n2) {
  function getFactoriel(num) {
    let result = 1;
    for (let i = 1; i < num; i++) {
      result += result * i;
    }

    return result;
  }

  console.log((getFactoriel(n1) / getFactoriel(n2)).toFixed(2));
}

factorial(6, 2)
