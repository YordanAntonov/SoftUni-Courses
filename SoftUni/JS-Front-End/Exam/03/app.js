const mainUrl = `http://localhost:3030/jsonstore/tasks`;

let foodInput = document.getElementById("food");
let timeInput = document.getElementById("time");
let caloriesInput = document.getElementById("calories");


//LOAD MEALS FUNCTIONALITY
let loadBtn = document.getElementById("load-meals");
loadBtn.addEventListener("click", loadMeals);

let editBtn = document.getElementById("edit-meal");

let formElement = document.querySelector("#form form");

async function loadMeals(){
    
    let mainDiv = document.getElementById("list");
    mainDiv.innerHTML = "";

    let getMealsRequest = await fetch(mainUrl);
    let mealsCollection = await getMealsRequest.json();
    
    for (const meal of Object.values(mealsCollection)) {
        let childDiv = document.createElement("div");
        childDiv.classList.add("meal");
        
        let foodNameH2 = document.createElement("h2");
        foodNameH2.textContent = meal.food;
        
        let timeH3 = document.createElement("h3");
        timeH3.textContent = meal.time;
        
        let caloriesH3 = document.createElement("h3");
        caloriesH3.textContent = meal.calories;
        
        childDiv.appendChild(foodNameH2);
        childDiv.appendChild(timeH3);
        childDiv.appendChild(caloriesH3);
        
        //BUTTTOOOOONNNNSS
        let btnDiv = document.createElement('div');
        btnDiv.classList.add("meal-buttons");
        
        //CHANGE BTN
        let changeBtn = document.createElement("button");
        changeBtn.classList.add("change-meal");
        changeBtn.textContent = "Change";

        changeBtn.addEventListener("click", async () => {

            foodInput.value = meal.food;
            timeInput.value = meal.time;
            caloriesInput.value = meal.calories;

            mainDiv.removeChild(childDiv);

            addBtn.disabled = true;
            editBtn.disabled = false;

            formElement.dataset.currentMeal = meal._id;
        })
        
        //DELETE BTN
        let deleteBtn = document.createElement("button");
        deleteBtn.classList.add("delete-meal");
        deleteBtn.textContent = "Delete";

        deleteBtn.addEventListener("click", async () => {
            let id = meal._id;

            await fetch(mainUrl + `/${id}`,{
                method: 'DELETE'
            });

            loadMeals();
        })
        
        btnDiv.appendChild(changeBtn);
        btnDiv.appendChild(deleteBtn);
        
        childDiv.appendChild(btnDiv);
        
        
        //APPEND TO MAIN DIV
        mainDiv.appendChild(childDiv);
        
        //DISABLE edit BUTTON
    }
    
    editBtn.disabled = true;
    
}

//ADD-MEAL FUNCTIONALITY
let addBtn = document.getElementById("add-meal");
addBtn.addEventListener("click", addMeal);

async function addMeal(){

    let currentFoodObj = {
        food: foodInput.value,
        calories: caloriesInput.value,
        time: timeInput.value
    };

    await fetch(mainUrl, {
        method: "POST",
        body: JSON.stringify(currentFoodObj)
    });

    foodInput.value = "";
    timeInput.value = "";
    caloriesInput.value = "";

    loadMeals();
}

//EDIT MEAL FUNCTIONALITY 
editBtn.addEventListener("click", editMeal);

async function editMeal(){

    const currFoodId = formElement.dataset.currentMeal;
    let mealObj = {
        food: foodInput.value,
        time: timeInput.value,
        calories: caloriesInput.value,
        _id: currFoodId
    };

    await fetch(mainUrl + `/${currFoodId}`, {
        method: "PUT",
        body: JSON.stringify(mealObj)
    });

    loadMeals();

    editBtn.disabled = true;
    addBtn.disabled = false;

    foodInput.value = "";
    caloriesInput.value = "";
    timeInput.value = "";
}

