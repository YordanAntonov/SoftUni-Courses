function attachEvents() {
  const mainUrl = "http://localhost:3030/jsonstore/phonebook";

  const loadBtn = document.getElementById("btnLoad");
  loadBtn.addEventListener("click", loadContacts);

  const createBtn = document.getElementById("btnCreate");
  createBtn.addEventListener("click", createContact);

  const phoneBook = document.getElementById("phonebook");

  async function loadContacts() {
    phoneBook.innerHTML = "";
    const fetchContacts = await fetch(mainUrl);
    const contacts = await fetchContacts.json();

    console.log(contacts);
    for (const contactObj of Object.values(contacts)) {
      const liItem = document.createElement("li");
      const deleteBtn = document.createElement("button");
      deleteBtn.textContent = "Delete";

      liItem.textContent = `${contactObj.person}: ${contactObj.phone}`;
      liItem.appendChild(deleteBtn);

      phoneBook.appendChild(liItem);

      deleteBtn.addEventListener("click", deleteContact);

      async function deleteContact() {
        await fetch(mainUrl + `/${contactObj._id}`, {
          method: "DELETE",
        });

        liItem.remove();
      }
    }
  }

  async function createContact() {
    const personInput = document.getElementById("person");
    const numberInput = document.getElementById("phone");

    let contactObj = {
      person: personInput.value,
      phone: numberInput.value,
    };

    await fetch(mainUrl, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(contactObj),
    });

    personInput.value = "";
    numberInput.value = "";

    loadContacts();
  }
}

attachEvents();
