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
