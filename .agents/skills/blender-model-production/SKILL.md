---
name: blender-model-production
description: Use when planning, creating, revising or exporting a game-ready 3D asset in Blender, including routing to retopology, rigging and animation.
---

# Blender model production

Router principal para trabajo 3D mediante el MCP Blender local.

## Preflight

Antes de editar, confirmar:

- uso del asset y camara/distancia de juego;
- referencias y direccion visual aprobadas;
- unidades, escala, orientacion y pivote;
- presupuesto aproximado de geometria/materiales/texturas;
- si necesita UV, bake, LOD, rig, animacion o colisiones;
- formato y destino de exportacion.

Si el juego aun no se decidio 3D, no producir assets 3D salvo pedido explicito independiente.

## Flujo de jam

1. Bloqueo de silueta y proporcion.
2. Preview desde la camara de uso.
3. Aprobacion de direccion.
4. Geometria y materiales imprescindibles.
5. UV/texturas solo al nivel visible.
6. Retopologia, rig o animacion solo si el corte las requiere.
7. Validacion y exportacion.

## Routing

- `blender-retopology`: topologia de deformacion, reduccion y LOD.
- `blender-rigging`: jerarquia, controles, pesos y deformacion.
- `blender-animation`: acciones, timing, loops y exportacion de clips.

## Validacion

Revisar transforms, dimensiones, normales, UV, materiales, nombres, objetos ocultos, modificadores y dependencias. Medir conteos reales. Probar el archivo exportado cuando exista un consumidor; una escena Blender correcta no acredita la importacion Unity.

## Salida

Archivo fuente/exportado, version, unidades, orientacion, conteos, texturas/materiales, rig/clips si aplican, capturas bajo condiciones conocidas y limites.

