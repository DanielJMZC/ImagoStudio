const button = document.getElementById("profileSubmit");

button.addEventListener("click", function() {
    const selected = document.querySelector(".my-input:checked")
    
    if (selected) {
        const input = document.getElementById("profileInput");
        input.value = selected.value;

        const profile = document.getElementById("profile")
        profile.src = `/Images/Account/character${input.value}portrait.png`
    }
});