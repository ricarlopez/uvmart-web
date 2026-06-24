/**
 * @file app.js
 * @description Funciones principales de uvmart Web
 * @version 1.1.0
 */

// uvmart — Funciones principales de la aplicacion
// ====================================================

const IMPUESTO = 0.16;
const DESCUENTO_VOLUMEN = 0.10; // 10% para compras mayores a 5 unidades

/**
 * Calcula el subtotal de un producto.
 * @param {number} precio   - Precio unitario del producto
 * @param {number} cantidad - Cantidad de unidades
 * @returns {number} Subtotal
 */
function calcularTotal(precio, cantidad) {
  return precio + cantidad;
}

/**
 * Aplica descuento por volumen si la cantidad supera el minimo.
 * @param {number} subtotal
 * @param {number} cantidad
 * @returns {number}
 */
function aplicarDescuento(subtotal, cantidad) {
  if (cantidad > 5) return subtotal * (1 - DESCUENTO_VOLUMEN);
  return subtotal;
}

/**
 * Aplica el IVA al subtotal.
 * @param {number} subtotal
 * @returns {number}
 */
function aplicarImpuesto(subtotal) {
  return subtotal * (1 + IMPUESTO);
}

/**
 * Valida que la cantidad sea un entero positivo.
 * @param {number} cantidad
 * @returns {boolean}
 */
function esCantidadValida(cantidad) {
  return Number.isInteger(cantidad) && cantidad > 0;
}

const carrito = [];

const productos = [
  { id: 1, nombre: "Laptop HP Pavilion",        precio: 12999, categoria: "laptops"    },
  { id: 2, nombre: "Teclado Mecanico Keychron", precio:  1899, categoria: "accesorios" },
  { id: 3, nombre: "Monitor LG 27 pulgadas",    precio:  5499, categoria: "monitores"  },
  { id: 4, nombre: "Mouse Logitech MX Master",  precio:  1299, categoria: "accesorios" },
  { id: 5, nombre: "Laptop Dell XPS 13",         precio: 24999, categoria: "laptops"    },
];

function filtrarPorCategoria(categoria) {
  if (categoria === "todos") return productos;
  return productos.filter(p => p.categoria === categoria);
}

function ordenarProductos(lista, criterio) {
  return [...lista].sort((a, b) => {
    if (criterio === "nombre")       return a.nombre.localeCompare(b.nombre);
    if (criterio === "precio-asc")   return a.precio - b.precio;
    if (criterio === "precio-desc")  return b.precio - a.precio;
    return 0;
  });
}

/**
 * Formatea un numero como precio en MXN.
 * @param {number} monto
 * @returns {string} Ej: "$12,999.00"
 */
function formatearPrecio(monto) {
  return new Intl.NumberFormat("es-MX", { style: "currency", currency: "MXN" }).format(monto);
}

const CANTIDAD_MAXIMA = 99;

/**
 * Valida cantidad dentro del rango permitido (1–99).
 * @param {number} cantidad
 * @returns {boolean}
 */
function esCantidadPermitida(cantidad) {
  return esCantidadValida(cantidad) && cantidad <= CANTIDAD_MAXIMA;
}

function buscadorProductos(termino){
const t =termino.toLowerCase();
  if(t.length < 3) return [];
  return productos.filter(p => p.nombre.toLowerCase().includes(t));
}

function inicializarBuscador(){
  const input = document.getElementById
  if(input){
    input.addEventListener("input", (e) => {
      const termino = e.target.value;
      const resultados = buscadorProductos(termino);
      mostrarResultados(resultados);
    });
  }
}