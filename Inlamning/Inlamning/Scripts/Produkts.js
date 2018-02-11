$(document).ready(function () {



    //två array en för databasen och en för kundshop (cart) 
    var produktList = [];//backend
    var cartlist = []; //frontend


    //söka genom localstorage ifann kunde har adderat produkter förut
    cartlist = JSON.parse(localStorage.getItem("cartItem", cartlist));
    produktList = JSON.parse(localStorage.getItem("cart", produktList));

    //null till listor igen om local är tom
    if (produktList == null) {

        var produktList = [];
        var cartlist = [];
    }
    //add knapen
    $(".addcart").on("click", function () {
        //hämta info från contenen id,namn,pris
        var container = $(this).parents(".produktContiner");
        alert("Din Produkt ligger i shoppingcart");
        var id = $(container).attr("id");
        var titelfunk = $(".title", $(container));
        var prisfunk = $(".pris", $(container));
        var found = false;

        //vissa objekt som text
        var titelfunk = titelfunk.text();
        var prisfunk = prisfunk.text();


        // loppa genom array föratt gamföra id med varandra ifall det stämmer så plusa man antal
        for (var i = 0; i < produktList.length; i++) {


            if (produktList[i].ProduktId == $(container).attr("id")) {

                produktList[i].Amount++;

                cartlist[i].Amount++;

                found = true;
            }


        }


        if (!found) {
            // om det finns inte tydigare prdukter så skapa nya 
            cartlist.push({ Namn: titelfunk, pris: prisfunk, Amount: 1, Totalt: 0 })
            produktList.push({ ProduktId: id, Amount: 1 });


        }
        // spara i localstorage
        localStorage.setItem("cartItem", JSON.stringify(cartlist));

        localStorage.setItem("cart", JSON.stringify(produktList));

        $("#hiddenCart").val(JSON.stringify(produktList));


        location.reload();

    });

    // rensa vår localstorige och refresh sidan

    $(".DeletAray").on("click", function () {
        localStorage.clear();
        location.reload();
    });


    // funktion som skickar id och amout för prudukter som vi har i cart (localStorage) till controlen createorder
    $("#buy").on("click", function () {
        $.ajax({
            url: "/Home/CreateOrder",
            method: "POST",
            contentType: "application/json;odata=verbose",
            data: localStorage.getItem("cart"),
            success: function (result) {

                $(".mainContent").html(result)

            },
            error: function (error) {
                $(".alert-danger").show();
            }

        });

    });




    cartlistinfo = JSON.parse(localStorage.getItem("cartItem", cartlist));

    var totalsum = null;//totalpriset frontend
    //hämta info från cartlist och vissa de som p tag i sidan
    for (var i = 0; i < cartlistinfo.length; i++) {


        $("#myDIVindex").append("<div class='shoppingCartItem'><p>Namn: " + cartlistinfo[i].Namn + "</p>" +
            "<p> Pris: " + cartlistinfo[i].pris * cartlistinfo[i].Amount + " kr</p>" + "<p> Antal: " + cartlistinfo[i].Amount + "</p> <hr>" + "</div >");


        cartlistinfo[i].Totalt = (cartlistinfo[i].pris * cartlistinfo[i].Amount);

        totalsum = totalsum + cartlistinfo[i].Totalt;
    }

    if (totalsum != null) {

        $("#mytotalindex").append("<div><p>Total Pris: " + totalsum + " </p>" + "</div> ");

    }





    // funktion som laddas upp när den anropas i sutet av siden jag har den för att kuna vissa info direkt när man kommer in i produkt och köp sida (OBS.Den funkar varja gång sidan refreshas)
    function codeAddress() {
        cartlistinfo = JSON.parse(localStorage.getItem("cartItem", cartlist));
        for (var i = 0; i < cartlistinfo.length; i++) {

            $("#myDIV").append("<div class='shoppingCartItem'><p>Namn: " + cartlistinfo[i].Namn + "</p>" +
                "<p> Pris: " + cartlistinfo[i].pris * cartlistinfo[i].Amount + " kr</p>" + "<p> Antal: " + cartlistinfo[i].Amount + "</p> <hr>" + "</div >");
        }

        if (totalsum != null) {

            $("#mytotel").append("<div><p>Total Pris: " + totalsum + " </p>" + "</div> ");

        }
    }







    var produktListDefault = JSON.parse(localStorage.getItem("cart", produktList)) || [];
    $("#hiddenCart").val(JSON.stringify(produktListDefault));

    window.onload = codeAddress
    cartlistinfo = [];


    $(".showlist").on("click", function () {

        var modal = document.getElementById('myModal');

        // hämta id för att opna extra rutan
        var btn = document.getElementById("myBtn");

        // hämta id för att stang extra rutan
        var span = document.getElementsByClassName("close")[0];


        // When the user clicks the button, open the modal
        btn.onclick = function () {
            modal.style.display = "block";
        }

        // When the user clicks on <span> (x), close the modal
        span.onclick = function () {
            modal.style.display = "none";


        }

        // When the user clicks anywhere outside of the modal, close it
        window.onclick = function (event) {
            if (event.target == modal) {
                modal.style.display = "none";
            }
        }

    });

    

});