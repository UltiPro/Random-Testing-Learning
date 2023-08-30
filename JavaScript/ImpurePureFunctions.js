function add(num1, num2) { // pure
    return num1 + num2;
}

console.log(add(1, 5));
console.log(add(12, 15));

function addRandom(num1) { // unpure
    return num1 + Math.random();
}

console.log(addRandom(5));

let previousResult = 0;

function addMoreNumbers(num1, num2) { // unpure
    const sum = num1 + num2;
    previousResult = sum;
    return sum;
}

console.log(addMoreNumbers(1, 5));

const hobbies = ['Sports', 'Cooking'];

function printHobbies(h) { // unpure
    h.push('NEW HOBBY');
    console.log(h);
}

printHobbies(hobbies);