---
name: game-2d-export
description: Use when preparing final 2D assets, sprite sheets, frame metadata, pivots, palettes and import-ready files for the game project.
---

# Game 2D export

## Antes de exportar

Confirmar consumidor, formato, dimensiones, escala, transparencia, color space, orden de frames, nombres/tags, pivote y si se requiere atlas o archivos separados.

## Reglas

- Conservar fuente editable separada del export final.
- Recortar solo si no rompe pivote, alineacion o grid.
- Evitar filtrado y compresion con perdida en pixel art.
- No duplicar el primer frame al cerrar un loop salvo contrato expreso.
- Mantener orden determinista: accion, direccion y frame.
- Incluir metadata solo en el formato que el consumidor entiende.
- Verificar alpha limpio, bordes, dimensiones y cantidad de frames despues de exportar.

## Naming sugerido

Usar nombres legibles y estables, por ejemplo `player_run_e_00.png` o tags `idle`, `run`, `attack`. Adaptar el patron al importador real; no crear convenciones paralelas.

## Entrega

Fuente, archivos exportados, dimensiones, pivote/origen, orden/timing, paleta y una preview. Comprobar al menos una importacion real cuando exista el proyecto; si aun no existe, declarar que la integracion queda sin verificar.

