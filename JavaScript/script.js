{
    // example for code block empty
    // console.log("Code block works!");
}

(function () {
    console.log("samo wywołująca się funkcja");
})()

outside: for (let i = 0; i < 10; i++) {
    inside: for (let j = 0; j < 10; j++) {
        if ((i * j) % 2 == 0) continue inside;
        //console.log(i,j);
    }
}

const returnObj = () => ({ name: "Pat" });

//console.log(returnObj());

function someDo(first, second, ...args) {
    for (let variable of arguments) {
        console.log(variable);
    }
    for (let variable of args) {
        console.log(variable);
    }
}

//someDo("jeden","dwa","trzy","cztery","pięć");

const btn = document.querySelector("button");

function someDoTwo(variable) {
    console.log(this);
    variable *= 2;
    console.log(variable);
}

btn.addEventListener("click", someDoTwo.bind({ name: 'Pat' }, 2));

try {
    throw Error("no to ten tego");
}
catch (e) {
    console.log(e);
}
finally {
    console.log("finnally");
}