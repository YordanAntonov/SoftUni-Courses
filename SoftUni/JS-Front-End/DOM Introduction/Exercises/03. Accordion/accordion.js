function toggle() {
  let btn = document.getElementsByClassName("button")[0];
  let popUpText = document.getElementById("extra");
  if (btn.textContent === "More") {
    btn.textContent = "Less";
    popUpText.style.display = "block";
  } else {
    btn.textContent = "More";
    popUpText.style.display = "none";
  }
}
