function validate() {
    document.getElementById('email').addEventListener('change', onChange);

    function onChange(e){
        const regex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/g;

        if (!regex.test(e.currentTarget.value)){
            e.currentTarget.classList.add('error');
        }else{
            e.currentTarget.classList.remove('error');
        }
    }
 
}