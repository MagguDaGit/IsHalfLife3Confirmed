//animations in javascript
function SetQuote() {
    if (document.getElementById("quote")) {
        let arr = ["Noooope", "That's a negative", "Gaben has not blessed us today", "Gordon still waits", "They are busy getting rich of steam",
            "Just like CS:GO anticheat, it is not here yet", "Gambling makes too much money to start on HL3", "Just like your dad, Half-Life 3 still isn't here"];
        let randVal = Math.floor(Math.random() * arr.length);
        let quote = document.getElementById("quote");
        quote.innerHTML = arr[randVal];
    }
    if (document.getElementById("confirmed")) {
        let arr = ["Today we have been blessed!", "Praise Gaben, Half-Life 3 is coming", "Finally some good news", "You best upgrade your pc",
            "y'all ain't ready"];
        let randVal = Math.floor(Math.random() * arr.length);
        let quote = document.getElementById("confirmed");
        quote.innerHTML = arr[randVal];
    }
}
SetQuote(); 

//https://developer.mozilla.org/en-US/docs/Web/API/Element/animate
function Animate() {

    if (document.getElementById("quote")) {
        const animation = [
            { transform: 'rotate(0) scale(0)' },
            { transform: 'rotate(360deg) scale(1)' }
        ];
        const timing = {
            duration: 2000,
            iterations: 1,
        }
        let quote = document.getElementById("quote");
        quote.animate(animation, timing); 
    }
    else if (document.getElementById("confirmed")) {
        const animation = [
            { transform: 'rotate(0) scale(0)' },
            { transform: 'rotate(360deg) scale(1)' }
        ];
        const timing = {
            duration: 2000,
            iterations: 1,
        }
        let quote = document.getElementById("confirmed");
        quote.animate(animation, timing); 
    }
    else {
        console.log("Kunne ikke starte animasjon")
    }
    
}


Animate(); 



//alert("Bruh - from animation"); 
