(() => {
  'use strict'
  const invalidFeedback = document.getElementById("email-error")
  console.log("error:", invalidFeedback.textContent)
  if (invalidFeedback.textContent.includes("El correo electrónico debe ser único"))
  {
    document.getElementById("registerEmail").classList.add('is-invalid')
  }

  const forms = document.querySelectorAll('.needs-validation')

  Array.from(forms).forEach(form => {
    form.addEventListener('submit', event => {
        checkName();
        checkEmail();
        checkPassword();
        checkConfirmPassword();
        
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
  email = document.getElementById("registerEmail")
  feedback = document.getElementById("email-error")

  regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/

  if (!regex.test(email.value))
  {
    email.setCustomValidity("Invalid Email");
    feedback.textContent = "El correo no es válido.";
  } else {
    email.setCustomValidity("");
  }
}

function checkPassword()
{
  password = document.getElementById("registerPassword")
  feedback = document.getElementById("password-error")

  if (password.value.length === 0)
  {
    password.setCustomValidity("Invalid");
    feedback.textContent = "Debes ingresar una contraseña."
  } else if (password.value.length < 5) {
        password.setCustomValidity("Invalid");
        feedback.textContent = "La contraseña tiene menos de 5 caracteres.";
  } else {
    password.setCustomValidity("");
  }
}

function checkConfirmPassword()
{

  password = document.getElementById("registerPassword")
  confirmPassword = document.getElementById("registerConfirmPassword")
  confirmFeedback = document.getElementById("confirmPassword-error")

  if (confirmPassword.value.length === 0)
  {
    confirmPassword.setCustomValidity("Invalid");
    confirmFeedback.textContent = "Debes ingresar una contraseña."
  } else if (confirmPassword.value.length < 5) {
        confirmPassword.setCustomValidity("Invalid");
        confirmFeedback.textContent = "La contraseña tiene menos de 5 caracteres.";
  } else if (password.value != confirmPassword.value) {
        confirmPassword.setCustomValidity("Invalid");
        confirmFeedback.textContent = "Las contraseñas no coinciden."
  } else {
    confirmPassword.setCustomValidity("");
  }
}

function checkName()
{
    nombre = document.getElementById("registerName");
    feedback = document.getElementById("name-error");

    if (nombre.value.length === 0)
    {
        nombre.setCustomValidity("Invalid");
        feedback.textContent = "Debes ingresar un nombre."
    } else {
        nombre.setCustomValidity("");
    }
}