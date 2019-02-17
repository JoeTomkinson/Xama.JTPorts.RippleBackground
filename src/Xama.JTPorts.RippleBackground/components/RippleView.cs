using Android.Content;
using Android.Graphics;
using Android.Views;
using Java.Lang;

namespace Xama.JTPorts.RippleBackground.components
{
    class RippleView : View
    {
        protected float rippleStrokeWidth;
        protected Paint paint;

        public RippleView(Context context, float rippleStrokeWidth, Paint paint) : base (context)
        {
            Visibility = ViewStates.Invisible;
            this.rippleStrokeWidth = rippleStrokeWidth;
            this.paint = paint;
        }

        protected override void OnDraw(Canvas canvas)
        {
            int radius = (Math.Min(Width, Height)) / 2;
            canvas.DrawCircle(radius, radius, radius - rippleStrokeWidth, paint);
        }
    }
}