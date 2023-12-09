function attachEventsListeners() {
    const dayBtn = document.getElementById('daysBtn').addEventListener('click', convertDays);
    const daysInput = document.getElementById('days');

    const hourBtn = document.getElementById('hoursBtn').addEventListener('click', convertHours);
    const hoursInput = document.getElementById('hours');

    const minuteBtn = document.getElementById('minutesBtn').addEventListener('click', convertMinutes)
    const minutesInput = document.getElementById('minutes');

    const secondBtn = document.getElementById('secondsBtn').addEventListener('click', convertSeconds)
    const secondsInput = document.getElementById('seconds');

    function convertDays(e){
        hoursInput.value = Number(daysInput.value * 24);
        minutesInput.value = Number(daysInput.value * 1440);
        secondsInput.value = Number(daysInput.value * 86400);
    }

    function convertHours(e){
        daysInput.value = Number(hoursInput.value / 24);
        minutesInput.value = Number(daysInput.value * 1440);
        secondsInput.value = Number(daysInput.value * 86400);
    }

    function convertMinutes(e){
        daysInput.value = Number(minutesInput.value / 1440);
        hoursInput.value = Number(daysInput.value * 24);
        secondsInput.value = Number(daysInput.value * 86400);
    }
    
    function convertSeconds(e){
        daysInput.value = Number(secondsInput.value / 86400);
        hoursInput.value = Number(daysInput.value * 24);
        minutesInput.value = Number(daysInput.value * 1440);
    }
}


