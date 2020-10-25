var mainform =document.getElementById("studentForm");
var username1 = document.getElementById('firstname');
var username2 = document.getElementById('lastname');
var username = document.getElementById('pfirstname');
var email = document.getElementById('email');
var phone = document.getElementById('phone');
//var address = document.getElementById('add');
mainform.addEventListener('submit',(e) =>{
    e.preventDefault();
    checkInputs();
});


function checkInputs(){
    var userNameValue1 = username1.value.trim();
    var userNameValue2 = username2.value.trim();
    var userNameValue = username.value.trim();
    var emailValue = email.value.trim();
    var phoneValue = phone.value;
    /*var addressValue = address.value.trim();
    */
    if(userNameValue1 === ''){
        setErrorMessage(username1,'Can not be blank');
    }
    else{
               
        setSuccessMessage(username1);
    }
    if(userNameValue2 === ''){
        setErrorMessage(username2,'Can not be blank');
    }
    else{
        setSuccessMessage(username2);
    }
    if(userNameValue === ''){
        setErrorMessage(username,'Can not be blank');
    }
    else{
        setSuccessMessage(username);
    }

    if(emailValue === ''){
        setErrorMessage(email,'Email can not be blank');
    }
    else{
        setSuccessMessage(email);
    }

    if(phoneValue === '' ){
        setErrorMessage(phone,'phone number can not be blank');
    }
    else{
        setSuccessMessage(phone);
    }
    if(phoneValue < 11 ){
        setErrorMessage(phone,'Fill in the complete number');
    }
    else{
        setSuccessMessage(phone);
    }
/*
    if(addressValue ==='' ){
        setErrorMessage(address,'Fill address');
    }
    else{
        setSuccessMessage(phone);
    }
*/
}

function setErrorMessage(input,message){
    var formdesign = input.parentElement;
    var small = formdesign.querySelector('small');
    
    small.innerHTML = message;
    formdesign.className = 'formdesign error';
    
}
function setSuccessMessage(input){
    var formdesign = input.parentElement;
    formdesign.className = 'formdesign success';
    
}
