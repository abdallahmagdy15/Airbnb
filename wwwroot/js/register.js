var firstPage = document.getElementsByClassName('first-page');
var secondPage = document.getElementsByClassName('second-page');
var firstContinueBtn = document.getElementById('continue1');

firstContinueBtn.addEventListener('click',()=>{
    firstPage[0].style.display="none";
    firstPage[1].style.display="none";
    secondPage[0].style.display="block"
    console.log("clicked");
})

var secondPage = document.getElementsByClassName('second-page');
var secondContinueBtn = document.getElementById('continue2');
var thirdPage = document.getElementsByClassName('steps');

secondContinueBtn.addEventListener('click',()=>{
    firstPage[0].style.display="none";
    firstPage[1].style.display="none";
    secondPage[0].style.display="none";
    thirdPage[0].style.display="block"
    console.log("clicked");
})

var final = document.getElementsByClassName('final');
var thirdContineBtn = document.getElementById('continue3');
thirdContineBtn.addEventListener('click',()=>{
    firstPage[0].style.display="none";
    firstPage[1].style.display="none";
    secondPage[0].style.display="none";
    thirdPage[0].style.display="none"
    final[0].style.display="block";
    console.log("clicked");
})

