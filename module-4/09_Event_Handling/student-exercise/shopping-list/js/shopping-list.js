let allItemsIncomplete = true;
const pageTitle = 'My Shopping List';
const groceries = [
  { id: 1, name: 'Oatmeal', completed: false },
  { id: 2, name: 'Milk', completed: false },
  { id: 3, name: 'Banana', completed: false },
  { id: 4, name: 'Strawberries', completed: false },
  { id: 5, name: 'Lunch Meat', completed: false },
  { id: 6, name: 'Bread', completed: false },
  { id: 7, name: 'Grapes', completed: false },
  { id: 8, name: 'Steak', completed: false },
  { id: 9, name: 'Salad', completed: false },
  { id: 10, name: 'Tea', completed: false }
];

/**
 * This function will get a reference to the title and set its text to the value
 * of the pageTitle variable that was set above.
 */
function setPageTitle() {
  const title = document.getElementById('title');
  title.innerText = pageTitle;
}

/**
 * This function will loop over the array of groceries that was set above and add them to the DOM.
 */
function displayGroceries() {
  const ul = document.querySelector('ul');

  groceries.forEach((item) => {
    const li = document.createElement('li');
    li.innerText = item.name;
    const checkCircle = document.createElement('i');
    checkCircle.setAttribute('class', 'far fa-check-circle');
    li.appendChild(checkCircle);
    ul.appendChild(li);
  });
}
function ToggleCompletion() {
  const lis = document.querySelectorAll('ul > li');
  
  lis.forEach((groceryItem) => {
    groceryItem.classList.remove('completed');
    groceryItem.children[0].classList.remove('completed');
    let buttonName = document.querySelector('.btn');
    buttonName.innerText = 'Mark All Complete';
    // allItemsIncomplete = false;
  });
  allItemsIncomplete = !allItemsIncomplete;

  if (allItemsIncomplete) {
    lis.forEach((groceryItem) => {
      groceryItem.classList.add('completed');
      groceryItem.children[0].classList.add('completed');
      let buttonName = document.querySelector('.btn');
      buttonName.innerText = 'Mark All Incomplete';
      // allItemsIncomplete = false;
    });
    
  }

  
    }
// function markIncomplete() {
//       const lis = document.querySelectorAll('ul > li');
      
//       lis.forEach((groceryItem) => {
//         groceryItem.classList.remove('completed');
//         groceryItem.children[0].classList.remove('completed');
//         let buttonName = document.querySelector('.btn');
//         buttonName.innerText = 'Mark All Complete';
//         allItemsIncomplete = true;
//       });
//         }

document.addEventListener('DOMContentLoaded', () =>{
  setPageTitle();
  displayGroceries();
  const ul = document.querySelector('ul');
  ul.addEventListener('click', (ev) => {
    // console.log(`User clicked on UL. Target element was ${ev.target}, source was ${ev.srcElement}`);
    // console.log(ev.target);
    // console.log(ev.srcElement);
        //ev.target is our li. Set it's class.
        ev.target.classList.add('completed');
        console.log(ev.target)
        ev.target.querySelector('i').classList.add('completed');
  });
  ul.addEventListener('dblclick', (ev) => {
    ev.target.classList.remove('completed');
    ev.target.querySelector('i').classList.remove('completed');
  });
  const button = document.querySelector('.btn');
  button.addEventListener('click', ToggleCompletion)



  
});


