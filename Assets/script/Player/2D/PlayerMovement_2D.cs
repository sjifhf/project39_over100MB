using UnityEngine;

public class PlayerMovement_2D : MonoBehaviour
{
    [Header("控制對象")]
    public Transform player;          // 主 Player（有 CharacterController）
    public Transform rotatingObject;  // player_2D（會旋轉的物件）
    public rotationchanging rotationScript; // 旋轉腳本

    [Header("移動設定")]
    public float speed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -9.8f;

    private CharacterController controller;
    private float yVelocity;
    private bool isGrounded;

    void OnEnable()
    {
        // 啟用時重置狀態
        yVelocity = 0f;
        
        if (controller != null && controller.isGrounded)
        {
            yVelocity = -1f;
        }
    }

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("PlayerMovement_2D：未指定 Player");
            enabled = false;
            return;
        }

        controller = player.GetComponent<CharacterController>();

        if (controller == null)
        {
            Debug.LogError("Player 沒有 CharacterController");
            enabled = false;
        }
    }

    void Update()
    {
        if (!controller) return;

        // 1️⃣ 是否在地面
        isGrounded = controller.isGrounded;

        // 2️⃣ 跳躍 & 重力
        if (isGrounded && yVelocity < 0)
            yVelocity = -1f;

        if (Input.GetButtonDown("Jump") && isGrounded)
            yVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);

        yVelocity += gravity * Time.deltaTime;

        // 3️⃣ 撞天花板停止上升
        if ((controller.collisionFlags & CollisionFlags.Above) != 0 && yVelocity > 0)
            yVelocity = 0f;

        // 4️⃣ 2D 移動（只接受 Horizontal 輸入）
        float moveInput = Input.GetAxis("Horizontal");
        
        // 如果正在旋轉，禁止移動
        if (rotationScript != null && rotationScript.isRotating)
            moveInput = 0f;

        // 使用 rotatingObject 的 right 方向
        Transform moveReference = (rotatingObject != null) ? rotatingObject : player;
        Vector3 move = moveReference.right * moveInput;
        move.y = yVelocity;

        // 5️⃣ 移動 Player
        controller.Move(move * speed * Time.deltaTime);
    }
}