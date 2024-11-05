// Obtener parámetro de la URL
function getParameterByName(name) {
    const urlParams = new URLSearchParams(window.location.search);
    return urlParams.get(name);
}

// Marcar checkbox o radio button según el parámetro de URL
window.onload = function () {
    const categoria = getParameterByName('categoria');
    if (categoria) {
        const checkbox = document.querySelector(`input[value="${categoria}"]`);
        if (checkbox) checkbox.checked = true;
    }

    const sede = getParameterByName('sede');
    if (sede) {
        const radio = document.querySelector(`input[name="sede"][value="${sede}"]`);
        if (radio) radio.checked = true;
    }
};

// Llamada a la API para obtener productos
async function fetchProductos(sede = '', categoria = '', marca = '') {
    try {
        const response = await fetch(`/api/productos?sede=${sede}&categoria=${categoria}&marca=${marca}`);
        const productos = await response.json();
        //depende de como lo tengan en la API
        mostrarProductos(productos);
    } catch (error) {
        console.error('Error al obtener los productos:', error);
    }
}

// Mostrar productos en el HTML
function mostrarProductos(productos) {
    const productList = document.getElementById("product-list");
    productList.innerHTML = ""; // Limpiar el contenedor

    productos.forEach(producto => {
        const productHTML = `
            <div class="col-md-4 mb-4" data-category="${producto.categoria}" data-price="${producto.precio}">
                <a href="detalle_producto.aspx?id=${producto.id}" class="text-decoration-none">
                    <div class="card">
                        <img src="${producto.imagenUrl}" class="card-img-top" alt="${producto.nombre}">
                        <div class="card-body">
                            <h6 class="card-title">${producto.nombre}</h6>
                            <p class="card-text">S/${producto.precio}</p>
                        </div>
                    </div>
                </a>
            </div>
        `;
        productList.insertAdjacentHTML('beforeend', productHTML);
    });
}

// Aplicar filtros
function aplicarFiltros() {
    const sede = document.querySelector('input[name="sede"]:checked')?.value || '';
    const categoria = document.querySelector('input[name="categoria"]:checked')?.value || '';
    const marca = document.querySelector('input[name="marca"]:checked')?.value || '';
    fetchProductos(sede, categoria, marca);
}

// Agregar evento a los filtros
document.querySelectorAll('input[name="sede"], input[name="categoria"], input[name="marca"]').forEach(input => {
    input.addEventListener("change", aplicarFiltros);
});

// Llamar a la función al cargar la página
document.addEventListener("DOMContentLoaded", () => fetchProductos());




//seleccion de sedes
// Función para mostrar el pop-up de selección de sede
function mostrarPopupSede() {
    // Código para mostrar un pop-up. Aquí puedes diseñar el pop-up como prefieras.
    alert("Por favor, seleccione una sede antes de continuar.");
    // Muestra el pop-up reemplazando el alert.
    document.getElementById('popup').style.display = 'flex';
}

function openPopup() {
    document.getElementById("popup").classList.add("active");
}

function closePopup() {
    document.getElementById("popup").classList.remove("active");
}

// Función para aplicar filtros de marca o categoría
function aplicarFiltros() {
    const sedeSeleccionada = document.querySelector('input[name="sede"]:checked');
    const categoriaSeleccionada = document.querySelector('input[name="categoria"]:checked')?.value || '';
    const marcaSeleccionada = document.querySelector('input[name="marca"]:checked')?.value || '';

    if (!sedeSeleccionada) {
        // Si no se ha seleccionado una sede, muestra el pop-up
        mostrarPopupSede();
    } else {
        // Si la sede está seleccionada, redirige según el filtro aplicado
        const sede = sedeSeleccionada.value;
        let url = `/listado_productos.aspx?sede=${sede}`;

        if (categoriaSeleccionada) {
            url += `&categoria=${categoriaSeleccionada}`;
        }
        if (marcaSeleccionada) {
            url += `&marca=${marcaSeleccionada}`;
        }

        // Redirigir a la URL con los filtros aplicados
        window.location.href = url;
    }
}

// Evento para capturar cambios en las opciones de categoría o marca
document.querySelectorAll('input[name="categoria"], input[name="marca"]').forEach(input => {
    input.addEventListener("change", aplicarFiltros);
});

