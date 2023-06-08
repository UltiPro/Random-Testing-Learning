$(function () {
    $("#btn").click(function (event) { // klik
        //console.log(event);
        alert("click");
    });

    //$("#btn").click(); // wywołanie klikania

    $("#btn").hover(function (event) { // hover, hover(handlerIn,handlerOut)
        $(this).css("background-color", "royalblue");
    }, function (event) {
        $(this).css("background-color", "white");
    });

    $("#btn").mouseenter(function () {  // mouse enter
        $("#mouse").text("tak");
    });

    $("#btn").mouseleave(function () { // mouse leave
        $("#mouse").text("nie");
    });

    $("#btn2").on("click keydown", function (event) { // klik inaczej, oraz wiele method na raz
        alert("click");
    });
});