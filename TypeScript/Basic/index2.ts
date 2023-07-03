// Union Types

function combine(imput1: number | string, imput2: number | string) {
    let result;
    if(typeof imput1 === "number" && typeof imput2 === "number"){
        result = imput1 + imput2;
    }
    else
    {
        result = imput1.toString() + imput2.toString();
    }
    return result;
}

console.log(combine(2,3));

console.log(combine("Patrick ","Wójtowicz"));

// Literal Types

function combine2(imput1: number | string, imput2: number | string, result_type: "as_number" | "as_string") {
    let result;
    if(typeof imput1 === "number" && typeof imput2 === "number"){
        result = imput1 + imput2;
    }
    else
    {
        result = imput1.toString() + imput2.toString();
    }
    if(result_type === "as_string") return result.toString();
    else return +result;
}

console.log(combine2(2,3, "as_string"));

console.log(combine2("Patrick ","Wójtowicz", "as_string"));

// Type Aliases

type Combinal = string | number;
type Combinal2 = "as_number" | "as_string";

function combine3(imput1: Combinal, imput2: Combinal) {}

type User = { name: string; age: number };
const u1: User = { name: 'Patrick', age: 22 };

// Function return

function combine4(imput1: Combinal, imput2: Combinal): Combinal {
    let result;
    if(typeof imput1 === "number" && typeof imput2 === "number"){
        result = imput1 + imput2;
    }
    else
    {
        result = imput1.toString() + imput2.toString();
    }
    return result;
}

console.log(combine4(2,3));

console.log(combine4("Patrick ","Wójtowicz"));

function voidfun(): void {
    
}
