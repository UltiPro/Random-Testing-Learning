// numbers
// strings
// boolean

function add(num1: number, num2: number, print: boolean, text: string) {
    if (print) console.log(text + (num1 + num2))
    else return num1 + num2;
}

add(5, 3, true, "The result is: ");

// typy z małej litery gdyż number != Number

const num: number = 5;
const str: string = "string";
const bool: boolean = false;

// object

// można też zagnieżdzać typy w obiektach umieszzonych w obiektach i tak dalej

const person: {
    name: string;
    age: number;
} = { // obj type ale lepiej zostawić auto dopasowanie przez typescipt 
    name: "Patrick",
    age: 22
}

console.log(person.name);

// Arrays

const arrayyy: string[] = ["first", "second"];

const person2 = {
    name: "Patrick",
    age: 22,
    hobbies: ["Sports", "Cooking"]
}

for(const hobby of person2.hobbies){
    console.log(hobby.toUpperCase());
}

// Tuples

const person3: {
    name: string;
    age: number;
    hobbies: string[];
    role: [number, string];  // tuple z numerem i stringiem
} = {
    name: "Patrick",
    age: 22,
    hobbies: ["Sports", "Cooking"],
    role: [2, "author"]
}

person3.role.push(5); // wyjątek push działa !
//person3.role[1] = 5; // nie zadziała
person3.role[1] = "tak";

// Enums

enum Role {
    AUTHOR,
    ADMIN,
    MODERATOR
};

enum Role2 {
    AUTHOR = 5,
    ADMIN = "ADMIN",
    MODERATOR = 100
};

const person4 = {
    name: "Patrick",
    age: 22,
    hobbies: ["Sports", "Cooking"],
    role: Role.AUTHOR
};

// any 

const any_array: any[] = [1, "string", true]
