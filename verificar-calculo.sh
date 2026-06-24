#!/bin/bash
# verificar-calculo.sh
# Uso: bash verificar-calculo.sh
# Sale con 0 si calcularTotal usa multiplicacion (CORRECTO)
# Sale con 1 si usa suma u otro operador         (BUG)
grep -q "return precio \* cantidad" app.js
