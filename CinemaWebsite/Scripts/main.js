function selectseats(elem, amount) {
    let rownumber = elem.id.split('-')
    let begin = rownumber[1] - Math.round(amount/2) + 1
    let booked = false;
    begin < 1 ? begin = 1 : begin + amount > 11 ? begin = 11 - amount : begin;
    for(let i = 0; i < amount; i++){
        if(document.getElementById(rownumber[0] + '-' + (begin + i)).className == 'bookedseat'){
            booked = true;
        }
    }
    if(!booked){
        resetseats()
        for(let i = 0; i < amount; i++){
            document.getElementById(rownumber[0] + '-' + (begin + i)).style.backgroundColor = 'yellow'
        }
    }
}
function resetseats(){
    let seats = document.getElementsByClassName('seat')
    for (let i = 0; i < seats.length; i++){
            seats[i].style.backgroundColor = null
    }
    let bookedseats = document.getElementsByClassName('bookedseat')
    for(let i = 0; i < bookedseats.length; i++){
        bookedseats[i].style.backgroundColor = null
    }
}