// Union Types

function combine(imput1: number | string, imput2: number | string) {
    let result;
    if (typeof imput1 === "number" && typeof imput2 === "number") {
        result = imput1 + imput2;
    }
    else {
        result = imput1.toString() + imput2.toString();
    }
    return result;
}

console.log(combine(2, 3));

console.log(combine("Patrick ", "Wójtowicz"));

// Literal Types

function combine2(imput1: number | string, imput2: number | string, result_type: "as_number" | "as_string") {
    let result;
    if (typeof imput1 === "number" && typeof imput2 === "number") {
        result = imput1 + imput2;
    }
    else {
        result = imput1.toString() + imput2.toString();
    }
    if (result_type === "as_string") return result.toString();
    else return +result;
}

console.log(combine2(2, 3, "as_string"));

console.log(combine2("Patrick ", "Wójtowicz", "as_string"));

// Type Aliases

type Combinal = string | number;
type Combinal2 = "as_number" | "as_string";

function combine3(imput1: Combinal, imput2: Combinal) { }

type User = { name: string; age: number };
const u1: User = { name: 'Patrick', age: 22 };

// Function return

function combine4(imput1: Combinal, imput2: Combinal): Combinal {
    let result;
    if (typeof imput1 === "number" && typeof imput2 === "number") {
        result = imput1 + imput2;
    }
    else {
        result = imput1.toString() + imput2.toString();
    }
    return result;
}

console.log(combine4(2, 3));

console.log(combine4("Patrick ", "Wójtowicz"));

function voidfun(): void {
    console.log("nothing");
}

let a = voidfun();

if (a === undefined) console.log("prove");

function undef(): undefined {
    return;
}

/*
function undef2(): undefined // błąd, tylko i wyłącznie undefined 
// możę być w przypadku return, gdy go nie ma trzeba użyć void
{
    console.log("cos");
}
*/

// Functions as Types

let combinedvar;
combinedvar = combine;

console.log(combinedvar(1, 2));

combinedvar = 5;

console.log(combinedvar(1, 2));
// błąd teraz pointer combinedvar nie wskazuje na funkcje tylko zmienna

// dlatego używamy

let combinedvar2: Function; // jako funkcja
let combinedvar3: () => number; //jako funkcja zwracająca coś (w tym przypadku number)
let combinedvar4: (a: number, b: number) => number; // tak jak wyżej tylko z parametrami

//combinedvar4 = combine3; //error

//Callback 

function AddAndHandle(n1: number, n2: number, cb: (n: number) => void) {
    const res = n1 + n2;
    cb(res);
}

AddAndHandle(5, 10, (res) => {
    console.log("This works!", res);
});

// Unknown type

let userinput: unknown;
let testing: string;
let userinput2: any;

userinput = 5;
userinput = "Rick";

//testing = userinput;// nie zadziała ponieważ unknow 
//zabrania użyciu do okreśonych zmiennych w tym przypadku string

testing = userinput2; // to już zadziała dla any , nie dla unknown

if (typeof userinput === "string") { //tutaj jest sprawdzenie wiec zadziała
    testing = userinput;
}

// Never type

function GenerateError(message: string, code: number): never {
    //never bo przez throw nigdy nic nie zwróci
    throw { message: message, errorCode: code };
    // while(true) {}
}

const res = GenerateError("Tak działa", 404);
console.log(res);