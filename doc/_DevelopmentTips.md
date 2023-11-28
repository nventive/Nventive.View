# Development tips

## Multitargeting

The projects in this solution are **multitargeted**. 

This means that each project is compiled to generate one assembly per target.

The available targets are:
- WinUI
- iOS
- Android 11.0
- Android 12.0
- WebAssembly (WASM)

Compiling all targets can take some time.

In order to compile only specific targets (e.g. only Android 8.0) and save time, update the [crosstargeting_override.props](../build/crosstargeting_override.props.sample) file.