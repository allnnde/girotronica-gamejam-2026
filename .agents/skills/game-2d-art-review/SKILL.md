---
name: game-2d-art-review
description: Use when reviewing a 2D asset for visual direction, gameplay readability, consistency and delivery correctness before integration.
---

# Game 2D art review

Revisar la version concreta del asset, no una descripcion ni una preview desactualizada.

## Orden

1. Lectura en contexto y tamano real.
2. Silueta, foco y contraste.
3. Consistencia con referencias aprobadas.
4. Paleta, luz, perspectiva y volumen.
5. Bordes, transparencia, seams, pivote y metadata.
6. Animacion/tiles solo si forman parte del encargo.

## Severidad

- Bloqueante: formato ilegible, asset inutilizable o contradiccion del criterio principal.
- Alta: falla de lectura, escala, pivote o consistencia que afecta gameplay.
- Media: defecto visible que admite integracion temporal.
- Baja: pulido opcional.

## Salida

`APROBADO`, `CORREGIR` o `BLOQUEADO`; version revisada; hallazgos ordenados; correccion concreta; evidencia a escala de uso. No pedir pulido fuera del alcance ni certificar integracion sin verla en el consumidor.

