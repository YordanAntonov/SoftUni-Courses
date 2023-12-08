function solve() {
   Array.from(document.querySelectorAll('.add-product')).forEach(x => x.addEventListener('click', add));
   document.querySelector('.checkout').addEventListener('click', checkout);
   const products = {
      'Bread': 0.8,
      'Milk': 1.09,
      'Tomatoes': 0.99
   }
   const bought = [];
   const textArea = document.querySelector('textarea');
   let cost = 0;
   let textOutput = '';
 
   function add(e) {
      const current = e.currentTarget.parentNode.parentNode.querySelector('.product-title').textContent;
      textOutput = `Added ${current} for ${products[current].toFixed(2)} to the cart.\n`;
      cost += products[current];
      textArea.value += textOutput;
      if (!bought.includes(current)) { bought.push(current) }
   }
 
   function checkout() {
      textOutput = `You bought ${bought.join(', ')} for ${cost.toFixed(2)}.`;
      textArea.value += textOutput;
      Array.from(document.querySelectorAll('button')).forEach(x => x.disabled = true);
   }
}