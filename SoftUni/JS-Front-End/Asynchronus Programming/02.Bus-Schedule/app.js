function solve() {
  const departBtn = document.getElementById("depart");
  const arriveBtn = document.getElementById("arrive");

  const infoTable = document.getElementById("info");

  const mainUrl = `http://localhost:3030/jsonstore/bus/schedule/`;
  let nextStopId = `depot`;
  let currentStopName = "";

  async function depart() {
    try {
      const response = await fetch(mainUrl + nextStopId);
      const stopInfo = await response.json();

      currentStopName = stopInfo.name;
      nextStopId = stopInfo.next;

      infoTable.textContent = `Next stop is ${currentStopName}`;

      //   btnSwitch();
      departBtn.disabled = true;
      arriveBtn.disabled = false;

    } catch (error) {
      infoTable.textContent = `Error`;
      departBtn.disabled = true;
      arriveBtn.disabled = true;
    }
  }

  function arrive() {
    infoTable.textContent = `Arriving at ${currentStopName}`;
    // btnSwitch();
    departBtn.disabled = false;
    arriveBtn.disabled = true;
  }

  return {
    depart,
    arrive,
  };

  //   function btnSwitch() {
  //     if (!departBtn.disabled && arriveBtn.disabled) {
  //       departBtn.disabled = true;
  //       arriveBtn.disabled = false;
  //     } else {
  //       departBtn.disabled = false;
  //       arriveBtn.disabled = true;
  //     }
  //   }
}

let result = solve();
