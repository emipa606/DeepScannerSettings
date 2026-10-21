# GitHub Copilot Instructions for RimWorld Modding Project: Deep Scanner Settings (Continued)

## Mod Overview and Purpose

Welcome to the Deep Scanner Settings (Continued) mod, an enhanced continuation of Neceross's original mod. This mod is designed to provide players with advanced customization options for the use of the ground penetrating scanner to optimize deep drilling in RimWorld. With this mod, you can adjust the settings for each deep ore present in your game, including those introduced by other mods, allowing for a personalized mining experience.

## Key Features and Systems

- **Customizable Deep Ore Settings:** Via the settings menu, players can adjust the following characteristics:
  - **Commonality:** Manage how rare or common each resource is relative to others using a weighted scale.
  - **Resource Amount:** Specify how much ore can be extracted during each digging cycle.
  - **Vein Size:** Determine the potential size variation for each ore vein.

- **General Improvements:**
  - Added a feature for resetting settings to default, ensuring players can easily revert changes.

- **Localization:** Japanese translation available, thanks to Proxyer.

## Coding Patterns and Conventions

This mod employs several key coding patterns and conventions:

- **C# Code Files:** Organized into functional categories facilitating readability and maintainability.
  - **Singleton Pattern:** Utilized in settings management for maintaining a single point of configuration.
  - **Event Driven:** Hooks into RimWorld's lifecycle events for initialization and updates.
  
- **Utility Functions:** Include helper methods for common tasks like UI elements and string manipulation.

## XML Integration

- **About.xml and Manifest.xml:** These files define essential metadata and mod dependencies to ensure proper integration with RimWorld's modding system.
  - **About.xml:** Contains mod name, description, author details, and tags, aiding in user and community interaction.
  - **Manifest.xml:** Manages mod dependencies and compatibility.

## Harmony Patching

This mod leverages Harmony for runtime method patching, allowing seamless integration and conflict resolution with the base game and other mods. Key areas Harmony is used include:

- Injecting settings-related changes without altering core game files.

## Suggestions for Copilot

When using GitHub Copilot with this project, consider the following suggestions:

1. **Consistent Naming Conventions:** Encourage Copilot to follow existing naming schemes for methods and classes to maintain code consistency.

2. **Commenting Best Practices:** Generate meaningful comments for newly introduced code to ensure future maintainability.

3. **Suggest Utility Enhancements:** Identify repetitive patterns where new utility methods could reduce redundancy.

4. **Error Handling Patterns:** Promote the inclusion of robust error handling, particularly around user input in settings to prevent game-breaking errors.

5. **XML Schema Suggestions:** Aid in generating well-structured XML nodes when extending the mod's metadata or localization support.

By following these guideposts, Copilot can effectively assist you in extending and maintaining the Deep Scanner Settings (Continued) mod for an optimal modding journey in RimWorld.

---

**License:** MIT License; this mod is open-source, enabling the community to freely use, modify, and distribute its contents.

For further assistance, refer to the RimWorld modding community and error-reporting channels for collaborative problem-solving and development support.

This instruction file provides a comprehensive overview to aid contributors in understanding the mod's purpose, current implementation, and guidelines for further development.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

