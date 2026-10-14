using System;

public class Karyawan
{
    public string Nama;
    public double Gaji;

    public Karyawan(string nama, double gaji)
    {
        this.Nama = nama;
        this.Gaji = gaji;
    }

    public virtual void Kerja()
    {
        Console.WriteLine($"{Nama} saat ini sedang bekerja");
    }

    public virtual void InfoKaryawan()
    {
        Console.WriteLine($"Nama: {Nama}");
        Console.WriteLine($"Gaji: {Gaji:N0}");
    }
}

public class Tetap : Karyawan
{
    public double Tunjangan;

    public Tetap(string nama, double gaji, double tunjangan) : base(nama, gaji)
    {
        this.Tunjangan = tunjangan;
    }

    public double HitungGajiTotal()
    {
        return Gaji + Tunjangan;
    }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} sedang bekerja menjadi karyawan tetap penuh waktu");
    }

    public override void InfoKaryawan()
    {
        base.InfoKaryawan();
        Console.WriteLine($"Tunjangan: {Tunjangan:N0}");
        Console.WriteLine($"Gaji total: {HitungGajiTotal():N0}");
    }
}

public class Kontrak : Karyawan
{
    public int Durasi;

    public Kontrak(string nama, double gaji, int durasi) : base(nama, gaji)
    {
        this.Durasi = durasi;
    }

    public void CekKontrak()
    {
        Console.WriteLine($"Kontrak {Nama} berlaku selama {Durasi} bulan.");
    }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} bekerja menjadi karyawan kontrak selama {Durasi}.");
    }

    public override void InfoKaryawan()
    {
        base.InfoKaryawan();
        Console.WriteLine($"Durasi: {Durasi} bulan");
    }
}

public class Manager : Tetap
{
    public Manager(string nama, double gaji, double tunjangan) : base(nama, gaji, tunjangan) { }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} bekerja menjadi Manager untuk tim");
    }

    public void Memimpin()
    {
        Console.WriteLine($"{Nama} yang akan memimpin rapat kerja");
    }
}

public class Staff : Tetap
{
    public Staff(string nama, double gaji, double tunjangan) : base(nama, gaji, tunjangan) { }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} bekerja menjadi Staff perusahaan");
    }

    public void KerjakanTugas()
    {
        Console.WriteLine($"{Nama} sedang menyelesaikan tugas yang diberikan Manager");
    }
}

public class Magang : Kontrak
{
    public Magang(string nama, double gaji, int durasi) : base(nama, gaji, durasi) { }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} bekerja menjadi karyawan magang");
    }

    public void Belajar()
    {
        Console.WriteLine($"{Nama} sedang belajar peraturan di perusahaan");
    }
}

public class Freelancer : Kontrak
{
    public Freelancer(string nama, double gaji, int durasi) : base(nama, gaji, durasi) { }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} bekerja menjadi Freelancer");
    }

    public void AmbilProyek()
    {
        Console.WriteLine($"{Nama} sedang mengambil proyek dari klien");
    }
}

public class Perusahaan
{
    public List<Karyawan> daftarKaryawan = new List<Karyawan>();

    public void TambahKaryawan(Karyawan karyawan)
    {
        daftarKaryawan.Add(karyawan);
        Console.WriteLine($"{karyawan.Nama} menjadi karyawan perusahaan baru");
    }

    public void DaftarKaryawan()
    {
        Console.WriteLine("\nList Karyawan Perusahaan");
        int urutan = 1;
        foreach (Karyawan k in daftarKaryawan)
        {
            Console.WriteLine($"\n{urutan++}. {k.GetType().Name}");
            k.InfoKaryawan();
        }
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Perusahaan perusahaan = new Perusahaan();

        Manager manager = new Manager("Adi", 4000000, 2000000);
        Staff staff = new Staff("Huda", 4500000, 1500000);
        Magang magang = new Magang("Roji", 3700000, 8);
        Freelancer freelancer = new Freelancer("Masdar", 1500000, 4);

        perusahaan.TambahKaryawan(manager);
        perusahaan.TambahKaryawan(staff);
        perusahaan.TambahKaryawan(magang);
        perusahaan.TambahKaryawan(freelancer);

        perusahaan.DaftarKaryawan();
        Console.WriteLine();

        foreach (Karyawan k in perusahaan.daftarKaryawan) //polymorphism
        {
            k.Kerja();
        }
        Console.WriteLine();

        //daftar method
        manager.Memimpin();
        staff.KerjakanTugas();
        magang.Belajar();
        freelancer.AmbilProyek();
        magang.CekKontrak();
        freelancer.CekKontrak();
        Console.WriteLine($"Gaji total {manager.Nama} adalah {manager.HitungGajiTotal():N0}");
        Console.WriteLine();

        //soal 1 method Kerja() pada objek manager dan freelancer
        manager.Kerja();
        freelancer.Kerja();
        Console.WriteLine();

        manager.Memimpin();    //soal 2 method memimpin() pada objek manager
        Console.WriteLine();

        manager.InfoKaryawan();  //soal 3 menampilkan informasi lengkap dari objek manager
        Console.WriteLine();

        magang.Belajar();  //soal 4 method Belajar() pada objek magang
        Console.WriteLine();

        //soal 5 isi objek Staff dengan variabel Karyawan dan jalankan method Kerja()
        Karyawan xyz = new Staff("Rena", 3000000, 1000000);
        xyz.Kerja();
        ((Staff)xyz).KerjakanTugas();
    }
}