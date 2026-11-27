using System;
using System.Collections.Generic;
using System.Linq;

namespace Buoi02_DanhSach
{
    struct NhanVien
    {
        public string MaNV;
        public string Hoten;
        public int Namsinh;
        public string Phongban;
        public int LuongCB;
        public int Thuong;
    }

    class Node
    {
        public int Data;
        public Node Next;

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }

    class SingleLinkedList
    {
        public Node Head;

        public void AddLast(int val)
        {
            Node newNode = new Node(val);
            if (Head == null)
            {
                Head = newNode;
                return;
            }
            Node cur = Head;
            while (cur.Next != null)
            {
                cur = cur.Next;
            }
            cur.Next = newNode;
        }

        public void Print()
        {
            if (Head == null)
            {
                Console.WriteLine("(Danh sách rỗng)");
                return;
            }
            Node cur = Head;
            while (cur != null)
            {
                Console.Write(cur.Data + (cur.Next != null ? " -> " : "\n"));
                cur = cur.Next;
            }
        }

        public int DemBangX(int x)
        {
            int dem = 0;
            Node cur = Head;
            while (cur != null)
            {
                if (cur.Data == x) dem++;
                cur = cur.Next;
            }
            return dem;
        }

        public int? TimDuongNhoNhat()
        {
            int minDuong = int.MaxValue;
            Node cur = Head;
            while (cur != null)
            {
                if (cur.Data > 0 && cur.Data < minDuong)
                {
                    minDuong = cur.Data;
                }
                cur = cur.Next;
            }
            return minDuong == int.MaxValue ? (int?)null : minDuong;
        }

        public bool XoaDauTienBangX(int x)
        {
            if (Head == null) return false;

            if (Head.Data == x)
            {
                Head = Head.Next;
                return true;
            }

            Node prev = Head;
            Node cur = Head.Next;
            while (cur != null)
            {
                if (cur.Data == x)
                {
                    prev.Next = cur.Next;
                    return true;
                }
                prev = cur;
                cur = cur.Next;
            }
            return false;
        }

        public int? TimMax()
        {
            if (Head == null) return null;
            int max = int.MinValue;
            Node cur = Head;
            while (cur != null)
            {
                if (cur.Data > max) max = cur.Data;
                cur = cur.Next;
            }
            return max;
        }

        public long TinhTong()
        {
            long tong = 0;
            Node cur = Head;
            while (cur != null)
            {
                tong += cur.Data;
                cur = cur.Next;
            }
            return tong;
        }

        public int DemSoNguyenTo()
        {
            int dem = 0;
            Node cur = Head;
            while (cur != null)
            {
                if (IsPrime(cur.Data)) dem++;
                cur = cur.Next;
            }
            return dem;
        }

        public void DemAmDuongKhong(out int am, out int bang0, out int duong)
        {
            am = 0;
            bang0 = 0;
            duong = 0;
            Node cur = Head;
            while (cur != null)
            {
                if (cur.Data < 0) am++;
                else if (cur.Data > 0) duong++;
                else bang0++;
                cur = cur.Next;
            }
        }

        private static bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
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

            Console.WriteLine("\nNhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }

        // ==================== BÀI 1 ====================
        static void Bai1()
        {
            int n;
            do
            {
                Console.Write("Nhập số lượng phần tử n (> 0): ");
            } while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);

            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                int val;
                do
                {
                    Console.Write($"Nhập số nguyên dương a[{i}]: ");
                } while (!int.TryParse(Console.ReadLine(), out val) || val <= 0);
                a[i] = val;
            }

            Console.WriteLine("Danh sách vừa nhập:");
            InMang1Chieu(a);

            Console.Write("Nhập giá trị x cần chèn: ");
            int x = int.Parse(Console.ReadLine() ?? "0");

            int k;
            do
            {
                Console.Write($"Nhập vị trí k cần chèn (0 .. {a.Length}): ");
            } while (!int.TryParse(Console.ReadLine(), out k) || k < 0 || k > a.Length);

            int[] tmp = new int[a.Length + 1];
            for (int i = 0; i < k; i++)
            {
                tmp[i] = a[i];
            }
            tmp[k] = x;
            for (int i = k; i < a.Length; i++)
            {
                tmp[i + 1] = a[i];
            }
            a = tmp;

