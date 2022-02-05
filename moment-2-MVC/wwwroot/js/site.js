// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

const { get } = require("jquery");

// Write your JavaScript code.
function formValidationDouble(formName) {
    let form = document.forms[formName].getElementsByTagName("input");
    let containers = document.getElementsByClassName("message")
    console.log(form[0].value)
    if (form[0].value == "") {
        for (let i = 0; i < containers.length; i++) {
         containers[i].innerHTML = "<span>Please fill in the field</span>"
        }
        
    }
    else {
        document.forms[formName].submit();
    }
}