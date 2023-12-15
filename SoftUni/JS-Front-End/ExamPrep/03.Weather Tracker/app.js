const mainUrl = `http://localhost:3030/jsonstore/tasks`;

const loadHistoryBtn = document.getElementById('load-history');
const addWeatherBtn = document.getElementById('add-weather');
const editWeatherBtn = document.getElementById('edit-weather');

let locationInput = document.getElementById('location');
let temperatureInput = document.getElementById('temperature');
let dateInput = document.getElementById('date');

const listDivision = document.getElementById('list');

const formElement = document.querySelector('#form form');

// LOAD HISTORY BUTTON FUNCTIONALITY:
loadHistoryBtn.addEventListener('click', getWeather);

async function getWeather(){

    listDivision.innerHTML = "";

    const getRequiest = await fetch(mainUrl);
    let weatherCollection = await getRequiest.json();

    for (const weather of Object.values(weatherCollection)) {
        let divContainer = document.createElement('div');
        divContainer.classList.add('container');

        let h2CityName = document.createElement('h2');
        h2CityName.textContent = weather.location;

        let h3Date = document.createElement('h3');
        h3Date.textContent = weather.date;

        let h3Celsius = document.createElement('h3');
        h3Celsius.classList.add('celsius');
        h3Celsius.textContent = weather.temperature;

        let divContainerBtn = document.createElement('div');
        divContainerBtn.classList.add('buttons-container');

        let changeBtn = document.createElement('button');
        changeBtn.classList.add('change-btn');
        changeBtn.textContent = 'Change'; 
        //EDIT WEATHER BUTTON FUNCTIONALITY

        changeBtn.addEventListener('click', async (e) => {
            locationInput.value = weather.location;
            temperatureInput.value = weather.temperature;
            dateInput.value = weather.date;
            

            listDivision.removeChild(divContainer);

            addWeatherBtn.disabled = true;
            editWeatherBtn.disabled = false;

            formElement.dataset.currentWeather = weather._id;
        });


        let deleteBtn = document.createElement('button');
        deleteBtn.classList.add('delete-btn');
        deleteBtn.textContent  = 'Delete';

        //Delete functionality:
        deleteBtn.addEventListener('click', async () =>{
            let id = weather._id;

            await fetch(mainUrl + `/${id}`,{
                method: 'DELETE'
            });

            getWeather();
        });

        divContainerBtn.appendChild(changeBtn);
        divContainerBtn.appendChild(deleteBtn);

        divContainer.appendChild(h2CityName);
        divContainer.appendChild(h3Date);
        divContainer.appendChild(h3Celsius);
        divContainer.appendChild(divContainerBtn);
        
        listDivision.appendChild(divContainer);
    }
}

//ADD WEATHER BUTTON FUNCTIONALITY
addWeatherBtn.addEventListener('click', addWeather);

async function addWeather(){
    let weatherObj = {
        location: locationInput.value,
        temperature: temperatureInput.value,
        date: dateInput.value
    };

    await fetch(mainUrl, {
        method: 'POST',
        body: JSON.stringify(weatherObj)
    });

    getWeather();

    locationInput.value = "";
    temperatureInput.value = "";
    dateInput.value = "";
}

//EDIT WEATHER BUTTON FUNCTIONALITY
editWeatherBtn.addEventListener('click', editWeather);

async function editWeather(){
    const currId = formElement.dataset.currentWeather;
    let weatherObj = {
        location: locationInput.value,
        temperature: temperatureInput.value,
        date: dateInput.value,
        _id: currId
    };

    
    await fetch(mainUrl + `/${currId}`, {
        method: 'PUT',
        body: JSON.stringify(weatherObj)
    });

    getWeather();

    addWeatherBtn.disabled = false;
    editWeatherBtn.disabled = true;

    locationInput.value = "";
    temperatureInput.value = "";
    dateInput.value = "";
}

