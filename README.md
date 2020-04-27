# Xamarin Ripple Background
[![platform](https://img.shields.io/badge/platform-Xamarin.Android-brightgreen.svg)](https://www.xamarin.com/)
[![API](https://img.shields.io/badge/API-21%2B-orange.svg?style=flat)](https://android-arsenal.com/api?level=10s)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://opensource.org/licenses/MIT)
[![NuGet](https://img.shields.io/nuget/v/Xama.JTPorts.RippleBackground.svg?label=NuGet)](https://www.nuget.org/packages/Xama.JTPorts.RippleBackground/)


# Namespace: Xama.JTPorts.RippleBackground

Animated ripple background for Xamarin.Android Ported from a Java library. You can adjust the ripple colours, the speed of the ripples as well as the amount of ripples.

## Fill Ripple

![!gif](https://github.com/DigitalSa1nt/Xama.JTPorts.RippleBackground/blob/master/images/20190217_220639.gif?raw=true)

## Stroke Ripple

![!gif](https://github.com/DigitalSa1nt/Xama.JTPorts.RippleBackground/blob/master/images/20190217_220842.gif?raw=true)

# How to Install

![NuGetIcon](https://raw.githubusercontent.com/DigitalSa1nt/Xama.JTPorts.RippleBackground/master/images/nugetIcon.png)

Simply add the [NuGet package](https://www.nuget.org/packages/Xama.JTPorts.RippleBackground/) directly to your Xamarin.Android solution, or use one of the following:

Package Manager:
> Install-Package Xama.JTPorts.RippleBackground -Version 1.0.0

.NET CLI:
> dotnet add package Xama.JTPorts.RippleBackground --version 1.0.0

# Basic Usage

Simply define the ripple control in your AXML layout and wrap it around whatever you want. You can set the control to ripple on click, or you can disable that via the attribute 'rb_rippleOnClick' and set up your own way of starting the ripple effect by simply calling the following method `StartRippleAnimation();` on the ripple control object.

```cs
<Xama.JTPorts.RippleBackground.RippleBackground
     android:layout_width="match_parent"
     android:layout_height="match_parent"
     android:id="@+id/content"
     app:rb_radius="32dp"
     app:rb_rippleAmount="4"
     app:rb_duration="3000"
     app:rb_rippleColour="@color/colorAccent"
     app:rb_type="strokeRipple"
     app:rb_strokeWidth="1dp"
     app:rb_rippleOnClick="true"
     app:rb_scale="6">

     <ImageView
         android:layout_width="64dp"
         android:layout_height="64dp"
         android:layout_centerInParent="true"
         android:id="@+id/centerImage"
         android:src="@drawable/iconheartwatch"/>

</Xama.JTPorts.RippleBackground.RippleBackground>
```

The Paint.Color attribute used in the process of drawing the ripple circles has been changed to be a static property of the `RippleBackground` control. So you can set `.RippleColour` on the ripple control programatically and it will apply to all initialised ripples.

# Available Attributes

You can supply the following attributes:

| Attribute        | Type            | Purpose                 |
|------------------|-----------------|-------------------------|
| rb_rippleOnClick | bool            | Automatically sets up a ripple on click event with toggle |
| rb_rippleColour  | color/reference | This defines the fill or stroke colour of the ripple effect itself |
| rb_strokeWidth   | dimension       | If you choose a stroke ripple, this defines the ripple stroke widths |
| rb_radius        | dimension       | Radius of the ripples   |
| rb_duration      | integer         | Duration of the individual ripple animations in milliseconds |
| rb_rippleAmount  | integer         | Maximum amount of ripples |
| rb_scale         | float           | Scale of ripple at the end of one animation cycle |
| rb_type          | enum            | fillRipple/strokeRipple |

# Support 💎

If you want to support the work that I do and you find any of these libraries useful? Consider supporting it by joining [**stargazers**](https://github.com/DigitalSa1nt/Xama.JTPorts.RippleBackground/stargazers) for this repository. :telescope: :stars:

<br/>

or alternatively if you want to you can also buy me a coffee.

<a href="https://www.buymeacoffee.com/JTT" target="_blank"><img src="https://cdn.buymeacoffee.com/buttons/default-red.png" alt="Buy Me A Coffee" tyle="height: 41px !important;width: 174px !important;box-shadow: 0px 3px 2px 0px rgba(190, 190, 190, 0.5) !important;-webkit-box-shadow: 0px 3px 2px 0px rgba(190, 190, 190, 0.5) !important;" ></a>
-----
_You know, only if you want to._
