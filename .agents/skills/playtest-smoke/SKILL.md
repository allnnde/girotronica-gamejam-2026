---
name: playtest-smoke
description: Use when checking a playable build or interaction quickly for game-jam readiness, especially the main loop, input, feedback, failure, success and retry path.
---

# Playtest smoke

Validar el camino principal en pocos minutos y detenerse ante el primer bloqueo reproducible.

## Preflight

- Identificar build/escena y delta exactos.
- Confirmar controles y criterio observable.
- Si no hay proyecto o build, devolver `BLOCKED`; un guion no es evidencia de ejecucion.

## Recorrido minimo

1. Iniciar sin error bloqueante.
2. Obtener control con el input previsto.
3. Ejecutar la accion principal.
4. Observar feedback legible e inmediato.
5. Alcanzar exito o fracaso.
6. Reintentar o reiniciar sin quedar atrapado.
7. Repetir una vez el tramo modificado para detectar regresion obvia.

Agregar un caso solo si deriva directamente del cambio, por ejemplo perder foco, quedarse sin recurso o colisionar en un borde. No realizar una auditoria general.

## Prioridad de hallazgos

1. Crash, bloqueo o perdida permanente de control.
2. Loop imposible de completar.
3. Input o feedback ambiguo.
4. Regresion visible del tramo afectado.
5. Pulido cosmetico.

## Salida

- `PASS`, `FAIL` o `BLOCKED`.
- Build/escena/version recorrida.
- Pasos ejecutados.
- Primer fallo con reproduccion e impacto.
- Captura o log solo cuando agrega evidencia util.

No inventar resultados, no exigir una sesion manual al usuario y no escribir tests automatizados salvo pedido expreso.