            Console.WriteLine($"Danh sách sau khi chèn {x} vào vị trí {k}:");
            InMang1Chieu(a);
        }

        static void InMang1Chieu(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + (i < arr.Length - 1 ? " " : ""));
            }
            Console.WriteLine();
        }

        // ==================== BÀI 2 ====================
        static int TinhThucLinh(NhanVien nv)
        {
            return nv.LuongCB + nv.Thuong;
        }

        static void InThongTinNV(NhanVien nv)
        {
            long thucLinh = TinhThucLinh(nv);
            Console.WriteLine(
                $"Mã: {nv.MaNV} | Họ tên: {nv.Hoten} | Năm sinh: {nv.Namsinh} | " +
                $"Phòng: {nv.Phongban} | Lương CB: {nv.LuongCB:N0} | Thưởng: {nv.Thuong:N0} | Thực lĩnh: {thucLinh:N0}"
            );
        }

        static void Bai2()
        {
            NhanVien[] ds = new NhanVien[]
            {
                new NhanVien { MaNV = "NV03", Hoten = "Nguyễn Văn An", Namsinh = 1998, Phongban = "IT", LuongCB = 10000000, Thuong = 1500000 },
                new NhanVien { MaNV = "NV01", Hoten = "Trần Thị Bình", Namsinh = 2000, Phongban = "IT", LuongCB = 8000000, Thuong = 1200000 },
                new NhanVien { MaNV = "NV02", Hoten = "Lê Hoàng Cường", Namsinh = 1995, Phongban = "Kế toán", LuongCB = 8000000, Thuong = 900000 },
                new NhanVien { MaNV = "NV04", Hoten = "Phạm Minh Đức", Namsinh = 1999, Phongban = "Nhân sự", LuongCB = 12000000, Thuong = 2000000 }
            };

            long tongThucLinh = 0;
            for (int i = 0; i < ds.Length; i++)
            {
                tongThucLinh += TinhThucLinh(ds[i]);
            }
            Console.WriteLine($"a. Tổng thực lĩnh tháng của công ty: {tongThucLinh:N0}");

            int minLuongCB = int.MaxValue;
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].LuongCB < minLuongCB)
                {
                    minLuongCB = ds[i].LuongCB;
                }
            }
            Console.WriteLine($"b. Nhân viên có lương cơ bản thấp nhất ({minLuongCB:N0}):");
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].LuongCB == minLuongCB)
                {
                    InThongTinNV(ds[i]);
                }
            }

            int demThuongCao = 0;
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].Thuong >= 1200000)
                {
                    demThuongCao++;
                }
            }
            Console.WriteLine($"c. Số nhân viên có thưởng >= 1.200.000: {demThuongCao}");

            NhanVien[] dsSapXep = (NhanVien[])ds.Clone();
            for (int i = 0; i < dsSapXep.Length - 1; i++)
            {
                for (int j = i + 1; j < dsSapXep.Length; j++)
                {
                    int cmpPhong = string.Compare(dsSapXep[i].Phongban, dsSapXep[j].Phongban, StringComparison.CurrentCulture);
                    bool canDoi = false;

                    if (cmpPhong > 0)
                    {
                        canDoi = true;
                    }
                    else if (cmpPhong == 0)
                    {
                        int cmpMa = string.Compare(dsSapXep[i].MaNV, dsSapXep[j].MaNV, StringComparison.CurrentCulture);
                        if (cmpMa < 0)
                        {
                            canDoi = true;
                        }
                    }

                    if (canDoi)
                    {
                        NhanVien temp = dsSapXep[i];
                        dsSapXep[i] = dsSapXep[j];
                        dsSapXep[j] = temp;
                    }
                }
            }

            Console.WriteLine("d. Danh sách sắp xếp tăng dần theo phòng ban, giảm dần theo mã NV:");
            for (int i = 0; i < dsSapXep.Length; i++)
            {
                InThongTinNV(dsSapXep[i]);
            }

            Console.WriteLine("e. Danh sách sau khi cập nhật tăng lương cơ bản thêm 5%:");
            for (int i = 0; i < ds.Length; i++)
            {
                ds[i].LuongCB = (int)Math.Round(ds[i].LuongCB * 1.05);
                InThongTinNV(ds[i]);
            }
        }

        // ==================== BÀI 3 ====================
        static void Bai3()
        {
            int n;
            do
            {
                Console.Write("Nhập cấp ma trận vuông n (0 < n < 100): ");
            } while (!int.TryParse(Console.ReadLine(), out n) || n <= 0 || n >= 100);

            int[,] a = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"a[{i},{j}] = ");
                    a[i, j] = int.Parse(Console.ReadLine() ?? "0");
                }
            }

            int tongAll = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    tongAll += a[i, j];
                }
            }
            Console.WriteLine($"a. Tổng tất cả các phần tử của ma trận: {tongAll}");

            int minDuong = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (a[i, j] > 0 && a[i, j] < minDuong)
                    {
                        minDuong = a[i, j];
                    }
                }
            }
            if (minDuong == int.MaxValue)
                Console.WriteLine("b. Ma trận không có phần tử dương.");
            else
                Console.WriteLine($"b. Giá trị dương nhỏ nhất của ma trận: {minDuong}");

            int tongCheoPhu = 0;
            for (int i = 0; i < n; i++)
            {
                tongCheoPhu += a[i, n - 1 - i];
            }
            Console.WriteLine($"c. Tổng các phần tử trên đường chéo phụ: {tongCheoPhu}");

            int[] tg = new int[n];
            for (int i = 0; i < n; i++)
            {
                tg[i] = a[i, i];
            }

            bool tangDan = true;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (!(tg[i] < tg[j]))
                    {
                        tangDan = false;
                        break;
                    }
                }
                if (!tangDan) break;
            }

            Console.WriteLine(tangDan
                ? "d. Các phần tử trên đường chéo chính TĂNG DẦN."
                : "d. Các phần tử trên đường chéo chính KHÔNG tăng dần.");
        }

        // ==================== BÀI 4 ====================
        static void Bai4()
        {
            SingleLinkedList pHeadList = new SingleLinkedList();
            int[] mau = { 5, 12, 3, 5, 8, 2, 5 };
            foreach (int item in mau) pHeadList.AddLast(item);

            Console.Write("Danh sách liên kết đơn ban đầu: ");
            pHeadList.Print();

            Console.Write("Nhập x cần đếm và xóa đầu tiên: ");
            int x = int.Parse(Console.ReadLine() ?? "5");

            Console.WriteLine($"a. Số lượng phần tử bằng {x}: {pHeadList.DemBangX(x)}");

            int? minDuong = pHeadList.TimDuongNhoNhat();
            Console.WriteLine(minDuong.HasValue
                ? $"b. Phần tử dương nhỏ nhất: {minDuong.Value}"
                : "b. Không có phần tử dương nào.");

            bool daXoa = pHeadList.XoaDauTienBangX(x);
            Console.WriteLine(daXoa
                ? $"c. Đã xóa phần tử {x} đầu tiên. Danh sách hiện tại:"
                : $"c. Không tìm thấy phần tử {x} để xóa. Danh sách hiện tại:");
            pHeadList.Print();
        }

        // ==================== BÀI 5 ====================
        static void Bai5()
        {
            SingleLinkedList l = new SingleLinkedList();
            int[] mau = { -4, 0, 7, 11, -2, 7, 15, 0 };
            foreach (int item in mau) l.AddLast(item);

            Console.Write("Danh sách l: ");
            l.Print();

            int? maxVal = l.TimMax();
            Console.WriteLine(maxVal.HasValue
                ? $"a. Phần tử lớn nhất của l: {maxVal.Value}"
                : "a. Danh sách rỗng.");

            Console.WriteLine($"b. Tổng các phần tử của l: {l.TinhTong()}");
            Console.WriteLine($"c. Số lượng số nguyên tố trong l: {l.DemSoNguyenTo()}");

            int am, bang0, duong;
            l.DemAmDuongKhong(out am, out bang0, out duong);
            Console.WriteLine($"d. Số âm: {am} | Số bằng 0: {bang0} | Số dương: {duong}");

            Console.Write("Nhập x cần đếm trong l: ");
            int x = int.Parse(Console.ReadLine() ?? "7");
            Console.WriteLine($"e. Số lượng phần tử bằng {x} trong l: {l.DemBangX(x)}");

            int? minDuong = l.TimDuongNhoNhat();
            Console.WriteLine(minDuong.HasValue
                ? $"f. Phần tử dương nhỏ nhất trong l: {minDuong.Value}"
                : "f. Không có phần tử dương trong l.");
        }
    }
}