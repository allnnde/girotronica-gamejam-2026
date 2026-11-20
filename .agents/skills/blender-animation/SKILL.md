---
name: blender-animation
description: Use when creating or reviewing Blender game animation actions, loops, root motion, contacts, timing and exported clips.
---

# Blender animation

## Plan

Definir accion, lectura jugable, duracion/FPS, loop, root motion o in-place, contactos, orientacion y lista exacta de clips. Para jam, producir primero idle y accion principal.

## Flujo

1. Verificar rig, rest pose y escala.
2. Bloquear poses clave y timing.
3. Revisar arcos, peso, anticipacion, impacto y recuperacion segun la accion.
4. Corregir foot sliding y contactos.
5. Limpiar curvas solo donde mejore lectura; evitar sobrepulido invisible.
6. Comprobar inicio/fin del loop sin duplicar pausa.
7. Separar acciones con nombres/rangos claros.
8. Exportar y reproducir los clips reales en el destino cuando exista.

## Salida

Clips, rangos, FPS/duracion, loop, root motion, rig/version, evidencia de reproduccion y limites. Un preview en Blender no certifica importacion ni comportamiento de gameplay.

