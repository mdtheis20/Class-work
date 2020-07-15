/***************************************************************** */
/***************  Array Functions  ******************************* */
/***************************************************************** */
function arrayFunctions()
{
  // Split a string into an array
    let phrase1 = "When in the course of human events it becomes necessary for one people to dissolve the political bands";
    // split here...
    let words = phrase1.split(' ');

    // call printArray here...
    // printArray(words);    

    // array.slice gets a "sub-array" but does not modify the original
    // array.slice(startElement, nonInclusiveEndElement)
    console.log('*** ***\r\narray.slice gets a "sub-array" but does not modify the original' );
    // slice here...
    let arr = words.slice(3, 7);
    // printArray(arr);
    // printArray(words);
    

    // array.splice gets a "sub-array" and removes those elements.
    // array.splice(start, count, newelements…)
    console.log('*** ***\r\narray.splice gets a "sub-array" and removes those elements.' );
    // splice here...
    arr = words.splice(3, 4, "middle", "of", "the", "night", "or", "day")
    // printArray(arr);
    // printArray(words);


    // array.concat(arr2)
    // array.concat joins two arrays, and does not modify either.
    console.log('*** ***\r\narray.concat joins two arrays, and does not modify either.' );
    // concat here...
    let bigArray = words.concat(arr);
    printArray(words);
    printArray(arr);
    printArray(bigArray);

}

/**
 * Joins an array of strings together with the - separator and prints to console.
 * @param {string[]} arr The array to be printed
 */
function printArray(arr){
  console.log(arr);
  console.log(arr.join("-"));
}



/***************************************************************** */
/************* Functions and Parameters ************************** */
/***************************************************************** */
/**
 * Write a function called multiplyTogether that multiplies two numbers together. But 
 * what happens if we don't pass a value in? What happens if the value is not a number?
 *
 * @param {number} firstParameter the first parameter to multiply
 * @param {number} secondParameter the second parameter to multiply
 */
function multiplyTogether( n1, n2 ){
  return n1 * n2;
}

/**
 * This version makes sure that no parameters are ever missing. If
 * someone calls this function without parameters, we default the
 * values to 0. However, it is impossible in JavaScript to prevent
 * someone from calling this function with data that is not a number.
 * Call this function multiplyNoUndefined
 *
 * @param {number} [firstParameter=0] the first parameter to multiply
 * @param {number} [secondParameter=1] the second parameter to multiply
 */
function multiplyTogether( n1 = 0, n2 = 1 ){
  return n1 * n2;
}


/**
 * How can I write the multiply function so that it will multiply any number of 
 * parameters?
 */
function multiply(){
  if (arguments.length === 0){
    return 0;
  }

  arguments.push(100);

  let product = 1;
  for (let arg of arguments){
    if (typeof(arg) === "number"){
      product *= arg;
    }
  }

  return product;
}

// How can we change this so that it can add up zero to three numbers?

/**
 * 
 * @param {number} num1 A number to add
 * @param {number} num2 A number to add
 * @param {number} num3 A number to add
 * @returns {number} The sum of numbers passed in
 */
function Add(num1, num2, num3) {
  return num1 + num2 + num3;
}






/***************************************************************** */
/***************** Anonymous Functions  ************************** */
/***************************************************************** */

/*********************************************************
 * Anonymous Functions
 * 
 * Functions are a "first-class object" in JavaScript.  
 * There are numerous ways to define functions.  We have seen just one 
 * way so far... with the "function" keyword similar to how we define a method in C#.
 */
// Anonymous functions
function doubleIt(n){
  return n * 2;
}

/***************************
 * There is actually a "variable" called doubleIt now
 */
// print it...
console.log(`doubleIt is type ${typeof(doubleIt)}`)
console.log(doubleIt.name);


/************************
 * Now that the function is defined, we can actually "assign" that function to 
 * another variable.
 */
let func = doubleIt;
console.log(`func is type ${typeof(func)}`)
console.log(func.name);


// Call the function doubleIt
let x = doubleIt(12);
console.log(x);


// Call the function f
x = func(35);
console.log(x);

/*****************************
 * Another way to define a function - assign it to a variable directly
 * 
 */
let tripleIt = function (n) {
  return n * 3;
}
console.log(`tripleIt is type ${typeof(tripleIt)}`)
console.log(tripleIt.name);
console.log( tripleIt(13) );


/*******************************
 * And finally, a shortcut for the above using lambda (fat arrow)
 * 
 */
let quadrupleIt = (n) => {
  return n * 4;
}
console.log(`quadrupleIt is type ${typeof(quadrupleIt)}`)
console.log(quadrupleIt.name);
console.log( quadrupleIt(13) );


/************************************
 * You may even see a shorter-cut, called an expression-bodied function
 * but I won't use it normally
 */
let quintupleIt = (n) => n * 5;
console.log(`quintupleIt is type ${typeof(quintupleIt)}`)
console.log(quintupleIt.name);
console.log( quintupleIt(13) );
console.log(quintupleIt);

/************************************
 * Now we can write a function, which takes another function as a parameter.
 * The passed-in function can be called (executed / invoked).
 */
function toAllElements(arr, functionToApply){
  let outArray = [];
  for (let i = 0; i < arr.length; i++){
    let newValue = functionToApply( arr[i] );
    outArray.push( newValue );
  }
  return outArray;
}

/***********************************
 * Define an array of numbers
 */
let myArray = [1,2,3,4,5];

/**********************************
 * Now in the Console window, call toAllElements, passing in myArray, and a function
 * which will perform an operation on every element
 */
//toAllElements(myArray, doubleIt);

let newArray = toAllElements([10,100,1000], (n) => {
  return n * n;
});
console.log(newArray);





/*************************************************************************************
 * Using Anonymous functions
 * ***********************************************************************************
 */

 /**
 * Takes an array and returns a new array of only numbers that are
 * multiples of 3
 *
 * @param {number[]} numbersToFilter numbers to filter through
 * @returns {number[]} a new array with only those numbers that are
 *   multiples of 3
 */
function allDivisibleByThree(numbersToFilter) {
  // let outArray = [];
  // for (let num of numbersToFilter){
  //   if (num % 3 === 0){
  //     outArray.push(num);
  //   }
  // }
  // return outArray;

  return numbersToFilter.filter( num => { 
    return (num % 3 === 0);
  })
}


/**
 * Takes an array and, using the power of anonymous functions, generates
 * their sum.
 *
 * @param {number[]} numbersToSum numbers to add up
 * @returns {number} sum of all the numbers
 */
function sumAllNumbers(numbersToSum) {
  return numbersToSum.reduce( (sum, num) => {
    return sum + num;
  });
}





let people = [
  { name: "name", age: 21, height: 71 },
];


// List all the people using foreach
/**
 * This function prints a list of all people in the array to the console
 * @param {Object[]} people An array of person objects
 * 
 * @returns {undefined} There is no return value
 */
function listAllPeople(people) {
}

// Filter people by height or age
/**
 * Create an array holding only short people
 * @param {Object[]} people An array of person objects
 * @returns {Object[]} An array of people who are short.
 */
function shortPeople(people) {
}

// Map Name to uppercase
function upperName(people) {
}


// Reduce to total height of all people
function totalHeight(people) {
}

// Sort the array


