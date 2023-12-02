function calc() {
  let firstNumber = Number(document.getElementById("num1").value);
  let secondNumber = Number(document.getElementById("num2").value);

  let result = document.getElementById("sum");

  console.log(firstNumber);
  console.log(secondNumber);
  console.log(result);

  result.value = String(firstNumber + secondNumber);
}
