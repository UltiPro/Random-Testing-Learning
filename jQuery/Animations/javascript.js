$(function () {
    $('.box-red').fadeOut(2000); // display none
    //$('.box-red').fadeOut("slow");
    //$('.box-red').fadeOut("fast");
    $('.box-red').fadeIn(1000);
    $('.box-blue').fadeTo(1000, 0.5); // opacity 0 but still display block
    $('.box-blue').fadeToggle(1000);
    $('.box-blue').fadeToggle(1000);
    //$('.box-green').hide(); //bez czasu jest instant
    //$('.box-green').show();
    $('.box-green').toggle(2000);
    $('.box-blue').slideUp(2000); // display none
    $('.box-blue').slideDown(2000);
});