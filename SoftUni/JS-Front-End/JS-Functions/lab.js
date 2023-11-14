//Task 1
function grade(grade) {
  let option = "";

  if (grade < 3) {
    option = "Fail (2)";
  } else if (grade < 3.5) {
    option = `Poor (${grade.toFixed(2)})`;
  } else if (grade < 4.5) {
    option = `Good (${grade.toFixed(2)})`;
  } else if (grade < 5.5) {
    option = `Very good (${grade.toFixed(2)})`;
  } else {
    option = `Excellent (${grade.toFixed(2)})`;
  }

  console.log(option);
}

// grade(3.33);

//Task 2
function powerUp(number, power) {
  console.log(Math.pow(number, power));
}

// powerUp(3, 4);

//Task 3
function repeat(word, n) {
  console.log(word.repeat(n));
}

// repeat("String", 2);

//Task 4
function orders(product, n){
    let total = 0;

    switch (product){
        case "coffee": total = n * 1.50; break;
        case "water": total = n * 1.00; break;
        case "coke": total = n * 1.40; break;
        case "snacks": total = n * 2.00; break;
    }

    console.log(total.toFixed(2));
}

// orders("water", 5)

//Task 5
function mathOperations(x, y, operator){
  const operation = {
    multiply: (x, y) => x * y,
    divide: (x, y) => x / y,
    add: (x, y) => x + y,
    subtract: (x, y) => x - y,
  };

  console.log(operation[operator](x, y));
}

// mathOperations(5, 5,'add')

//Task 6
function checkIfPositive(num1, num2, num3){
  let result = num1 * num2 * num3;

  let print = result > 0 ? "Positive" : "Negative";

  console.log(print);
}

checkIfPositive(-200, -2, -3);