$(function () {

    //fade zanikanie całkowite
    $('.box-red').fadeOut(2000); // display none
    //$('.box-red').fadeOut("slow");
    //$('.box-red').fadeOut("fast");
    $('.box-red').fadeIn(1000);
    $('.box-blue').fadeTo(1000, 0.5); // opacity 0 but still display block
    $('.box-blue').fadeToggle(1000);
    $('.box-blue').fadeToggle(1000);

    // zwykłe zanikanie do lewego górnego rogu
    //$('.box-green').hide(); //bez czasu jest instant
    //$('.box-green').show();
    $('.box-green').toggle(2000);

    // zanikanie slidem do góry i z góry
    $('.box-blue').slideUp(2000); // display none
    $('.box-blue').slideDown(2000);
    $('p').slideUp(1000);
    $('p').slideDown(1000);
    $('p').slideToggle();

    // animacje
    $(".box-red").delay(2000).animate({ //delay opóźnia and chaining animations
        "margin-left": "+=200px", //dwa podejścia ale ciągi dłuższ z - muszą być w cudzysłowie
        opacity: "0"              // to wyżej
    }, 2000, "linear");

    $(".box-red").fadeTo(1000, 1, () => { //callback function 
        $(".box-green").fadeTo(1000, 1);
    });

    /*
    $(".box-red").fadeTo(1000, 0, function() {
            alert("work");
        });
    */

    // .stop() blokuje animacje na zdarzeniach !!! jak wyjdziesz myszką np na hoverze 
    // to nie konczy się animacja tylko wykonuje inna
});