$(function () {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/api/task",
        success:  populateTaskTable,
        error: errorOnAjax
    })
})

function errorOnAjax() {
    console.log("ERROR on ajax request");
}

function populateTaskTable(data)
{
    console.log("Data recieved, now populating table.");
    var table = document.querySelector("#tasks")

    while(table.rows.length > 1)
    {
        table.deleteRow(1);
    }
    if(data.length == 0)
    {
        var row = table.insertRow();
        row.innerHTML = "You have no tasks!";
    }
    else
    {
        for(let i = 0; i < data.length; i++)
        {
            var row = table.insertRow();

            var cell = row.insertCell();
            cell.innerHTML = data[i].name;
            cell.setAttribute("width", "10%");

            cell = row.insertCell();
            cell.innerHTML = data[i].firstCompletion.split("T")[0];

            cell = row.insertCell();
            cell.innerHTML = data[i].notes
        }
    }
}

function getTaskValues() {
    const firstCompletion = document.getElementById("start-date-input");
    const frequency = document.getElementById("interval-input");
    const notes = document.getElementById("description-input");
    const createTaskForm = document.getElementById("create-new-task");
    if (!createTaskForm.checkValidity()) {
        alert("One or more form values are invalid.");
        return { status: false };
    }
    return {
        status: true,
        firstCompletion: new Date(firstCompletion.value).toISOString(),
        frequency: Number(frequency.value),
        notes: notes.value,
        name: "",
        itemId: Number(null)
    }
}

$(function () {
    $(".btn-secondary").click(function () {
        console.log("Adding task button was clicked.")
        var itemId = this.dataset.itemId;
        var itemName = this.dataset.itemName;
        $("#taskModal").modal("show");
        var modal = document.querySelector(".modal-title");
        modal.innerHTML = itemName;
        modal.id = itemId;
    });

    $(".closer").click(function () {
        $("#taskModal").modal("hide");
    });

    $("#add-task-button").click(function() {
        const values = getTaskValues();
        values.name = document.querySelector(".modal-title").innerHTML;
        values.itemId = document.querySelector(".modal-title").id;
        $("#taskModal").modal("hide");
        if (values.status) {
            console.log("Got values for task.");
            $.ajax({
                method: "POST",
                url: "/api/task",
                dataType: "json",
                contentType: "application/json; charset=UTF-8",	// data type to send
                data: JSON.stringify(values),
                success: populateTaskTable,
                error: errorOnAjax
            });
        }
        else {

        }
    })
});