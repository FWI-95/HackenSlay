# Contributing to HackenSlay

Thank you for considering a contribution! This project welcomes pull requests and feedback. To keep the code base maintainable and the history clean, please follow the guidelines below.

## Code Style

- **Formatting**
  - Use 4 spaces for indentation.
  - Limit lines to 120 characters where possible.
  - Remove trailing whitespace.

- **Naming Conventions**
  - Classes, structs and enums use **PascalCase**.
  - Methods and public properties use **PascalCase**.
  - Local variables use **camelCase**.
  - Private fields start with an underscore, e.g. `_spriteBatch`.

## Commit Messages

Commit messages should use the following structure:

```
<short summary in present tense>

<optional detailed description>
```

The summary line should be concise (under 72 characters) and written in the imperative mood (e.g. `Add new menu` or `Fix collision bug`).

## Wiki Entries

When adding or updating wiki pages, follow the guidance in the [ChatGPT-Kodex](wiki/leitfaden/chatgpt-kodex.md) to keep entries short and consistent.

## Pull Requests

- Create topic branches from `main`.
- Include any relevant issue references in the description.
- Ensure the project builds before submitting a pull request:
  ```bash
  dotnet build
  ```

Thank you for helping improve HackenSlay!
