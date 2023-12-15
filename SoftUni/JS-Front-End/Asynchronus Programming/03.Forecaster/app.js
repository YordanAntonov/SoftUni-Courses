async function attachEvents() {
  const mainUrl = `http://localhost:3030/jsonstore/forecaster/`;

  const getWeatherBtn = document.getElementById("submit");
  const inputArea = document.getElementById("location");

  const forecastMainDiv = document.getElementById("forecast");
  const currentWeatherDiv = document.getElementById("current");
  const upcomingWeatherDiv = document.getElementById("upcoming");

  getWeatherBtn.addEventListener("click", getWeather);

  async function getWeather() {
    let matchLocationCode = ``;
    let hasMatch = false;
    forecastMainDiv.style.display = `none`;

    try {
      const result = await fetch(mainUrl + `locations`);
      const locations = await result.json();

      for (const location of Object.entries(locations)) {
        if (inputArea.value === location[1].name) {
          matchLocationCode = location[1].code;
          hasMatch = true;
        }
      }

      if (!hasMatch) {
        let errorDiv = document.createElement("div");
        errorDiv.id = `error`;
        errorDiv.textContent = "Error";
        forecastMainDiv.appendChild(errorDiv);
        forecastMainDiv.style.display = `block`;
        return;
      }

      const getCurrentWeather = await fetch(
        mainUrl + `today/${matchLocationCode}`
      );
      const currentConditions = await getCurrentWeather.json();

      const currentCityName = currentConditions.name;
      const { condition, high, low } = currentConditions.forecast;

      let newCurrentWeatherDiv = document.createElement("div");
      newCurrentWeatherDiv.classList.add("forecasts");

      let weatherIcon = document.createElement("span");
      weatherIcon.classList.add("symbol");

      if (condition === `Sunny`) {
        weatherIcon.textContent = "&#x2600;";
      } else if (condition === `Partly sunny`) {
        weatherIcon.textContent = "&#x26C5;";
      } else if (condition === `Overcast`) {
        weatherIcon.textContent = "&#x2601;";
      } else if (condition === `Rain`) {
        weatherIcon.textContent = "&#x2614;";
      }

      let conditionSpan = document.createElement("span");
      conditionSpan.classList.add("condition");

      let cityNameSpan = document.createElement("span");
      cityNameSpan.classList.add("forecast-data");
      cityNameSpan.textContent = currentCityName;

      let degreesSpan = document.createElement("span");
      degreesSpan.classList.add("forecast-data");
      degreesSpan.textContent = `${low}&#176;/${high}&#176;`;

      let outsideCondSpan = document.createElement("span");
      outsideCondSpan.classList.add("forecast-data");
      outsideCondSpan.textContent = condition;

      conditionSpan.appendChild(cityNameSpan);
      conditionSpan.appendChild(degreesSpan);
      conditionSpan.appendChild(outsideCondSpan);

      newCurrentWeatherDiv.appendChild(weatherIcon);
      newCurrentWeatherDiv.appendChild(conditionSpan);

      currentWeatherDiv.appendChild(newCurrentWeatherDiv);

      forecastMainDiv.style.display = `block`;
    } catch {
      let errorDiv = document.createElement("div");
      errorDiv.id = `error`;
      errorDiv.textContent = "Error";
      forecastMainDiv.appendChild(errorDiv);
      forecastMainDiv.style.display = `block`;
    }
  }
}
attachEvents();
