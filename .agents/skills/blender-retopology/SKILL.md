---
name: blender-retopology
description: Use when reducing, rebuilding or reviewing Blender mesh topology for game use, deformation, shading, UVs or requested LODs.
---

# Blender retopology

## Objetivo

Crear la topologia mas simple que conserve silueta, shading y deformacion visibles en el uso objetivo.

## Flujo

1. Medir mesh fuente y fijar un objetivo basado en camara/uso, no un numero universal.
2. Preservar silueta y articulaciones antes que detalle plano.
3. Mantener loops donde cambie la forma o deba deformarse.
4. Evitar poles problematicos en zonas de flexion y caras degeneradas.
5. Recalcular/revisar normales, smoothing y tangentes.
6. Crear UV sin overlaps accidentales; reservar densidad al foco visible.
7. Si hay bake, comprobar cage, proyeccion y artefactos.
8. Para LOD, probar cada nivel a la distancia/tamano previsto.

## Cierre

Informar vertices/triangulos, materiales, UV sets, LODs y diferencias visibles. No retopologizar props simples si una limpieza o decimate controlado cumple el criterio de jam.

