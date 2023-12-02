//Task 1
function crtObj(firstName, lastName, age) {
  let obj = {
    firstName,
    lastName,
    age,
  };

  return obj;
}

// console.log(crtObj("Peter", `Pan`, `20`));

//Task 2
function printObj(obj) {
  for (const key in obj) {
    console.log(`${key} -> ${obj[key]}`);
  }
}

// printObj({

//     name: "Plovdiv",

//     area: 389,

//     population: 1162358,

//     country: "Bulgaria",

//     postCode: "4000"

//})

//Task 3
function jsonToObj(jasonObj) {
  let obj = JSON.parse(jasonObj);

  for (const key in obj) {
    console.log(`${key}: ${obj[key]}`);
  }
}

// jsonToObj('{"name": "George", "age": 40, "town": "Sofia"}');

//Task 4
function convertToJson(name, lastName, hairColor) {
  let obj = {
    name,
    lastName,
    hairColor,
  };

  console.log(JSON.stringify(obj));
}

// convertToJson('George', 'Jones','Brown');

//Task 5
function phoneBook(arr) {
  let phoneBook = {};

  for (const number of arr) {
    let [name, num] = number.split(" ");
    if (!phoneBook.hasOwnProperty(name)) {
      phoneBook[name] = num;
    } else {
      phoneBook[name] = num;
    }
  }
  for (const key in phoneBook) {
    console.log(`${key} -> ${phoneBook[key]}`);
  }
}

// phoneBook([
//   "Tim 0834212554",

//   "Peter 0877547887",

//   "Bill 0896543112",

//   "Tim 0876566344",
// ]);

//Task 6
function meetings(meetings) {
  const scheduledMeetings = {};

  for (const meeting of meetings) {
    let [day, name] = meeting.split(" ");

    if (!scheduledMeetings.hasOwnProperty(day)) {
      scheduledMeetings[day] = name;
      console.log(`Scheduled for ${day}`);
    } else {
      console.log(`Conflict on ${day}!`);
    }
  }

  for (const day in scheduledMeetings) {
    console.log(`${day} -> ${scheduledMeetings[day]}`);
  }
}

// meetings(['Monday Peter', 'Wednesday Bill', 'Monday Tim', 'Friday Tim']);

//Task 7
function addressBook(addresses) {
  const validAdresses = {};

  for (const address of addresses) {
    let [name, adrs] = address.split(`:`);

    if (!validAdresses.hasOwnProperty(name)) {
      validAdresses[name] = adrs;
    } else {
      validAdresses[name] = adrs;
    }
  }

  const prePeopleOrdered = Object.entries(validAdresses);
  const sortedPeople = prePeopleOrdered.sort();

  for (const key of sortedPeople) {
    console.log(`${key[0]} -> ${key[1]}`);
  }
}

// addressBook(['Bob:Huxley Rd','John:MilwaukeeCrossing','Peter:Fordem Ave','Bob:Redwing Ave','George:MestaCrossing','Ted:Gateway Way',

// 'Bill:Gateway Way',

// 'John:Grover Rd',

// 'Peter:Huxley Rd',

// 'Jeff:Gateway Way',

// 'Jeff:Huxley Rd']);

//Task 8
function cats(arr) {
  class Cat {
    constructor(catName, age) {
      (this.name = catName), (this.age = age);
    }

    meow() {
      console.log(`${this.name}, age ${this.age} says Meow`);
    }
  }

  for (const cat of arr) {
    let [catName, age] = cat.split(" ");
    let kitty = new Cat(catName, age);
    kitty.meow();
  }
}

// cats(['Mellow 2', 'Tom 5']);

//Task 9
function songs(arr) {
  class Song {
    constructor(songType, songName, songLength) {
      (this.songType = songType),
        (this.songName = songName),
        (this.songLength = songLength);
    }
  }

  let numberOfSongs = arr.shift();
  let songType = arr.pop();

  let songs = [];

  for (const song1 of arr) {
    let [songType, songName, songLength] = song1.split(`_`);

    let song = new Song(songType, songName, songLength);
    songs.push(song);
  }

  let isAll = songType === "all";
  for (const song of songs) {
    if (isAll) {
      console.log(song.songName);
    } else {
      if (song.songType === songType) {
        console.log(song.songName);
      }
    }
  }
}

// songs([2,'like_Replay_3:15','ban_Photoshop_3:48','all']);