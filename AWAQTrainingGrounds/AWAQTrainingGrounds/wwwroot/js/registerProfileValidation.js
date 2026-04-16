(() => {
  'use strict'

  const forms = document.querySelectorAll('.needs-validation')

  Array.from(forms).forEach(form => {
    form.addEventListener('submit', event => {
      checkDate();

      if (!form.checkValidity()) {
        event.preventDefault()
        event.stopPropagation()
      }

      form.classList.add('was-validated')
    }, false)
  })
})()

function checkDate()
{
  var day = document.getElementById("birth_day");
  var month = document.getElementById("birth_month");
  var year = document.getElementById("birth_year");

  feedback = document.getElementById("date-error")


  if(!validDate())
  {
    day.setCustomValidity("invalid");
    month.setCustomValidity("invalid");
    year.setCustomValidity("invalid"); 
    feedback.textContent = "Por favor selecciona un rango de fechas válido."
  } else {
    var day_value = parseInt(document.getElementById("birth_day").value);
    var month_value = parseInt(document.getElementById("birth_month").value);
    var year_value =  parseInt(document.getElementById("birth_year").value);

    date = new Date(year_value, month_value - 1, day_value)
    today = new Date()
    
    if (date > today)
    {
      day.setCustomValidity("invalid");
      month.setCustomValidity("invalid");
      year.setCustomValidity("invalid"); 
      feedback.textContent = "Por favor selecciona un rango de fechas válido."
    } else {
      today.setFullYear(today.getFullYear() - 18)
      if (date > today)
      {
        day.setCustomValidity("invalid");
        month.setCustomValidity("invalid");
        year.setCustomValidity("invalid"); 
        feedback.textContent = "Debes ser mayor de 18 años."
      } else {
        day.setCustomValidity("");
        month.setCustomValidity("");
        year.setCustomValidity(""); 
      }
    }
  }
} 

function validDate()
{
  var day = parseInt(document.getElementById("birth_day").value);
  var month = parseInt(document.getElementById("birth_month").value);
  var year = parseInt(document.getElementById("birth_year").value);

  var date = new Date(year, month - 1, day)

  return date.getFullYear() === year && date.getMonth() === month - 1 && date.getDate() === day;

}