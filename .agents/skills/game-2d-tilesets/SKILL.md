---
name: game-2d-tilesets
description: Use when creating or reviewing grid-based tilesets, autotile sets, modular backgrounds and reusable 2D environment props.
---

# Game 2D tilesets

## Contrato

Confirmar tamano de celda, perspectiva, numero de vecinos/reglas, capas, colision prevista, transparencia y restricciones de paleta. No asumir un formato de autotile antes de conocer el consumidor.

## Flujo

1. Crear tile base y comprobar repeticion.
2. Resolver bordes, esquinas internas/externas y uniones necesarias.
3. Agregar variaciones solo para romper patrones visibles.
4. Separar suelo, pared, overlay y props cuando lo requiera el motor.
5. Montar un mapa de prueba pequeno con todos los casos utilizados.

## Revision

- Sin seams ni pixels fuera de celda.
- Lectura clara de caminable/no caminable.
- Luz y perspectiva coherentes.
- Repeticion aceptable a escala de juego.
- Indices/reglas documentados junto a la exportacion.

Preferir Aseprite AI Artist para pixel art y Krita para fondos raster no modulares. No producir combinaciones que el juego no vaya a usar.

