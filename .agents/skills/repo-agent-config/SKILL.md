---
name: repo-agent-config
description: Use when creating, auditing or changing this repository's AGENTS policy, local agent profiles, local skills or MCP configuration while keeping the setup self-contained.
---

# Repo agent config

Mantener toda la superficie agentica util dentro del repositorio.

## Owners

- `AGENTS.md`: politica, alcance y routing.
- `.codex/agents/*.toml`: perfiles locales.
- `.agents/skills/*/SKILL.md`: procedimientos locales.
- `.codex/config.toml`: features y MCP del repositorio.

## Flujo

1. Inventariar los cuatro owners y el worktree.
2. Cambiar solo el owner de la regla o capacidad.
3. Preservar bloques MCP y rutas de ejecutables fuera del pedido.
4. Evitar referencias a perfiles o skills globales/remotos; toda skill requerida debe existir en `.agents/skills`.
5. Validar TOML, frontmatter YAML, nombres unicos, rutas relativas y referencias.
6. Confirmar que no se incorporaron directorios o comandos de especificacion formal, runners de tests, copias bajo `.codex/skills` ni nombres de agentes ausentes.
7. Usar una sesion nueva para comprobar discovery cuando la sesion actual no pueda recargar configuracion.

## Restricciones

- No editar configuracion global del usuario.
- No instalar MCP o herramientas como efecto lateral de una auditoria.
- No copiar procesos del proyecto base que contradigan el modo game jam.
- No hacer commit ni publicar.

## Salida

Listar perfiles, skills y MCP preservados, validaciones ejecutadas y cualquier limitacion de discovery en la sesion actual.

