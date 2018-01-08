function selectseats(elem, amount) {
    //Get the Row and the Number of the Seat
    let rownumber = elem.id.split('-')
    //Get the selected Seat Number and move the amount of seats to the left
    let begin = rownumber[1] - Math.round(amount/2) + 1
    let booked = false
    //Check if the beginning of the selected Seats is less than 1 or greater than 11
    begin < 1 ? begin = 1 : begin + amount > 11 ? begin = 11 - amount : begin
    //Check if any of the Seats in the selected Row are booked
    for(let i = 0; i < amount; i++){
        if(document.getElementById(rownumber[0] + '-' + (begin + i)).className == 'bookedseat'){
            booked = true
            break
        }
    }
    if(!booked){
        resetseats()
        for(let i = 0; i < amount; i++){
            let element = document.getElementById(rownumber[0] + '-' + (begin + i))
            element.style.backgroundColor = 'yellow'
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