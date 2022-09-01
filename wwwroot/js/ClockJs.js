// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const clockDesigns = ["Spedometer", "clock", "clock2", "clock3", "clock4", "clock5"];
const maxLength = clockDesigns.length;
let startIndex = 0;

const clock = document.querySelector(".clock");
clock.style.background = "url('./Images/Spedometer.png')";
clock.style.backgroundSize = "cover";

function changeClock2() {
    startIndex++;
    if (startIndex === maxLength) {
        startIndex = 0;
    }
    clock.style.background = `url('./Images/${clockDesigns[startIndex]}.png')`;
    clock.style.backgroundSize = "cover";
}

const deg = 6;
const hour = document.querySelector(".hour");
const minute = document.querySelector(".minute");
const second = document.querySelector(".second");

setInterval(() => {
    let day = new Date();
    let hh = day.getHours() * 30;
    let mm = day.getMinutes() * deg;
    let ss = day.getSeconds() * deg;

    hour.style.transform = `rotateZ(${hh + mm / 12}deg)`;
    minute.style.transform = `rotateZ(${mm}deg)`;
    second.style.transform = `rotateZ(${ss}deg)`;
});