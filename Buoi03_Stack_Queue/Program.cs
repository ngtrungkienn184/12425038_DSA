using System;
using System.Collections.Generic;

namespace Buoi03_StackQueue
{
    class StackFrame
    {
        public string FunctionName { get; set; }
        public string ParamsInfo { get; set; }
        public string ReturnAddress { get; set; }
    }

    class PrintJob
    {
        public int Id { get; set; }
        public string DocumentName { get; set; }
        public int Pages { get; set; }
    }

    class DataPacket
    {
        public int Seq { get; set; }
        public string Payload { get; set; }
        public int DelayMs { get; set; }
        public bool IsCorrupted { get; set; }
    }

    class CustomerTicket
    {
        public int TicketNumber { get; set; }
        public string CustomerName { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string ServiceType { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Để in được tiếng Việt
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Bài 1 ===");
            Bai1();

            Console.WriteLine("\n=== Bài 2 ===");
            Bai2();

            Console.WriteLine("\n=== Bài 3 ===");
            Bai3();

            Console.WriteLine("\n=== Bài 4 ===");
            Bai4();

            Console.WriteLine("\n=== Bài 5 ===");
            Bai5();

            Console.WriteLine("\n=== Bài 6 ===");
            Bai6();

            Console.WriteLine("\nNhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }

        // ==================== BÀI 1: KIỂM TRA BIỂU THỨC NGOẶC ====================
        static void Bai1()
        {
            string[] testExpressions =
            {
                "{[()]} + (a + b) * [c - d]",
                "([)]",
                "((a + b)",
                "{[()()]}",
                "a + b]"
            };

            foreach (string expr in testExpressions)
            {
                bool hopLe = KiemTraBieuThucNgoac(expr);
                Console.WriteLine($"Biểu thức: \"{expr}\" -> {(hopLe ? "Hợp lệ" : "Không hợp lệ")}");
            }
        }

        static bool KiemTraBieuThucNgoac(string expr)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in expr)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.Count == 0)
                        return false;

                    char top = stack.Pop();
                    if (!LaCapNgoacTuongUng(top, c))
                        return false;
                }
            }

