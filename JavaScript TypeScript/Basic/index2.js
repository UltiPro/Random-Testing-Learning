// Union Types
function combine(imput1, imput2) {
    var result;
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
function combine2(imput1, imput2, result_type) {
    var result;
    if (typeof imput1 === "number" && typeof imput2 === "number") {
        result = imput1 + imput2;
    }
    else {
        result = imput1.toString() + imput2.toString();
    }
    if (result_type === "as_string")
        return result.toString();
    else
        return +result;
}
console.log(combine2(2, 3, "as_string"));
console.log(combine2("Patrick ", "Wójtowicz", "as_string"));
function combine3(imput1, imput2) { }
var u1 = { name: 'Patrick', age: 22 };
// Function return
function combine4(imput1, imput2) {
    var result;
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
function voidfun() {
    console.log("nothing");
}
var a = voidfun();
if (a === undefined)
    console.log("prove");
function undef() {
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
var combinedvar;
combinedvar = combine;
console.log(combinedvar(1, 2));
combinedvar = 5;
console.log(combinedvar(1, 2));
