---
name: game-2d-animation
description: Use when designing, creating or reviewing frame-by-frame 2D animation, sprite tags, timing, loops and motion consistency.
---

# Game 2D animation

## Plan minimo

Definir accion, lectura jugable, loop/no-loop, FPS o duracion por frame, punto de contacto y frames imprescindibles. Para la jam, producir primero idle y la accion principal; agregar transiciones solo si el corte las necesita.

## Flujo

1. Fijar pivote, baseline y canvas.
2. Dibujar poses clave: anticipacion, accion, impacto y recuperacion cuando correspondan.
3. Probar timing con siluetas.
4. Agregar intermedios solo donde mejoren lectura.
5. Limpiar volumen, paleta, outlines y elementos anclados.
6. Reproducir a velocidad real y revisar el loop sin pausas accidentales.

## Criterios

- La accion se entiende sin detalle fino.
- Los contactos no patinan salvo intencion.
- El volumen no cambia de forma arbitraria.
- El primer/ultimo frame no duplica tiempo en loops.
- Tags, orden y duraciones coinciden con la exportacion.

Usar Aseprite AI Artist para frames/tags. No inventar direcciones o estados no solicitados.

