/*
    Example of a multi-line 
    comment just like in C#/Java
*/

// Single line comment


/**
 * Functions start with the word function.
 * They don't have a return type and the naming convention is camel-case.
 */
function variables() {
  // Declares a variable where the value cannot be changed
  const daysInWeek = 7;
  printValueAndType("daysInWeek", daysInWeek);

  // Can I change it?

  // daysInWeek = 8; //NO!

  console.log(`There are ${daysInWeek} days in the week`)

  // Declares a variable those value can be changed
  let daysPerMonth = 31;
  printValueAndType("daysPerMonth", daysPerMonth);

  // Can I change it?
  daysPerMonth = 28;


  // Declares a variable that will always be an array (prime numbers)
  const primeNumbers = [1, 2, 3, 5, 7, 11, 13];
  console.table(primeNumbers);
  console.log(primeNumbers);

  // Can I change the values in the array?
  // primeNumbers[1] = 4;
  primeNumbers[7] = 17;
  console.table(primeNumbers);
  

  // Can I re-assign the variable?
  //  prime = "prime numbers";

  //primeNumbers = [1,2,3]; //NO!

  // Declare variable obj, but don't define it. Print out its value and type
  let obj;
  printValueAndType("obj", obj);

  // Now set it to null, and print out its value and type
  obj = null;
  printValueAndType("obj", obj);

  // Return value can be any type.  If there is nothing returned, the value / type is undefined
  return 'Friday';
}

function printValueAndType(name, obj) {
  console.log(`${name}: value is ${obj}, type is ${typeof (obj)}`);

  // Console.WriteLine($"{name}: value is {obj} . type is {typeof(obj)}");
}

/**
 * Functions can also accept parameters.
 * Notice the parameters do not have types.
 * @param {Number} param1 The first number to display
 * @param {Number} param2 The second number to display
 */
function printParameters(param1, param2) {
  console.log(`The value of param1 is ${param1}, and the type is ${typeof (param1)}`);
  console.log(`The value of param2 is ${param2}, and the type is ${typeof (param2)}`);
}

/**
 * Compares two values x and y.
 * == is loose equality
 * === is strict equality
 * @param {Object} x
 * @param {Object} y
 */
function equality(x, y) {
  console.log(`x is ${typeof x}`);
  console.log(`y is ${typeof y}`);

  console.log(`x == y : ${x == y}`); // true
  console.log(`x === y : ${x === y}`); // false
}

/**
 * Each value is inherently truthy or falsy.
 * false, 0, '', null, undefined, and NaN are always falsy
 * everything else is always truthy
 * @param {Object} x The object to check for truthy or falsy,
 */
function falsy(x) {
  if (x) {
    console.log(`${x} is truthy`);
  } else {
    console.log(`${x} is falsy`);
  }
}

/**
 * Arrays can change in size
 * You won't get an Index-out-of-range exception
 * arrays can hold multiple types
 */
function arrays() {
  // Create an empty array
  let scores = [];
  printValueAndType("scores", scores);

  // Add some elements by pushing
  scores.push(60);
  scores.push('A');
  scores.push(true);

  // Add some more elements sparsely
  scores[10] = 100;

  // Use the table command to print the results
  console.table(scores);
  
  // // Loop through the array and print all elements
  // for (let i = 0; i < scores.length; i++) {
  //     console.log(scores[i]);
  // }

  // for (let score of scores){
  //   console.log(score);
  // }

  let s = scores.shift();
  console.log(s);
  console.table(scores);

  let things = [12, 'Dan', true];
  console.table(things);

  return 0;
}

/**
 *  Objects are simple key-value pairs
    - values can be primitive data types
    - values can be arrays
    - or they can be functions
*/
function objects() {
  const person = {
    firstName: "Bill",
    lastName: "Lumbergh",
    age: 42,
    employees: [
      "Peter Gibbons",
      "Milton Waddams",
      "Samir Nagheenanajar",
      "Michael Bolton"
    ],
    introduce: function () {
      return `Hi, my name is ${this.firstName} ${this.lastName}. I am (${this.age}) years old.`;
    },
    addEmployee: function(empName) {
      this.employees.push(empName);
    }
  };

  // Log the object
  console.log(person);

  // Log the first and last name
  console.log(person.firstName);


  // Change a property
  person.firstName = "William";
  person.employees.push("Kevin Klik");

  console.log(person);

  // Log each employee
  for (const emp of person.employees){
    console.log(emp);
  }

  for (let i = 0; i < person.employees.length; i++){
    console.log(person.employees[i]);
  }

  // Call the object function introduce
  console.log(person.introduce());

  person.addEmployee(999);

  console.table(person);
}

/*
########################
Function Overloading
########################

Function Overloading is not available in Javascript. If you declare a
function with the same name, more than one time in a script file, the
earlier ones are overridden and the most recent one will be used.
*/

function Add(num1, num2) {
  return num1 + num2;
}

function Add(num1, num2, num3) {
  return num1 + num2 + num3;
}

/*
########################
Math Library
########################

A built-in `Math` object has properties and methods for mathematical constants and functions.
*/

function mathFunctions() {
  console.log("Math.PI : " + Math.PI);
  console.log("Math.LOG10E : " + Math.LOG10E);
  console.log("Math.abs(-10) : " + Math.abs(-10));
  console.log("Math.floor(1.99) : " + Math.floor(1.99));
  console.log("Math.ceil(1.01) : " + Math.ceil(1.01));
  console.log("Math.random() : " + Math.random());
  console.log("Math.random() : " + Math.random());
  console.log("Math.random() : " + Math.random());

  // Random number from 1 - 10
  for (let i = 0; i < 20; i++){
    console.log(Math.ceil(Math.random() * 10));
  }
}

/*
########################
String Methods
########################

The string data type has a lot of properties and methods similar to strings in Java/C#
*/

function stringFunctions(value) {
  console.log(`.length -  ${value.length}`);
  console.log(`.endsWith('World') - ${value.endsWith("World")}`);
  console.log(`.startsWith('Hello') - ${value.startsWith("Hello")}`);
  console.log(`.indexOf('Hello') - ${value.indexOf("Hello")}`);

  console.table( value.split(' ') );
  /*
    Other Methods
        - split(string)
        - substring(number, number)
        - toLowerCase()
        - trim()
        - https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String
    */
   // Split and join

   const str = 'The quick brown fox jumped over the lazy dog';
   let arr = str.split(' ');
   console.table(arr);
   let s = arr.join('-');
  console.log(s);

}

function quirks() {
  // Adding and subtracting strings as numbers
  console.log(`'5' - '2' = ${'5' - '2'}`);  // 
  console.log(`'5' + '2' = ${'5' + '2'}`);

  // Truthiness
  console.log(`0 == false = ${0 == false}`);
  console.log(`1 == true = ${1 == true}`);
  console.log(`2 == true = ${2 == true}`);

  console.log(`2 + true = ${2 + true}`);

  // undefined variables become global. 'use strict' to create an error
  x = 50;

  console.log([2, 11, 21, 1, 4, 32].sort());

  console.log(`Not-a-number is a ${typeof (NaN)}`);
  console.log(`(NaN === NaN) = ${(NaN === NaN)}`);

}
