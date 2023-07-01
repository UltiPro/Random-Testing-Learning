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

