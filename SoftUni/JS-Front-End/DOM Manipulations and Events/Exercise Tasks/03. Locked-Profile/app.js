function lockedProfile() {
  const buttons = Array.from(document.getElementsByTagName("button"));
  buttons.forEach((btn) => {
    btn.addEventListener("click", getInfo);
  });

  function getInfo(e) {
    const lockBtn = e.currentTarget.parentNode.getElementsByTagName("input")[0];

    const currBtn = e.currentTarget;

    const additionalInfo = e.currentTarget.parentNode.querySelector("div");

    if (lockBtn.checked) {
      return;
    }

    if (currBtn.textContent === "Show more") {
      additionalInfo.style.display = "block";
      currBtn.textContent = "Hide it";
    } else {
      additionalInfo.style.display = "";
      currBtn.textContent = "Show more";
    }
  }
}
