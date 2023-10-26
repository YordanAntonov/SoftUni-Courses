//Task 1
function numberMultipliedByTwo(num) {
  console.log(num * 2);
}

// numberMultipliedByTwo(2);
// numberMultipliedByTwo(5);
// numberMultipliedByTwo(20);

//Task 2
function studentInfo(name, age, grade) {
  let info = `Name: ${name}, Age: ${age}, Grade: ${grade.toFixed(2)}`;
  console.log(info);
}

// studentInfo('John', 15, 5.54678);
// studentInfo('Steve', 16, 2.1426);
// studentInfo('Marry', 12, 6.00);

//Task 3
function excellent(num) {
  let score = undefined;

  if (num >= 5.5) {
    console.log(`Excellent`);
  } else {
    console.log(`Not excellent`);
  }
}

// excellent(5.50);
// excellent(6);
// excellent(4.35);
// excellent(5.49);
// excellent(10);

//Task 4
function solve(num) {
  let month = undefined;

  switch (num) {
    case 1:
      month = "January";
      break;
    case 2:
      month = "February";
      break;
    case 3:
      month = "March";
      break;
    case 4:
      month = "April";
      break;
    case 5:
      month = "May";
      break;
    case 6:
      month = "June";
      break;
    case 7:
      month = "July";
      break;
    case 8:
      month = "August";
      break;
    case 9:
      month = "September";
      break;
    case 10:
      month = "October";
      break;
    case 11:
      month = "November";
      break;
    case 12:
      month = "December";
      break;
    default:
      month = "Error!";
      break;
  }

  console.log(month);
}

// solve(2);
// solve(13);
// solve(54);

//Task 5
function solve(num1, num2, opr) {
  let result = undefined;

  switch (opr) {
    case "+":
      result = num1 + num2;
      break;
    case "-":
      result = num1 - num2;
      break;
    case "*":
      result = num1 * num2;
      break;
    case "/":
      result = num1 / num2;
      break;
    case "%":
      result = num1 % num2;
      break;
    case "**":
      result = num1 ** num2;
      break;
  }

  console.log(result);
}

// solve(5, 6, '+');
// solve(3, 5.5, '*');
// solve(2, 2, '%');

//Task 6
function solve(num1, num2, num3) {
  console.log(`The largest number is ${Math.max(num1, num2, num3)}.`);
}

// solve(1, 2, 3);

//Task 7
function solve(day, age) {
  let result = undefined;

  if (day === "Weekday") {
    if (age >= 0 && age <= 18) {
      result = "12$";
    } else if (age > 18 && age <= 64) {
      result = "18$";
    } else if (age > 64 && age <= 122) {
      result = "12$";
    }
  } else if (day === "Weekend") {
    if (age >= 0 && age <= 18) {
      result = "15$";
    } else if (age > 18 && age <= 64) {
      result = "20$";
    } else if (age > 64 && age <= 122) {
      result = "15$";
    }
  } else if (day === "Holiday") {
    if (age >= 0 && age <= 18) {
      result = "5$";
    } else if (age > 18 && age <= 64) {
      result = "12$";
    } else if (age > 64 && age <= 122) {
      result = "10$";
    }
  }

  if (!result) {
    result = "Error!";
  }

  console.log(result);
}

// solve("Weekday", 42);
// solve("Holiday", -12);
// solve("Holiday", 15);
// solve("Weekend", 123);

//Task 8
function solve(num) {
  if (typeof num !== "number") {
    console.log(
      `We can not calculate the circle area, because we receive a ${typeof num}.`
    );
  } else {
    console.log((Math.pow(num, 2) * Math.PI).toFixed(2));
  }
}

// solve(5);

//Task 9
function solve(){
    for (let index = 1; index <= 5; index++) {      
        console.log(index);
    };
}

// solve();

//Task 10
function solve(num1, num2){
    for (let i = num1; i >= num2; i--) {
        console.log(i)
    };
};

// solve(4, 1);