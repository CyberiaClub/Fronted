﻿// Función para obtener el valor del parámetro desde la URL
function getParameterByName(name) {
    const urlParams = new URLSearchParams(window.location.search);
    return urlParams.get(name);
}

// Al cargar la página, marcar el checkbox correspondiente y aplicar los filtros
window.onload = function () {
    const categoria = getParameterByName('categoria');
    if (categoria) {
        // Busca el checkbox de la categoría y lo marca
        const checkbox = document.querySelector(`input[value="${categoria}"]`);
        if (checkbox) {
            checkbox.checked = true;
        }
    }

    // Aplicar los filtros automáticamente al cargar la página
    applyFilters();

    // Añadir el evento de cambio para los filtros de categoría y precio
    document.querySelectorAll('.form-check-input[type="checkbox"]').forEach(checkbox => {
        checkbox.addEventListener('change', applyFilters);
    });

    // Añadir evento de cambio para el filtro de precio
    document.getElementById("priceRange").addEventListener('input', applyFilters);
};

// Función para aplicar los filtros de productos
//function applyFilters() {
//    const selectedCategories = getSelectedCategories();
//    const maxPrice = document.getElementById("priceRange").value;

//    // Mostrar el valor actual del rango de precio
//    document.getElementById("priceValue").textContent = maxPrice;

//    const products = document.querySelectorAll("#product-list .col-md-4");

//    products.forEach(product => {
//        const productPrice = parseFloat(product.getAttribute("data-price"));
//        const productCategory = product.getAttribute("data-category");

//        // Condición: mostrar solo si cumple con categoría seleccionada y precio
//        if ((selectedCategories.length === 0 || selectedCategories.includes(productCategory)) && productPrice <= maxPrice) {
//            product.style.display = "block";
//        } else {
//            product.style.display = "none";
//        }
//    });
//}
function applyFilters() {
    const selectedSede = document.querySelector('input[name="sede"]:checked');
    const selectedCategories = getSelectedCategories();
    const maxPrice = document.getElementById("priceRange").value;

    // Mostrar el valor actual del rango de precio
    document.getElementById("priceValue").textContent = maxPrice;

    const products = document.querySelectorAll("#product-list .col-md-4");

    let hasVisibleProducts = false;

    products.forEach(product => {
        const productPrice = parseFloat(product.getAttribute("data-price"));
        const productSede = product.getAttribute("data-sede");
        const productCategory = product.getAttribute("data-category");

        // Mostrar el producto solo si cumple con sede seleccionada, categoría seleccionada y precio
        if (
            (!selectedSede || selectedSede.value === productSede) &&
            (selectedCategories.length === 0 || selectedCategories.includes(productCategory)) &&
            productPrice <= maxPrice
        ) {
            product.style.display = "block";
            hasVisibleProducts = true;
        } else {
            product.style.display = "none";
        }
    });

    // Mostrar un mensaje si no hay productos visibles
    const noProductsMessage = document.getElementById("no-products-message");
    if (!hasVisibleProducts) {
        if (!noProductsMessage) {
            const message = document.createElement("p");
            message.id = "no-products-message";
            message.textContent = "No hay productos disponibles para la combinación seleccionada.";
            message.style.color = "red";
            document.getElementById("product-list").appendChild(message);
        }
    } else {
        if (noProductsMessage) {
            noProductsMessage.remove();
        }
    }
}
//para los filstros de sedes solo seleccione uno
//metodo 1
//function selectOnlyOne(selectedCheckbox) {
//    const checkboxes = document.querySelectorAll('input[name="sede"]');
//    checkboxes.forEach((checkbox) => {
//        if (checkbox !== selectedCheckbox) {
//            checkbox.checked = false;
//        }
//    });
//}
// Para los filtros de sedes: solo permitir seleccionar uno a la vez
function selectOnlyOne(selectedCheckbox) {
    const checkboxes = document.querySelectorAll('input[name="sede"]');
    checkboxes.forEach((checkbox) => {
        if (checkbox !== selectedCheckbox) {
            checkbox.checked = false;
        }
    });
    applyFilters(); // Llama a applyFilters para aplicar el filtro de sede
}
//metodo 2
//function selectOnlyOne(selectedCheckbox) {
//    const checkboxes = document.querySelectorAll('input[name="sede"]');
//    checkboxes.forEach((checkbox) => {
//        if (checkbox !== selectedCheckbox) {
//            checkbox.checked = false;
//        }
//    });

//    // Obtener el idSede seleccionado
//    const idSede = selectedCheckbox.value;

//    // Realizar una solicitud AJAX para recargar los productos
//    fetch(`listado_productos.aspx?idSede=${idSede}`)
//        .then(response => response.text())
//        .then(data => {
//            // Actualizar el contenedor de productos con la respuesta del servidor
//            document.getElementById('product-list').innerHTML = data;
//        });
//}
// Obtener las categorías seleccionadas
function getSelectedCategories() {
    const categories = [];
    document.querySelectorAll('.form-check-input[name="categoria"]:checked').forEach(checkbox => {
        categories.push(checkbox.value);
    });
    return categories;
}

// Llamar a applyFilters cada vez que cambia la selección de sede o categoría
document.querySelectorAll('input[name="sede"]').forEach(checkbox => {
    checkbox.addEventListener('change', applyFilters);
});
document.querySelectorAll('.form-check-input[name="categoria"]').forEach(checkbox => {
    checkbox.addEventListener('change', applyFilters);
});
document.getElementById("priceRange").addEventListener('input', applyFilters);



