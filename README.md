# Nventive.View
Suite of controls to use with WinUI and Uno Platform

# IMPORTANT NOTE:
This project is still very much in alpha. 
It will become smaller and smaller as we find alternatives in WindowsCommunityToolkit or other maintained projects.
APIs will change as they are being reviewed.

## Controls status
- AnimatedContentcontrol - kept for legacy purposes, to evaluate its future
- AnimatedControl - TO remove, focus on AnimatedContentControl to evaluate its future
- AnimatedHeaderControl - to remove, projects can pull it directly.
- DelayControl - To keep and document. Very useful so far.
- ImageSlideshow - To keep and document.
- ParrallalaxListView - To remove, bring it back later
- PathControl - To keep for now, it helps by being a control we can make Styles for.
- PeekingFlipView - todo: Evaluate, projects seem to have copies of this.
- SwipeRefresh - Keep for now, stay vigilant for WinUI alternatives
- ZoomControl - Keep, useful for pages where you need to crop an image.

## Converter status

- Remove `ConversionExtensionsConverter`
- Make sure `FromEnumToStringConverter` is documented
- Keep `PartitionConverter`, probably share it a little more as it is very useful
- Keep `PrettyDateConverter`, `PrettySizeConverter`, `PrettyDistanceConverter`
- TODO: Compare the rest of converters with WCT

## DataTemplateSelectors
- To remove

## Extensions (a.k.a AttachedProperties)
- BindableVisualState 
- Remove `ComboboxSynchronizer`
- Rename `ExpandIntoOverscrollBehavior` and advertise it.
    - Class name suggestion `ScrollExtensions` with property `IsExpandingOnOverscroll`
    -  
