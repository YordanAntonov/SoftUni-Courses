function attachGradientEvents() {
    const gradient = document.getElementById('gradient');

    gradient.addEventListener('mousemove', gradientMove);
    gradient.addEventListener('mouseout', gradientOut);
    
    function gradientMove(e){
        let power = e.offsetX / (e.target.clientWidth - 1);
        power = Math.trunc(power * 100);
        document.getElementById('result').textContent = power + "%"; 
    }
    
    function gradientOut(){
        document.getElementById('result').textContent = "0 %"; 
    }
}

