# Buổi 03 - Stack_Queue
Họ tên: Nguyễn Trung Kiên · MSV: 12425038
## Bài đã làm
Bài 1, 2, 3, 4, 5
## Cách chạy
```
dotnet run --project Buoi03_Stack_Queue
```
## Kết quả chạy
```
=== Bài 1 ===
Biểu thức: "{[()]} + (a + b) * [c - d]" -> Hợp lệ
Biểu thức: "([)]" -> Không hợp lệ
Biểu thức: "((a + b)" -> Không hợp lệ
Biểu thức: "{[()()]}" -> Hợp lệ
Biểu thức: "a + b]" -> Không hợp lệ

=== Bài 2 ===
Trang bắt đầu: home.vn
[Truy cập mới] Đang xem: news.vn | Back: 1, Forward: 0
[Truy cập mới] Đang xem: tech.vn/csharp | Back: 2, Forward: 0
[Truy cập mới] Đang xem: docs.microsoft.com | Back: 3, Forward: 0
[Back] Đang xem: tech.vn/csharp | Back: 2, Forward: 1
[Back] Đang xem: news.vn | Back: 1, Forward: 2
[Forward] Đang xem: tech.vn/csharp | Back: 2, Forward: 1
[Truy cập mới] Đang xem: github.com | Back: 3, Forward: 0
[Forward] Không thể chuyển tiếp.

=== Bài 3 ===
-> Gọi hàm Main(args=[]) | Độ sâu stack: 1
-> Gọi hàm TinhTongMang(n=5) | Độ sâu stack: 2
-> Gọi hàm CongHaiSo(a=10, b=20) | Độ sâu stack: 3
<- Trả về từ CongHaiSo (về địa chỉ TinhTongMang+0x28) | Còn lại: 2
<- Trả về từ TinhTongMang (về địa chỉ Main+0x14) | Còn lại: 1
<- Trả về từ Main (về địa chỉ 0x0000) | Còn lại: 0
<- Call stack đang rỗng.

=== Bài 4 ===
[Enqueue] Thêm lệnh in #1: BaoCao_Tuan1.docx (4 trang). Hàng chờ: 1
[Enqueue] Thêm lệnh in #2: Slide_ThuyetTrinh.pptx (15 trang). Hàng chờ: 2
[Enqueue] Thêm lệnh in #3: HoaDon_102.pdf (2 trang). Hàng chờ: 3
[Dequeue] Đang in #1: BaoCao_Tuan1.docx (4 trang). Còn lại: 2
[Dequeue] Đang in #2: Slide_ThuyetTrinh.pptx (15 trang). Còn lại: 1
[Dequeue] Đang in #3: HoaDon_102.pdf (2 trang). Còn lại: 0
[Dequeue] Hàng đợi in trống.

=== Bài 5 ===
[Gửi] Gói #1 ("SYN", trễ 10ms, lỗi=False) đã vào đường truyền.
[Gửi] Gói #2 ("GET /api/data", trễ 35ms, lỗi=False) đã vào đường truyền.
[Gửi] Gói #3 ("0xFF_ERR", trễ 20ms, lỗi=True) đã vào đường truyền.
[Gửi] Gói #4 ("ACK_END", trễ 15ms, lỗi=False) đã vào đường truyền.
--- Bắt đầu nhận và xử lý gói tin theo thứ tự gửi ---
[Gói #1] Trễ 10ms | Nhận thành công dữ liệu: "SYN"
[Gói #2] Trễ 35ms | Nhận thành công dữ liệu: "GET /api/data"
[Gói #3] Trễ 20ms | LỖI ĐƯỜNG TRUYỀN -> Yêu cầu gửi lại gói '0xFF_ERR'
[Gói #4] Trễ 15ms | Nhận thành công dữ liệu: "ACK_END"

=== Bài 6 ===
[Lấy số #101] Nguyễn Minh Anh | Dịch vụ: Mở tài khoản | Lúc 12:31:10
[Lấy số #102] Trần Quốc Bảo | Dịch vụ: Chuyển tiền / Nộp tiền | Lúc 12:31:10
[Lấy số #103] Lê Thu Hà | Dịch vụ: Tư vấn thẻ tín dụng | Lúc 12:31:10
--- Trạng thái hàng đợi hiện tại (3 khách đang chờ) ---
  - Số #101: Nguyễn Minh Anh | Mở tài khoản
  - Số #102: Trần Quốc Bảo | Chuyển tiền / Nộp tiền
  - Số #103: Lê Thu Hà | Tư vấn thẻ tín dụng
[Quầy 01] Đang phục vụ số #101 - Nguyễn Minh Anh (Mở tài khoản). Còn chờ: 2
[Quầy 02] Đang phục vụ số #102 - Trần Quốc Bảo (Chuyển tiền / Nộp tiền). Còn chờ: 1
--- Trạng thái hàng đợi hiện tại (1 khách đang chờ) ---
  - Số #103: Lê Thu Hà | Tư vấn thẻ tín dụng
[Quầy 01] Đang phục vụ số #103 - Lê Thu Hà (Tư vấn thẻ tín dụng). Còn chờ: 0
[Quầy 01] Không có khách đang chờ.

```