document.addEventListener("DOMContentLoaded", function () {
    const btnAsignar = document.getElementById("<%= btnAsignar.ClientID %>");
    const tipoDocumento = document.getElementById("<%= tipo_documento.ClientID %>");
    const dni = document.getElementById("<%= dni.ClientID %>");
    const nombre = document.getElementById("<%= nombre.ClientID %>");
    const correo = document.getElementById("<%= correo.ClientID %>");
    const telefono = document.getElementById("<%= telefono.ClientID %>");
    const direccion = document.getElementById("<%= direccion.ClientID %>");
    const rol = document.getElementById("<%= rol.ClientID %>");
    const sueldo = document.getElementById("<%= sueldo.ClientID %>");
    const sede = document.getElementById("<%= sede.ClientID %>");

    // Validar entrada del campo sueldo
    sueldo.addEventListener("input", function () {
        this.value = this.value.replace(/[^0-9.]/g, ""); // Permitir solo números y puntos
    });

    // Validar al hacer clic en el botón
    btnAsignar.addEventListener("click", function (event) {
        // Validar que todos los campos estén completos
        if (
            tipoDocumento.value === "0" ||
            dni.value.trim() === "" ||
            nombre.value.trim() === "" ||
            correo.value.trim() === "" ||
            telefono.value.trim() === "" ||
            direccion.value.trim() === "" ||
            rol.value === "0" ||
            sueldo.value.trim() === "" ||
            sede.value === "0"
        ) {
            alert("Por favor, complete todos los campos.");
            event.preventDefault();
            return false;
        }

        // Validar la longitud del número de documento
        const tipoDocValue = tipoDocumento.value;
        const dniLength = dni.value.trim().length;

        if (
            (tipoDocValue === "1" && dniLength !== 8) || // DNI debe tener 8 caracteres
            ((tipoDocValue === "2" || tipoDocValue === "3") && dniLength !== 12) // Pasaporte o Carnet de Extranjería deben tener 12 caracteres
        ) {
            alert("El número de documento no cumple con la longitud requerida.");
            event.preventDefault();
            return false;
        }

        // Validar el sueldo
        if (!/^\d+(\.\d+)?$/.test(sueldo.value.trim())) {
            alert("Por favor, ingrese un sueldo válido (solo números y el carácter '.').");
            event.preventDefault();
            return false;
        }

        // Si todo es válido
        alert("Formulario validado correctamente.");
    });
});