$(function () {
    // WSZEDZIE TEŻ MONŻNA PODAĆ WIELE tagów, klas i id

    // Selectors
    $('p').css("background-color", "rgba(180,180,30,0.8)"); //item klasa id wszystko w skrócie
    $('.p').css("background-color", "rgba(180,180,30,0.8)"); //item klasa id wszystko w skrócie
    $('#p').css("background-color", "rgba(180,180,30,0.8)"); //item klasa id wszystko w skrócie
    $('input[type="text"]').css("background-color", "rgba(180,180,30,0.8)"); // typ inputa
    $('input:text').css("background-color", "rgba(180,180,30,0.8)"); // inaczej typ inputa
    $('h2, h3').css("background-color", "rgba(180,180,30,0.8)"); // wiele selektorów
    $('li:last').css("background-color", "rgba(180,180,30,0.8)"); // subklasy first last
    $('li:even').css("background-color", "rgba(120,120,160,0.8)"); // subklasy even odd

    // Traversal
    $("#list").find("li").css("background-color", "rgba(120,120,160,0.8)"); // wszystko
    $("#list").children("li").css("background-color", "rgba(120,120,160,0.8)"); // tylko dziecko nie wnuki 
    $("#list").parents().css("background-color", "rgba(120,120,160,0.8)"); // rodzice all
    $("#list").parents("div").css("background-color", "rgba(120,120,160,0.8)"); // rodzice div, body też może być 
    $("#list").parent().css("background-color", "rgba(120,120,160,0.8)"); // rodzic tylko
    $("#list").siblings().css("background-color", "rgba(120,120,160,0.8)"); // rodzeństwo all
    $("#list").siblings("p").css("background-color", "rgba(120,120,160,0.8)"); // rodzeństwo all typu p 
    $("#list").siblings().css("background-color", "rgba(120,120,160,0.8)"); // rodzeństwo all
    $("#list").prev().css("background-color", "rgba(120,120,160,0.8)"); // poprzedni element
    $("#list").next().css("background-color", "rgba(120,120,160,0.8)"); // następny element

    // Filtering
    $("#list").find("li").filter(":even").css("background-color", "rgba(120,120,160,0.8)");
    $("li").filter((index) => {
        return index % 3 == 1;
    }).css("background-color", "rgba(120,120,160,0.8)");
    $("#list").first().css("background-color", "rgba(120,120,160,0.8)");
    $("#list").last().css("background-color", "rgba(120,120,160,0.8)");
    $("#list").eq(0).css("background-color", "rgba(120,120,160,0.8)"); // po indexach, equal
    $("#list").eq(-4).css("background-color", "rgba(120,120,160,0.8)"); // liczy od tyłu
    $("li").not(":first").css("background-color", "rgba(120,120,160,0.8)"); // można też dać funkcje
});