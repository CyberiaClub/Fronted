// Función para obtener el valor del parámetro desde la URL
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

    // Aplicamos los filtros automáticamente al cargar la página
    applyFilters();

    // Añadir el evento de cambio para los filtros de categoría y precio
    document.querySelectorAll('.form-check-input[type="checkbox"]').forEach(checkbox => {
        checkbox.addEventListener('change', applyFilters);
    });

    // Añadir evento de cambio para el filtro de precio
    document.getElementById("priceRange").addEventListener('input', applyFilters);
};

// Función para aplicar los filtros de productos
function applyFilters() {
    const selectedCategories = getSelectedCategories();
    const maxPrice = document.getElementById("priceRange").value;

    // Mostrar el valor actual del rango de precio
    document.getElementById("priceValue").textContent = maxPrice;

    const products = document.querySelectorAll("#product-list .col-md-4");

    products.forEach(product => {
        const productPrice = parseFloat(product.getAttribute("data-price"));
        const productCategory = product.getAttribute("data-category");

        // Condición: mostrar solo si cumple con categoría seleccionada y precio
        if ((selectedCategories.length === 0 || selectedCategories.includes(productCategory)) && productPrice <= maxPrice) {
            product.style.display = "block";
        } else {
            product.style.display = "none";
        }
    });
}

// Obtener las categorías seleccionadas
function getSelectedCategories() {
    const categories = [];
    document.querySelectorAll('.form-check-input[type="checkbox"]:checked').forEach(checkbox => {
        categories.push(checkbox.value);
    });
    return categories;
}