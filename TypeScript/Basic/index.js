// numbers
// strings
// boolean
function add(num1, num2, print, text) {
    if (print)
        console.log(text + (num1 + num2));
    else
        return num1 + num2;
}
add(5, 3, true, "The result is: ");
// typy z małej litery gdyż number != Number
var num = 5;
var str = "string";
var bool = false;
// object
// można też zagnieżdzać typy w obiektach umieszzonych w obiektach i tak dalej
var person = {
    name: "Patrick",
    age: 22
};
console.log(person.name);
// Arrays
var arrayyy = ["first", "second"];
var person2 = {
    name: "Patrick",
    age: 22,
    hobbies: ["Sports", "Cooking"]
};
for (var _i = 0, _a = person2.hobbies; _i < _a.length; _i++) {
    var hobby = _a[_i];
    console.log(hobby.toUpperCase());
}
var any_array = [1, "string", true];
