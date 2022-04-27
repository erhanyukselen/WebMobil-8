console.log("3.js");

var changeColor = () => {
    var rangeRed = document.getElementById("range-red");
    var rangeGreen = document.getElementById("range-green");
    var rangeBlue = document.getElementById("range-blue");

    var pickerDiv = document.getElementById("picker-div");

    console.log([rangeRed.value, rangeGreen.value, rangeBlue.value]);
    //var color = "rgb(" + rangeRed.value + "," + rangeGreen.value + "," + rangeBlue.value + ")";
    var color = `rgb(${rangeRed.value},${rangeGreen.value},${rangeBlue.value})`; // üst satır ile aynı işlemi yapar backtik kullanılır stringleri birleştirmek için
    var colorRev = `rgb(${255 - rangeRed.value},${255 - rangeGreen.value},${255 - rangeBlue.value})`; //255-renk dememizin sebebi yazının sürekli okunabilir olması için 
    pickerDiv.innerHTML = color;
    pickerDiv.style.backgroundColor = color;
    pickerDiv.style.color = colorRev;
}

changeColor();