            return stack.Count == 0;
        }

        static bool LaCapNgoacTuongUng(char open, char close)
        {
            return (open == '(' && close == ')') ||
                   (open == '[' && close == ']') ||
                   (open == '{' && close == '}');
        }

        // ==================== BÀI 2: MÔ PHỎNG LỊCH SỬ TRÌNH DUYỆT ====================
        static void Bai2()
        {
            Stack<string> backStack = new Stack<string>();
            Stack<string> forwardStack = new Stack<string>();
            string currentPage = "home.vn";

            Console.WriteLine($"Trang bắt đầu: {currentPage}");

            TruyCapTrang("news.vn", ref currentPage, backStack, forwardStack);
            TruyCapTrang("tech.vn/csharp", ref currentPage, backStack, forwardStack);
            TruyCapTrang("docs.microsoft.com", ref currentPage, backStack, forwardStack);

            QuayLai(ref currentPage, backStack, forwardStack);
            QuayLai(ref currentPage, backStack, forwardStack);
            ChuyenTiep(ref currentPage, backStack, forwardStack);

            // Truy cập trang mới sẽ xóa lịch sử Forward
            TruyCapTrang("github.com", ref currentPage, backStack, forwardStack);
            ChuyenTiep(ref currentPage, backStack, forwardStack);
        }

        static void TruyCapTrang(string newUrl, ref string currentPage, Stack<string> backStack, Stack<string> forwardStack)
        {
            backStack.Push(currentPage);
            currentPage = newUrl;
            forwardStack.Clear();
            Console.WriteLine($"[Truy cập mới] Đang xem: {currentPage} | Back: {backStack.Count}, Forward: {forwardStack.Count}");
        }

        static void QuayLai(ref string currentPage, Stack<string> backStack, Stack<string> forwardStack)
        {
            if (backStack.Count == 0)
            {
                Console.WriteLine("[Back] Không thể quay lại.");
                return;
            }
            forwardStack.Push(currentPage);
            currentPage = backStack.Pop();
            Console.WriteLine($"[Back] Đang xem: {currentPage} | Back: {backStack.Count}, Forward: {forwardStack.Count}");
        }

        static void ChuyenTiep(ref string currentPage, Stack<string> backStack, Stack<string> forwardStack)
        {
            if (forwardStack.Count == 0)
            {
                Console.WriteLine("[Forward] Không thể chuyển tiếp.");
                return;
            }
            backStack.Push(currentPage);
            currentPage = forwardStack.Pop();
            Console.WriteLine($"[Forward] Đang xem: {currentPage} | Back: {backStack.Count}, Forward: {forwardStack.Count}");
        }

        // ==================== BÀI 3: FUNCTION CALL STACK ====================
        static void Bai3()
        {
            Stack<StackFrame> callStack = new Stack<StackFrame>();

            GoiHam(callStack, "Main", "args=[]", "0x0000");
            GoiHam(callStack, "TinhTongMang", "n=5", "Main+0x14");
            GoiHam(callStack, "CongHaiSo", "a=10, b=20", "TinhTongMang+0x28");

            KetThucHam(callStack);
            KetThucHam(callStack);
            KetThucHam(callStack);
            KetThucHam(callStack);
        }

        static void GoiHam(Stack<StackFrame> callStack, string funcName, string paramsInfo, string retAddr)
        {
            callStack.Push(new StackFrame
            {
                FunctionName = funcName,
                ParamsInfo = paramsInfo,
                ReturnAddress = retAddr
            });
            Console.WriteLine($"-> Gọi hàm {funcName}({paramsInfo}) | Độ sâu stack: {callStack.Count}");
        }

        static void KetThucHam(Stack<StackFrame> callStack)
        {
            if (callStack.Count == 0)
            {
                Console.WriteLine("<- Call stack đang rỗng.");
                return;
            }
            StackFrame frame = callStack.Pop();
            Console.WriteLine($"<- Trả về từ {frame.FunctionName} (về địa chỉ {frame.ReturnAddress}) | Còn lại: {callStack.Count}");
        }

        // ==================== BÀI 4: MÔ PHỎNG HỆ THỐNG IN ẤN (FIFO) ====================
        static void Bai4()
        {
            Queue<PrintJob> printQueue = new Queue<PrintJob>();

            ThemYeuCauIn(printQueue, new PrintJob { Id = 1, DocumentName = "BaoCao_Tuan1.docx", Pages = 4 });
            ThemYeuCauIn(printQueue, new PrintJob { Id = 2, DocumentName = "Slide_ThuyetTrinh.pptx", Pages = 15 });
            ThemYeuCauIn(printQueue, new PrintJob { Id = 3, DocumentName = "HoaDon_102.pdf", Pages = 2 });

            XuLyInTiepTheo(printQueue);
            XuLyInTiepTheo(printQueue);
            XuLyInTiepTheo(printQueue);
            XuLyInTiepTheo(printQueue);
        }

        static void ThemYeuCauIn(Queue<PrintJob> queue, PrintJob job)
        {
            queue.Enqueue(job);
            Console.WriteLine($"[Enqueue] Thêm lệnh in #{job.Id}: {job.DocumentName} ({job.Pages} trang). Hàng chờ: {queue.Count}");
        }

        static void XuLyInTiepTheo(Queue<PrintJob> queue)
        {
            if (queue.Count == 0)
            {
                Console.WriteLine("[Dequeue] Hàng đợi in trống.");
                return;
            }
            PrintJob job = queue.Dequeue();
            Console.WriteLine($"[Dequeue] Đang in #{job.Id}: {job.DocumentName} ({job.Pages} trang). Còn lại: {queue.Count}");
        }

        // ==================== BÀI 5: MÔ PHỎNG ĐƯỜNG TRUYỀN DỮ LIỆU ====================
        static void Bai5()
        {
            Queue<DataPacket> networkQueue = new Queue<DataPacket>();

            GuiGoiTin(networkQueue, new DataPacket { Seq = 1, Payload = "SYN", DelayMs = 10, IsCorrupted = false });
            GuiGoiTin(networkQueue, new DataPacket { Seq = 2, Payload = "GET /api/data", DelayMs = 35, IsCorrupted = false });
            GuiGoiTin(networkQueue, new DataPacket { Seq = 3, Payload = "0xFF_ERR", DelayMs = 20, IsCorrupted = true });
            GuiGoiTin(networkQueue, new DataPacket { Seq = 4, Payload = "ACK_END", DelayMs = 15, IsCorrupted = false });

            Console.WriteLine("--- Bắt đầu nhận và xử lý gói tin theo thứ tự gửi ---");
            while (networkQueue.Count > 0)
            {
                DataPacket pkt = networkQueue.Dequeue();
                if (pkt.IsCorrupted)
                {
                    Console.WriteLine($"[Gói #{pkt.Seq}] Trễ {pkt.DelayMs}ms | LỖI ĐƯỜNG TRUYỀN -> Yêu cầu gửi lại gói '{pkt.Payload}'");
                }
                else
                {
                    Console.WriteLine($"[Gói #{pkt.Seq}] Trễ {pkt.DelayMs}ms | Nhận thành công dữ liệu: \"{pkt.Payload}\"");
                }
            }
        }

        static void GuiGoiTin(Queue<DataPacket> queue, DataPacket pkt)
        {
            queue.Enqueue(pkt);
            Console.WriteLine($"[Gửi] Gói #{pkt.Seq} (\"{pkt.Payload}\", trễ {pkt.DelayMs}ms, lỗi={pkt.IsCorrupted}) đã vào đường truyền.");
        }

        // ==================== BÀI 6: QUẢN LÝ HÀNG ĐỢI DỊCH VỤ / NGÂN HÀNG ====================
        static void Bai6()
        {
            Queue<CustomerTicket> serviceQueue = new Queue<CustomerTicket>();
            int nextTicket = 101;

            KhachDen(serviceQueue, nextTicket++, "Nguyễn Minh Anh", "Mở tài khoản");
            KhachDen(serviceQueue, nextTicket++, "Trần Quốc Bảo", "Chuyển tiền / Nộp tiền");
            KhachDen(serviceQueue, nextTicket++, "Lê Thu Hà", "Tư vấn thẻ tín dụng");
            HienThiTrangThaiHangDoi(serviceQueue);

            PhucVuKhach(serviceQueue, "Quầy 01");
            PhucVuKhach(serviceQueue, "Quầy 02");
            HienThiTrangThaiHangDoi(serviceQueue);

            PhucVuKhach(serviceQueue, "Quầy 01");
            PhucVuKhach(serviceQueue, "Quầy 01");
        }

        static void KhachDen(Queue<CustomerTicket> queue, int ticketNo, string name, string service)
        {
            CustomerTicket ticket = new CustomerTicket
            {
                TicketNumber = ticketNo,
                CustomerName = name,
                ArrivalTime = DateTime.Now,
                ServiceType = service
            };
            queue.Enqueue(ticket);
            Console.WriteLine($"[Lấy số #{ticket.TicketNumber}] {ticket.CustomerName} | Dịch vụ: {ticket.ServiceType} | Lúc {ticket.ArrivalTime:HH:mm:ss}");
        }

        static void PhucVuKhach(Queue<CustomerTicket> queue, string counterName)
        {
            if (queue.Count == 0)
            {
                Console.WriteLine($"[{counterName}] Không có khách đang chờ.");
                return;
            }
            CustomerTicket khach = queue.Dequeue();
            Console.WriteLine($"[{counterName}] Đang phục vụ số #{khach.TicketNumber} - {khach.CustomerName} ({khach.ServiceType}). Còn chờ: {queue.Count}");
        }

        static void HienThiTrangThaiHangDoi(Queue<CustomerTicket> queue)
        {
            Console.WriteLine($"--- Trạng thái hàng đợi hiện tại ({queue.Count} khách đang chờ) ---");
            if (queue.Count == 0)
            {
                Console.WriteLine("  (Trống)");
                return;
            }
            foreach (var k in queue)
            {
                Console.WriteLine($"  - Số #{k.TicketNumber}: {k.CustomerName} | {k.ServiceType}");
            }
        }
    }
}