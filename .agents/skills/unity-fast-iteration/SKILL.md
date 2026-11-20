---
name: unity-fast-iteration
description: Use when implementing or validating Unity gameplay in this repository after a Unity project exists; focuses on compile, console and a short play-mode smoke without automated test suites.
---

# Unity fast iteration

## Guardia inicial

Comprobar que existen `Assets/`, `Packages/` y `ProjectSettings/`. Si faltan, no crear el proyecto ni asumir version, template o dimension; informar que Unity aun no esta inicializado.

## Ciclo

1. Abrir el proyecto con Unity Relay cuando este disponible.
2. Esperar importacion y compilacion.
3. Corregir primero el error bloqueante mas cercano al delta.
4. Entrar en Play Mode sobre la escena afectada.
5. Recorrer el corte definido en `playtest-smoke`.
6. Salir de Play Mode y confirmar que no quedaron errores bloqueantes.
7. Repetir solo las comprobaciones afectadas por la ultima correccion.

## Reglas de implementacion

- Pocos componentes con responsabilidad visible.
- Referencias serializadas o resolucion local clara; evitar service locators nuevos.
- Placeholders permitidos si estan identificados y no rompen el loop.
- No crear infraestructura para contenido futuro.
- No cambiar version, render pipeline, input package o plataforma como efecto lateral.
- No agregar tests automatizados salvo pedido expreso.

## Evidencia

Entregar estado de compilacion, escena recorrida, resultado del smoke, errores relevantes y limites del entorno. Una consola limpia no demuestra que el juego sea divertido ni que todo el producto funcione.

