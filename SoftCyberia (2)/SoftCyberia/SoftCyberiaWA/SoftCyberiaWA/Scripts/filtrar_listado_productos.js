// Archivo: filtros.js
function filterProducts() {
    const selectedCategories = [];

    // Obtener todas las categorías seleccionadas
    const checkboxes = document.querySelectorAll('input[type="checkbox"]:checked');
    checkboxes.forEach(checkbox => {
        selectedCategories.push(checkbox.value);
    });

    // Obtener todos los productos
    const products = document.querySelectorAll('.col-md-4.mb-4');

    // Mostrar u ocultar productos según la categoría seleccionada
    products.forEach(product => {
        const productCategory = product.getAttribute('data-category');
        if (selectedCategories.length === 0 || selectedCategories.includes(productCategory)) {
            product.style.display = 'block';  // Mostrar producto
        } else {
            product.style.display = 'none';  // Ocultar producto
        }
    });
}

// Añadir evento de cambio a los checkboxes
document.querySelectorAll('input[type="checkbox"]').forEach(checkbox => {
    checkbox.addEventListener('change', filterProducts);
});


// Cargamos los productos y aplicamos los filtros en una sola función
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

// Inicializar el filtro cuando cambie el precio o la categoría
document.addEventListener('DOMContentLoaded', function () {
    applyFilters(); // Aplicamos los filtros al cargar la página
});
