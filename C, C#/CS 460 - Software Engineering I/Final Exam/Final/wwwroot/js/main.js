setInterval(fetchdata, 5000);

function fetchdata(){
    let country = document.querySelector(".country").innerHTML;
    let address = "/api/results/" + country;
    $.ajax({
        type: "GET",
        dataType: "json",
        url: address,
        success: displayStats,
        error: errorOnAjax
    })
}

function errorOnAjax() {
    console.log("ERROR in ajax request");
    // take care of the error, maybe display a message to the user
    // ...
}

function displayStats(data)
{
    var wins = document.querySelector(".wins");
    wins.innerHTML = data.wins;
    var losses = document.querySelector(".losses");
    losses.innerHTML = data.losses;
    var draws = document.querySelector(".draws");
    draws.innerHTML = data.draws;
}