// Evento para la selección de sede que redirige a `listado_pedidos.aspx`
document.querySelectorAll('input[name="sede"]').forEach(input => {
    input.addEventListener("change", () => {
        const sedeSeleccionada = document.querySelector('input[name="sede"]:checked').value;
        if (sedeSeleccionada) {
            window.location.href = `/listado_pedidos.aspx?sede=${sedeSeleccionada}`;
        }
    });
});




// Función para obtener el valor del parámetro desde la URL
function getParameterByName(name) {
    const urlParams = new URLSearchParams(window.location.search);
    return urlParams.get(name);
}

// Al cargar la página, marcar el checkbox correspondiente
window.onload = function () {
    const categoria = getParameterByName('categoria');
    if (categoria) {
        // Busca el checkbox de la categoría y lo marca
        const checkbox = document.querySelector(`input[value="${categoria}"]`);
        if (checkbox) {
            checkbox.checked = true;
        }
    }
};

window.onload = function () {
    const sede = getParameterByName('sede');
    if (sede) {
        // Busca el radio button de la sede y lo marca
        const radio = document.querySelector(`input[name="sede"][value="${sede}"]`);
        if (radio) {
            radio.checked = true;
        }
    }
};
//llamada ala fioncion Api productos
async function fetchProductos() {
    try {
        const response = await fetch('/api/productos');
        const productos = await response.json();
        mostrarProductos(productos);
    } catch (error) {
        console.error('Error al obtener los productos:', error);
    }
}

function mostrarProductos(productos) {
    const productList = document.getElementById("product-list");
    productList.innerHTML = ""; // Limpiar el contenedor

    //FORMATO CON EL QUE SE MUESTRA EN HTML LOS PRODUCTOS
    productos.forEach(producto => {
        const productHTML = `
            <div class="col-md-4 mb-4" data-category="${producto.categoria}" data-price="${producto.precio}">
                <a href="detalle_producto.aspx?id=${producto.id}" class="text-decoration-none">
                    <div class="card">
                        <img src="${producto.imagenUrl}" class="card-img-top" alt="${producto.nombre}">
                        <div class="card-body">
                            <h6 class="card-title">${producto.nombre}</h6>
                            <p class="card-text">S/${producto.precio}</p>
                        </div>
                    </div>
                </a>
            </div>
        `;
        productList.insertAdjacentHTML('beforeend', productHTML);
    });
}

// Llamar a la función al cargar la página
document.addEventListener("DOMContentLoaded", fetchProductos);

//enlace de filtros
function aplicarFiltros() {
    const sede = document.querySelector('input[name="sede"]:checked').value;
    const categoria = document.querySelector('input[name="categoria"]:checked')?.value || '';
    const marca = document.querySelector('input[name="marca"]:checked')?.value || '';
    fetchProductos(sede, categoria, marca);
}

document.querySelectorAll('input[name="sede"], input[name="categoria"], input[name="marca"]').forEach(input => {
    input.addEventListener("change", aplicarFiltros);
});
//Modifica la función fetchProductos para incluir los filtros en la URL,
async function fetchProductos(sede = '', categoria = '', marca = '') {
    try {
        const response = await fetch(`/api/productos?sede=${sede}&categoria=${categoria}&marca=${marca}`);
        const productos = await response.json();
        mostrarProductos(productos);
    } catch (error) {
        console.error('Error al obtener los productos:', error);
    }
}

async function fetchMarcas() {
    try {
        const response = await fetch('/listado_productos.aspx/ObtenerMarcas', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
        });
        const result = await response.json();
        const marcas = result.d; // assuming response structure from WebMethod

        const marcaContainer = document.getElementById("marcaContainer");
        marcaContainer.innerHTML = ""; // Clear any existing checkboxes

        marcas.forEach(marca => {
            const marcaHTML = `
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="${marca}" id="marca${marca.replace(/ /g, '')}" onchange="applyFilters()">
                    <label class="form-check-label" for="marca${marca.replace(/ /g, '')}">${marca}</label>
                </div>
            `;
            marcaContainer.insertAdjacentHTML('beforeend', marcaHTML);
        });
    } catch (error) {
        console.error('Error al obtener las marcas:', error);
    }
}

// Call this function when the page loads
document.addEventListener("DOMContentLoaded", fetchMarcas);