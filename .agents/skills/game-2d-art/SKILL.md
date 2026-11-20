---
name: game-2d-art
description: Use when planning, producing or integrating 2D game art and deciding whether Aseprite AI Artist or PaintBridge/Krita is the right local tool.
---

# Game 2D art

Router y contrato comun para arte 2D.

## Preflight visual

Antes de producir, reunir solo lo necesario:

- uso en juego y tamano real de pantalla;
- pixel art o raster pintado;
- camara/perspectiva, silueta y referencias aprobadas;
- paleta, luz, fondo y transparencia;
- estados/frames requeridos;
- dimensiones, pivote, nombres y formato de entrega.

Si falta una decision que invalida el asset, no rellenarla por costumbre. Producir primero una muestra pequena para aprobar direccion.

## Routing local

- `pixel-art-sprites`: personajes, objetos e iconos pixel art.
- `game-2d-animation`: movimiento frame a frame.
- `game-2d-tilesets`: tiles, autotiles y props modulares.
- `game-2d-art-review`: revision visual y tecnica.
- `game-2d-export`: limpieza, atlas y metadata.
- Aseprite AI Artist: edicion precisa de pixels, layers, frames, tags y tiles.
- PaintBridge/Krita: concepts, ilustracion raster, paintovers y texturas pintadas.

## Iteracion de jam

1. Silueta o bloque de color.
2. Una muestra a escala de uso.
3. Aprobacion de direccion.
4. Estados/frames imprescindibles.
5. Revision y exportacion.

No producir variantes, resoluciones o animaciones no solicitadas. Conservar fuente editable y distinguir preview de archivo final.

## Entrega

Incluir archivo fuente/exportado, dimensiones, paleta si aplica, pivote/origen, lista de frames/tags y una preview a escala real.

