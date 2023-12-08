function focused() {
  const divs = Array.from(document.getElementsByTagName("input"));

  divs.forEach((div) => {
    div.addEventListener("focus", onFocus);
    div.addEventListener("blur", onBlur);
  });

  function onFocus(e) {
    e.currentTarget.parentNode.classList.add("focused");
  }

  function onBlur(e) {
    e.currentTarget.parentNode.classList.remove("focused");
  }
}
