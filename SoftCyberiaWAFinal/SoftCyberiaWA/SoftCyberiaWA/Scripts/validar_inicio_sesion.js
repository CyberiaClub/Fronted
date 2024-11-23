document.getElementById('loginButton').addEventListener('click', function () {
    // Obtener valores
    const email = document.getElementById('personaCorreo').value;
    const password = document.getElementById('personaContrasena').value;


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

function autenticarUsuario(email, password) {
    // Enviar datos al servidor mediante fetch
    fetch("/autenticarUsuario.aspx", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ email, password })
    })
        .then(response => response.json())
        .then(data => {
            if (data.tipoUsuario) {
                redirigirPorTipoUsuario(data.tipoUsuario);
            } else {
                // Manejo de error
                document.getElementById("passwordError").textContent = "Credenciales incorrectas.";
            }
        })
        .catch(error => console.error("Error:", error));
}

// Función para redirigir según el tipo de usuario
function redirigirPorTipoUsuario(tipoUsuario) {
    switch (tipoUsuario) {
        case "cliente":
            window.location.href = "/SoftCyberiaCliente.Master";
            break;
        case "administrador":
        case "vendedor":
        case "almacen":
            window.location.href = "/SoftCyberiaAdministrador.Master";
            break;
        case "falta_verificar":
            window.location.href = "/verificar_correo.aspx";
            break;
        default:
            alert("Tipo de usuario no reconocido.");
    }
}