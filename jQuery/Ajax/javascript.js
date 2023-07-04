$(function () {
    // $.get() $.post() $.ajax() $.getJSON() $.load()

    $("#code").load("javascript.js");

    $("#code").load("donotexitst.js", function(request, status){
        if(status == "error"){
            console.log("error");
        }
        else{
            // do smth
        }
    });

    // next

    const flickerapi = "https://www.flickr.com/services/feeds/photos_public.gne?jsoncallback=?";

    $.getJSON(flickerapi, {
        tags: "sun, beach",
        tagmode: "any",
        format: "json"
    }).done(function (data){
        $.each(data.items, function(index, value) {
            $("<img>").attr("src", value.media.m).appendTo("body");
            if(index == 4) return false;
        });
    }).fail(function (){
        alert("ajax failed");
    });
});