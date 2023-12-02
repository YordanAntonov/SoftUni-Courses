//Task 1
function employees(employees) {
  let employeeBadges = {};
  for (const employee of employees) {
    if (!employeeBadges.hasOwnProperty(employee)) {
      employeeBadges[employee] = employee.length;
    }
  }

  for (const key in employeeBadges) {
    console.log(`Name: ${key} -- Personal Number: ${employeeBadges[key]}`);
  }
}

//Task 2
function towns(towns) {
  let legitTowns = [];

  for (const town of towns) {
    let [townName, latitude, longitude] = town.split(" | ");

    let t = {
      town: townName,
      latitude: Number(latitude).toFixed(2),
      longitude: Number(longitude).toFixed(2),
    };

    legitTowns.push(t);
  }

  for (const t of legitTowns) {
    console.log(t);
  }
}

//Task 3
function storeProvision(currentStock, orderedStock) {
  let storeStock = {};

  for (let i = 0; i < currentStock.length; i += 2) {
    let product = currentStock[i];
    let quantity = Number(currentStock[i + 1]);

    storeStock[product] = quantity;
  }

  for (let i = 0; i < orderedStock.length; i += 2) {
    let product = orderedStock[i];
    let quantity = Number(orderedStock[i + 1]);

    if (currentStock.includes(product)) {
      storeStock[product] += quantity;
    } else {
      storeStock[product] = quantity;
    }
  }

  for (const key in storeStock) {
    console.log(`${key} -> ${storeStock[key]}`);
  }
}

//Task 4
function movies(movies) {
  let storedMovies = [];

  for (const movie of movies) {
    if (movie.includes("addMovie")) {
      let currMovie = movie.split("addMovie ");
      let newMovie = {
        name: currMovie[1],
      };

      storedMovies.push(newMovie);
    } else if (movie.includes("directedBy")) {
      let currMovie = movie.split(" directedBy ");

      let search = storedMovies.find((el) => el.name === currMovie[0]);

      if (search) {
        search["director"] = currMovie[1];
      }
    } else {
      let currMovie = movie.split(" onDate ");

      let search = storedMovies.find((el) => el.name === currMovie[0]);
      if (search) {
        search["date"] = currMovie[1];
      }
    }
  }

  for (const movie of storedMovies) {
    if (
      movie.hasOwnProperty(`name`) &&
      movie.hasOwnProperty(`director`) &&
      movie.hasOwnProperty(`date`)
    ) {
      console.log(JSON.stringify(movie));
    }
  }
}

//Task 5
function heroes(heroes) {
  let finalHeros = [];

  for (const heroSpecifics of heroes) {
    let [name, level, ...rest] = heroSpecifics.split(" / ");

    let newHero = {
      name,
      level: Number(level),
      items: rest,
    };

    finalHeros.push(newHero);
  }

  finalHeros = finalHeros.sort((a, b) => a.level - b.level);

  finalHeros.forEach((hero) => {
    console.log(`Hero: ${hero.name}`);
    console.log(`level => ${hero.level}`);
    console.log(`items => ${hero.items.join(", ")}`);
  });
}

//Task 6
function wordTracker(sentance) {
  let searchTerm = sentance.shift().split(" ");
  let words = {};

  for (let i = 0; i < searchTerm.length; i++) {
    words[searchTerm[i]] = 0;

    for (let j = 0; j < sentance.length; j++) {
      if (sentance[j] === searchTerm[i]) {
        words[searchTerm[i]] += 1;
      }
    }
  }

  words = Object.entries(words).sort((a, b) => b[1] - a[1]);
  for (const [key, value] of words) {
    console.log(`${key} - ${value}`);
  }
}

//Task 7
function oddOccurances(occurances) {
  occurances = occurances.toLowerCase();
  let arrOfElement = occurances.split(" ");

  let map = new Map();

  arrOfElement.forEach((element) => {
    if (map.has(element)) {
      let oldValue = map.get(element);
      let newValue = oldValue + 1;

      map.set(element, newValue);
    } else {
      map.set(element, 1);
    }
  });

  let result = [];
  map.forEach((value, key) => {
    if (value % 2 !== 0) {
      result.push(key);
    }
  });

  console.log(result.join(" "));
}

// oddOccurances("Java C# Php PHP Java PhP 3 C# 3 1 5 C#");

//Task 8
function parkongLot(arr) {
  let result = [];

  for (const car of arr) {
    let [inOrOut, carNumber] = car.split(", ");

    if (inOrOut === "IN") {
      if (!result.includes(carNumber)) {
        result.push(carNumber);
      }
    } else {
      if (result.includes(carNumber)) {
        let indexOfNumber = result.indexOf(carNumber);

        result.splice(indexOfNumber, 1);
      }
    }
  }

  if (result.length > 0) {
    result = result.sort((a, b) => {
      return a.localeCompare(b);
    });
    result.forEach((car) => {
      console.log(car);
    });
  } else {
    console.log(`Parking Lot is Empty`);
  }
}

// parkongLot([
//   "IN, CA2844AA",
//   "IN, CA1234TA",
//   "OUT, CA2844AA",
//   "IN, CA9999TT",
//   "IN, CA2866HI",
//   "OUT, CA1234TA",
//   "IN, CA2844AA",
//   "OUT, CA2866HI",
//   "IN, CA9876HH",
//   "IN, CA2822UU",
// ]);

//Task 9
function deJsonString(arr) {
  let strings = {};

  for (const string of arr) {
    let obj = JSON.parse(string);
    for (const el of Object.entries(obj)) {
      const [key, value] = el;

      if (!strings.hasOwnProperty(key)) {
        strings[key] = value;
      } else {
        strings[key] = value;
      }
    }
  }

  let sortedStrings = Object.keys(strings).sort();

  for (const key of sortedStrings) {
    console.log(`Term: ${key} => Definition: ${strings[key]}`);
  }
}

// deJsonString([
//   '{"Coffee":"A hot drink madefrom the roasted and groundseeds (coffee beans) of atropical shrub."}',

//   '{"Bus":"A large motor vehiclecarrying passengers by road,typically one serving the publicon a fixed route and for afare."}',

//   '{"Boiler":"A fuel-burningapparatus or container forheating water."}',

//   '{"Tape":"A narrow strip ofmaterial, typically used to holdor fasten something."}',

//   '{"Microphone":"An instrumentfor converting sound waves intoelectrical energy variations Term: Boiler => Definition: A fuel-burning apparatus or container for heating water. Term: Bus => Definition: A large motor vehicle carrying passengers by road, typically one serving the public on a fixed route and for a fare. Term: Coffee => Definition: A hot drink made from the roasted and ground seeds (coffee beans) of a tropical shrub. Term: Microphone => Definition: An instrument for converting sound waves into electrical energy variations which may then be amplified, transmitted, or recorded. Term: Tape => Definition: A narrow strip of material, typically used to hold or fasten somethingwhich may then be amplified, transmitted, or recorded."}',
// ]);

//Task 10
class Vehicle {
  constructor(type, model, parts, fuel) {
    (this.type = type),
      (this.model = model),
      (this.parts = {
        engine: parts.engine,
        power: parts.power,
        quality: parts.engine * parts.power,
      });
    this.fuel = fuel;
  }

  drive(fuelLost){
    this.fuel -= fuelLost;
  }
}


let parts = { engine: 6, power: 100 };

let vehicle = new Vehicle('a', 'b', parts, 200);

vehicle.drive(100);

console.log(vehicle.fuel);

console.log(vehicle.parts.quality)
