---
name: blender-rigging
description: Use when building or reviewing a Blender armature, controls, skin weights, attachments and deformation for a game asset.
---

# Blender rigging

## Preflight

Confirmar movimientos necesarios, tipo de esqueleto, exportador/importador, root motion o in-place, attachments y limites reales de influencias. No crear un rig completo si el asset solo necesita una animacion rigida simple.

## Flujo

1. Aplicar/entender transforms antes de bind.
2. Construir una jerarquia pequena con nombres estables y root claro.
3. Separar huesos de deformacion y controles cuando el exportador lo requiera.
4. Vincular y pintar pesos empezando por zonas de contacto.
5. Probar poses extremas solicitadas y corregir colapsos/volumen.
6. Revisar influencias, normalizacion, vertices sin peso y attachments.
7. Exportar solo huesos/objetos requeridos y verificar el resultado importado cuando sea posible.

## Salida

Jerarquia, bind/rest pose, influencias relevantes, controles no exportables, pruebas de deformacion y limites. No afirmar compatibilidad Humanoid/Generic sin comprobar el importador real.

