document.getElementById('loginButton').addEventListener('click', function () {
    // Obtener valores
    const email = document.getElementById('email').value;
    const password = document.getElementById('password').value;

    // Limpiar mensajes de error anteriores
    document.getElementById('emailError').textContent = '';
    document.getElementById('passwordError').textContent = '';

    let valid = true;

    // Validación de email
    if (!validateEmail(email)) {
        document.getElementById('emailError').textContent = 'Por favor ingrese un correo válido.';
        valid = false;
    }

    // Validación de contraseña
    if (password.trim() === '') {  // Asegura que el campo de contraseña no esté vacío
        document.getElementById('passwordError').textContent = 'La contraseña no puede estar vacía.';
        valid = false;
    }

    // Si es válido, puedes proceder con la lógica de inicio de sesión
    if (valid) {
        // Aquí puedes ejecutar tu lógica de inicio de sesión (ej. enviar los datos al servidor o redireccionar)
        console.log('Inicio de sesión exitoso');
    }
});

// Función para validar el formato de email
function validateEmail(email) {
    const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return re.test(String(email).toLowerCase());
}