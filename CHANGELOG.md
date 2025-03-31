# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [0.6.0]

### Added
* Added support for .NET 7.

### Changed
* Updated Uno.WinUI to 5.0.19.
* Updated Contributing documentation.

### Removed
* Removed support for Xamarin.
* Removed support for .NET 6.
* Removed support for NetStandard2.0 in View.Uno.WinUI.

## Deprecated
* RegisterLoadActions is deprecated with Uno 5

## [0.4.0]

### Added
* Support for Android 11 (March, 2021)
* [#31] Change target Uno.UI version to 4.0.7

### Removed
| **Control** | **Alternative**|
|------|-----------------|
|  Image Presenter    |     ImagEx (**WCT**)  |
|  SwipableItem    |     SwipeControl (in Uno, UWP, WinUI)  |
|  MembershipCardControl    |    TODO: create its own package |
|  LandscapeUprightPanel    |    TODO: create its own package for cards control |
|  LogCounterControl    |     N/A  |
|  StickyGroupHeaderBehavior    |     N/A  |
|  FromDoubleArithmeticToStringConverter    |     N/A  |
|  Lottie    |     Lottie (**WCT**)  |

### Fixed
* Fix issue #35: DataContext propagation on Android
