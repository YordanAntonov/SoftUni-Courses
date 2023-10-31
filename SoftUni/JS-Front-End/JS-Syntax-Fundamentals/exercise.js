//Task 1

function solve(age) {
  let result = undefined;

  if (age >= 0 && age <= 2) {
    result = "baby";
  } else if (age > 2 && age <= 13) {
    result = "child";
  } else if (age > 13 && age <= 19) {
    result = "teenager";
  } else if (age > 19 && age <= 65) {
    result = "adult";
  } else if (age >= 66) {
    result = "elder";
  } else {
    result = "out of bounds";
  }

  console.log(result);
}

//Task 2

function price(num, group, day) {
  let price = undefined;

  switch (group) {
    case "Students":
      if (day === "Friday") {
        price = 8.45 * num;
      } else if (day === "Saturday") {
        price = 9.8 * num;
      } else if (day === "Sunday") {
        price = 10.46 * num;
      }
      if (num >= 30) {
        price = price - price * 0.15;
      }
      break;
    case "Business":
      if (day === "Friday") {
        price = 10.9 * num;
      } else if (day === "Saturday") {
        price = 15.6 * num;
      } else if (day === "Sunday") {
        price = 16 * num;
      }
      if (num >= 100) {
        price = price - 10 * (price / num);
      }
      break;

    case "Regular":
      if (day === "Friday") {
        price = 15 * num;
      } else if (day === "Saturday") {
        price = 20 * num;
      } else if (day === "Sunday") {
        price = 22.5 * num;
      }
      if (num >= 10 && num <= 20) {
        price = price - price * 0.05;
      }
      break;
  }

  console.log(`Total price: ${price.toFixed(2)}`);
}

// price(30, "Students", "Sunday");
// price(40, "Regular", "Saturday");

//Task 3
function leapYear(year) {
  let result = undefined;

  if (year % 4 === 0 && year % 100 !== 0) {
    result = "yes";
  } else if (year % 400 === 0) {
    result = "yes";
  } else {
    result = "no";
  }

  console.log(result);
}

// leapYear(1984);
// leapYear(2003);
// leapYear(4);

//Task 4
function loop(num1, num2) {
  let result = "";
  let sum = 0;

  for (let i = num1; i <= num2; i++) {
    result += `${i} `;
    sum += i;
  }

  console.log(result);
  console.log(`Sum: ${sum}`);
}

//  loop(5, 10);

//Task 5
function table(x) {
  for (let i = 1; i <= 10; i++) {
    console.log(`${x} X ${i} = ${x * i}`);
  }
}

// table(5);

//Task 6
function number(number) {
  let stringNum = String(number);
  let sum = 0;

  for (let i = 0; i < stringNum.length; i++) {
    sum += Number(stringNum[i]);
  }

  console.log(sum);
}

// number(245678);

//Task 7
function string(a, b, c) {
  console.log(`${a}${b}${c}`);
}

// string("a", "b", "c");

//Task 8

function reverse(a, b, c) {
  let string = `${a}${b}${c}`;
  let newString = "";

  for (let i = string.length - 1; i >= 0; i--) {
    newString += string[i] + ` `;
  }

  console.log(newString);
}

// reverse('a', 'b', 'c');

//Task 9

function priceCalc(product, weight, price) {
  let realWeight = weight / 1000;
  let sum = realWeight * price;

  console.log(
    `I need $${sum.toFixed(2)} to buy ${realWeight.toFixed(
      2
    )} kilograms ${product}.`
  );
}

// priceCalc(`orange`, 2500, 1.80);

//Task 10

function sameNumbers(number) {
  let numAsString = String(number);
  let isSame = true;
  let sum = 0;

  for (let i = 0; i < numAsString.length; i++) {
    if (i != numAsString.length - 1 && isSame) {
      if (numAsString[i] != numAsString[i + 1]) {
        isSame = false;
      }
    }
    sum += Number(numAsString[i]);
  }

  console.log(isSame);
  console.log(sum);
}

// sameNumbers(1234)

//Task 11
function speedLimit(speed, area) {
  let limit = 0;
  let status = "";

  switch (area) {
    case "motorway":
      limit = 130;
      break;
    case "interstate":
      limit = 90;
      break;
    case "city":
      limit = 50;
      break;
    case "residential":
      limit = 20;
      break;
  }

  let overLimit = Math.abs(speed - limit);

  if (speed <= limit) {
    console.log(`Driving ${speed} km/h in a ${limit} zone`);
  } else {
    if (overLimit <= 20) {
      status = `speeding`;
    } else if (overLimit <= 40) {
      status = `excessive speeding`;
    } else {
      status = `reckless driving`;
    }

    console.log(
      `The speed is ${overLimit} km/h faster than the allowed speed of ${limit} - ${status}`
    );
  }
}

// speedLimit(400, "city");

//Task 12
function cooking(num, ing1, ing2, ing3, ing4, ing5) {
  let number = Number(num);
  let ingArray = [ing1, ing2, ing3, ing4, ing5];

  for (let i = 0; i < ingArray.length; i++) {
    let currIng = ingArray[i];

    switch (currIng) {
      case "chop":
        number /= 2;
        break;
      case "dice":
        number = Math.sqrt(number, 2);
        break;
      case "spice":
        number += 1;
        break;
      case "bake":
        number *= 3;
        break;
      case "fillet":
        number *= 0.8;
        break;
    }

    console.log(number);
  }
}

// cooking('9', 'dice', 'spice', 'chop', 'bake','fillet');

//Bonus Task:
function gladiatus(fights, helmetP, swordP, shieldP, armorP) {
  let totalSum = 0;
  let shieldCounter = 0;

  for (let i = 1; i <= fights; i++) {
    if (i % 2 === 0) {
      totalSum += helmetP;
    }
    if (i % 3 === 0) {
      totalSum += swordP;
    }
    if (i % 2 === 0 && i % 3 === 0) {
      totalSum += shieldP;
      shieldCounter++;
      if (shieldCounter % 2 === 0 && shieldCounter != 0) {
        totalSum += armorP;
      }
    }
  }

  console.log(`Gladiator expenses: ${totalSum.toFixed(2)} aureus`);
}

gladiatus(23, 12.5, 21.5, 40, 200);
