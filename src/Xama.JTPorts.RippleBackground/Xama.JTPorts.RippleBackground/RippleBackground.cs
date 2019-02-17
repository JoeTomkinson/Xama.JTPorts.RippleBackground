using Android.Animation;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views.Animations;
using Android.Widget;
using Java.Lang;
using Xama.JTPorts.RippleBackground.components;

namespace Xama.JTPorts.RippleBackground
{
    public class RippleBackground : RelativeLayout
    {
        protected static int DEFAULT_RIPPLE_COUNT = 6;
        protected static int DEFAULT_DURATION_TIME = 3000;
        protected static float DEFAULT_SCALE = 6.0f;
        protected static int DEFAULT_FILL_TYPE = 0;

        protected int rippleColor;
        protected float rippleStrokeWidth;
        protected float rippleRadius;
        protected int rippleDurationTime;
        protected int rippleAmount;
        protected int rippleDelay;
        protected float rippleScale;
        protected int rippleType;
        protected Paint paint;
        protected bool animationRunning = false;
        protected AnimatorSet animatorSet;
        protected JavaList<Animator> animatorList;
        protected LayoutParams rippleParams;
        private readonly JavaList<RippleView> rippleViewList = new JavaList<RippleView>();

        public bool IsRippleAnimationRunning => animationRunning;

        public RippleBackground(Context context) : base(context)
        {
            //
        }

        public RippleBackground(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init(context, attrs);
        }

        public RippleBackground(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Init(context, attrs);
        }

        private void Init(Context context, IAttributeSet attrs)
        {
            if (IsInEditMode)
            {
                return;
            }
            
            if (null == attrs)
            {
                throw new IllegalArgumentException("Attributes should be provided to this view,");
            }

            TypedArray typedArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.RippleBackground);
            rippleColor = typedArray.GetColor(Resource.Styleable.RippleBackground_rb_color, Resource.Color.rippelColor);
            rippleStrokeWidth = typedArray.GetDimension(Resource.Styleable.RippleBackground_rb_strokeWidth, Resource.Dimension.rippleStrokeWidth);
            rippleRadius = typedArray.GetDimension(Resource.Styleable.RippleBackground_rb_radius, Resource.Dimension.rippleRadius);
            rippleDurationTime = typedArray.GetInt(Resource.Styleable.RippleBackground_rb_duration, DEFAULT_DURATION_TIME);
            rippleAmount = typedArray.GetInt(Resource.Styleable.RippleBackground_rb_rippleAmount, DEFAULT_RIPPLE_COUNT);
            rippleScale = typedArray.GetFloat(Resource.Styleable.RippleBackground_rb_scale, DEFAULT_SCALE);
            rippleType = typedArray.GetInt(Resource.Styleable.RippleBackground_rb_type, DEFAULT_FILL_TYPE);
            typedArray.Recycle();

            rippleDelay = rippleDurationTime / rippleAmount;

            paint = new Paint
            {
                AntiAlias = true
            };

            if (rippleType == DEFAULT_FILL_TYPE)
            {
                rippleStrokeWidth = 0;
                paint.SetStyle(Paint.Style.Fill);
            }
            else
            {
                paint.SetStyle(Paint.Style.Stroke);
                paint.Color = new Color(rippleColor);
            }

            rippleParams = new LayoutParams((int)(2 * (rippleRadius + rippleStrokeWidth)), (int)(2 * (rippleRadius + rippleStrokeWidth)));
            // changed from TRUE to 1
            rippleParams.AddRule(LayoutRules.CenterInParent, 1);

            animatorSet = new AnimatorSet();
            animatorSet.SetInterpolator(new AccelerateDecelerateInterpolator());
            animatorList = new JavaList<Animator>();

            for (int i = 0; i < rippleAmount; i++)
            {
                RippleView rippleView = new RippleView(Context, rippleStrokeWidth, paint);
                AddView(rippleView, rippleParams);
                rippleViewList.Add(rippleView);

                ObjectAnimator scaleXAnimator = ObjectAnimator.OfFloat(rippleView, "ScaleX", 1.0f, rippleScale);
                scaleXAnimator.RepeatCount = ValueAnimator.Infinite;
                scaleXAnimator.RepeatMode = ValueAnimatorRepeatMode.Restart;
                scaleXAnimator.StartDelay = (i * rippleDelay);
                scaleXAnimator.SetDuration(rippleDurationTime);
                animatorList.Add(scaleXAnimator);

                ObjectAnimator scaleYAnimator = ObjectAnimator.OfFloat(rippleView, "ScaleY", 1.0f, rippleScale);
                scaleYAnimator.RepeatCount = ValueAnimator.Infinite;
                scaleYAnimator.RepeatMode = ValueAnimatorRepeatMode.Restart;
                scaleYAnimator.StartDelay = (i * rippleDelay);
                scaleYAnimator.SetDuration(rippleDurationTime);
                animatorList.Add(scaleYAnimator);

                ObjectAnimator alphaAnimator = ObjectAnimator.OfFloat(rippleView, "Alpha", 1.0f, 0f);
                alphaAnimator.RepeatCount = ValueAnimator.Infinite;
                alphaAnimator.RepeatMode = ValueAnimatorRepeatMode.Restart;
                alphaAnimator.StartDelay = (i * rippleDelay);
                alphaAnimator.SetDuration(rippleDurationTime);
                animatorList.Add(alphaAnimator);
            }

            animatorSet.PlayTogether(animatorList);
        }

        public void StartRippleAnimation()
        {
            if (!IsRippleAnimationRunning)
            {
                foreach (RippleView rippleView in rippleViewList)
                {
                    rippleView.Visibility = Android.Views.ViewStates.Visible;
                }
                animatorSet.Start();
                animationRunning = true;
            }
        }

        public void StopRippleAnimation()
        {
            if (IsRippleAnimationRunning)
            {
                animatorSet.End();
                animationRunning = false;
            }
        }
    }
}
