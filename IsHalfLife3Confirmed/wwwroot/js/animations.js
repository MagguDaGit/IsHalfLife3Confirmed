//animations in javascript
function SetQuote() {
    if (document.getElementById("quote")) {
        console.log("Setter quote");
        let arr = ["Noooope", "That's a negative", "Gaben has not blessed us today", "Gordon still waits", "They are busy getting rich of steam",
            "Just like CS:GO anticheat, it is not here yet", "Gambling makes too much money to start on HL3", "Just like your dad, Half-Life 3 still isn't here"];
        let randVal = Math.floor(Math.random() * arr.length);
        let quote = document.getElementById("quote");
        quote.innerHTML = arr[randVal];
    }
}
SetQuote(); 

//https://developer.mozilla.org/en-US/docs/Web/API/Element/animate
function Animate() {
    console.log("Sjekker om vi finner quote å animere")
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
    else {
        console.log("Kunne ikke starte animasjon")
    }
    
}


Animate(); 



//alert("Bruh - from animation"); 
