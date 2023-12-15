function astroAdventure(array) {
  const numberOfAstronauts = array.shift();
  let astronauts = {};

  for (let i = 0; i < numberOfAstronauts; i++) {
    const currentElement = array.shift();
    let [name, oxyLevel, energyReserve] = currentElement.split(" ");

    astronauts[name] = {
      oxygen: Number(oxyLevel),
      energy: Number(energyReserve),
    };
  }

  let currentElement = array.shift();

  while (currentElement !== "End") {
    let currentCommands = currentElement.split(" - ");
    const command = currentCommands[0];

    if (command === "Explore") {

      const astroName = currentCommands[1];
      const energyNeeded = Number(currentCommands[2]);
      if (energyNeeded <= astronauts[astroName].energy) {
        astronauts[astroName].energy -= energyNeeded;
        console.log(
          `${astroName} has successfully explored a new area and now has ${astronauts[astroName].energy} energy!`
        );

      } else {

        console.log(`${astroName} does not have enough energy to explore!`);

      }
    }else if (command === "Refuel"){
        const astroName = currentCommands[1];
        let refuelAmount = Number(currentCommands[2]);
        let beforeRefuel = astronauts[astroName].energy;
        astronauts[astroName].energy += refuelAmount;

        if (astronauts[astroName].energy >= 200){
            astronauts[astroName].energy = 200;
            refuelAmount = 200 - beforeRefuel;
        }

        console.log(`${astroName} refueled their energy by ${refuelAmount}!`);
    }else if (command === "Breathe"){
        const astroName = currentCommands[1];
        let replenishedOxy = Number(currentCommands[2]);

        let beforeBreathe = astronauts[astroName].oxygen;
        astronauts[astroName].oxygen += replenishedOxy;

        if (astronauts[astroName].oxygen >= 100){
            astronauts[astroName].oxygen = 100;
            replenishedOxy = 100 - beforeBreathe;
        }

        console.log(`${astroName} took a breath and recovered ${replenishedOxy} oxygen!`);
    }

    currentElement = array.shift();
  }

  for (const [name, values] of Object.entries(astronauts)) {
    console.log(`Astronaut: ${name}, Oxygen: ${values.oxygen}, Energy: ${values.energy}`);
  }
}

astroAdventure([
  "3",
  "John 50 120",
  "Kate 80 180",
  "Rob 70 150",
  "Explore - John - 50",
  "Refuel - Kate - 30",
  "Breathe - Rob - 20",
  "End",
]);
