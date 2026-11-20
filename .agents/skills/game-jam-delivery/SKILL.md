---
name: game-jam-delivery
description: Use when scoping, designing, implementing or closing any game-jam task in this repository; routes work to the smallest playable result and prevents OpenSpec, premature architecture and unrequested engine setup.
---

# Game jam delivery

Entregar primero el nucleo jugable y limitar todo lo demas.

## Flujo

1. Leer `AGENTS.md`, la solicitud y `git status --short`.
2. Identificar una sola salida observable: una decision, un asset, una interaccion o un corte jugable.
3. Si no existe proyecto Unity, no crearlo. Trabajar solo en diseño, assets o configuracion autorizada.
4. Si 2D/3D sigue abierto, no tomar decisiones que cierren esa eleccion.
5. Seleccionar el owner:
   - concepto, loop y recorte: `designer`;
   - codigo e integracion: `dev`;
   - smoke y aceptacion: `playtester`;
   - sprites/raster: `artist2d`;
   - 3D/rig/animacion: `modeler`.
6. Implementar el camino mas corto que mantenga legible el siguiente cambio probable.
7. Validar solo lo afectado y detenerse cuando el criterio observable se cumpla.

## Presupuesto de complejidad

Permitido para la jam:

- constantes y configuracion local faciles de encontrar;
- una escena o flujo vertical antes que sistemas genericos;
- duplicacion pequena antes que una abstraccion incierta;
- placeholders identificados;
- comentarios breves solo para decisiones no obvias.

Evitar salvo necesidad demostrada:

- frameworks internos, factories, buses o capas nuevas;
- configuracion para plataformas no pedidas;
- optimizacion sin medicion;
- migraciones preventivas;
- OpenSpec, ADR y documentacion de proceso extensa;
- tests automatizados no solicitados.

## Cortes recomendados

Un primer corte jugable deberia incluir, como maximo: entrada, accion principal, feedback, condicion de exito o fracaso y reinicio. Menu, guardado, opciones, tutorial, contenido extra y pulido entran despues, solo si el loop ya funciona.

## Cierre

Informar:

- que se puede observar ahora;
- archivos o assets cambiados;
- compilacion/smoke realizados, si aplica;
- limitaciones que afectan la siguiente decision.

No crear backlog preventivo ni convertir ideas opcionales en trabajo pendiente.

