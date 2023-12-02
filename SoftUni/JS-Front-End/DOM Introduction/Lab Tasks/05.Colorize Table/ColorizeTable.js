function colorize() {
    let tableRows = document.querySelectorAll('tbody tr');
    for (let index = 1; index < tableRows.length; index++) {
        if (index % 2 !== 0){
            tableRows[index].style.background = 'Teal';
        }
    }
}