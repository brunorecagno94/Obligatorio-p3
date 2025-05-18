// ENVÍO: mostrar o esconder formulario común/urgente
document.addEventListener('DOMContentLoaded', function () {
    const checkbox = document.getElementById('checkbox-urgente');
    const sectionComun = document.getElementById('section-comun');
    const sectionUrgente = document.getElementById('section-urgente');

    function habilitarSecciones() {
        const inputsComun = sectionComun.querySelectorAll('input, select');
        const inputsUrgente = sectionUrgente.querySelectorAll('input, select');

        if (checkbox.checked) {
            inputsComun.forEach(input => input.disabled = true);
            inputsUrgente.forEach(input => input.disabled = false);
        } else {
            inputsComun.forEach(input => input.disabled = false);
            inputsUrgente.forEach(input => input.disabled = true);
        }
    }

    checkbox.addEventListener('change', habilitarSecciones);
    habilitarSecciones();
});