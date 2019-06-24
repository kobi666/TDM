using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BezierSolution
{
	public class EnemyWalker2D : MonoBehaviour
	{
        public enum TravelMode { Once, Loop, PingPong };
        private bool inStopEvent = false;
        public bool InStopEvent { get => inStopEvent; set => inStopEvent = value; }
        private Transform cachedTransform;
        public float SplineLength;
        public float ProximityToEndOfSpline;

        // Direction is calculated inside the move walker function, Vdirection True means Going up, HDirection True means Going right, otherwise it's down, left
        public bool Vdirection;
        public bool Hdirection;

		public BezierSpline spline;
		public TravelMode travelMode;

		public float speed = 5f;
		private float progress = 0f;

		public float NormalizedT
		{
			get { return progress; }
			set { progress = value; }
		}

        

        [Range( 0f, 0.06f )]
		public float relaxationAtEndPoints = 0.01f;

		//public float movementLerpModifier = 10f;
		public float rotationLerpModifier = 10f;

		public bool lookForward = true;

		private bool isGoingForward = true;

		public UnityEvent onPathCompleted = new UnityEvent();
		private bool onPathCompletedCalledAt1 = false;
		private bool onPathCompletedCalledAt0 = false;


        void MoveWalker ()
        {
            float targetSpeed = (isGoingForward) ? speed : -speed;

            Vector3 targetPos;
            // Code below uses the obsolete MoveAlongSpline function
            //float absSpeed = Mathf.Abs( speed );
            //if( absSpeed <= 2f )
            //	targetPos = spline.MoveAlongSpline( ref progress, targetSpeed * Time.deltaTime, maximumError: 0f );
            //else if( absSpeed >= 40f )
            //	targetPos = spline.MoveAlongSpline( ref progress, targetSpeed * Time.deltaTime, increasedAccuracy: true );
            //else
            //	targetPos = spline.MoveAlongSpline( ref progress, targetSpeed * Time.deltaTime );
            
            targetPos = spline.MoveAlongSpline(ref progress, targetSpeed * Time.deltaTime);

            if (targetPos.x < cachedTransform.position.x)
            {
                Hdirection = true;
            }
            else
            {
                Hdirection = false;
            }

            if (targetPos.y < cachedTransform.position.y)
            {
                Vdirection = true;
            }
            else
            {
                Vdirection = false;
            }


            cachedTransform.position = targetPos;
            //cachedTransform.position = Vector3.Lerp( cachedTransform.position, targetPos, movementLerpModifier * Time.deltaTime );
            //Debug.Log("Current pos: " + transform.position.ToString());
            //Debug.Log("TargetPos : " + targetPos.ToString());
            


            bool movingForward = (speed > 0f) == isGoingForward;

            //if( lookForward )
            //{
            //	Quaternion targetRotation;
            //	if( movingForward )
            //		targetRotation = Quaternion.LookRotation( spline.GetTangent( progress ) );
            //	else
            //		targetRotation = Quaternion.LookRotation( -spline.GetTangent( progress ) );

            //	cachedTransform.rotation = Quaternion.Lerp( cachedTransform.rotation, targetRotation, rotationLerpModifier * Time.deltaTime );
            //}

            if (movingForward)
            {
                if (progress >= 1f - relaxationAtEndPoints)
                {
                    if (!onPathCompletedCalledAt1)
                    {
                        onPathCompleted.Invoke();
                        onPathCompletedCalledAt1 = true;
                    }

                    if (travelMode == TravelMode.Once)
                        progress = 1f;
                    else if (travelMode == TravelMode.Loop)
                        progress -= 1f;
                    else
                    {
                        progress = 2f - progress;
                        isGoingForward = !isGoingForward;
                    }
                }
                else
                {
                    onPathCompletedCalledAt1 = false;
                }
            }
            else
            {
                if (progress <= relaxationAtEndPoints)
                {
                    if (!onPathCompletedCalledAt0)
                    {
                        onPathCompleted.Invoke();
                        onPathCompletedCalledAt0 = true;
                    }

                    if (travelMode == TravelMode.Once)
                        progress = 0f;
                    else if (travelMode == TravelMode.Loop)
                        progress += 1f;
                    else
                    {
                        progress = -progress;
                        isGoingForward = !isGoingForward;
                    }
                }
                else
                {
                    onPathCompletedCalledAt0 = false;
                }
            }
        }


        


		void Awake()
		{
			cachedTransform = transform;      
            
		}

        private void Start()
        {
            SplineLength = spline.Length;
        }

        void Update()
		{
            
            if (InStopEvent == false)
            {
                MoveWalker();
            }
            //Debug.Log("Proximity to end of spline is : " + (SplineLength * (1.0f - progress)).ToString());
            ProximityToEndOfSpline = SplineLength * (1.0f - progress);
        }
    }
}