# Xamarin Ripple Background
[![platform](https://img.shields.io/badge/platform-Xamarin.Android-brightgreen.svg)](https://www.xamarin.com/)
[![API](https://img.shields.io/badge/API-21%2B-orange.svg?style=flat)](https://android-arsenal.com/api?level=10s)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://opensource.org/licenses/MIT)

# Namespace: Xama.JTPorts.RippleBackground

Animated ripple background for Xamarin.Android Ported from a Java library. You can adjust the ripple colours, the speed of the ripples as well as the amount of ripples.

<br>
## Fill Ripple
![!gif](https://github.com/DigitalSa1nt/Xama.JTPorts.RippleBackground/blob/master/images/20190217_220639.gif?raw=true)

## Stroke Ripple
![!gif](https://github.com/DigitalSa1nt/Xama.JTPorts.RippleBackground/blob/master/images/20190217_220842.gif?raw=true)

<br>

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


# Useful?
<a href="https://www.buymeacoffee.com/digitalsa1nt" target="_blank"><img src="https://www.buymeacoffee.com/assets/img/custom_images/purple_img.png" alt="Buy Me A Coffee" style="height: auto !important;width: auto !important;" ></a>

 _You know, only if you want to_
