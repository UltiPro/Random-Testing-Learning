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

    function LogEvent() {
        console.log("this works for Log event");
    }

    $("#btn3").on("click", LogEvent);

    // delegated events

    $("body").on("click", "h1", function() {
        $(this).css("background-color", "rgba(120,120,160,0.8)");
        $("body").append("<h1>tak</h1>");
    });

    // passing data

    $("#btn4").click({
        name: "Patrick",
        age: 23
    }, function(event) {
        console.log(event.data);
    });

    // key down/up events // keypress has no official documentation

    $("html").keydown(function(event){
        console.log(event.which);
    })

    // focus & blur events

    const inputs = $("input:text");
    inputs.focus(function (){
        $(this).css("background", "royalblue");
    });

    inputs.blur(function (){
        $(this).css("background", "white");
    });

    // change events

    const checkboxes = $("input:checkbox");
    checkboxes.change(function (){
        const ischecked = $(this).is(":checked"); // .prop("checked");
        if(ischecked){
            $("label").css("color", "green");
        }
        else
        {
            $("label").css("color", "black");
        }
    });

    // submit event

    $("form").submit(function (event){
        event.preventDefault();
        window.alert("tak!");
    });

});