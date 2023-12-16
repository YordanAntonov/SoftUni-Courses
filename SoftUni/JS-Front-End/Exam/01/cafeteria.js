function solve(array){
    const numberOfBaristas = array.shift();
    let baristas = {};

    for (let i = 0; i < numberOfBaristas; i++){
        let [name, shift, skills] = array.shift().split(" ");
        let currSkills = skills.split(",");

        baristas[name] = {
            shift: shift,
            coffes: currSkills
        };
    }

    
    let currElement = array.shift();

    while (currElement !== "Closed"){

        let actions = currElement.split(" / ");
        let command = actions.shift();

        if (command === "Prepare"){
            let baristaName = actions[0];
            let currShift = actions[1];
            let coffeType = actions[2];

            let hasCoffee = baristas[baristaName].coffes.includes(coffeType);

            if (currShift === baristas[baristaName].shift && hasCoffee){
                console.log(`${baristaName} has prepared a ${coffeType} for you!`);
            }else{
                console.log(`${baristaName} is not available to prepare a ${coffeType}.`);
            }
        }else if (command === "Change Shift"){
            let baristaName = actions[0];
            let newShift = actions[1];

            baristas[baristaName].shift = newShift;

            console.log(`${baristaName} has updated his shift to: ${newShift}`);
        }else if (command === "Learn"){
            let baristaName = actions[0];
            let newCoffeType = actions[1];

            let hasCoffee = baristas[baristaName].coffes.includes(newCoffeType);

            if (hasCoffee){
                console.log(`${baristaName} knows how to make ${newCoffeType}.`);
            }else{
                baristas[baristaName].coffes.push(newCoffeType);
                console.log(`${baristaName} has learned a new coffee type: ${newCoffeType}.`);
            }
        }
        


        currElement = array.shift();
    }

    for (const [names, values] of Object.entries(baristas)) {
        console.log(`Barista: ${names}, Shift: ${values.shift}, Drinks: ${values.coffes.join(", ")}`);
    }
}


solve(['3', 'Alice day Espresso,Cappuccino', 'Bob night Latte,Mocha', 'Carol day Americano,Mocha', 'Prepare / Alice / day / Espresso', 'Change Shift / Bob / night', 'Learn / Carol / Latte', 'Learn / Bob / Latte', 'Prepare / Bob / night / Latte', 'Closed']
);