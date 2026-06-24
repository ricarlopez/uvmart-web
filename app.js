/**
 * @file app.js
 * @description Funciones principales de uvmart Web
 * @version 1.0.0
 */

// uvmart — Funciones principales de la aplicacion
// ====================================================

const IMPUESTO = 0.16; // IVA vigente en Mexico

/**
 * Calcula el subtotal de un producto.
 * @param {number} precio   - Precio unitario del producto
 * @param {number} cantidad - Cantidad de unidades
 * @returns {number} Subtotal (precio por cantidad)
 */
function calcularTotal(precio, cantidad) {
  return precio * cantidad;
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

// Datos de productos
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
