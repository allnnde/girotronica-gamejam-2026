---
name: urp-rendering
description: Use when configuring or changing Unity URP materials, shaders, lighting, cameras, post-processing or imported asset appearance after the render pipeline is confirmed.
---

# URP rendering para jam

## Preflight

Verificar que el proyecto usa URP y leer la version instalada, renderer, color space y quality actual. No convertir el proyecto a URP ni elegir Renderer2D/Forward por iniciativa propia.

## Reglas

- Reutilizar shaders URP incluidos antes de crear Shader Graph.
- Crear materiales por necesidad visual concreta, con nombres y destino claros.
- Preferir un Volume local por escena a cambiar perfiles globales.
- No modificar `GraphicsSettings` o `QualitySettings` como efecto lateral.
- Para 2D, confirmar si los sprites deben recibir luz antes de elegir Lit/Unlit.
- Para 3D, comprobar escala, normales, tangentes, UV, materiales y canales de textura del asset importado.
- No optimizar efectos sin un problema medido en el hardware o build objetivo.

## Validacion

Comparar en Game view o build con camara, iluminacion y postprocesado reales. Una Scene view bonita no acredita el resultado final. Tras un cambio, revisar consola, apariencia, transparencias, sorting/depth y el smoke afectado.

## Salida

Materiales/ajustes modificados, condicion de observacion, resultado visual, coste conocido y limites. No prometer FPS sin medicion.

