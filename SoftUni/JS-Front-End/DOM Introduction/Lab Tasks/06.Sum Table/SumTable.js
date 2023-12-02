function sumTable() {
    let productsPriceCollection = Array.from(document.querySelectorAll('tbody td'));
    let result = document.querySelector('#sum');
    let sum = 0;

    for (let index = 1; index < productsPriceCollection.length - 2; index += 2) {
        
        sum += Number(productsPriceCollection[index].textContent);
        console.log(productsPriceCollection[index].textContent);
    }

    result.textContent = String(sum);
}