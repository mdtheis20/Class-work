// add pageTitle
const titleOfPage = 'My Shopping List';
// add groceries
groceries = ['Milk', 'Eggs', 'Bread', 'Water', 'Beer', 'Apples', 'Bananas', 'Cheese', 'Chips', 'Candy'];
/**
 * This function will get a reference to the title and set its text to the value
 * of the pageTitle variable that was set above.
 */
function setPageTitle() {
  let titleSpan = document.querySelector('#title');

  titleSpan.innerText = titleOfPage;
}

/**
 * This function will loop over the array of groceries that was set above and add them to the DOM.
 */
function displayGroceries() {
  let listUl = document.getElementById('groceries');
  groceries.forEach(groc => {
    let item = document.createElement('li');
    item.innerText = groc;
    listUl.appendChild(item);
  });
}

/**
 * This function will be called when the button is clicked. You will need to get a reference
 * to every list item and add the class completed to each one
 */
function markCompleted() {
const lis = document.querySelectorAll('#groceries > li');

lis.forEach((groceryItem) => {
  groceryItem.classList.add('completed');
});

  // let grocery = document.getElementById('groceries');
  // groceries.forEach( groc => {
  //   let grocContainer = document.createElement('div');
  //   grocContainer.classList.add('completed');
  // })

  }


setPageTitle();

displayGroceries();

// Don't worry too much about what is going on here, we will cover this when we discuss events.
document.addEventListener('DOMContentLoaded', () => {
  // When the DOM Content has loaded attach a click listener to the button
  const button = document.querySelector('.btn');
  button.addEventListener('click', markCompleted);
});
