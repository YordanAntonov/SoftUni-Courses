async function getInfo() {
  const mainUrl = "http://localhost:3030/jsonstore/bus/businfo/";

  const bussStopInput = document.getElementById("stopId");
  const stopNameOutput = document.getElementById("stopName");
  const bussArrivalsOutput = document.getElementById("buses");
  let bussStops = {};
  if (bussStopInput.value !== "") {
    try {

        bussArrivalsOutput.innerHTML = '';

        const response = await fetch(mainUrl + bussStopInput.value);
        const bussInfo = await response.json();

        for (let [bussNumber, minutes] of Object.entries(bussInfo.buses)) {
            let li = document.createElement('li');
            li.textContent = `Bus ${bussNumber} arrives in ${minutes} minutes`;
            bussArrivalsOutput.appendChild(li);
        }

        stopNameOutput.textContent = bussInfo.name;    

    } catch (error) {
        stopNameOutput.textContent = "Error";
    }

  } else {
    stopNameOutput.textContent = "Error";
  }
}
