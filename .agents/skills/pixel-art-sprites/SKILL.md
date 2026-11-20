---
name: pixel-art-sprites
description: Use when creating or repairing pixel-art characters, props, icons or sprite sheets with controlled silhouettes, clusters and palettes.
---

# Pixel art sprites

## Construccion

1. Fijar canvas, escala de visualizacion y fondo de contraste.
2. Bloquear silueta con masas grandes antes de detalle.
3. Definir una fuente de luz y una paleta pequena con roles claros.
4. Construir clusters; evitar ruido de pixels aislados y pillow shading.
5. Reservar contraste alto para foco, cara, arma o interaccion.
6. Revisar a 1x y a la escala exacta de juego.

## Consistencia

- Mantener proporcion, volumen, outline y luz entre estados.
- Evitar subpixel accidental si el pipeline exige pixel-perfect.
- No interpolar al escalar; usar nearest-neighbor.
- Alinear pivote y baseline antes de animar.

## Herramienta

Preferir Aseprite AI Artist para pixels, capas, frames y paleta. PaintBridge/Krita sirve para concept o paintover, pero una reduccion automatica no sustituye una limpieza pixel a pixel.

## Salida

Canvas, paleta, escala de uso, pivote, fondo/transparencia y lista de estados. Mostrar preview a 1x y ampliada sin filtrado.

