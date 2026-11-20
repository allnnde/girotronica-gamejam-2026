---
name: unity-ui
description: Use when creating or changing Unity runtime HUDs, menus, overlays or interactive screens after the project and UI direction have been confirmed.
---

# Unity UI para jam

## Antes de editar

- Confirmar stack UI, resolucion/aspect objetivo e inputs pedidos.
- Si el proyecto aun no existe, no crear prefabs ni elegir uGUI/UI Toolkit.
- Definir la informacion minima que permite jugar el loop.

## Implementacion

- Una pantalla o HUD simple antes que un sistema de navegacion generico.
- Separar presentacion y decision solo lo suficiente para evitar logica duplicada.
- Estados esenciales: normal, seleccionado/deshabilitado cuando aplique y feedback de error.
- Texto legible, contraste suficiente y no depender solo del color.
- Evitar animaciones, responsive multi-formato, localizacion y gamepad si no estan en alcance.
- No hardcodear contenido que el mismo corte deba cambiar en varios lugares; una constante local es valida para contenido estable de la jam.

## Validacion

Comprobar el aspecto objetivo, input principal, visibilidad durante gameplay, superposiciones y retorno al juego. Usar `playtest-smoke`; no crear una suite automatizada por tocar UI.

## Salida

Pantalla/prefab modificado, comportamiento visible, controles probados y limitaciones reales.

