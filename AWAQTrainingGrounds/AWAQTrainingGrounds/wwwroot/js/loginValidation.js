(() => {
  'use strict'
  const invalidFeedback1 = document.getElementById("email-error")
  if (invalidFeedback1.textContent.includes("Credenciales inválidas"))
  {
    document.getElementById("loginEmail").classList.add('is-invalid')
    document.getElementById("loginPassword").classList.add('is-invalid')
  }

  const forms = document.querySelectorAll('.needs-validation')

  Array.from(forms).forEach(form => {
    form.addEventListener('submit', event => {
      checkEmail();
      checkPassword()
      
      if (!form.checkValidity()) {
        event.preventDefault()
        event.stopPropagation()
      }

      form.classList.add('was-validated')
    }, false)
  })
})()

function checkEmail()
{
  email = document.getElementById("loginEmail")
  feedback = document.getElementById("email-error")

  regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/

  if (!regex.test(email.value))
  {
    email.setCustomValidity("Invalid Email");
    feedback.textContent = "Ingresa un correo electrónico válido.";
  } else {
    email.setCustomValidity("");
  }
}

function checkPassword()
{
  password = document.getElementById("loginPassword")
  feedback = document.getElementById("password-error")

  if (password.value.length === 0)
  {
    password.setCustomValidity("Invalid");
    feedback.textContent = "Debes ingresar una contraseña."
  } else {
    password.setCustomValidity("");
  }
}