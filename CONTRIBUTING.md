# Guia de contribucion — uvmart Web

## Flujo de trabajo (GitHub Flow)

1. Crea una rama desde `main`: `git switch -c tipo/descripcion`
2. Commits siguiendo Conventional Commits.
3. Abre un Pull Request con descripcion clara.
4. Minimo 1 aprobacion antes de merge.
5. Elimina la rama tras el merge.

## Tipos de commit

| Tipo     | Uso                         |
|----------|-----------------------------|
| feat     | Nueva funcionalidad         |
| fix      | Correccion de bug           |
| docs     | Solo documentacion          |
| style    | Formato sin cambio logico   |
| refactor | Refactorizacion interna     |
| test     | Anadir o corregir tests     |
| chore    | Mantenimiento, CI, deps     |

## Reglas

- Primera linea: maximo 72 caracteres.
- Verbo en imperativo: agregar, corregir, eliminar.
- PR: maximo 400 lineas cambiadas, minimo 1 aprobacion.
