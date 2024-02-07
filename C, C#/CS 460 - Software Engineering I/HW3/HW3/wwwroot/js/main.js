$(function () {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/api/user",
        success: populateUserInfo,
        error: errorOnAjax
    });
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/api/repositories",
        success: populateRepoList,
        error: errorOnAjax
    })
})

function errorOnAjax() {
    console.log("ERROR in ajax request");
    // take care of the error, maybe display a message to the user
    // ...
}

function populateUserInfo(data)
{
    $("#avatar").attr("src", data.avatarURL);
    $("#name").html(`<div class="row" style="font-size: 40px"><a href="https://github.com/JustinDavis7">${data.name}</a></div>`);
    $("#userName").text(data.userName);
    $("#email").text(data.email);
    $("#company").text(data.company);
    $("#location").text(data.location);
    console.log("Got user info");
}

function populateRepoList(data)
{
    var name = "";
    var fullName = "";
    for(let i = 0; i < data.length; i++)
    {  
        var button = document.createElement("button");
        name = data[i].name;
        fullName = data[i].fullName;

        button.setAttribute("id", "repoButton");
        button.setAttribute("name", name);
        button.setAttribute("type", "button");
        button.setAttribute("class", "btn");
        button.setAttribute("type", "submit");
        button.setAttribute("style", "color: #017465;"); 
        button.innerHTML = fullName;
        button.addEventListener("click", getCommits);

        $("#repoName").append(button);
    };
    console.log("Made list of repos")
}

function getCommits()
{
    var temp = this.innerHTML.split("/");
    $.ajax({
        type: "GET",
        dataType: "json",
        url: `/api/commits/?owner=${temp[0]}&repositoryName=${temp[1]}`,
        success: populateCommitList,
        error: errorOnAjax
    })
    $("#container2").show();
    console.log("Table shown");
    
    var thead = document.querySelector('#tableRepoName');
    thead.innerHTML = `<a style="color: black; font-size: 30px" href="https://github.com/${temp[0]}/${temp[1]}">${temp[1]}`;

    var tr = document.querySelector('#ownerName');
    tr.innerHTML = `<br>Owner: ${temp[0]}`;

    $.ajax({
        type: "GET",
        dataType: "json",
        url: `/api/repository/?owner=${temp[0]}&repositoryName=${temp[1]}`,
        success: populateOwner,
        error: errorOnAjax
    })
    $.ajax({
        type: "GET",
        dataType: "json",
        url: `/api/branches/?owner=${temp[0]}&repositoryName=${temp[1]}`,
        success: populateBranches,
        error: errorOnAjax
    })
}   

function populateCommitList(data)
{
    var table = document.querySelector("#commitsTable");
    while(table.rows.length > 1)
    {
        table.deleteRow(1);
    }

    for(let i = 0; i < data.length; i++)
    {
        var row = table.insertRow();
        var cell = row.insertCell();
        cell.innerHTML = `<a href=${data[i].htmlUrl}>${data[i].sha.slice(0, 8)}`;
        cell.setAttribute("width", "10%");

        cell = row.insertCell();
        cell.innerHTML = data[i].whenCommitted;
        cell.setAttribute("width", "20%");

        cell = row.insertCell();
        cell.innerHTML = data[i].committer;
        cell.setAttribute("width", "15%");

        cell = row.insertCell();
        cell.innerHTML = data[i].commitMessage;
        cell.setAttribute("width", "55%");
    }

    console.log("Got Commits for current repo");
}

function populateOwner(data)
{
    var tr = document.querySelector('#lastUpdate');

    var currentDate = new Date();
    var updateDate = new Date(data.lastUpdated.split('T')[0]);

    tr.innerHTML = `Last updated: ${Math.trunc((currentDate.getTime() - updateDate.getTime())/ (1000 * 60 * 60 * 24))} days ago`
    
    $("#avatar2").attr("src", data.ownerAvatarUrl);
    console.log("Populated Owner Info");
}

function populateBranches(data)
{
    console.log("Got Branches");
    var table = document.querySelector('#repoOwner');
    while(table.rows.length > 2)
    {
        table.deleteRow(2);
    }
    var row = table.insertRow();
    row.innerHTML = `<li style="color: white">Branches:</li>`
    for(let i = 0; i < data.length; i++)
    {
        var row = table.insertRow();
        row.innerHTML = `<li style="color: white; list-style-type: square">${data[i].name}</li>`
    }
}