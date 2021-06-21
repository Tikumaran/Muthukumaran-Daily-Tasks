// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function calculate() {
    var kg = document.getElementById("Kg").value;
    var PricePerKg = 100, petrol = 200, gst = (2 / 100), price = 0;
    PricePerKg = kg * PricePerKg;
    price = PricePerKg + petrol;
    gst = price * gst;
    price = price + gst;
    document.getElementById("Price").value = price;
    
};


