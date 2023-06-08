$(function () {
    // można też wybrać wiele elementów i dodać do każdego z nich czynność

    $("ul ul:first").append("<li>last i am</li>"); // dodaje na końcu
    $("<li>last i am 2</li>").appendTo($("ul ul:first")); // inaczej dodaje na końcu

    $("ul ul:first").prepend("<li>first i am</li>"); // dodaje na początku
    $("<li>first i am 2</li>").prependTo($("ul ul:first")); // inaczej dodaje na początku

    $("ul li:last").after("<li>Main item 5</li>"); // po danym elemencie jako rodzeństwo

    $("<li>last i am 2</li>").insertAfter($("ul ul:first")); // inaczej dodaje po danym elemencie jako rodzeństwo

    $("ul li:first").before("<li>Main item 6</li>"); // przed danym elementem jako rodzeństwo

    $("<li>first i am 2</li>").insertBefore($("ul ul:first")); // inaczej dodaje przed danym elementem jako rodzeństwo

    $("ul li:first").before(function() {
        return "<li>Main item 7</li>";
    }); // przed danym elementem jako rodzeństwo, funckja 

    $("ul li:first").before($("ul li:last"));   // dla wielu elementów wybranych na początku do 1 jest przenoszony
                                                // do reszty jest kopiowany

    $("ul li:last").replaceWith("<li>Tak</li>"); // podmienia element
    $("ul li:last").replaceWith(function() {
        //$(this) // dla wybranego elementu w środku
        return "<li>Tak2</li>";
    }); // podmienia element jako funkcja
    // dla wielu elementów wybranych na początku do 1 jest przenoszony
    // do reszty jest kopiowany

    $("<li>Tak wszysztkie</li>").replaceAll("ul li:odd"); // podmienia wszystkie elementy

    $("li:first").remove(); // usuwa element, niew trzyma wszystkich eventów itp 

    var varriable = $("li:first").detach(); // usuwa element i go zwraca , trzyma wszystkie eventy itp
    $("#list").append(varriable);

    $("li:first").empty(); // usuwa zawartość nie element

    // attrs and props

    console.log($("a").attr("href")); // pobiera attrybut
    $("a").attr("href", "/ulr-two"); // ustawia atrybut

    console.log($("input:checkbox").prop("checked")); // pobiera properties
    
    console.log($("input:text").val()); // pobiera value
    $("input:text").val("Peter2"); // ustawia value

    // css

    $("input:text").css("background", "yellow"); // ustawia css'y

    console.log($("input:text").css("background-color")); // pobiera css value

    $("input:text").css("width", "+=200px"); //można dodawać wartosci
});