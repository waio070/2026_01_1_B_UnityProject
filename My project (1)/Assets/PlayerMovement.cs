//using UnityEngine;

//public class PlayerMovement : MonoBehaviour
//{
//    [Header("기본 이동 설정")]
//    public float moveSpeed = 5.0f;
//    public float jumpForce = 7.0f;
//    public float turnSpeed = 10f;

//    [Header("점프 개선 설정")]
//    public float fallMutiplier = 2.5f;
//    public float lowJumpMultiplier = 2.0f;

//    [Header("지면 감지 설정")]
//    public float coyoteTime = 0.15f;
//    public float coyoteTimeCounter;
//    public bool realGrouned = true;

//    [Header("글라이더 설정")]
//    public GameObject gliderObject;
//    public float gliderFallSpeed = 1.0f;
//    public float gliderMoveSpeed = 7.0f;
//    public float gliderMaxTime = 5.0f;
//    public float gliderTimeLeft;
//    public bool isGliding = false;

//    public Rigidbody rb;

//    public bool isGrounded = true;
//    void Start()
//    {
//        coyoteTimeCounter = 0;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        UpdateGrounededState();


//        float moveHorizontal = Input.GetAxis("Horizontal");
//        float moveVertical = Input.GetAxis("Vertical");

//        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

//        if (movement.magnitude > 0.1f)
//        {
//            Quaternion targetRotation = Quaternion.LookRotation(movement);
//            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime); ;
//        }

//        //속도값으로 직접 이동
//        rb.linearVelocity = new Vector3(moveHorizontal * moveSpeed, rb.linearVelocity.y, moveVertical * moveSpeed);

//        //착지 점프높이 구현
//        if (rb.linearVelocity.y < 0)
//        {
//            rb.linearVelocity += Vector3.up * Physics.gravity.y * (fallMutiplier - 1) * Time.deltaTime;
//        }
//        else if (rb.linearVelocity.y > 0 && !Input.GetButton("Jump"))


//        {
//            rb.linearVelocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
//        }
//        //점프 입력
//        if (Input.GetButtonDown("Jump") && isGrounded)
//        {
//            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
//            isGrounded = false;
//            coyoteTimeCounter = 0;
//        }

//        if (Input.GetKey(KeyCode.G) && !isGrounded && gliderTimeLeft > 0)
//        {
//            if (isGliding)
//            {
//                EnableGlider();
//            }


//            gliderTimeLeft -= Time.deltaTime;

//            if (gliderTimeLeft <= 0)
//            {
//                DisableGlider();
//            }
//        }
//        else if (isGliding)
//        {
//            DisableGlider();
//        }

//        void EnableGlider()
//        {
//            isGliding = true;

//            if (gliderObject != null)
//            {
//                gliderObject.SetActive(true);
//            }

//            rb.linearVelocity = new Vector3(rb.linearVelocity.x, -gliderFallSpeed, rb.linearVelocity.z);
//        }

//        void DisableGlider()
//        {
//            isGliding = false;

//            if (gliderObject != null)
//            {
//                gliderObject.SetActive(false);
//            }

//            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);




//        }

//        void UpdateGrounededState()
//        {
//            if (realGrouned)
//            {
//                coyoteTimeCounter = coyoteTime;
//                isGrounded = true;
//            }
//            else
//            {
//                if (coyoteTimeCounter > 0)
//                {
//                    coyoteTimeCounter -= Time.deltaTime;
//                    isGrounded = true;
//                }
//                else
//                {
//                    isGrounded = false;
//                }
//            }
//        }
//    private void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.tag == "Ground")
//        {
//            isGrounded = true;
//        }
//    }

//    private void OnCollisionStay(Collision collision)
//    {
//        if (collision.gameObject.tag == "Ground")
//        {
//            realGrouned = true;
//        }
//    }

//    private void OnCollisionExit(Collision collision)
//    {
//        if (collision.gameObject.tag == "Ground")
//        {
//            realGrouned = true;
//        }
//    }
//}
