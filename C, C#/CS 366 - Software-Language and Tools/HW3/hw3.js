function calculate(){
    var loan = document.getElementById("loanAmount").value;
    var interest = document.getElementById("interestRate").value;
    var payment = document.getElementById("payment").value;
    var balance = loan;
    var i = 0;

    if(loan*interest > payment)
    {
        alert("Your payment is too low!");
        return;
    }

    if ($("#paymementTable tbody").length == 0){
        $("#paymementTable").append("<tbody></tbody>");
    }

    do{
        i = i + 1;
        balance = (balance*(1+interest)) - payment;
        $("#paymementTable tbody").append("<tr>" +
    "<td>" + i +"</td>" +
            "<td>" + "$" + payment + "</td>" +
            "<td>" + "$" + balance.toFixed(2) + "</td>" +
            "</tr>");
    }while (balance > 0 && balance > payment)
    $("#paymementTable tbody").append("<tr>" +
    "<td>" + (i+1) +"</td>" +
            "<td>" + "$" + balance.toFixed(2) + "</td>" +
            "<td>" + 0 + "</td>" +
            "</tr>");
}
