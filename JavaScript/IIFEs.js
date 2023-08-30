(function () {
    var age = 30;
    console.log(age); // 30
})()

console.log(age); // Error: "age is not defined"

// const and let solve that problem...

{
    const age = 30;
    console.log(age); // 30
}

console.log(age); // Error: "age is not defined"