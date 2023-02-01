let navbar = document.querySelector('.navbar')

document.querySelector('#menu-btn').onclick = () =>{
    navbar.classList.toggle('active');
    loginForm.classList.remove('active');
}

let loginForm = document.querySelector('.login-form')

document.querySelector('#login-btn').onclick = () =>{
    loginForm.classList.toggle('active');
    navbar.classList.remove('active');}


window.onscroll = () =>{
    navbar.classList.remove('active');
    loginForm.classList.remove('active');}

let themeBtn = document.querySelector('#theme-btn');
const whcard = document.querySelectorAll('.wh-card');
const bkcard = document.querySelectorAll('.bk-card');
const card = document.querySelectorAll('.card');
const input = document.querySelectorAll('.form-color');


if (localStorage.getItem("theme") === "dark") {
    themeBtn.classList.toggle('fa-sun');
    darkmode();
}


function check() {

    themeBtn.classList.toggle('fa-sun');

    if (themeBtn.classList.contains('fa-sun')) {
        localStorage.setItem("theme", "dark");

    } else {
        localStorage.setItem("theme", "light");
    }

    darkmode();

};


function darkmode() {
    if (localStorage.getItem("theme") === "dark") {
        document.body.classList.add('active');

        card.forEach(txt => {

                txt.classList.remove('bg-white');
                txt.classList.add('bg-dark');

        });

        bkcard.forEach(txt => {
            if (txt.classList.contains('bg-dark')) {

                txt.classList.remove('bg-dark');
                txt.classList.add('bg-white');
            }
        });

        input.forEach(txt => {
            if (txt.classList.contains('bg-light')) {

                txt.classList.remove('bg-light');
                txt.classList.add('bg-dark');
            }
            else {
                txt.classList.remove('bg-dark');
                txt.classList.add('bg-light');
            }
        });
    }
    else {
        document.body.classList.remove('active');

        card.forEach(txt => {
                txt.classList.remove('bg-dark');
                txt.classList.add('bg-white');

        });

        bkcard.forEach(txt => {
            if (txt.classList.contains('bg-white')) {

                txt.classList.remove('bg-white');
                txt.classList.add('bg-dark');
            }
        });

        input.forEach(txt => {
            if (txt.classList.contains('bg-light')) {

                txt.classList.remove('bg-light');
                txt.classList.add('bg-dark');
            }
            else {
                txt.classList.remove('bg-dark');
                txt.classList.add('bg-light');
            }
        });

    }
}


themeBtn.onclick = () => {
    check(); 
};


var path = window.location.pathname;
var page = path.split('.').slice(0, -1).join('.')
page = page.replace('/', '');
page = page.replace('-', '');
//console.log(page);

document.getElementById(page).setAttribute("class", "list active");

