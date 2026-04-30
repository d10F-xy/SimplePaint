namespace SimplePaint
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Windows.Forms;
    public partial class Form1 : Form
    {
        enum ToolType { Line, Rectangle, Circle } // 사용할 도형 타입
        private Bitmap canvasBitmap; // 실제 그림이 저장되는 비트맵
        private Graphics canvasGraphics; // 비트맵 위에 그리기 위한 객체
        private bool isDrawing = false; // 현재 드래그 중인지 여부
        private Point startPoint; // 드래그 시작점
        private Point endPoint; // 드래그 끝점
        private ToolType currentTool = ToolType.Line; // 현재 선택된 도형
        private Color currentColor = Color.Black; // 현재 색상
        private int currentLineWidth = 2; // 현재 선 두께
        private float zoomLevel = 1.0f; // 확대/축소 레벨
        private Bitmap originalBitmap; // 원본 이미지 (확대/축소 계산용)

        public Form1()
        {
            InitializeComponent();

            // 캔버스 초기화
            canvasBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            canvasGraphics = Graphics.FromImage(canvasBitmap);
            canvasGraphics.Clear(Color.White); // 캔버스를 흰색으로 초기화

            picCanvas.Image = canvasBitmap; // 그린 그림을 화면(PictureBox)에 표시

            // 마우스 이벤트 연결
            picCanvas.MouseDown += picCanvas_MouseDown;
            picCanvas.MouseMove += picCanvas_MouseMove;
            picCanvas.MouseUp += picCanvas_MouseUp;

            // picCanvas가 다시 그려질 때 PicCanvas_Paint 함수를 실행하도록 연결
            picCanvas.Paint += picCanvas_Paint;

            // 도형 선택 버튼 이벤트 연결
            btnLine.Click += btnLine_Click;
            btnRectangle.Click += btnRectangle_Click;
            btnCircle.Click += btnCircle_Click;

            // 색상 콤보박스 이벤트 연결
            cmbColor.SelectedIndexChanged += cmbColor_SelectedIndexChanged;
            cmbColor.SelectedIndex = 0; // 기본값: Black

            // 선 두께 트랙바 이벤트 연결
            trbLineWidth.Minimum = 1; // 최소값
            trbLineWidth.Maximum = 10; // 최대값
            trbLineWidth.Value = 2;
            trbLineWidth.ValueChanged += trbLineWidth_ValueChanged;

            // 파일 저장 버튼 이벤트 연결
            btnSaveFile.Click += btnSaveFile_Click;

            // 파일 열기 버튼 이벤트 연결
            btnOpenFile.Click += btnOpenFile_Click;

            // 마우스 휠 확대/축소 이벤트 연결
            picCanvas.MouseWheel += picCanvas_MouseWheel;
            picCanvas.Focus();

            // 폼 자동 스크롤 비활성화 (Panel에서 처리)
            this.AutoScroll = false;
        }

        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true; // 드래그 시작
            startPoint = e.Location; // 시작점 저장
        }

        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return; // 그림 그리기와 상관 없는 마우스 움직임은 무시
            endPoint = e.Location; // 현재 위치 갱신

            // picCanvas를 다시 그려라 (Paint 이벤트를 발생시킨다)
            picCanvas.Invalidate(); // 화면 다시 그리기 (미리보기) 
        }

        private void picCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return; // 그림 그리기와 상관 없는 마우스 움직임은 무시
            isDrawing = false; // 드래그 종료
            endPoint = e.Location;

            // 실제 비트맵에 도형 그리기 (확정)
            using (Pen pen = new Pen(currentColor, currentLineWidth))
            {
                DrawShape(canvasGraphics, pen, startPoint, endPoint);
            }
            picCanvas.Invalidate(); // 다시 그려서 결과 반영, Paint 이벤트 발생
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (!isDrawing) return;
            // 점선 펜 (미리보기용)
            using (Pen previewPen = new Pen(currentColor, currentLineWidth))
            {
                previewPen.DashStyle = DashStyle.Dash;
                DrawShape(e.Graphics, previewPen, startPoint, endPoint);
            }
        }

        private void DrawShape(Graphics g, Pen pen, Point p1, Point p2)
        {
            Rectangle rect = GetRectangle(p1, p2);
            switch (currentTool)
            {
                case ToolType.Line:
                    g.DrawLine(pen, p1, p2);
                    break;
                case ToolType.Rectangle:
                    g.DrawRectangle(pen, rect);
                    break;
                case ToolType.Circle:
                    g.DrawEllipse(pen, rect);
                    break;
            }
        }

        private Rectangle GetRectangle(Point p1, Point p2)
        {
            return new Rectangle(
            Math.Min(p1.X, p2.X),
            Math.Min(p1.Y, p2.Y),
            Math.Abs(p1.X - p2.X),
            Math.Abs(p1.Y - p2.Y)
            );
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Line;
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Rectangle;
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Circle;
        }

        private void cmbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbColor.SelectedIndex)
            {
                case 0: // Black 검정
                    currentColor = Color.Black;
                    break;
                case 1: // Red 빨강
                    currentColor = Color.Red;
                    break;
                case 2: // Blue 파랑
                    currentColor = Color.Blue;
                    break;
                case 3: // Green 녹색
                    currentColor = Color.Green;
                    break;
                default:
                    currentColor = Color.Black;
                    break;
            }
        }

        private void trbLineWidth_ValueChanged(object sender, EventArgs e)
        {
            currentLineWidth = trbLineWidth.Value;
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "그림을 저장하세요";
            saveFileDialog.Filter = "PNG 파일 (*.png)|*.png|JPG 파일 (*.jpg)|*.jpg|BMP 파일 (*.bmp)|*.bmp";
            saveFileDialog.DefaultExt = "png";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                try
                {
                    ImageFormat imageFormat = GetImageFormat(filePath);
                    canvasBitmap.Save(filePath, imageFormat);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"저장 중 오류가 발생했습니다:\n{ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private ImageFormat GetImageFormat(string filePath)
        {
            string extension = System.IO.Path.GetExtension(filePath).ToLower();
            return extension switch
            {
                ".png" => ImageFormat.Png,
                ".jpg" => ImageFormat.Jpeg,
                ".bmp" => ImageFormat.Bmp,
                _ => ImageFormat.Png
            };
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "이미지 파일을 열어주세요";
            openFileDialog.Filter = "이미지 파일 (*.png;*.jpg;*.bmp;*.gif)|*.png;*.jpg;*.bmp;*.gif|PNG 파일 (*.png)|*.png|JPG 파일 (*.jpg)|*.jpg|BMP 파일 (*.bmp)|*.bmp|모든 파일 (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog.FileName;

                    // 기존 비트맵 및 그래픽 객체 해제
                    if (canvasGraphics != null) canvasGraphics.Dispose();
                    if (canvasBitmap != null) canvasBitmap.Dispose();
                    if (originalBitmap != null) originalBitmap.Dispose();

                    // 이미지 파일 로드
                    originalBitmap = new Bitmap(filePath);

                    // 사용 가능한 캔버스 크기 계산 (Panel의 크기)
                    int panelWidth = panelCanvas.ClientSize.Width - 2; // 테두리 고려
                    int panelHeight = panelCanvas.ClientSize.Height - 2;

                    // 이미지 크기가 패널을 초과하면 스케일 조정
                    float scaleWidth = (float)panelWidth / originalBitmap.Width;
                    float scaleHeight = (float)panelHeight / originalBitmap.Height;
                    float scale = Math.Min(1.0f, Math.Min(scaleWidth, scaleHeight)); // 1.0 이하로 제한

                    int displayWidth = (int)(originalBitmap.Width * scale);
                    int displayHeight = (int)(originalBitmap.Height * scale);

                    // 스케일된 캔버스 비트맵 생성
                    canvasBitmap = new Bitmap(displayWidth, displayHeight);
                    canvasGraphics = Graphics.FromImage(canvasBitmap);
                    canvasGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                    canvasGraphics.DrawImage(originalBitmap, 0, 0, displayWidth, displayHeight);

                    // PictureBox 업데이트 (Panel 내에서 크기 조정)
                    picCanvas.Image = canvasBitmap;
                    picCanvas.Size = new Size(Math.Max(displayWidth, panelWidth), Math.Max(displayHeight, panelHeight));
                    picCanvas.Location = new Point(0, 0);

                    // 줌 레벨 초기화
                    zoomLevel = 1.0f;

                    MessageBox.Show("이미지가 로드되었습니다!", "완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"이미지 로드 중 오류가 발생했습니다:\n{ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void picCanvas_MouseWheel(object sender, MouseEventArgs e)
        {
            if (canvasBitmap == null) return;

            // 마우스 휠 위쪽: 확대, 아래쪽: 축소
            if (e.Delta > 0) // 위쪽
            {
                zoomLevel += 0.1f;
            }
            else // 아래쪽
            {
                zoomLevel -= 0.1f;
            }

            // 줌 레벨 범위 제한 (0.1배 ~ 5배)
            zoomLevel = Math.Max(0.1f, Math.Min(5.0f, zoomLevel));

            // 이미지 재생성
            UpdateCanvasWithZoom();
        }

        private void UpdateCanvasWithZoom()
        {
            if (originalBitmap == null) return;

            // 기존 비트맵 해제
            if (canvasGraphics != null) canvasGraphics.Dispose();
            if (canvasBitmap != null) canvasBitmap.Dispose();

            // 줌 적용된 새로운 크기 계산
            int newWidth = (int)(originalBitmap.Width * zoomLevel);
            int newHeight = (int)(originalBitmap.Height * zoomLevel);

            // 새로운 비트맵 생성
            canvasBitmap = new Bitmap(newWidth, newHeight);
            canvasGraphics = Graphics.FromImage(canvasBitmap);
            canvasGraphics.SmoothingMode = SmoothingMode.AntiAlias;

            // 원본 이미지를 확대/축소하여 그리기
            canvasGraphics.DrawImage(originalBitmap, 0, 0, newWidth, newHeight);

            // PictureBox 업데이트
            picCanvas.Image = canvasBitmap;
            picCanvas.Size = canvasBitmap.Size;
            picCanvas.Invalidate();
        }
    }
}
