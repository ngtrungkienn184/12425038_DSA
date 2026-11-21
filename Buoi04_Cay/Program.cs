using System;

class Program
{
    static CayNode root = KhoiTaoCayMau();

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;   // để in được tiếng Việt

        // Gọi từng hàm B1(), B2(), ..., B8() theo nhu cầu
        B1();
        B2();
        B3();
        B4();
        B5();
        B6();
        B7();
        B8();
    }

    // Hàm khởi tạo sẵn cây nhị phân mẫu:
    //        10
    //       /  \
    //      5    15
    //     / \   / \
    //    2   8 12  20
    static CayNode KhoiTaoCayMau()
    {
        CayNode cayMau = new CayNode(10);

        cayMau.Left = new CayNode(5);
        cayMau.Right = new CayNode(15);

        cayMau.Left.Left = new CayNode(2);
        cayMau.Left.Right = new CayNode(8);

        cayMau.Right.Left = new CayNode(12);
        cayMau.Right.Right = new CayNode(20);

        return cayMau;
    }

    // Bài 1: Cài đặt thuật toán đếm số nút trên cây nhị phân
    static void B1()
    {
        Console.WriteLine("=== Bài 1 ===");
        Console.WriteLine($"Tổng số nút trên cây: {DemSoNut(root)}");
    }

    // Bài 2: Cài đặt thuật toán tính tổng giá trị các nút trên cây nhị phân
    static void B2()
    {
        Console.WriteLine("=== Bài 2 ===");
        Console.WriteLine($"Tổng giá trị các nút trên cây: {TinhTong(root)}");
    }

    // Bài 3: Cài đặt thuật toán hiển thị giá trị các nút trên cây nhị phân
    static void B3()
    {
        Console.WriteLine("=== Bài 3 ===");
        Console.Write("Giá trị các nút trên cây: ");
        if (root == null)
        {
            Console.WriteLine("Cây rỗng.");
            return;
        }
        HienThiNut(root);
        Console.WriteLine();
    }

    // Bài 4: Cài đặt thuật toán hiển thị giá trị các nút có giá trị chẵn trên cây nhị phân
    static void B4()
    {
        Console.WriteLine("=== Bài 4 ===");
        Console.Write("Giá trị các nút chẵn trên cây: ");
        if (root == null || DemNutChan(root) == 0)
        {
            Console.WriteLine("Không có nút chẵn nào.");
            return;
        }
        HienThiNutChan(root);
        Console.WriteLine();
    }

    // Bài 5: Cài đặt thuật toán đếm số nút có giá trị chẵn trên cây nhị phân
    static void B5()
    {
        Console.WriteLine("=== Bài 5 ===");
        Console.WriteLine($"Số nút có giá trị chẵn trên cây: {DemNutChan(root)}");
    }

    // Bài 6: Cài đặt thuật toán đếm số con của một nút trên cây nhị phân
    static void B6(int giaTriNut = 5)
    {
        Console.WriteLine("=== Bài 6 ===");
        CayNode nut = TimNut(root, giaTriNut);
        if (nut == null)
        {
            Console.WriteLine($"Không tìm thấy nút có giá trị {giaTriNut} trên cây.");
            return;
        }
        Console.WriteLine($"Số con trực tiếp của nút {giaTriNut}: {DemConTrucTiep(nut)}");
    }

    // Bài 7: Cài đặt thuật toán hiển thị giá trị các nút trên cây con trái của cây nhị phân
    static void B7()
    {
        Console.WriteLine("=== Bài 7 ===");
        Console.Write("Giá trị các nút trên cây con trái: ");
        if (root == null || root.Left == null)
        {
            Console.WriteLine("Không có cây con trái.");
            return;
        }
        HienThiNut(root.Left);
        Console.WriteLine();
    }

    // Bài 8: Cài đặt thuật toán duyệt cây nhị phân theo các thứ tự
    static void B8()
    {
        Console.WriteLine("=== Bài 8 ===");
        if (root == null)
        {
            Console.WriteLine("Cây rỗng.");
            return;
        }

        Console.Write("Duyệt trước (N-L-R): ");
        DuyetTruoc(root);
        Console.WriteLine();

        Console.Write("Duyệt giữa  (L-N-R): ");
        DuyetGiua(root);
        Console.WriteLine();

        Console.Write("Duyệt sau   (L-R-N): ");
        DuyetSau(root);
        Console.WriteLine();
    }

    // --- Các hàm thuật toán xử lý cây ---

    static int DemSoNut(CayNode node)
    {
        if (node == null) return 0;
        return 1 + DemSoNut(node.Left) + DemSoNut(node.Right);
    }

    static int TinhTong(CayNode node)
    {
        if (node == null) return 0;
        return node.Data + TinhTong(node.Left) + TinhTong(node.Right);
    }

    static void HienThiNut(CayNode node)
    {
        if (node == null) return;
        Console.Write($"{node.Data} ");
        HienThiNut(node.Left);
        HienThiNut(node.Right);
    }

    static void HienThiNutChan(CayNode node)
    {
        if (node == null) return;
        if (node.Data % 2 == 0)
            Console.Write($"{node.Data} ");
        HienThiNutChan(node.Left);
        HienThiNutChan(node.Right);
    }

    static int DemNutChan(CayNode node)
    {
        if (node == null) return 0;
        int dem = (node.Data % 2 == 0) ? 1 : 0;
        return dem + DemNutChan(node.Left) + DemNutChan(node.Right);
    }

    static CayNode TimNut(CayNode node, int x)
    {
        if (node == null) return null;
        if (node.Data == x) return node;

        CayNode trai = TimNut(node.Left, x);
        if (trai != null) return trai;

        return TimNut(node.Right, x);
    }

    static int DemConTrucTiep(CayNode node)
    {
        if (node == null) return 0;
        int count = 0;
        if (node.Left != null) count++;
        if (node.Right != null) count++;
        return count;
    }

    static void DuyetTruoc(CayNode node)
    {
        if (node == null) return;
        Console.Write($"{node.Data} ");
        DuyetTruoc(node.Left);
        DuyetTruoc(node.Right);
    }

    static void DuyetGiua(CayNode node)
    {
        if (node == null) return;
        DuyetGiua(node.Left);
        Console.Write($"{node.Data} ");
        DuyetGiua(node.Right);
    }

    static void DuyetSau(CayNode node)
    {
        if (node == null) return;
        DuyetSau(node.Left);
        DuyetSau(node.Right);
        Console.Write($"{node.Data} ");
    }
}

class CayNode
{
    public int Data;
    public CayNode Left;
    public CayNode Right;

    public CayNode(int data)
    {
        Data = data;
    }
}